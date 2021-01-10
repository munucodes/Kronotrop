using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KronotropApp.Models
{
    public class BeverageOrdered : Beverage
    {
        //normalde sadece sipariş verilen içeceğin addition'u olabilir.
        public List<AdditionOrdered> Additions { get; set; }

        //TODO: size ekle (enum olabilir)

    }
}