using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Project.Backend
{
    class Admin
    {
        [System.ComponentModel.DataAnnotations.Key]
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password {private get; set; }
    }
}
