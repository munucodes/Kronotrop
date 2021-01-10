using KronotropApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KronotropApp.Controllers
{

    public class BeveragesController : ApiController
    {
        //bunları normalde DB'de tutacağız tabii ki, EF üzerinden DB eklerken çok vakit kaybetmemek
        //için maalesef bu şekilde ekledim. En azından uygulama ayakta olduğu sürece runtime'da ekleyip 
        //çıkarabiliriz listeden.
        public static List<Beverage> _beverages = new List<Beverage>()
        {
            new Beverage(){Id = 0, BeverageName = "Black Coffee", BeveragePrice = 4, IsSeasonal = false},
            new Beverage(){Id = 1, BeverageName = "Latte", BeveragePrice = 5, IsSeasonal = false},
            new Beverage(){Id = 2, BeverageName = "Mocha", BeveragePrice = 6, IsSeasonal = false},
            new Beverage(){Id = 3, BeverageName = "Tea", BeveragePrice = 4, IsSeasonal = false},
            new Beverage(){Id = 4, BeverageName = "Christmas Coffee", BeveragePrice = 7, IsSeasonal = true},
        };




        // GET: api/Beverages
        public IEnumerable<Beverage> Get()
        {
            return _beverages;
        }

        // GET: api/Beverages/5
        public Beverage Get(int id)
        {
            return _beverages.Find(x => x.Id == id);
        }

        // POST: api/Beverages
        public void Post([FromBody]Beverage beverage)
        {
            _beverages.Add(beverage);
        }

        // PUT: api/Beverages/5
        public void Put(int id, [FromBody]Beverage beverage) //Aslında gerek yok, order kısmında özellikle izin vermedim.
        {
            _beverages.Remove(_beverages.Find(x => x.Id == id));
            _beverages.Add(beverage);
        }

        // DELETE: api/Beverages/5
        public void Delete(int id)
        {
            _beverages.Remove(_beverages.Find(x => x.Id == id));
        }
    }
}
