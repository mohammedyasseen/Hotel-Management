using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class CustomerList
    {
        public List<Customer> CustomerStore { get; set; }


        public CustomerList() { 
        CustomerStore= new List<Customer>();
        }


        // full checkout
        public double Checkout()

        {
            int choice = 0;
            Console.WriteLine("Choose customer to checkout");
            double Totalcost = 0;
            display();
            while (true)
            {// choose customer
                try
                {
                    choice = int.Parse(Console.ReadLine()) - 1;
                    Console.WriteLine("\nYour booking:");

                    //calculate total price for multiple reservations by the same customer

                    //displays all reservation details
                    Totalcost += CustomerStore[choice].Checkout();

                    
                    break;
                }
                catch (Exception ex)
                {
                    if (ex is FormatException || ex is IndexOutOfRangeException)
                    {
                        Console.WriteLine(" Invalid input");
                    }
                }

            }

            Console.WriteLine("\n Your Total is: "+Totalcost);  
            return Totalcost;
        }


        //display customers
        public void display()
        {
            for (int i = 0; i < CustomerStore.Count(); i++)
            {
                Console.WriteLine(" Customer " + "#" + (i+1) + " Name: " + CustomerStore[i].Name + " Phone number: " + CustomerStore[i].PhoneNumber);
            }
        }
        }
}
