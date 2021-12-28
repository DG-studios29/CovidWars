using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkingNode<T>
{
    public int id;
    public T _data;
    public LinkingNode<T> _next;
    public LinkingNode<T> _previous;

    public LinkingNode( )
    {
        _next = null;
    }

    public LinkingNode(int _id, T data, LinkingNode<T> prev)
    {
        id = _id;
        _data = data;
        _next = null;
        _previous = prev;
    }
}
