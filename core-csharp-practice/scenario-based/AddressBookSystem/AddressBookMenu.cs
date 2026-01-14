using System;

namespace AddressBookSystem
{
    class AddressBookMenu
    {
        public void ShowMenu()
        {
            AddressBookList addressBook = new AddressBookList();
            while (true)
            {
                Console.WriteLine("Select Value:");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Display all Contacts");
                Console.WriteLine("3. Edit Contact");
                Console.WriteLine("4. Delete Contact");
                Console.WriteLine("5. Search Contact by City or State");
                Console.WriteLine("6. Exit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1: 
                        addressBook.AddContact();
                        break;
                    case 2: 
                        addressBook.DisplayContacts();
                        break;
                    case 3:
                        addressBook.EditContact();
                        break;
                    case 4:
                        addressBook.DeleteContact();
                        break;
                    case 5:
                        addressBook.SearchContact();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}