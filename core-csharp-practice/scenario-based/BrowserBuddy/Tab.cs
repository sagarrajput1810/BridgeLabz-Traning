// Tab.cs
using System;

public class Tab
{
    public Guid Id { get; private set; }
    public DoublyLinkedList History { get; private set; }
    public string Name { get; set; } // Optional: for display purposes

    public Tab(string initialUrl, string name = "New Tab")
    {
        Id = Guid.NewGuid();
        History = new DoublyLinkedList();
        History.Add(initialUrl);
        Name = name;
        Console.WriteLine($"Tab {Name} ({Id}) opened with initial URL: {initialUrl}");
    }

    public string CurrentUrl => History.GetCurrentUrl();

    public void Navigate(string url)
    {
        History.Add(url);
    }

    public string GoBack()
    {
        return History.Back();
    }

    public string GoForward()
    {
        return History.Forward();
    }

    public bool CanGoBack => History.CanGoBack;
    public bool CanGoForward => History.CanGoForward;

    public override string ToString()
    {
        return $"Tab '{Name}' (ID: {Id.ToString().Substring(0, 8)}) - Current URL: {CurrentUrl}";
    }
}
