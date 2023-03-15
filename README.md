# Hapara-Exercise
The LRUCache class has four public methods, and one private class.

LRUCache(int capacity)
The Constructor of LRUCache class, which initializes the LRU cache with a given capacity. It throws an exception if the capacity is less than 1 or greater than 1000.

Get(int key)
This method returns the value associated with the given key if it exists in the cache. If not, it returns -1. This method also moves the node to the head of the linked list to indicate that it has been recently used.

Put(int key, int value)
This method adds a new key-value pair to the cache. If the key already exists in the cache, it updates the value and moves the node to the head of the linked list. If the cache is full, it removes the least recently used item before adding the new key-value pair.

Delete(int key)
This method removes the key-value pair associated with the given key from the cache and returns the value. If the key does not exist in the cache, it returns -1.

Node
This class represents a node in the doubly linked list used to implement the LRU cache. Each node contains a key, value, and pointers to the previous and next nodes in the list.

The program includes a Main method, which creates an instance of the LRUCache class and calls its Put and Get methods to add and retrieve values from the cache. If an exception is thrown, the program prints the exception message to the console. In this case, the program adds two key-value pairs to the cache and retrieves the value associated with the first key, which is 1.
