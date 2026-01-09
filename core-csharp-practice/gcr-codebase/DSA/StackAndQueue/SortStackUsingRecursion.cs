using System;
using System.Collections.Generic;

namespace StackAndQueueProblems
{
    /// <summary>
    /// Problem: Given a stack, sort its elements in ascending order using recursion.
    /// 
    /// Approach: Pop elements recursively, sort the remaining stack, 
    /// and insert the popped element back at the correct position.
    /// 
    /// Time Complexity: O(n^2)
    /// Space Complexity: O(n) for recursion stack
    /// </summary>
    public class SortStackUsingRecursion
    {
        /// <summary>
        /// Sorts a stack in ascending order using recursion
        /// </summary>
        public static void SortStack(Stack<int> stack)
        {
            // Base case: if stack is empty, return
            if (stack.Count == 0)
                return;

            // Pop the top element
            int top = stack.Pop();

            // Recursively sort the remaining stack
            SortStack(stack);

            // Insert the popped element at correct position
            InsertInSortedOrder(stack, top);
        }

        /// <summary>
        /// Helper method to insert an element in correct position in sorted stack
        /// </summary>
        private static void InsertInSortedOrder(Stack<int> stack, int value)
        {
            // Base case: if stack is empty or value is greater than top
            if (stack.Count == 0 || value > stack.Peek())
            {
                stack.Push(value);
                return;
            }

            // Pop the top element
            int top = stack.Pop();

            // Recursively insert the value
            InsertInSortedOrder(stack, value);

            // Push the popped element back
            stack.Push(top);
        }

        /// <summary>
        /// Alternative approach: Sort using auxiliary stack
        /// </summary>
        public static void SortStackUsingAuxiliary(Stack<int> stack)
        {
            Stack<int> auxStack = new Stack<int>();

            while (stack.Count > 0)
            {
                int element = stack.Pop();

                // Move elements from aux to main stack if they are greater
                while (auxStack.Count > 0 && auxStack.Peek() > element)
                {
                    stack.Push(auxStack.Pop());
                }

                auxStack.Push(element);
            }

            // Transfer back to original stack
            while (auxStack.Count > 0)
            {
                stack.Push(auxStack.Pop());
            }
        }

        public static void PrintStack(Stack<int> stack)
        {
            Stack<int> temp = new Stack<int>(stack);
            while (temp.Count > 0)
            {
                Console.Write(temp.Pop() + " ");
            }
            Console.WriteLine();
        }

        public static void Main()
        {
            Console.WriteLine("=== Sort Stack Using Recursion ===\n");

            // Test case 1: Recursive approach
            Stack<int> stack1 = new Stack<int>();
            int[] elements1 = { 5, 3, 8, 1, 9, 2 };
            
            Console.WriteLine("Original Stack: ");
            foreach (int e in elements1)
            {
                stack1.Push(e);
                Console.Write(e + " ");
            }
            Console.WriteLine();

            SortStack(stack1);

            Console.WriteLine("Sorted Stack (Recursive): ");
            PrintStack(stack1);

            // Test case 2: Auxiliary stack approach
            Console.WriteLine("\n--- Using Auxiliary Stack Approach ---");
            Stack<int> stack2 = new Stack<int>();
            int[] elements2 = { 34, 3, 31, 98, 92, 23 };

            Console.WriteLine("Original Stack: ");
            foreach (int e in elements2)
            {
                stack2.Push(e);
                Console.Write(e + " ");
            }
            Console.WriteLine();

            SortStackUsingAuxiliary(stack2);

            Console.WriteLine("Sorted Stack (Auxiliary): ");
            PrintStack(stack2);

            // Test case 3: Already sorted
            Console.WriteLine("\n--- Already Sorted Stack ---");
            Stack<int> stack3 = new Stack<int>();
            int[] elements3 = { 5, 4, 3, 2, 1 };

            Console.WriteLine("Original Stack: ");
            foreach (int e in elements3)
            {
                stack3.Push(e);
                Console.Write(e + " ");
            }
            Console.WriteLine();

            SortStack(stack3);

            Console.WriteLine("Sorted Stack: ");
            PrintStack(stack3);
        }
    }
}
