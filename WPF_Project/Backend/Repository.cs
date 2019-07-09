using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Project.Backend.Exceptions;
using WPF_Project.Backend;
using System.ComponentModel;

namespace WPF_Project.Backend
{
    public class Repository : INotifyPropertyChanged
    {

        List<UserProps> Userlist = new List<UserProps>();
        List<Admin> Adminlist = new List<Admin>();
        static public UserProps ActiveUser = new UserProps();

       

        public bool loginCheck(string email,string password)
        {
            try
            {
                var db = new DataBase_connection();
                var res = db.users.Where(i => i.Email == email && i.Password == password).FirstOrDefault();

                if (res != null)
                {
                    ActiveUser.Email = email;    ActiveUser.Password = password;
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

        public bool signupCheck(string email,string password)
        {
            if (email == "\0" || password == "\0")
                throw new EmptyField();
            try
            {
                var db = new DataBase_connection();
                var res = db.users.Where(i => i.Email == email).FirstOrDefault();

                if (res != null)
                {
                    return false;
                }
                db.users.Add(new UserProps() { Email = email, Password = password });
                Userlist.Add(new UserProps { Email = email, Password = password });
                ActiveUser.Email = email;      ActiveUser.Password = password;
            }
            catch (Exception)
            {
                throw new DBFail();
            }
            return true;
        }
         public void complete_signup(string name,string adress,string phonenum)
        {
            try
            {
                var db = new DataBase_connection();
                var result1 = db.users.Where(i => i.Email==ActiveUser.Email).SingleOrDefault();
                if (result1 == null)
                {
                    var result2 = db.admins.Where(i => i.Email == ActiveUser.Email).SingleOrDefault();
                    result2.Name = name;
                    db.SaveChanges();
                }
                result1.Name = name;
                result1.Adress = adress;
                result1.PhoneNo = phonenum;
                db.SaveChanges();
            }
            catch(Exception)
            {
                throw new DBFail();
            }
         }
    }
}
