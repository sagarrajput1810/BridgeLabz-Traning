using System;
using System.Collections.Generic;

namespace StackAndQueueProblems
{
    /// <summary>
    /// Problem: Design a queue using two stacks such that enqueue and dequeue 
    /// operations are performed efficiently.
    /// 
    /// Approach: Use one stack for enqueue and another stack for dequeue. 
    /// Transfer elements between stacks as needed.
    /// </summary>
    public class QueueUsingStacks<T>
    {
        private Stack<T> enqueueStack;
        private Stack<T> dequeueStack;

        public QueueUsingStacks()
        {
            enqueueStack = new Stack<T>();
            dequeueStack = new Stack<T>();
        }

        /// <summary>
        /// Enqueue operation - O(1) time complexity
        /// </summary>
        public void Enqueue(T value)
        {
            enqueueStack.Push(value);
        }

        /// <summary>
        /// Dequeue operation - O(n) amortized time complexity
        /// </summary>
        public T Dequeue()
        {
            if (dequeueStack.Count == 0)
            {
                // Transfer all elements from enqueue stack to dequeue stack
                while (enqueueStack.Count > 0)
                {
                    dequeueStack.Push(enqueueStack.Pop());
                }
            }

            if (dequeueStack.Count == 0)
                throw new InvalidOperationException("Queue is empty");

            return dequeueStack.Pop();
        }

        /// <summary>
        /// Peek at the front element without removing it
        /// </summary>
        public T Peek()
        {
            if (dequeueStack.Count == 0)
            {
                while (enqueueStack.Count > 0)
                {
                    dequeueStack.Push(enqueueStack.Pop());
                }
            }

            if (dequeueStack.Count == 0)
                throw new InvalidOperationException("Queue is empty");

            return dequeueStack.Peek();
        }

        public bool IsEmpty() => enqueueStack.Count == 0 && dequeueStack.Count == 0;
        public int Count => enqueueStack.Count + dequeueStack.Count;
    }

    public class QueueUsingStacksProgram
    {
        public static void Main()
        {
            Console.WriteLine("=== Queue Using Stacks ===\n");

            var queue = new QueueUsingStacks<int>();

            // Enqueue elements
            Console.WriteLine("Enqueuing: 1, 2, 3, 4, 5");
            for (int i = 1; i <= 5; i++)
            {
                queue.Enqueue(i);
            }

            // Peek
            Console.WriteLine($"\nPeek (first element): {queue.Peek()}");

            // Dequeue elements
            Console.WriteLine("\nDequeuing all elements:");
            while (!queue.IsEmpty())
            {
                Console.WriteLine($"Dequeued: {queue.Dequeue()}");
            }

            // Test with strings
            Console.WriteLine("\n--- Testing with Strings ---");
            var stringQueue = new QueueUsingStacks<string>();
            stringQueue.Enqueue("Hello");
            stringQueue.Enqueue("World");
            stringQueue.Enqueue("!");

            Console.WriteLine($"Dequeue: {stringQueue.Dequeue()}");
            Console.WriteLine($"Dequeue: {stringQueue.Dequeue()}");
            Console.WriteLine($"Dequeue: {stringQueue.Dequeue()}");
        }
    }
}
