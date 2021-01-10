using KronotropApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KronotropApp.Controllers
{
    public class OrdersController : ApiController
    {
        //db yerine elimizdeki statik değerleri çekiyoruz, gelen id'lerle eşleştireceğiz. 
        //normalde cache'e alırdık. her order'da yeniden çekmezdik datayı da.

        public List<Beverage> beverages = BeveragesController._beverages;
        public List<Addition> additions = AdditionsController._additions;

        //Burada normalde dbcontext'imizi çekiyor olurduk.
        public static List<Order> _orders = new List<Order>();


        // GET: api/Orders
        public IEnumerable<Order> Get()
        {
            return _orders;
        }

        // GET: api/Orders/5
        public Order Get(int id)
        {
            return _orders.Find(x => x.Id == id);
        }

        //TODO: by far en karışık metot oldu. bunu işlere göre ayırmak gerek. 
        // POST: api/Orders
        public IHttpActionResult Post([FromBody]List<BeverageOrdered> orderedBeverages)
        {
            //order'ın tamamını dönmelerini beklemiyoruz. sadece beverage ve addition id'leri ve 
            //addition sayılarını dönmeleri yeterli. sürekli isimleri price'Ları taşımamıza gerek yok.
            //Response olarak doğru order'ı biz döneceğiz
            Order order = new Order();

            //Response Order'ına ekleyeeğimiz gerçek fiyatlı ve isimli içecek listesi
            List<BeverageOrdered> actualOrderedBeverages = new List<BeverageOrdered>();


            //total değerini toplayarak gideceğiz
            decimal total = 0;

            //ya hiç bir içecek gelmediyse kontrolü, hata dönülmeli
            if(orderedBeverages != null && orderedBeverages.Count > 0)
            {

                foreach (BeverageOrdered bev in orderedBeverages)
                {
                    //actual beverage listesine ekleyeceğimiz içecek.
                    var pricedBev = SetValuesOfBeverageById(bev);

                    //addition gelmemiş olabilir. 
                    if (bev.Additions != null && bev.Additions.Count > 0)
                    {
                        List<AdditionOrdered> actualAdditionList = new List<AdditionOrdered>();
                        foreach(var add in bev.Additions)
                        {
                            //actual addition olarak ekleyeceğimiz ek lezzetler
                            AdditionOrdered realAdd = SetValuesOfAdditionById(add);

                            //order edilen içeceğin additionlarla birlkte toplam fiyatını buluyoruz.
                            pricedBev.BeveragePrice += (realAdd.AdditionPrice * realAdd.AdditionAmount);

                            actualAdditionList.Add(realAdd);
                        }

                        pricedBev.Additions = actualAdditionList;          
                    }

                    actualOrderedBeverages.Add(pricedBev);

                    //total'i ekliyoruz.
                    total += pricedBev.BeveragePrice;
                }

                order.OrderItems = actualOrderedBeverages;
                order.TotalPrice = total;
                order.OrderDate = DateTime.Now;
                //id'yi yine DB olsaydı autoIncrement ederdik.
                order.Id = _orders.Count() + 1;

                return Ok(order);

            }
            else
            {
                return BadRequest();
            }

        }

        //PUT kullanmıyorum. Bir kere verilen order değiştirilemesin. DELETE edilip yeniden POST edilsin


        //TODO: history'sini tutarız silinen order'ların
        // DELETE: api/Orders/5
        public void Delete(int id)
        {
            _orders.Remove(_orders.Find(x => x.Id == id));

        }

        //sadece ID ve Amount gelen addition'un değerlerini çeken metot
        private AdditionOrdered SetValuesOfAdditionById(AdditionOrdered add)
        {
            //actual addition olarak ekleyeceğimiz ek lezzetler
            AdditionOrdered realAdd = new AdditionOrdered();

            //additionların gerçek değerlerinin id ile eşleştirilmesi
            realAdd.AdditionName = additions.Find(x => x.Id == add.Id).AdditionName;
            realAdd.AdditionPrice = additions.Find(x => x.Id == add.Id).AdditionPrice;
            realAdd.AdditionAmount = add.AdditionAmount; //yeni obje instance olunca bunu da eşleme gerekti

            return realAdd;

        }

        //sadece ID gelen beverage'ın değerlerini çeken metot
        private BeverageOrdered SetValuesOfBeverageById(BeverageOrdered bev)
        {
            //actual beverage listesine ekleyeceğimiz içecek.
            var pricedBev = new BeverageOrdered();

            //gelen id'lerle elimizdeki listeden asıl değerleri çekiyoruz.
            //buralarda Id geldiğine dair validasyonlar olmalı. ModelState kullanılabilir. DB eklenince yapabiliriz.
            pricedBev.BeveragePrice = beverages.Find(x => x.Id == bev.Id).BeveragePrice; //burada size da olsaydı size'a oranla fiyatları getirecek ya da çarpacaktık.
            pricedBev.BeverageName = beverages.Find(x => x.Id == bev.Id).BeverageName;

            return pricedBev;
        }
    }
}
