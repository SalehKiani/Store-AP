using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Project.Backend
{
    class Product
    {
        [System.ComponentModel.DataAnnotations.Key]
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Exist { get; set; }
        public double Price { get; set; }
        public string Specific { get; set; }
        public double Rate { get; set; }

    }
}
