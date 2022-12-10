using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Reservation
    {
        public Room room;
        public List<Guest> GuestList  { get; set; }


        public DateTime inDate { get; set; }
        public DateTime outDate { get; set; }

        
        
        public Reservation() {
        inDate= new DateTime(2001,1,1);
        outDate= new DateTime(2001, 1, 1);
            room = new Room();
        }
        public Reservation(string type, double price, string id,DateTime indate, DateTime outdate)
        {
         room= new Room(type, price,id);
         GuestList = new List<Guest>();
            inDate = indate;
            outDate= outdate;
        }



        // list guests for specific reservation
        public void displayguest()
        {
            Console.WriteLine(" \nThe Guests are:");
            if (GuestList.Count > 0)
            {
                for (int i = 0; i < GuestList.Count(); i++)
                {
                    Console.WriteLine(" \nGuest" + "#" + (i + 1) + " Name: " + GuestList[i].Name + " Phone number: " + GuestList[i].PhoneNumber);
                }
            }
            else { Console.WriteLine("\nThere are no guests"); }

        }
    }
}
