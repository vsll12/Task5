using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    internal class User
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public Card CreditCard { get; set; }

        public User() { }

        public User(string name, string surname, Card creditCard)
        {
            this.Name = name;
            this.Surname = surname; 
            this.CreditCard = creditCard;
        }
    }
}
