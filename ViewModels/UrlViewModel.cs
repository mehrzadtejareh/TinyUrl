using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TinyUrl.ViewModels
{
    public class UrlViewModel
    {
        public int id { get; set; }
        public string TinyCode { get; set; }
        public string TinyUrl { get; set; }
        public string SourceUrl { get; set; }
        public int Hit { get; set; } = 0;
    }
}
