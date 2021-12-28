using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphNode<T> 
{

    public int id;
    public T _data;
    public GraphNode<T> _next;
    public GraphNode<T> _previous;

    public GraphNode( )
    {
        _next = null;
    }

    public GraphNode(int _id, T data, GraphNode<T> prev)
    {
        id = _id;
        _data = data;
        _next = null;
        _previous = prev;
    }


}
