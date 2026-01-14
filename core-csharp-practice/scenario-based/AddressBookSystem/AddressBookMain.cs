using System;

namespace AddressBookSystem{
class AddressBookMain
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Address Book System!");
        AddressBookMenu menu = new AddressBookMenu();
        menu.ShowMenu();
    }
}}