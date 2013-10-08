using System;
using System.Collections.Generic;

namespace Homework3
{
	class MainClass
	{
		public static void Main (string[] args)
		{
            // Creation of linked listed
            LinkedList<string> lList = new LinkedList<string>();
            lList.AddFirst("hello");
            lList.AddLast("world");
            lList.AddLast("last");
            lList.AddFirst("first");

            // Creation of linked listed used to demonstrate circular
            LinkedList<string> circularLList = new LinkedList<string>();
            circularLList.AddFirst("two");
            circularLList.AddLast("three");
            circularLList.AddLast("four");
            circularLList.AddFirst("one");

            foreach (var node in lList)
            {
                Console.WriteLine(node);
            }

            Console.WriteLine();

            CheckForCircularList(lList, false);
            CheckForCircularList(circularLList, true);

            PrintInReverse(lList);

            Console.WriteLine();

            LongCheckForCircularList(lList, false);
            LongCheckForCircularList(circularLList, true);

            Console.WriteLine();

            Console.WriteLine(InfixToPostfix.ConvertToPostFix("1+2-1*8+2*3+1"));
            Console.WriteLine(InfixToPostfix.ConvertToPostFix("2+4*7+(3*4)"));
            Console.WriteLine(InfixToPostfix.ConvertToPostFix("6+2-8*9"));

            Console.ReadLine();
		}

        // Check for Circular list with runtime O(1) extra space
		public static void CheckForCircularList (LinkedList<string> linkedList, bool simulateIfCircular)
		{
            // simulateIfCircular basically is used to tell my list to act like a circular one
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

        // Check for Circualar list with runtime O(N)
        public static void LongCheckForCircularList(LinkedList<string> linkedList, bool simulateIfCircular )
        {
            // simulateIfCircular basically is used to tell my list to act like a circular one
            var node = linkedList.First;
            if (!simulateIfCircular)
            {
                for (int i = 0; i < linkedList.Count; i++)
                {
                    if (node.Next == null)
                    {
                        Console.WriteLine("List is not a cycle");
                    }
                    else if (node.Next != null & i != linkedList.Count - 1)
                    {
                        node = node.Next;
                    }
                    else
                    {
                        Console.WriteLine("List is a cycle");
                    }
                }
            }
            else
            {
                for (int i = 0; i < linkedList.Count; i++)
                {
                    if (node.Next == null)
                    {
                        Console.WriteLine("List is not a cycle");
                    }
                    else if (node.Next != null & i != linkedList.Count - 1)
                    {
                        node = CircularLinkedList.NextOrFirst(node.Next);
                    }
                    else
                    {
                        Console.WriteLine("List is a cycle");
                    }
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
