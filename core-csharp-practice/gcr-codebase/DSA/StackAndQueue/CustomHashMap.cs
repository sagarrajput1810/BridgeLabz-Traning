using System;
using System.Collections.Generic;

namespace HashMapProblems
{
    /// <summary>
    /// Problem: Design and implement a basic hash map class with operations 
    /// for insertion, deletion, and retrieval.
    /// 
    /// Approach: Use an array of linked lists to handle collisions using separate chaining.
    /// 
    /// Time Complexity: O(1) average, O(n) worst case
    /// Space Complexity: O(n)
    /// </summary>
    public class CustomHashMap<K, V> where K : IEquatable<K>
    {
        private const int InitialCapacity = 16;
        private const float LoadFactor = 0.75f;

        private LinkedList<KeyValuePair<K, V>>[] buckets;
        private int size;

        public CustomHashMap()
        {
            buckets = new LinkedList<KeyValuePair<K, V>>[InitialCapacity];
            size = 0;
        }

        /// <summary>
        /// Get the hash code for a key
        /// </summary>
        private int GetBucketIndex(K key)
        {
            if (key == null)
                return 0;
            return Math.Abs(key.GetHashCode()) % buckets.Length;
        }

        /// <summary>
        /// Put a key-value pair into the hash map
        /// </summary>
        public void Put(K key, V value)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            // Check load factor and resize if necessary
            if (size >= buckets.Length * LoadFactor)
            {
                Resize();
            }

            int bucketIndex = GetBucketIndex(key);

            if (buckets[bucketIndex] == null)
            {
                buckets[bucketIndex] = new LinkedList<KeyValuePair<K, V>>();
            }

            // Check if key already exists
            var node = buckets[bucketIndex].First;
            while (node != null)
            {
                if (node.Value.Key.Equals(key))
                {
                    // Update existing value
                    var entry = node.Value;
                    buckets[bucketIndex].Remove(node);
                    buckets[bucketIndex].AddLast(new KeyValuePair<K, V>(key, value));
                    return;
                }
                node = node.Next;
            }

            // Add new key-value pair
            buckets[bucketIndex].AddLast(new KeyValuePair<K, V>(key, value));
            size++;
        }

        /// <summary>
        /// Get the value associated with a key
        /// </summary>
        public V Get(K key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            int bucketIndex = GetBucketIndex(key);

            if (buckets[bucketIndex] != null)
            {
                var node = buckets[bucketIndex].First;
                while (node != null)
                {
                    if (node.Value.Key.Equals(key))
                    {
                        return node.Value.Value;
                    }
                    node = node.Next;
                }
            }

            throw new KeyNotFoundException($"Key '{key}' not found");
        }

        /// <summary>
        /// Check if a key exists in the hash map
        /// </summary>
        public bool ContainsKey(K key)
        {
            if (key == null)
                return false;

            int bucketIndex = GetBucketIndex(key);

            if (buckets[bucketIndex] != null)
            {
                var node = buckets[bucketIndex].First;
                while (node != null)
                {
                    if (node.Value.Key.Equals(key))
                    {
                        return true;
                    }
                    node = node.Next;
                }
            }

            return false;
        }

        /// <summary>
        /// Remove a key-value pair from the hash map
        /// </summary>
        public bool Remove(K key)
        {
            if (key == null)
                return false;

            int bucketIndex = GetBucketIndex(key);

            if (buckets[bucketIndex] != null)
            {
                var node = buckets[bucketIndex].First;
                while (node != null)
                {
                    if (node.Value.Key.Equals(key))
                    {
                        buckets[bucketIndex].Remove(node);
                        size--;
                        return true;
                    }
                    node = node.Next;
                }
            }

            return false;
        }

        /// <summary>
        /// Get the number of key-value pairs in the hash map
        /// </summary>
        public int Size => size;

        /// <summary>
        /// Check if the hash map is empty
        /// </summary>
        public bool IsEmpty => size == 0;

        /// <summary>
        /// Clear all entries from the hash map
        /// </summary>
        public void Clear()
        {
            buckets = new LinkedList<KeyValuePair<K, V>>[InitialCapacity];
            size = 0;
        }

        /// <summary>
        /// Resize the hash map when load factor is exceeded
        /// </summary>
        private void Resize()
        {
            LinkedList<KeyValuePair<K, V>>[] oldBuckets = buckets;
            buckets = new LinkedList<KeyValuePair<K, V>>[oldBuckets.Length * 2];
            size = 0;

            for (int i = 0; i < oldBuckets.Length; i++)
            {
                if (oldBuckets[i] != null)
                {
                    var node = oldBuckets[i].First;
                    while (node != null)
                    {
                        Put(node.Value.Key, node.Value.Value);
                        node = node.Next;
                    }
                }
            }
        }

