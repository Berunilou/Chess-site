using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerCustomization
{
    public class User
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public int Rate { get; private set; }
        public int GameNumber { get; private set; }

        public User()
        {
            using (DataSource db = new DataSource())
            {
                foreach ( var player in db.Players)
                {
                    //if (user.Name == player.Name) return "change user name";
                }
                //db.Players.Add(new Player { Name = user.Name, Email=user.Email, GameNumber = 0, Password = user.Password, Rate = 1500 });
                //return "creting successful";
            }
        }

        private void PlayerInitialization(string name, string password)
        {
            using (DataSource db = new DataSource())
            {
                using (var userName = db.Players.Where(p => p.Name == name))
                {

                }
                //foreach (var player in db.Players)
                //{
                //    if (name == player.Name) 
                //        if(password == player.Password) return true;
                //}                
                //return false;
            }
        }
    }
}
