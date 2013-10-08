using System;
using System.Collections.Generic;

namespace Homework3
{
	class MainClass
	{
		public static void Main (string[] args)
		{

			LinkedList<string> lList = new LinkedList<string> ();
			lList.AddFirst ("hello");
			lList.AddLast ("world");
			lList.AddLast ("last");
			lList.AddFirst ("first");

			LinkedList<string> circularLList = new LinkedList<string>();
			circularLList.AddFirst ("two");
			circularLList.AddLast ("three");
			circularLList.AddLast ("four");
			circularLList.AddFirst ("one");

			Console.WriteLine(CircularLinkedList.PreviousOrLast(circularLList.First));

			foreach (var node in lList) 
			{
				Console.WriteLine (node);
			}

			Console.WriteLine();

			CheckForCircularList(lList, false);
			CheckForCircularList(circularLList, true);

			PrintInReverse(lList);
		}

		public static void CheckForCircularList (LinkedList<string> linkedList, bool simulateIfCircular)
		{
			if (!simulateIfCircular) 
			{
				if (linkedList.Last.Next != null) 
				{
					Console.WriteLine ("List is a cycle");
				}
				else
				{
					Console.WriteLine ("List is not a cycle");
				}
			}
			else 
			{
				if(CircularLinkedList.NextOrFirst(linkedList.Last).Next != null)
				{
					Console.WriteLine ("List is a cycle");
				}
				else
				{
					Console.WriteLine ("List is not a cycle");
				}
			}
		}

		public static void PrintInReverse(LinkedList<string> linkedList)
		{
			// Retrieving the value of last node is an O(1) operation.
			LinkedListNode<string> lastNode = linkedList.Last;

			Console.WriteLine();

			// prints off the linked list in reverse
			Console.WriteLine(lastNode.Value);
			for (int i = 1; i < linkedList.Count; i++) 
			{
				Console.WriteLine(lastNode.Previous.Value);
				lastNode = lastNode.Previous;
			}
		}
	}
}
