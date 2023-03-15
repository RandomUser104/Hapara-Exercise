using System;
using System.Collections.Generic;

public class LRUCache
{
    private const int MinCapacity = 1;
    private const int MaxCapacity = 1000;
    private const int MinKey = 0;
    private const int MaxKey = 1000000;
    private const int MinValue = 0;
    private const int MaxValue = 100000;

    private int capacity;
    private Dictionary<int, Node> map;
    private Node head;
    private Node tail;

    public LRUCache(int capacity)
    {
        if (capacity < MinCapacity || capacity > MaxCapacity)
        {
            throw new ArgumentOutOfRangeException(nameof(capacity), $"Capacity must be between {MinCapacity} and {MaxCapacity}.");
        }

        this.capacity = capacity;
        this.map = new Dictionary<int, Node>();
        this.head = new Node(0, 0);
        this.tail = new Node(0, 0);
        this.head.next = this.tail;
        this.tail.prev = this.head;
    }

    public int Get(int key)
    {
        if (map.TryGetValue(key, out Node node))
        {
            MoveToHead(node);
            return node.value;
        }
        else
        {
            return -1;
        }
    }

    public void Put(int key, int value)
    {
        if (key < MinKey || key > MaxKey)
        {
            throw new ArgumentOutOfRangeException(nameof(key), $"Key must be between {MinKey} and {MaxKey}.");
        }

        if (value < MinValue || value > MaxValue)
        {
            throw new ArgumentOutOfRangeException(nameof(value), $"Value must be between {MinValue} and {MaxValue}.");
        }

        if (map.TryGetValue(key, out Node node))
        {
            node.value = value;
            MoveToHead(node);
        }
        else
        {
            if (map.Count == capacity)
            {
                RemoveLRU();
            }
            node = new Node(key, value);
            map.Add(key, node);
            AddToHead(node);
        }
    }

    public int Delete(int key)
    {
        if (map.TryGetValue(key, out Node node))
        {
            map.Remove(key);
            RemoveNode(node);
            return node.value;
        }
        else
        {
            return -1;
        }
    }

    private void MoveToHead(Node node)
    {
        RemoveNode(node);
        AddToHead(node);
    }

    private void AddToHead(Node node)
    {
        node.prev = head;
        node.next = head.next;
        head.next.prev = node;
        head.next = node;
    }

    private void RemoveNode(Node node)
    {
        node.prev.next = node.next;
        node.next.prev = node.prev;
    }

    private void RemoveLRU()
    {
        Node node = tail.prev;
        map.Remove(node.key);
        RemoveNode(node);
    }

    private class Node
    {
        public int key;
        public int value;
        public Node prev;
        public Node next;

        public Node(int key, int value)
        {
            this.key = key;
            this.value = value;
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            LRUCache cache = new LRUCache(2);
            cache.Put(1, 1);
            cache.Put(2, 2);
            string randomOne = cache.Get(1).ToString();
            Console.Write(randomOne);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