        /// <summary>
        /// Get all keys in the hash map
        /// </summary>
        public List<K> Keys()
        {
            List<K> keys = new List<K>();
            for (int i = 0; i < buckets.Length; i++)
            {
                if (buckets[i] != null)
                {
                    var node = buckets[i].First;
                    while (node != null)
                    {
                        keys.Add(node.Value.Key);
                        node = node.Next;
                    }
                }
            }
            return keys;
        }

        /// <summary>
        /// Get all values in the hash map
        /// </summary>
        public List<V> Values()
        {
            List<V> values = new List<V>();
            for (int i = 0; i < buckets.Length; i++)
            {
                if (buckets[i] != null)
                {
                    var node = buckets[i].First;
                    while (node != null)
                    {
                        values.Add(node.Value.Value);
                        node = node.Next;
                    }
                }
            }
            return values;
        }

        /// <summary>
        /// Get all entries in the hash map
        /// </summary>
        public List<KeyValuePair<K, V>> EntrySet()
        {
            List<KeyValuePair<K, V>> entries = new List<KeyValuePair<K, V>>();
            for (int i = 0; i < buckets.Length; i++)
            {
                if (buckets[i] != null)
                {
                    var node = buckets[i].First;
                    while (node != null)
                    {
                        entries.Add(node.Value);
                        node = node.Next;
                    }
                }
            }
            return entries;
        }
    }

    public class CustomHashMapProgram
    {
        public static void Main()
        {
            Console.WriteLine("=== Custom Hash Map Implementation ===\n");

            // Test with string keys and integer values
            var hashMap = new CustomHashMap<string, int>();

            Console.WriteLine("--- Insert Operations ---");
            hashMap.Put("apple", 1);
            hashMap.Put("banana", 2);
            hashMap.Put("cherry", 3);
            hashMap.Put("date", 4);
            hashMap.Put("elderberry", 5);

            Console.WriteLine($"Size after insertions: {hashMap.Size}");

            // Test retrieval
            Console.WriteLine("\n--- Retrieval Operations ---");
            Console.WriteLine($"Get 'apple': {hashMap.Get("apple")}");
            Console.WriteLine($"Get 'cherry': {hashMap.Get("cherry")}");
            Console.WriteLine($"Get 'date': {hashMap.Get("date")}");

            // Test containsKey
            Console.WriteLine("\n--- Contains Key Operations ---");
            Console.WriteLine($"Contains 'banana': {hashMap.ContainsKey("banana")}");
            Console.WriteLine($"Contains 'unknown': {hashMap.ContainsKey("unknown")}");

            // Test update
            Console.WriteLine("\n--- Update Operation ---");
            hashMap.Put("apple", 10);
            Console.WriteLine($"Updated 'apple' to: {hashMap.Get("apple")}");
            Console.WriteLine($"Size after update: {hashMap.Size}");

            // Test removal
            Console.WriteLine("\n--- Removal Operations ---");
            Console.WriteLine($"Remove 'banana': {hashMap.Remove("banana")}");
            Console.WriteLine($"Size after removal: {hashMap.Size}");
            Console.WriteLine($"Remove 'unknown': {hashMap.Remove("unknown")}");

            // Test keys, values, and entries
            Console.WriteLine("\n--- Keys, Values, and Entries ---");
            Console.WriteLine($"Keys: {string.Join(", ", hashMap.Keys())}");
            Console.WriteLine($"Values: {string.Join(", ", hashMap.Values())}");
            Console.WriteLine("Entries:");
            foreach (var entry in hashMap.EntrySet())
            {
                Console.WriteLine($"  {entry.Key} -> {entry.Value}");
            }

            // Test with integer keys and string values
            Console.WriteLine("\n--- Test with Integer Keys and String Values ---");
            var intHashMap = new CustomHashMap<int, string>();
            intHashMap.Put(1, "one");
            intHashMap.Put(2, "two");
            intHashMap.Put(3, "three");
            intHashMap.Put(100, "hundred");

            Console.WriteLine("Entries:");
            foreach (var entry in intHashMap.EntrySet())
            {
                Console.WriteLine($"  {entry.Key} -> {entry.Value}");
            }

            // Test resize
            Console.WriteLine("\n--- Test Resize (adding more elements) ---");
            var largeMap = new CustomHashMap<string, int>();
            for (int i = 0; i < 20; i++)
            {
                largeMap.Put($"key{i}", i);
            }
            Console.WriteLine($"Added 20 elements. Size: {largeMap.Size}");

            // Test clear
            Console.WriteLine("\n--- Clear Operation ---");
            Console.WriteLine($"Size before clear: {largeMap.Size}");
            largeMap.Clear();
            Console.WriteLine($"Size after clear: {largeMap.Size}");
            Console.WriteLine($"Is empty: {largeMap.IsEmpty}");
        }
    }
}
