using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Project.Backend.Exceptions;

namespace WPF_Project.Backend
{
    public class Repository
    {
        public bool loginCheck(string email,string password)
        {
            try
            {
                var db = new DataBase_connection();
                var res = db.users.Where(i => i.Email == email && i.Password == password).FirstOrDefault();

                if (res != null)
                {
                    return true;
                }
                else
                {
                    throw new LoginFail();
                }
            }
            catch (Exception)
            {
                throw new DBFail();
            }
            
        }
    }
}
