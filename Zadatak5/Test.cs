using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Zadatak5;

namespace Zadatak5
{
	public class Test
	{
		public static void Main(string[] args)
		{
			/*
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			Parallel.Invoke(() => Threads.LongOperation("A"),
			() => Threads.LongOperation("B"),
			() => Threads.LongOperation("C"),
			() => Threads.LongOperation("D"),
			() => Threads.LongOperation("E"));
			stopwatch.Stop();
			Console.WriteLine(" Parallel long operation calls finished {0} sec.",
				stopwatch.Elapsed.TotalSeconds);


			Console.ReadKey();
			*/
			/*
			object objectUsedForLock = new object();
			int counter = 0;
			Parallel.For(0, 100000, (i) =>
			{
				Thread.Sleep(1);
				lock (objectUsedForLock)
				{
					counter += 1;
				}
			}) ;
			Console.WriteLine(" Counter should be 100000. Counter is {0}", counter);

			Console.ReadKey();
			*/

			/*
			List<int> results = new List<int>();
			Parallel.For(0, 100000, (i) =>
			{
				Thread.Sleep(1);
				results.Add(i * i);
			}) ;
			Console.WriteLine("Bag length should be 100000. Length is {0}",
				results.Count);
			*/
			/*
			ConcurrentBag<int> iterations = new ConcurrentBag<int>();
			Parallel.For(0, 100000, (i) =>
			{
				Thread.Sleep(1);
				iterations.Add(i);
			}) ;
			Console.WriteLine("Bag length should be 100000. Length is {0}",
				iterations.Count);
			*/

		}
		
	}
}