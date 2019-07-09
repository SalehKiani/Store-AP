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
        public event PropertyChangedEventHandler PropertyChanged;

        List<UserProps> Userlist = new List<UserProps>();
        List<Admin> Adminlist = new List<Admin>();
        static public UserProps ActiveUser = new UserProps();

        private string email,pass;
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

        public bool signupCheck(string email,string password)
        {
            try
            {
                var db = new DataBase_connection();
                var res = db.users.Where(i => i.Email == email).FirstOrDefault();

                if (res != null)
                {
                    return false;
                }
                else
                {
                    this.email = email;
                    this.pass = password;
                    return true;
                }
            }
            catch(Exception)
            {
                throw new DBFail();
            }
        }
         public void complete_signup(string name,string adress,int phonenum)
         {
            try
            {
                var db = new DataBase_connection();
                db.users.Add(new UserProps() {Name = name,PhoneNo = phonenum.ToString(),Adress = adress, Email = this.email, Password = this.pass });
                db.SaveChanges();
            }
            catch(Exception)
            {
                throw new DBFail();
            }
         }
    }
}
