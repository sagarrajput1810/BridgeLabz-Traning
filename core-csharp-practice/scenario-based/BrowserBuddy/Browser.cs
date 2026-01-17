// Browser.cs
using System;
using System.Collections.Generic;
using System.Linq;

public class Browser
{
    private List<Tab> activeTabs;
    private Stack<Tab> closedTabsStack;
    private Tab currentTab; // Reintroducing the private field
    public Tab CurrentTab
    {
        get { return currentTab; }
        private set { currentTab = value; }
    }
    private int tabCounter = 0; // For naming new tabs

    public Browser()
    {
        activeTabs = new List<Tab>();
        closedTabsStack = new Stack<Tab>();
        currentTab = null;
    }

    public Tab OpenTab(string initialUrl)
    {
        tabCounter++;
        Tab newTab = new Tab(initialUrl, $"Tab {tabCounter}");
        activeTabs.Add(newTab);
        currentTab = newTab; // New tab becomes the current tab
        Console.WriteLine($"Opened new tab: {newTab.Name}");
        return newTab;
    }

    public void CloseTab(Guid tabId)
    {
        Tab tabToClose = activeTabs.FirstOrDefault(t => t.Id == tabId);
        if (tabToClose != null)
        {
            activeTabs.Remove(tabToClose);
            closedTabsStack.Push(tabToClose);
            Console.WriteLine($"Closed tab: {tabToClose.Name}");

            // If the closed tab was the current tab, switch to another active tab if available
            if (currentTab != null && currentTab.Id == tabId)
            {
                currentTab = activeTabs.FirstOrDefault();
                if (currentTab != null)
                {
                    Console.WriteLine($"Switched to: {currentTab.Name}");
                }
                else
                {
                    Console.WriteLine("No active tabs left.");
                }
            }
        }
        else
        {
            Console.WriteLine($"Tab with ID {tabId} not found.");
        }
    }

    public void SwitchToTab(Guid tabId)
    {
        Tab tabToSwitch = activeTabs.FirstOrDefault(t => t.Id == tabId);
        if (tabToSwitch != null)
        {
            currentTab = tabToSwitch;
            Console.WriteLine($"Switched to tab: {currentTab.Name} - Current URL: {currentTab.CurrentUrl}");
        }
        else
        {
            Console.WriteLine($"Tab with ID {tabId} not found.");
        }
    }

    public void Navigate(string url)
    {
        if (currentTab != null)
        {
            currentTab.Navigate(url);
            Console.WriteLine($"Current Tab ({currentTab.Name}) navigated to: {currentTab.CurrentUrl}");
        }
        else
        {
            Console.WriteLine("No active tab to navigate.");
        }
    }

    public void Back()
    {
        if (currentTab != null)
        {
            currentTab.GoBack();
        }
        else
        {
            Console.WriteLine("No active tab to go back.");
        }
    }

    public void Forward()
    {
        if (currentTab != null)
        {
            currentTab.GoForward();
        }
        else
        {
            Console.WriteLine("No active tab to go forward.");
        }
    }

    public Tab RestoreClosedTab()
    {
        if (!closedTabsStack.IsEmpty())
        {
            Tab restoredTab = closedTabsStack.Pop();
            activeTabs.Add(restoredTab);
            currentTab = restoredTab; // Restored tab becomes the current tab
            Console.WriteLine($"Restored tab: {restoredTab.Name} - Current URL: {restoredTab.CurrentUrl}");
            return restoredTab;
        }
        else
        {
            Console.WriteLine("No closed tabs to restore.");
            return null;
        }
    }

    public void DisplayActiveTabs()
    {
        Console.WriteLine("\n--- Active Tabs ---");
        if (activeTabs.Any())
        {
            foreach (var tab in activeTabs)
            {
                Console.WriteLine($"- {tab} {(tab == currentTab ? "(Current)" : "")}");
            }
        }
        else
        {
            Console.WriteLine("No active tabs.");
        }
        Console.WriteLine("-------------------\n");
    }

    public void DisplayClosedTabsStack()
    {
        Console.WriteLine("\n--- Closed Tabs (Stack Top to Bottom) ---");
        if (closedTabsStack.Count > 0)
        {
            // For demonstration, peek at elements without popping
            List<Tab> tempStack = new List<Tab>();
            while (!closedTabsStack.IsEmpty())
            {
                tempStack.Add(closedTabsStack.Pop());
            }
            tempStack.Reverse(); // To show from top to bottom
            foreach (var tab in tempStack)
            {
                Console.WriteLine($"- {tab.Name} (ID: {tab.Id.ToString().Substring(0, 8)}) - Last URL: {tab.CurrentUrl}");
                closedTabsStack.Push(tab); // Push back to restore original stack
            }
        }
        else
        {
            Console.WriteLine("No closed tabs.");
        }
        Console.WriteLine("-------------------------------------------\n");
    }
}
