using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiltersWebApp.Models.ViewModels
{
    public class ActionResultWrapper
    {
        public string Results { get; set; }
        public DateTime ServerTime => DateTime.Now;
    }
}
