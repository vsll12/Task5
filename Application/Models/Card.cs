using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    internal class Card
    {
        public string PAN { get; set; }
        public string PIN { get; set; }
        public string CVC { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal Balance { get; set; }

        Random random = new Random();
        public Card() { 
            for(int i = 0; i < 16;i++)PAN += random.Next(0,10).ToString();
            for(int i = 0; i < 4;i++)PIN += random.Next(0,10).ToString();
            for(int i = 0; i < 3;i++)CVC += random.Next(0,10).ToString();
            ExpireDate = DateTime.Now.AddYears(1);
        }

        public void DecreaseBalance(decimal balance)
        {
            if(Balance >= balance)
            {
                Balance -= balance;
            }
            else
            {
                throw new Exception("Balansinizda kifayet qeder mebleg yoxdur");
            }
        }
        public void Transfer(User user,decimal money)
        {
            if (money <= Balance)
            {
                user.CreditCard.Balance += money;
                Balance -= money;
            }
            else throw new Exception("Balansinizda kifayet qeder mebleg yoxdur");
        }

        public void ShowInfo()
        {
            Console.WriteLine($"PIN : {PIN}");
            Console.WriteLine($"PAN : {PAN}");
            Console.WriteLine($"CVC : {CVC}");
            Console.WriteLine($"Balance : {Balance}");
        }
    }
}
