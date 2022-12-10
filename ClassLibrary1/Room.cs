namespace ClassLibrary1
{
    public class Room
    {
        public string Type { get; set; }
        public double Price { get; set; }
        public string Id { get; set; }


        public Room() {
            Type = "No Entry";
            Price = 0.00;
            Id = "No Entry";
        
        }

        public Room(string type, double price,string id) { 
        
        Type= type;

        Price = price;

        Id = id;
        
        }

        // Displays room details
        public void display()
        {
            Console.WriteLine("\nRoom type: " + Type + " Room ID: " + Id + " Price: $" + Price
                );
        }


        // Checks availabilty of the room
        public bool isAvailable(RoomList roomList) {

            return roomList.RoomAvailable.Contains(this);
        }


    }
}