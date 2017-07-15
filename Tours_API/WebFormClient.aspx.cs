using ExploreTanga.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tours_API
{
    public partial class WebFormClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:13058");
            var tour = new Tour()
            {
                Name = "Http Client Tour in class",
                Description = "Dummy client description with Http Client",
                Length = 21,
                IncludesMeals = false,
                Price = 210.0M,
                Rating = null
            };
            client.PostAsJsonAsync("api/tours", tour);


        }
    }
}