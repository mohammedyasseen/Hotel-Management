using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class RoomList
    {
        public List<Room> RoomStore { get; set; }
        public List<Room> RoomAvailable { get; set; }

        public RoomList()
        {
            RoomStore = new List<Room>();
            RoomAvailable = new List<Room>();
        }


        // List all rooms
        public void display()
        {

            
                for (int i = 0; i < RoomStore.Count(); i++)
                {
                    Console.WriteLine(" Room " + "#" + (i+1) + " Type: " + RoomStore[i].Type + "  Price: $" + RoomStore[i].Price + "  ID: " + RoomStore[i].Id);
                }
            
        }

        // List available rooms
        public void Availabledisplay()
        {


            for (int i = 0; i < RoomAvailable.Count(); i++)
            {
                Console.WriteLine(" Room " + "#" + (i+1) + "  Type: " + RoomAvailable[i].Type + "  Price: $" + RoomAvailable[i].Price + "  ID: " + RoomAvailable[i].Id);
            }

        }

        public List<Room> areAvailable(CustomerList customerList, DateTime indate, DateTime outdate)
        {
            bool Flag = false;

            int dff = RoomStore.Count - RoomAvailable.Count;

            // temporarily adding availability to rooms depending on the date
            foreach ( Customer customer  in customerList.CustomerStore) {
                foreach ( Reservation reservation in customer.reservations)
                {
                    if ( (indate< reservation.inDate && outdate < reservation.inDate) || (indate > reservation.outDate && outdate>reservation.outDate) ) {
                        Flag= true;
                        RoomAvailable.Add(reservation.room);

                    }

                }

            
            }
            // output the availabe rooms 
            Availabledisplay();

            // removing temporarily rooms for new searches
            if ( Flag )
            { for (int i=0; i < dff ; i++)
                {
                    RoomAvailable.RemoveAt(RoomAvailable.Count-1);
                }
                
            }
            return RoomAvailable;
        }





    }
}
