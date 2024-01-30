using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBox.Model
{
    public class User
    {
        public User( string username, string password, string e_mail)
        {
            
            Username = username;
            Password = password;
            E_mail = e_mail;
        }

        //public double Price { get; set; }
        public int Id { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }
        public string  E_mail {get; set;}
        // ID покупки
        //public int PurchaseId { get; set; }
        // имя и фамилия покупателя
        //public string Person { get; set; }
        // адрес покупателя
        //public string Address { get; set; }
        // ID книги

        // дата покупки
        //public DateTime Date { get; set; }
    }
}
