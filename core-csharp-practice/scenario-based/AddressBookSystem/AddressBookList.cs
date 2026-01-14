using System;
using System.Diagnostics.Contracts;

namespace AddressBookSystem
{
    class AddressBookList
    {
        // Creating the object

        List<Contact> contacts = new List<Contact>();

        public void AddContact()
        {
            Contact contact = new Contact();
            Console.WriteLine("Enter First Name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter Address:");
            string address = Console.ReadLine();
            Console.WriteLine("Enter City:");
            string city = Console.ReadLine();
            Console.WriteLine("Enter State:");
            string state = Console.ReadLine();
            Console.WriteLine("Enter Zip Code:");
            string zip = Console.ReadLine();
            Console.WriteLine("Enter Phone Number:");
            long phoneNumber = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter Email:");
            string email = Console.ReadLine();

            contact.AddContact(firstName, lastName, address, city, state, zip, phoneNumber, email);
            contacts.Add(contact);
        }

        public void DisplayContacts()
        {
            foreach (var contact in contacts)
            {
                contact.DisplayContact();
            }
        }
        public void EditContact()
        {
            Console.WriteLine("select options");
            Console.WriteLine("1. Edit First Name");
            Console.WriteLine("2. Edit Last Name");
            Console.WriteLine("3. Edit Address");
            Console.WriteLine("4. Edit City");
            Console.WriteLine("5. Edit State");
            Console.WriteLine("6. Edit Zip Code");
            Console.WriteLine("7. Edit Phone Number");
            Console.WriteLine("8. Edit Email");
            int option = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Name to edit contact:");
            string name = Console.ReadLine();
            foreach (var contact in contacts)
            {
                if (contact.GetName().Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("Enter new First Name:");
                            contact.FirstName = Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("Enter new Last Name:");
                            contact.LastName = Console.ReadLine();
                            break;
                        case 3:
                            Console.WriteLine("Enter new Address:");
                            contact.Address = Console.ReadLine();
                            break;
                        case 4:
                            Console.WriteLine("Enter new City:");
                            contact.City = Console.ReadLine();
                            break;
                        case 5:
                            Console.WriteLine("Enter new State:");
                            contact.State = Console.ReadLine();
                            break;
                        case 6:
                            Console.WriteLine("Enter new Zip Code:");
                            contact.Zip = Console.ReadLine();
                            break;
                        case 7:
                            Console.WriteLine("Enter new Phone Number:");
                            contact.PhoneNumber = long.Parse(Console.ReadLine());
                            break;
                        case 8:
                            Console.WriteLine("Enter new Email:");
                            contact.Email = Console.ReadLine();
                            break;
                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }
                    Console.WriteLine("Contact updated successfully.");
                    return;
                }
            }
        }

        public void SearchContact()
        {
            Console.WriteLine("Enter City or State to search contact:");
            string location = Console.ReadLine();
            foreach (var contact in contacts)
            {
                if (contact.City.Equals(location, StringComparison.OrdinalIgnoreCase) ||
                    contact.State.Equals(location, StringComparison.OrdinalIgnoreCase))
                {
                    contact.DisplayContact();
                }
            }
        }

        public void DeleteContact()
        {
            Console.WriteLine("Enter Name to delete contact:");
            string name = Console.ReadLine();
            foreach (var contact in contacts)
            {
                if (contact.GetName().Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    contacts.Remove(contact);
                    Console.WriteLine("Contact deleted successfully.");
                    return;
                }
            }
        }
    }
}