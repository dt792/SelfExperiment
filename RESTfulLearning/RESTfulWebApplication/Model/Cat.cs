using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTfulWebApplication.Model
{
    public class Cat
    {
        public int id { get; set; }
        public string Name { get; set; } = "default";
        public int KG { get; set; }
        public string Type { get; set; }
        public string Discription { get; set; }
    }
}
