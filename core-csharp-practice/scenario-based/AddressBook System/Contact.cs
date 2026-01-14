using System;

class Contact
{
    private string FirstName {get; set;}
    private string LastName {get; set;}
    private string Address {get; set;}
    private string City {get; set;}
    private string State{get; set;}
    private int Zip {get; set;}
    private long PhoneNumber{get; set;}
    private string Email {get; set;}
    public void AddContact(string firstName, string lastName, string address, string city, string state, int zip, long phoneNumber, string email)
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
}