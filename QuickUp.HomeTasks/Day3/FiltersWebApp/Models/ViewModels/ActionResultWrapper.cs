using System;

namespace FiltersWebApp.Models.ViewModels
{
    public class ActionResultWrapper
    {
        public string Results { get; set; }
        public DateTime ServerTime => DateTime.Now;
    }
}
