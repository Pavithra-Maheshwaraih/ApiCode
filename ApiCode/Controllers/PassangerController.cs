using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ApiCode.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassangerController : Controller
    {
        [HttpGet("{passangerNo}")]
        public List<PriceCalucalte> Get(int passangerNo)
        {
            List<PriceCalucalte> pcList = new List<PriceCalucalte>();
            PriceCalucalte pc = null;

            try
            {
                string info = new WebClient().DownloadString("https://jayridechallengeapi.azurewebsites.net/api/QuoteRequest");
                if(info!=null)
                {
                    Jayride.Root jay = JsonConvert.DeserializeObject<Jayride.Root>(info);
                    List<Jayride.Listing> Jayridelist = new List<Jayride.Listing>();

                    //filtering based on passanger
                    Jayridelist = jay.Listings.Where(x => x.VehicleType.MaxPassengers == passangerNo).ToList();
                    if (Jayridelist != null)
                    {
                        for (int i = 0; i <= Jayridelist.Count - 1; i++)
                        {
                            pc = new PriceCalucalte();
                            //calucation total price
                            double Price = Jayridelist[i].PricePerPassenger * passangerNo;
                            pc.totalPrice = Price;
                            pcList.Add(pc);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return null;
            }

            return pcList.OrderByDescending(x => x.totalPrice).ToList();

        }

        public class PriceCalucalte
        {
            public double totalPrice { get; set; }
        }



    }
}
