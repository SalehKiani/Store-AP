using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Project.Backend
{
     public class UserProps
    {
        [System.ComponentModel.DataAnnotations.Key]
        public String Email { get; set; }
        public String PhoneNo { get; set; }
        public String Name { get; set; }
        public String Adress { get; set; }
        public String Password { get; set; }
    }
}
