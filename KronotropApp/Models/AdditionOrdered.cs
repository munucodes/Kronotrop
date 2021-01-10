using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KronotropApp.Models
{
    public class AdditionOrdered : Addition
    {
        //normal addition çeşitlerinin miktarı olmaz, sipariş anında runtime'da gerekli.
        public int AdditionAmount { get; set; }
    }
}