using System;
using System.Collections.Generic;

namespace Homework3
{
	// class to make a Linked List function and simulate a circular Linked List
	public static class CircularLinkedList
	{
		// method to to check if the current node has a next one if not returns the first node of LL
		public static LinkedListNode<string> NextOrFirst (this LinkedListNode<string> current)
		{
			if (current.Next == null) 
			{
				return current.List.First;
			}
			return current.Next;
		}

		// method to check if the current node has a previous one if not returns the last node of LL
		public static LinkedListNode<string> PreviousOrLast (this LinkedListNode<string> current)
		{
			if (current.Previous == null) 
			{
				return current.List.Last;
			}
			return current.Previous;
		}
	}

}
