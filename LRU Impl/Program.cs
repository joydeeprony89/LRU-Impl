using System;
using System.Collections.Generic;
using System.Linq;

namespace LRU_Impl
{
    class Program
    {
        static void Main(string[] args)
        {
            LRUCache lRUCache = new LRUCache(2);
            lRUCache.Put(1, 1);
            lRUCache.Put(2, 2);
            lRUCache.Get(1);
            lRUCache.Put(3, 3);
            lRUCache.Get(2);
            lRUCache.Put(4, 4);
            lRUCache.Get(1);
            lRUCache.Get(3);
            lRUCache.Get(4);
        }

        public class LRUCache
        {
            LinkedList<int> cache;
            Dictionary<int, int> reference;
            public int MAX;
            public LRUCache(int capacity)
            {
                cache = new LinkedList<int>();
                reference = new Dictionary<int, int>(capacity);
                MAX = capacity;
            }

            public int Get(int key)
            {
                if (!reference.ContainsKey(key)) return -1;
                cache.Remove(key);
                cache.AddFirst(key);
                return reference[key];
            }

            public void Put(int key, int value)
            {
                if (!reference.ContainsKey(key))
                {
                    if (MAX == cache.Count)
                    {
                        int temp = cache.Last();
                        cache.RemoveLast();
                        reference.Remove(temp);
                    }
                }
                else
                {
                    cache.Remove(key);
                }
                cache.AddFirst(new LinkedListNode<int>(key));
                reference[key] = value;
            }
        }
    }
}
