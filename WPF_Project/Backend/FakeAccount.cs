using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Project.Backend
{
    class FakeAccount
    {
        public void Create()
        {
            string[] names = new string[] { "Ali", "Reza", "Hassan", "Mohammad", "Hossein", "Amir", "Saleh", "Mehdi", "Hamid", "Sajad" };
            int pass, k1, k2, k3;
            Int64 phone;
            string name;
            Random random = new Random();
            var db = new DataBase_connection();
            for (int i = 1; i <= 10; i++)
            {
                pass = random.Next(1000, 10000);
                phone = random.Next(900, 1000) * 10000000 + random.Next(10000000);
                k1 = random.Next(10);
                k2 = random.Next(10);
                k3 = random.Next(10);
                name = names[k1] + names[k2] + names[k3];

                db.users.Add(new UserProps()
                {
                    Email = (name + pass.ToString() + "@gmail.com"),
                    PhoneNo = phone.ToString(),
                    Name = name,
                    Adress = names[k1] + "," + names[k2] + "," + names[k3] + ",House Number" + pass.ToString(),
                    Password = pass.ToString()
                });
            }
        }
    }
}
