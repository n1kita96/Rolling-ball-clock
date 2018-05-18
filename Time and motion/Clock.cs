using System.Collections.Generic;
/// ===============================
///  AUTHOR 
///  Mykyta Shvets
/// ===============================
namespace Time_and_motion
{
    class Clock
    {
        Stack<Ball> hourTrack;
        Stack<Ball> fiveMinTrack;
        Stack<Ball> minutesTrack;
        Queue<Ball> originalQueue;

        const int BALLS_IN_MIN_TRACK = 5;
        const int BALLS_IN_FIVEMIN_TRACK = 12;
        const int BALLS_IN_HOUR_TRACK = 12;

        public Clock(Queue<Ball> queue)
        {
            originalQueue = queue;
            minutesTrack = new Stack<Ball>();
            fiveMinTrack = new Stack<Ball>();
            hourTrack = new Stack<Ball>();
        }

        public double GetDays()
        {
            Queue<Ball> currentQueue = QueueCopier<Ball>.Copy(originalQueue);
            double days = 0;
            do
            {
                minutesTrack.Push(currentQueue.Dequeue());

                if (minutesTrack.Count == BALLS_IN_MIN_TRACK)
                {
                    fiveMinTrack.Push(minutesTrack.Pop());
                    while (minutesTrack.Count != 0)
                    {
                        currentQueue.Enqueue(minutesTrack.Pop());
                    }
                }
                if (fiveMinTrack.Count == BALLS_IN_FIVEMIN_TRACK)
                {
                    hourTrack.Push(fiveMinTrack.Pop());
                    while (fiveMinTrack.Count != 0)
                    {
                        currentQueue.Enqueue(fiveMinTrack.Pop());
                    }
                }
                if (hourTrack.Count == BALLS_IN_HOUR_TRACK)
                {
                    Ball last = hourTrack.Pop();
                    while (hourTrack.Count != 0)
                    {
                        currentQueue.Enqueue(hourTrack.Pop());
                    }
                    currentQueue.Enqueue(last);
                    days += 0.5; 
                }
            } while (!isEqual(currentQueue, originalQueue));

            return days;
        }
        //check if two queues are equal
        bool isEqual(Queue<Ball> queue1, Queue<Ball> queue2)
        {
            //two null queues are NOT equal
            if (queue1 == null || queue2 == null || (queue1.Count != queue2.Count))
            {
                return false;
            }
            //two empty queues are equal
            else if (queue1.Count == 0)
            {
                return true;
            }
            //create clones of queues
            Queue<Ball> copy1 = QueueCopier<Ball>.Copy(queue1);
            Queue<Ball> copy2 = QueueCopier<Ball>.Copy(queue2);
            //get elemens of queues one by one. If elements equal and no more elements in queues - they (queues) are equal
            while (copy1.Dequeue().Equals(copy2.Dequeue()))
            {
                if (copy1.Count == 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
