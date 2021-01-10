using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KronotropApp.Models
{
    public class Addition
    {
        [Key]
        public int Id { get; set; }
        public string AdditionName { get; set; }
        public decimal AdditionPrice { get; set; }
    }
}