using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList<T>
{
	public LinkingNode<T> head;
	public LinkingNode<T> tail;
	public LinkingNode<T> start;


    public void Add(T data)
    {
        LinkingNode<T> newNode = new LinkingNode<T>();
        if (tail != null)
        {
            newNode = new LinkingNode<T>(tail.id + 1, data,tail);
        }
        else
        {
            newNode = new LinkingNode<T>(1,data,null);
        }

        newNode._next = null;

        if(tail == null)
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

    public LinkingNode<T> Find(int id)
    {
        LinkingNode<T> current = new LinkingNode<T>();
        current = head;
        while(!Equals(current.id, id) && current._next != null)
		{
            if(current.id < id)
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
    public LinkingNode<T> goNext()
	{
        LinkingNode<T> current = new LinkingNode<T>();

        current = head._next;

        return current; 
	}     
    public LinkingNode<T> goBack()
	{
        LinkingNode<T> current = new LinkingNode<T>();

        current = head._previous;

        return current; 
	}

}