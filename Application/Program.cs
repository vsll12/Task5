using Application.Models;

Card card1 = new Card() { Balance = 210};
Card card3 = new Card() { Balance = 310 };
Card card2 = new Card() { Balance = 450 };
Card card4 = new Card() { Balance = 890 };
Card card5 = new Card() { Balance = 62 };

User[] users = new User[5]
{   new User("name1","surname1",card1),
    new User("name2", "surname2", card2),
    new User("name3","surname3",card3),
    new User("name4","surname4",card4),
    new User("name5","surname5",card5)
};

for (int i = 0; i < users.Length; i++)
{
    users[i].CreditCard.ShowInfo();
    Console.WriteLine(); ;
}

Thread.Sleep(5000);

Console.Clear();

while (true)
{
    pin_check: 
    Console.WriteLine("0.Chixish");
    Console.Write("PIN-i daxil edin : ");
    string? Pin = Console.ReadLine();
    if (Pin == "0") break;
    for (int i = 0; i < users.Length; i++)
    {
        if (users[i].CreditCard.PIN == Pin)
        {
            Console.WriteLine($"Xosh gelmishsiniz {users[i].Name}  {users[i].Surname}");
            Console.WriteLine("Zehmet olmasa asagidakilardan birini secerdiniz : ");
        Menyu:
            Console.Clear();
            Console.WriteLine("0.Chixish");
            Console.WriteLine("1.Balans");
            Console.WriteLine("2.Nagd pul");
            Console.WriteLine("3.Kartdan karta kocurme");
            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine(users[i].CreditCard.Balance);
                    Console.WriteLine("Davam etmek ucun enter basin");
                    var key = Console.ReadKey().Key;
                    if(key == ConsoleKey.Enter)
                    goto Menyu;
                    break;
                case "2":
                    case2_:
                    Console.WriteLine("1.10 AZN");
                    Console.WriteLine("2.20 AZN");
                    Console.WriteLine("3.50 AZN");
                    Console.WriteLine("4.100 AZN");
                    Console.WriteLine("5.Diger mebleg");
                    string? choice2 = Console.ReadLine();
                    switch(choice2) {

                        case "1":
                            try
                            {
                                users[i].CreditCard.DecreaseBalance(10);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                Thread.Sleep(2000);
                                goto Menyu;
                            }
                            goto Menyu;
                        case "2":
                            try{
                                users[i].CreditCard.DecreaseBalance(20);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                Thread.Sleep(2000);
                                goto Menyu;
                            }
                            goto Menyu;
                        case "3":
                            try
                            {
                                users[i].CreditCard.DecreaseBalance(50);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                Thread.Sleep(2000);
                                goto Menyu;
                            }
                            goto Menyu;
                        case "4":
                            try
                            {
                            users[i].CreditCard.DecreaseBalance(100);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                Thread.Sleep(2000);
                                goto Menyu;
                            }
                            goto Menyu;
                        case "5":
                            try
                            {
                                Console.Write("Meblegi daxil edin : ");
                                decimal mebleg = Convert.ToDecimal(Console.ReadLine());
                                users[i].CreditCard.DecreaseBalance(mebleg);
                            }
                            catch(Exception ex) {
                                Console.WriteLine(ex.Message);
                                Thread.Sleep(2000);
                                goto Menyu; }
                            goto Menyu;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Duzgun secim daxil elemediniz!");
                            Console.Clear();
                            goto case2_;
                    }
                    break;  
                case "3":
                    Console.Write("PAN-I yazin : ");
                    string? pan = Console.ReadLine();
                    for (int k = 0; k < users.Length; k++)
                    {
                        if (users[k].CreditCard.PAN == pan)
                        {
                            Console.Write("Gondermek istediyiniz miqdari daxil edin : ");
                            decimal money = Convert.ToDecimal(Console.ReadLine());
                            try
                            {
                                users[i].CreditCard.Transfer(users[k], money);
                            }
                            catch(Exception ex) { 
                                Console.WriteLine(ex.Message);     
                                Thread.Sleep(2000);
                                goto Menyu;
                            }
                        }
                    }
                    goto pin_check;
                    break;
                case "0":
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Duzgun secim daxil eliyin!");
                    Console.Clear();
                    goto Menyu;
            }
        }
    }
}


