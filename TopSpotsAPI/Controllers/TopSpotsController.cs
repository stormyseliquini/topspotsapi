using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using topSpotsApi.Models;
using System.Web.Http.Cors;

namespace topSpotsApi.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class TopSpotsController : ApiController
    {
        // GET: api/TopSpots
        public IEnumerable<TopSpot> Get()
        {





            return JsonConvert.DeserializeObject<List<TopSpot>>(File.ReadAllText(@"c:\dev\topspotsapi\topspotsapi\topspots.json"));
        }

        // GET: api/TopSpots/5
        public TopSpot Get(int id)
        {
            //---------- test to see if array of topspots can be accessed in url and assigned default ids
            switch (id)
            {

                case 2:
                    return new TopSpot { Name = "Play Tourist For The Afternoon With A Stroll Around Seaport Village", Description = "It may be a touristy spot with lots of tourist trap shops selling hats and sunglasses, but it’s definitely worth the walk to get great views of the harbor and Coronado, or just to enjoy the breeze.", Location = new double[] { 32.70922, -117.17007 } };
                // break;
                case 3:
                    return new TopSpot { Name = "Get Your Ultimate Geek On At Comic Con In July", Description = "Holy geekfest Batman. Every year, downtown San Diego turns into the biggest PR campaign Hollywood can buy. While it may be big business for Hollywood, it’s even bigger business for all of geek-kind. Comics, movies, collectables, cosplay, contests, it’s all here and so much more. Even if you can’t get a ticket, it’s worth stopping by the free events outside the convention center, and it’s always fun to see the cosplayers in the wild.", Location = new double[] { 32.70648, -117.16614 } };
                // break;
                case 4:
                    return new TopSpot { Name = "Take A Beer Tour At Stone Brewery", Description = "This special behind the scenes tour, lead by an “indoctrination specialist,” takes you behind the curtain of Stone’s diabolically tasty brews—most importantly it comes with free samples! Protip: tickets are first come, first serve and at $3 a pop for a 45-minute tour it’s a popular event, so be sure to get there early.", Location = new double[] { 33.115875, -117.120022 } };
                // break;
                default:
                    return new TopSpot { Name = "Go For A Run In The San Diego Zoo Safari Park", Description = "A half marathon on a trail running through the Safari Park, where animals roam free? Sounds like a barrel of monkeys (or rhinos).", Location = new double[] { 33.09745, -116.99572 } };
                    // break;  -------- dont need to break because you have a return statement, dummy!
            }


            //--------
        }

        // POST: api/TopSpots
        public TopSpot Post(TopSpot spot)
        {
            //Console.WriteLine(topspot);
            //read and deserialize again 
            //then add to object
            // then save it by WriteAllText

            //return topspot;

            //Read the JSON file from the system
            string json = File.ReadAllText(@"C:\dev\15-TopSpotsAPI\topSpotsApi\topSpotsApi\topspots.json");
            var output = JsonConvert.DeserializeObject<List<TopSpot>>(json);

            //Adds to list
            output.Add(spot);

            //Saves added list 
            string NewJson = Newtonsoft.Json.JsonConvert.SerializeObject(output);
            File.WriteAllText(@"C:\dev\15-TopSpotsAPI\topSpotsApi\topSpotsApi\topspots.json", NewJson);

            return spot;

        }

        // PUT: api/TopSpots/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TopSpots/5
        public void Delete(int id)
        {
        }
    }
}