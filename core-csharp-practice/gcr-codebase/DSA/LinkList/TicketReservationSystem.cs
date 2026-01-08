using System;
using System.Collections.Generic;

public class TicketReservationSystem
{
    private class Node
    {
        public string TicketId;
        public string CustomerName;
        public string MovieName;
        public string SeatNumber;
        public DateTime BookingTime;
        public Node? Next;

        public Node(string ticketId, string customerName, string movieName, string seatNumber, DateTime bookingTime)
        {
            TicketId = ticketId;
            CustomerName = customerName;
            MovieName = movieName;
            SeatNumber = seatNumber;
            BookingTime = bookingTime;
        }
    }

    private Node? _head;
    private Node? _tail;
    private int _count;

    public void AddTicket(string ticketId, string customerName, string movieName, string seatNumber, DateTime bookingTime)
    {
        var node = new Node(ticketId, customerName, movieName, seatNumber, bookingTime);
        if (_tail == null)
        {
            _head = _tail = node;
            node.Next = node;
        }
        else
        {
            node.Next = _head;
            _tail.Next = node;
            _tail = node;
        }
        _count++;
    }

    public bool RemoveTicket(string ticketId)
    {
        if (_head == null)
        {
            return false;
        }

        Node? current = _head;
        Node? previous = null;
        do
        {
            if (string.Equals(current!.TicketId, ticketId, StringComparison.OrdinalIgnoreCase))
            {
                if (previous == null)
                {
                    if (_head == _tail)
                    {
                        _head = _tail = null;
                    }
                    else
                    {
                        _head = _head!.Next;
                        _tail!.Next = _head;
                    }
                }
                else
                {
                    previous.Next = current.Next;
                    if (current == _tail)
                    {
                        _tail = previous;
                    }
                }
                _count--;
                return true;
            }
            previous = current;
            current = current.Next;
        } while (current != _head);

        return false;
    }

    public List<(string TicketId, string CustomerName, string MovieName, string SeatNumber, DateTime BookingTime)> DisplayTickets()
    {
        var tickets = new List<(string, string, string, string, DateTime)>();
        if (_head == null)
        {
            return tickets;
        }

        var current = _head;
        do
        {
            tickets.Add((current!.TicketId, current.CustomerName, current.MovieName, current.SeatNumber, current.BookingTime));
            current = current.Next;
        } while (current != _head);

        return tickets;
    }

    public List<(string TicketId, string CustomerName, string MovieName, string SeatNumber, DateTime BookingTime)> Search(string? customerName = null, string? movieName = null)
    {
        var result = new List<(string, string, string, string, DateTime)>();
        if (_head == null)
        {
            return result;
        }

        var current = _head;
        do
        {
            bool customerMatches = customerName != null && current!.CustomerName.IndexOf(customerName, StringComparison.OrdinalIgnoreCase) >= 0;
            bool movieMatches = movieName != null && current.MovieName.IndexOf(movieName, StringComparison.OrdinalIgnoreCase) >= 0;

            if (customerMatches || movieMatches)
            {
                result.Add((current.TicketId, current.CustomerName, current.MovieName, current.SeatNumber, current.BookingTime));
            }
            current = current.Next;
        } while (current != _head);

        return result;
    }

    public int CountTickets() => _count;
}
