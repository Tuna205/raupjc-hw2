using System;
using System.Threading;

namespace Zadatak5
{
    public class Threads
    {
	    public static void LongOperation(string taskName)
	    {
		    Thread.Sleep(1000);
		    Console.WriteLine("{0} Finished . Executing Thread : {1}", taskName,
			    Thread.CurrentThread.ManagedThreadId);
	    }
	}
}
