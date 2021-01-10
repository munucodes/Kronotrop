using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KronotropApp.Models
{
    public class Beverage
    {
        [Key]
        public int Id { get; set; }
        public string BeverageName { get; set; }
        public decimal BeveragePrice { get; set; }
        public bool IsSeasonal { get; set; } //isSeasonal false ile normal sezondakiler çekilebilir.
        //TODO popüler olanların önce önerilmesi için Sorting gelebilir. Yine DB'den yönetilebilir.
    }
}