using System;
using System.Threading;

namespace ThreadTest {
    class Program {
        static void Main(string[] args) {
            Thread childThread = new Thread(new ThreadStart(ChildThreadMethod));
            childThread.Start();
            while (true) {
                Console.WriteLine("MainThread - ...");
            }
        }

        static void ChildThreadMethod() {
            while (true) {
                Console.WriteLine("ChildThread - Running!");

            }
        }
    }
}
