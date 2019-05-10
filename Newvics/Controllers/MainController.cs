using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.IO;
using System.Net;
using System.Web.Mvc;

namespace Newvics.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Sports()
        {
            return View();
        }

        public ActionResult Footy()
        { 
            return View();
        }

        public ActionResult Footy2()
        {
            return View();
        }

        public ActionResult Footy3()
        {
            return View();
        }

        public ActionResult Basketball()
        {
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }

        public List<APlace> GetSportsData(string input, string input1)
        {
            //db.Places.clear();
            //string url = @"https://maps.googleapis.com/maps/api/place/textsearch/json?query=fitness+center+in+caulfield+east&key=AIzaSyD9LUlNJjOHpdMmBFzYkLpuC91VlO5McLg";

            string str1 = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=";
            if (String.IsNullOrEmpty(input))
            {
                input = "-37.881998";
            }
            if (String.IsNullOrEmpty(input1))
            {
                input1 = "145.043836";
            }
            string key = "&key=AIzaSyD9LUlNJjOHpdMmBFzYkLpuC91VlO5McLg";
            string str2 = "&radius=1500&type=point_of_interest&keyword=footy";
            string str = str1 + input + "," + input1 + str2 + key;

            string url = @str;

            WebRequest request = WebRequest.Create(url);

            WebResponse response = request.GetResponse();

            Stream data = response.GetResponseStream();

            StreamReader reader = new StreamReader(data);

            // json-formatted string from maps api
            string responseFromServer = reader.ReadToEnd();

            var jsonObject = JObject.Parse(responseFromServer);
            var json = jsonObject["results"];

            dynamic dynJson = JsonConvert.DeserializeObject(json.ToString());

            var places = new List<APlace>();

            foreach (var item in dynJson)
            {
                APlace place = new APlace();
                place.Id = item["id"];
                place.Name = item["name"];
                place.Photo_reference = input1;
                place.Latitude = item["geometry"]["location"]["lat"];
                place.Longitude = item["geometry"]["location"]["lng"];
                place.Rating = (decimal)Convert.ToSingle(item.rating);
                place.Adress = item.formatted_address;
                place.Icon = item.icon;
                place.Total_rating_people = Convert.ToInt32(item.user_ratings_total);
                place.Field_id = 1;
                place.Star = (place.Rating / 5).ToString("0.0%");

                places.Add(place);
            }
            response.Close();
            return places;
        }

        public List<APlace> GetSuburbData(string input)
        {
            //db.Places.clear();
            //string url = @"https://maps.googleapis.com/maps/api/place/textsearch/json?query=fitness+center+in+caulfield+east&key=AIzaSyD9LUlNJjOHpdMmBFzYkLpuC91VlO5McLg";

            string str1 = "https://maps.googleapis.com/maps/api/place/textsearch/json?query=footy+near";
            if (String.IsNullOrEmpty(input))
            {
                input = "melbourne";
            }
            else
            {
                input = input + " melbourne";
            }
            string suburb1 = input.Replace(' ', '+');
            string key = "&key=AIzaSyD9LUlNJjOHpdMmBFzYkLpuC91VlO5McLg";
            string str = str1 + suburb1 + key;

            string url = @str;

            WebRequest request = WebRequest.Create(url);

            WebResponse response = request.GetResponse();

            Stream data = response.GetResponseStream();

            StreamReader reader = new StreamReader(data);

            // json-formatted string from maps api
            string responseFromServer = reader.ReadToEnd();

            var jsonObject = JObject.Parse(responseFromServer);
            var json = jsonObject["results"];

            dynamic dynJson = JsonConvert.DeserializeObject(json.ToString());

            var places = new List<APlace>();

            foreach (var item in dynJson)
            {
                APlace place = new APlace();
                place.Id = item["id"];
                place.Name = item["name"];
                place.Latitude = item["geometry"]["location"]["lat"];
                place.Longitude = item["geometry"]["location"]["lng"];
                place.Rating = (decimal)Convert.ToSingle(item.rating);
                place.Adress = item.formatted_address;
                place.Icon = item.icon;
                place.Total_rating_people = Convert.ToInt32(item.user_ratings_total);
                place.Field_id = 1;
                place.Star = (place.Rating / 5).ToString("0.0%");

                places.Add(place);
            }
            response.Close();
            return places;
        }
    }
}
