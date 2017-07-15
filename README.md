# Tours Database ASP .NET MVC and Web API

Code first app about Tours


Testing Web API

After creating web api, user Fillder to test if the web API created are working as supposed to be

Run Fiddler, If you dont have can download here [Fider](http://www.telerik.com/download/fiddler)

Take the url and 

Uncheck traffic - To stop by unchecking it and then clean all them by selecting the X sign on Filder

Test method

Go to Composer tab and test the API how they work


GET

http://localhost:13058/api/tours

To see the response .
By default return Json Data

You can click Raw Tab to see Raw data, show no cache because data can change any time

To see as XML

Go to composter tab and choose write application to acccept xml

	Accept: Application/xml

Now second request will be send and you can select to see data inform of XML



POST

Putting data to the database using API
	We first need to select one of the row data is format. From the first get request we can select the first tour and use it to put data 

	i.e I took this one
	Now change request to POST

	And this request is going to the Requestbody

	{"Id":1,"Name":"Big Sur Retreat","Description":"Majestic tour of the coast","Length":3,"Price":750.00,"RatingId":2,"IncludesMeals":true,"Rating":null}

	You dont need id as it will be created automation, and change the name, and other field that you want
	We need to specify what kind content you are posting, in here we are sending json form, we need to specify on the header

	Content-Type: applicaion/json

	To check the data that was generated, select the request and go to Raw tab and see the infomation that was generated.

	PUT
		Put is used to modify information to database through our API, to PUT, add the id to the URL of the tour that you want to modify(/api/tours/1002), and also on the request body you need to Write the Id that we are targeting same as one on the PUT url.
		Select the excute tab on the right. Information will be changed.

		Response 204 is in a range of 200, that means our Web API works fine.

		You can check on the SQL for the changes, by double clicking the Database File on your Visual Studio.


DELETE
	On Composer
	You can delete by putting the tours api url with an id of the tour that you want to delete, change the request to Delete and the excute



#PICK ON SIGNALR
- SignalR is class libray for real time notification, can be used to make chat and other.

It is so simple to use if you understand what you want to do.
It has to be implemented by the use of C# and JQuery.

First for the setup, you need to add js files for signalR after bundle for normal jquery file.

In that you need to make a section outside of the layout.cshtml. So as it can be parsed/rendered after calling of jquery.js


In configuring the js for signalR, you need 

i.e

'''javascript
	@section scripts{

    <script src="~/Scripts/jquery.signalR-2.1.2.min.js"></script>
    <script src="~/signalr/hubs"></script>

     <!-- Above we are configuring script for signalR using section razor syntax -->



}
What you need after is adding a SignalR on your project that is on your solution explore.
Create action that want to perfom and expose method that will be called by jquery.

i.e

'''csharp
	
    public class NotifyHub : Hub
    {
        public void SendNotification(string message)
        {
            Clients.Others.showNotification(message);
        }
    }


 '''

 The above we create a SignalR class, and we want to send notification with a message to other users

 Depending on which action you want to send your notification, you can use boolean to configure place where to send notifcation

 i.e here I want to send a notication to other users who are using application wherener someone create  a new tour in the applicaiton

 In that I have to setup in my action on the Tours controller what should happen, I create a boolean field that I will pass to everyone accessing index action that a new tour once has been created


'''csharp

    In the index action I have set notifyUSers to false as first need to know if anything have been created

 	 public ActionResult Index(bool notifyUsers = false)
        {
            ViewBag.Notify = notifyUsers;
            var tours = db.Tours.Include(t => t.Rating);
            return View(tours.ToList());
        }


    In create action, when the user has successful post a tour, and when we direct him to index page, we will notify others that something has change using JQuery

   	    // POST: Tours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Length,Price,RatingId,IncludesMeals")] Tour tour)
        {
            if (ModelState.IsValid)
            {
                db.Tours.Add(tour);
                db.SaveChanges();
                return RedirectToAction("Index", new {notifyUsers = true});
            }

            ViewBag.RatingId = new SelectList(db.Ratings, "Id", "Name", tour.RatingId);
            return View(tour);
        }

'''


After setting up C# code login now we need to finish on that section of javascript what to do to the user

In the index.cshtml we need to add JQuery logic of notifying user using the action and method that we have create on our signalR class

'''javascript
 <script>

        var notify = $.connection.notifyHub; // our SignalR class but should be called with start of lowercase for JavaScript convertion
        // showNotification is being called from method in controller of the SignalR
        notify.client.showNotification = function (message) {
            alert(message);
        };

        $.connection.hub.start()
            .done(function () {
                @{
                 @*dd This should be same as one in the controller of our SignalR*@     
                    if (ViewBag.Notify)
                    {

                        <text>notify.server.sendNotification("Notice: A new tour has been added. Please reflesh page ");</text>
                    }
                }

            });

    </script>

'''



Should work. The End.