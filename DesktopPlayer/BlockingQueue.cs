using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;

namespace DesktopPlayer {

    class BlockingQueue<T> : IEnumerable<T> {
        private int _count = 0;
        private bool stopped = false;

        private Queue<T> _queue = new Queue<T>();

        public int GetCount() {
            return _count;
        }

        public void Start() {
            this.stopped = false;
        }

        public void StopWaiting() {
            this.stopped = true;
            lock(_queue) {
                _count++;
                Monitor.Pulse(_queue);
            }
        }

        public T Dequeue() {
            lock(_queue) {
                // If we have items remaining in the queue, skip over this. 
                while(_count <= 0) {
                    // Release the lock and block on this line until someone
                    // adds something to the queue, resuming once they 
                    // release the lock again.
                    Monitor.Wait(_queue);
                }
                //if(stopped)
                //    return default(T);

                _count--;

                try {
                    return _queue.Dequeue();
                }
                catch(InvalidOperationException ex) {
                    if(ex.HResult == -2146233079)
                        return default(T);
                    else
                        throw ex;
                }
            }
        }

        public void Enqueue(T data) {
            if(data == null)
                throw new ArgumentNullException("data");

            lock(_queue) {
                _queue.Enqueue(data);

                _count++;

                // If the consumer thread is waiting for an item
                // to be added to the queue, this will move it
                // to a waiting list, to resume execution
                // once we release our lock.
                Monitor.Pulse(_queue);
            }
        }

        // Lets the consumer thread consume the queue with a foreach loop.
        IEnumerator<T> IEnumerable<T>.GetEnumerator() {
            while(true)
                yield return Dequeue();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
    }
}
