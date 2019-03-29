using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PriorityQueue<T> : IEnumerable<T>
{
    List<Tuple<T, float>> queue = new List<Tuple<T, float>>();

    public void Enqueue(T val, float priority)
    {
        if (Count() == 0)
        {
            queue.Insert(0, new Tuple<T, float>(val, priority));
            return;
        }
            
        queue.Insert(FindIndexLogN(priority, 0, queue.Count - 1), new Tuple<T, float>(val, priority));

        //Local function for finding correct insert point, O(LogN)
        int FindIndexLogN(float p, int lowerBound, int upperBound)
        {
            int midPoint = lowerBound + (upperBound - lowerBound) / 2;

            if (upperBound - lowerBound == 1)
                return upperBound;

            float pr = queue[midPoint].Item2;
            if (p > pr)
                return FindIndexLogN(p, midPoint, upperBound);
            else if (p < pr)
                return FindIndexLogN(p, lowerBound, midPoint);
            else
                return queue.Count / 2;
        }
    }

    public T Dequeue()
    {
        if (queue.Count == 0)
            return default(T);

        T toReturn = queue[0].Item1;
        queue.RemoveAt(0);
        return toReturn;
    }

    public T Peek()
    {
        if (queue.Count == 0)
            return default(T);
        return queue[0].Item1;
    }

    public int Count()
    {
        return queue.Count;
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach(T obj in queue.Select(t => t.Item1))
        {
            yield return obj;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

