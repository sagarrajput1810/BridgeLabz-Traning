using System;

class HotelBooking
{
    private string guestName;
    private string roomType;
    private int nights;

    // Default Constructor
    public HotelBooking()
    {
        guestName = "Guest";
        roomType = "Standard";
        nights = 1;
    }

    // Parameterized Constructor
    public HotelBooking(string guestName, string roomType, int nights)
    {
        this.guestName = guestName;
        this.roomType = roomType;
        this.nights = nights;
    }

    // Copy Constructor
    public HotelBooking(HotelBooking h)
    {
        guestName = h.guestName;
        roomType = h.roomType;
        nights = h.nights;
    }

    public void Display()
    {
        Console.WriteLine("Guest Name : " + guestName);
        Console.WriteLine("Room Type  : " + roomType);
        Console.WriteLine("Nights     : " + nights);
        Console.WriteLine("------------------------");
    }

    static void Main(string[] args)
    {
        // 1️⃣ Default Constructor
        HotelBooking booking1 = new HotelBooking();
        booking1.Display();

        // 2️⃣ Parameterized Constructor (Hard-coded values)
        HotelBooking booking2 = new HotelBooking("Vijay", "Deluxe", 3);
        booking2.Display();

        // 3️⃣ Copy Constructor
        HotelBooking booking3 = new HotelBooking(booking2);
        booking3.Display();
    }
}
