using System;

namespace AddressBookSystem
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
        public void AddContact(string firstName, string lastName, string address, string city, string state, string zip, long phoneNumber, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            City = city;
            State = state;
            Zip = zip;
            PhoneNumber = phoneNumber;
            Email = email;
        }
        
        public string GetName()
        {
            return FirstName;
        }
        
        public void DisplayContact()
        {
            Console.WriteLine($"Name: {FirstName} {LastName}, Address: {Address}, City: {City}, State: {State}, Zip-Code: {Zip}, Phone Number: {PhoneNumber}, Email: {Email}");
        }
    }
}