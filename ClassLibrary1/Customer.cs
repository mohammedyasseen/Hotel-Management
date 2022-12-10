using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Customer : Person
    {
        public List<Reservation> reservations { get; set; }
        public Customer()
        {
            reservations = new List<Reservation>();
        }


        public double Checkout()
        {
            double Totalcost = 0;
            foreach (Reservation reservation in reservations)
            {
                //displays all reservation details
                reservation.room.display();
                reservation.displayguest();
                Console.WriteLine("\nFrom: " + reservation.inDate + " To: " + reservation.outDate);

                Totalcost += (reservation.room.Price + 0.25 * reservation.room.Price * reservation.GuestList.Count) * (reservation.outDate - reservation.inDate).TotalDays;

            }
            return Totalcost;
        }
    }


}
