// Program.cs
using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Starting BrowserBuddy Simulation...\n");

        Browser browser = new Browser();

        // Open some tabs
        Tab tab1 = browser.OpenTab("https://www.google.com");
        Tab tab2 = browser.OpenTab("https://www.github.com");
        Tab tab3 = browser.OpenTab("https://www.openai.com");

        browser.DisplayActiveTabs();

        // Interact with Tab 2
        Console.WriteLine("\n--- Interacting with Tab 2 ---");
        browser.SwitchToTab(tab2.Id);
        browser.Navigate("https://www.github.com/microsoft");
        browser.Navigate("https://www.github.com/google");
        browser.Back();
        browser.Back(); // Should go back to initial github.com
        browser.Forward(); // Should go forward to github.com/microsoft
        Console.WriteLine($"Current URL for Tab 2: {browser.CurrentTab.CurrentUrl}");


        // Interact with Tab 1
        Console.WriteLine("\n--- Interacting with Tab 1 ---");
        browser.SwitchToTab(tab1.Id);
        browser.Navigate("https://www.google.com/search?q=csharp");
        browser.Navigate("https://www.google.com/images");
        browser.Back();
        Console.WriteLine($"Current URL for Tab 1: {browser.CurrentTab.CurrentUrl}");

        browser.DisplayActiveTabs();

        // Close a tab
        Console.WriteLine("\n--- Closing Tab 3 ---");
        browser.CloseTab(tab3.Id);
        browser.DisplayActiveTabs();
        browser.DisplayClosedTabsStack();

        // Restore a closed tab
        Console.WriteLine("\n--- Restoring a Tab ---");
        Tab restoredTab = browser.RestoreClosedTab();
        if (restoredTab != null)
        {
            Console.WriteLine($"Restored tab name: {restoredTab.Name}");
        }
        browser.DisplayActiveTabs();
        browser.DisplayClosedTabsStack();

        // Close another tab and restore
        Console.WriteLine("\n--- Closing and Restoring Tab 1 ---");
        browser.CloseTab(tab1.Id);
        browser.DisplayActiveTabs();
        browser.DisplayClosedTabsStack();

        restoredTab = browser.RestoreClosedTab();
        if (restoredTab != null)
        {
            Console.WriteLine($"Restored tab name: {restoredTab.Name}");
        }
        browser.DisplayActiveTabs();
        browser.DisplayClosedTabsStack();
        Console.WriteLine("BrowserBuddy Simulation Ended.\n");
    }
}