using ClassLibrary1;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

namespace Hotel
{
    class program
    {
        static void Main(string[] args)

        {
            RoomList store = new RoomList();
            CustomerList CusStore = new CustomerList();
            Console.WriteLine("Welcome to the Hotel managment system ");
            int action = Action();

            while (action !=0)
            {

             switch(action)
                {
                    case 1:
                        // add new room
                        Room newRoom = new Room();

                        // user choose room type
                        string[] type = {"Single", "Double"} ;
                        while (newRoom.Type=="No Entry")
                        {

                            Console.WriteLine(" What is the room Type:\n 1- Single \n 2- Double");

                            try
                            {
                                newRoom.Type = type[int.Parse(Console.ReadLine()) - 1];
                            }
                            catch (Exception ex)
                            {
                                if (ex is FormatException || ex is IndexOutOfRangeException)
                                {
                                    Console.WriteLine("Invalid input");
                                }
                            }


                        }
                        // user input room price

                        while (newRoom.Price == 0.00)
                        {
                            Console.WriteLine(" What is the room price?");
                            try
                            {
                               
                             newRoom.Price = double.Parse(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid input");
                            }
                            }
                            Console.WriteLine("What is the room ID?");

                        
                        // user input room ID
                        newRoom.Id = Console.ReadLine();

                        store.RoomStore.Add(newRoom);
                        store.RoomAvailable.Add(newRoom);
                        break;

                    case 2:
                        //delete room
                        int roomchos;
                        while (true)
                        {

                            Console.WriteLine("Choose Room");
                            store.display();

                            try
                            {
                                roomchos = int.Parse(Console.ReadLine())-1;
                                store.RoomStore.RemoveAt(roomchos);
                                store.RoomAvailable.RemoveAt(roomchos);
                                break;
                            }
                            catch (Exception ex)
                            {
                                if (ex is FormatException || ex is IndexOutOfRangeException)
                                {
                                    Console.WriteLine("Invalid input");
                                }
                            }




                        }

                        break;

                        // reserve a room
                    case 3:
                        Reservation reservation = new Reservation();

                        List<Guest> GuestList = new List<Guest>();

                        Customer customer = new Customer();

                        // one customer can have multiple reservations
                        // checks if there is at least one customer that can reserve again
                        if (CusStore.CustomerStore.Count()-1 >=0)
                        {
                            int[] uxrange = { 1, 2 };
                            int uxinput;
                            // Option for new user or old user

                            Console.WriteLine("Select option:\n 1. Existing User \n 2. New user");
                            while (true)
                            {
                                try
                                {
                                    uxinput = uxrange[int.Parse(Console.ReadLine()) - 1];
                                    break;
                                }
                                catch (Exception ex)
                                {
                                    if (ex is IndexOutOfRangeException || ex is FormatException)
                                    {

                                        Console.WriteLine("Invalid input");
                                    }
                                }
                            }
                            if (uxinput == 1)
                                 
                            {   // Select which customer to reserve for
                                int cusnumber;
                                Console.WriteLine("Select customer");

                                CusStore.display();
                                while (true)
                                {
                                    try
                                    {
                                        cusnumber = int.Parse(Console.ReadLine()) - 1;
                                        break;
                                    }
                                    catch (Exception ex)
                                    {
                                        if (ex is IndexOutOfRangeException || ex is FormatException) {
                                            Console.WriteLine("Invalid input");

                                        }
                                    }

                                }
                                // details of guests input
                                Console.WriteLine("Enter the number of guests");

                                int guestnumb = int.Parse(Console.ReadLine());

                                for (int i = 0; i < guestnumb; i++)
                                {
                                    Guest guest = new Guest();

                                    Console.WriteLine("Enter the name for guest " + (i + 1));

                                    guest.Name = Console.ReadLine();

                                    Console.WriteLine("Enter the phone number for guest " + (i + 1));

                                    guest.PhoneNumber = Console.ReadLine();

                                    GuestList.Add(guest);
                                }
                                reservation.GuestList = GuestList;


                                // arrival date
                                while (reservation.inDate == new DateTime(2001, 1, 1))
                                {
                                    Console.WriteLine("Enter the arrivale date in MM\\DD\\YYYY format");
                                    try
                                    {
                                        reservation.inDate = DateTime.Parse(Console.ReadLine());
                                    }
                                    catch (System.FormatException)
                                    {
                                        Console.WriteLine("Invalid input");
                                    }
                                }


                                // departure date
                                while (reservation.outDate == new DateTime(2001, 1, 1))
                                {
                                    Console.WriteLine("Enter the departure date in MM\\DD\\YYYY format");
                                    try
                                    {
                                        reservation.outDate = DateTime.Parse(Console.ReadLine());
                                    }

                                    catch (System.FormatException)
                                    {
                                        Console.WriteLine("Invalid input");
                                    }
                                }
                                // room selection based on available rooms using dates
                                int roomch;
                                while (reservation.room.Type == "No Entry")
                                {

                                    Console.WriteLine("Choose Room");
                                    store.areAvailable(CusStore, reservation.inDate, reservation.outDate);

                                    try
                                    {
                                        roomch = int.Parse(Console.ReadLine()) - 1;
                                        reservation.room = store.RoomStore[roomch];
                                        store.RoomAvailable.RemoveAt(roomch);
                                    }
                                    catch (Exception ex)
                                    {
                                        if (ex is FormatException || ex is IndexOutOfRangeException)
                                        {
                                            Console.WriteLine("Invalid input");
                                        }
                                    }




                                }
                                // adding the reservation to the customer
                                CusStore.CustomerStore[cusnumber].reservations.Add(reservation);
                                break;
                            }
                            

                        }
                        // new user we need the name and phone number
                        Console.WriteLine("Enter The Customer's Name");

                        customer.Name = Console.ReadLine();

                        Console.WriteLine("Enter The Customer's Phone Number");

                        customer.PhoneNumber = Console.ReadLine();

                       
                        // details of guests
                        Console.WriteLine("Enter the number of guests");

                        int guestnumber = int.Parse(Console.ReadLine());

                        for(int i = 0; i < guestnumber; i++)
                        {
                            Guest guest = new Guest();

                            Console.WriteLine("Enter the name for guest "+(i+1));

                            guest.Name = Console.ReadLine();

                            Console.WriteLine("Enter the phone number for guest "+(i+1));

                            guest.PhoneNumber = Console.ReadLine();

                            GuestList.Add(guest);
                        }
                        reservation.GuestList = GuestList;


                        // arrival date
                        while (reservation.inDate == new DateTime(2001, 1, 1) )
                        {
                            Console.WriteLine("Enter the arrivale date in MM\\DD\\YYYY format");
                            try
                            {
                                reservation.inDate = DateTime.Parse(Console.ReadLine());
                            }
                            catch (System.FormatException)
                            {
                                Console.WriteLine("Invalid input");
                            }
                        }


                        //departure date
                        while (reservation.outDate == new DateTime(2001, 1, 1))
                        {
                            Console.WriteLine("Enter the departure date in MM\\DD\\YYYY format");
                            try
                            {
                                reservation.outDate = DateTime.Parse(Console.ReadLine());
                            }

                            catch (System.FormatException)
                            {
                                Console.WriteLine("Invalid input");
                            }
                        }
                        // room selection based on available rooms
                        int roomchosen;
                        while (reservation.room.Type == "No Entry")
                        {

                            Console.WriteLine("Choose Room");
                            store.areAvailable(CusStore, reservation.inDate, reservation.outDate);

                            try
                            {
                                roomchosen = int.Parse(Console.ReadLine())-1;
                                reservation.room = store.RoomStore[roomchosen];
                                store.RoomAvailable.RemoveAt(roomchosen);
                            }
                            catch (Exception ex)
                            {
                                if (ex is FormatException || ex is IndexOutOfRangeException)
                                {
                                    Console.WriteLine("Invalid input");
                                }
                            }




                        }
                        // add reservation to the customer
                        customer.reservations.Add(reservation);

                        //add the customer to the customers list
                        CusStore.CustomerStore.Add(customer);



                                            break;
                    // list of available rooms using date
                    case 4:
                        bool flag=true;
                        DateTime indate = new DateTime();
                        DateTime outdate= new DateTime();
                        
                        while (flag)
                        {
                            Console.WriteLine("Enter the arrivale date in MM\\DD\\YYYY format");
                            try
                            {
                                indate = DateTime.Parse(Console.ReadLine());
                                flag= false;
                            }
                            catch (System.FormatException)
                            {
                                Console.WriteLine("Invalid input");
                            }
                        }

                        flag= true;

                        while (flag)
                        {
                            Console.WriteLine("Enter the departure date in MM\\DD\\YYYY format");
                            try
                            {
                                outdate = DateTime.Parse(Console.ReadLine());
                                flag= false;
                            }

                            catch (System.FormatException)
                            {
                                Console.WriteLine("Invalid input");
                            }
                        }

                        store.areAvailable(CusStore, indate, outdate);

                        break;

                        // Checkout
                    case 5:
                        
                        CusStore.Checkout();
                        Console.WriteLine("-------------------------------------------------------------------");

                        break;

                        case 6:
                        store.display();
                       /* while (true)
                        {
                            try
                            { int a = int.Parse(Console.ReadLine())-1;

                                if (store.RoomStore[a].isAvailable(store))
                                {
                                    Console.WriteLine("The Room Is available");
                                }
                                else { Console.WriteLine("The Room is reserved"); }
                                break;
                            }
                            catch (Exception ex)
                            {
                                if (ex is FormatException )
                                {
                                    Console.WriteLine("Invalid input");
                                }
                            }
                        }*/
                        break;





                }

                action = Action();

            }

            static int exhandling(int num)
            { int a;
                while (true)
                { try
                    {
                        a=int.Parse(Console.ReadLine())-1;
                        if ((a+1)>num || a<0 )
                        {
                            Console.WriteLine("Invalid input");
                            continue;
                        }
                        break;
                    }
                    catch (FormatException)
                    {
                      
                            Console.WriteLine("Invalid input");
                        
                    }

                }
                return a;
            }
            

            static int Action()
            {
                int action = 0;
                Console.WriteLine("Choose Your option\n" +
                    "0. Quit\n"+
                    "1. Add Room\n" +
                    "2. Delete Room\n"+
                    "3. Make reservation\n" +
                    "4. List available Rooms\n" +
                    "5. Checkout\n" +
                    "6. List all rooms");
                action = int.Parse(Console.ReadLine());
                return action;
            }

        }

       
    }
}
