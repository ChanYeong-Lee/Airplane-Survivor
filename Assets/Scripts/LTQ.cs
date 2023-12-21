using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class LTQ
{
    public static Queue<T> ListToQueue<T>(List<T> list)
    {
        Queue<T> queue = new Queue<T>();
        foreach (T element in list)
        {
            queue.Enqueue(element);
        }
        return queue;
    }
}