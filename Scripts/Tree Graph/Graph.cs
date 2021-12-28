using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Graph<T>
{
    public GraphNode<T> head;
    public GraphNode<T> tail;
    public GraphNode<T> start;


    public void Add(T data)
    {
        GraphNode<T> newNode = new GraphNode<T>();
        if (tail != null)
        {
            newNode = new GraphNode<T>(tail.id + 1, data, tail);
        }
        else
        {
            newNode = new GraphNode<T>(1, data, null);
        }

        newNode._next = null;

        if (tail == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail._next = newNode;
            tail = newNode;
        }

    }
    public void AddLast(T value)
    {

    }

    public GraphNode<T> Find(int id)
    {
        GraphNode<T> current = new GraphNode<T>();
        current = head;
        while (!Equals(current.id, id) && current._next != null)
        {
            if (current.id < id)
            {
                current = current._next;
            }
            else
            {
                current = current._previous;
            }
        }
        return current;
    }
    public GraphNode<T> goNext( )
    {
        GraphNode<T> current = new GraphNode<T>();

        current = head._next;

        return current;
    }
    public GraphNode<T> goBack( )
    {
        GraphNode<T> current = new GraphNode<T>();

        current = head._previous;

        return current;
    }

}

