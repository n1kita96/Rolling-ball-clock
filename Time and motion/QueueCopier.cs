using System;
using System.Collections.Generic;
/// ===============================
///  AUTHOR 
///  Mykyta Shvets
/// ===============================
namespace Time_and_motion
{
    class QueueCopier<T>
    {
        /*return copy of income queue*/
        public static Queue<T> Copy(Queue<T> queue)
        {
            if (queue == null)
            {
                throw new ArgumentNullException("queue can not be null!");
            }

            Queue<T> queueCopy = new Queue<T>();
            int counter = queue.Count;
            for (int i = 0; i < counter; i++) 
            {
                T elem = queue.Dequeue();
                queueCopy.Enqueue(elem);
                queue.Enqueue(elem);
            }
            return queueCopy;
        }
    }
}
