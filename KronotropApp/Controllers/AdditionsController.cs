using KronotropApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KronotropApp.Controllers
{

    //bunları normalde DB'de tutacağız tabii ki, EF üzerinden DB eklerken çok vakit kaybetmemek
    //için maalesef bu şekilde ekledim. En azından uygulama ayakta olduğu sürece runtime'da ekleyip 
    //çıkarabiliriz listeden.
    public class AdditionsController : ApiController
    {
        public static List<Addition> _additions = new List<Addition>()
    {
            new Addition(){Id = 0, AdditionName = "Milk", AdditionPrice = 1},
            new Addition(){Id = 1,AdditionName = "Chocolate Sauce", AdditionPrice = 2},
            new Addition(){Id = 2,AdditionName = "Chocolate Sauce", AdditionPrice = 2}
    };
        // GET: api/Additions
        public IEnumerable<Addition> Get()
        {
            return _additions;
        }

        // GET: api/Additions/5
        public Addition Get(int id)
        {
            return _additions.Find(x => x.Id == id);
        }

        // POST: api/Additions
        public void Post([FromBody]Addition addition)
        {
            _additions.Add(addition);
        }

        // PUT: api/Additions/5
        public void Put(int id, [FromBody]Addition addition)
        {
            _additions.Remove(_additions.Find(x => x.Id == id));
            _additions.Add(addition);
        }

        // DELETE: api/Additions/5
        public void Delete(int id)
        {
            _additions.Remove(_additions.Find(x => x.Id == id));
        }
    }
}
