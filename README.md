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


		

