using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KronotropApp.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public List<BeverageOrdered> OrderItems { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        //TODO PaymentType (enum) olarak eklenebilir (MobileWallet, Cash, CreditCard, etc)
        //TODO Here Or To-Go bir boolean olarak eklenebilir. 
        //TODO Kasiyer bilgisi eklenebilir
        //TODO Müşteri bilgisi eklenebilir
        //TODO loyalty programı eklenebilir. 9 kahve alana 10. bedava gibi
        //Ürünler şu anda sadece içecek. İçecek dışı ürün çeşidi eklenebilir.
    }
}