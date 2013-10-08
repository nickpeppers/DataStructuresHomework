using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework3
{
    class InfixToPostfix
    {
        public static string ConvertToPostFix(string inFix)
        {
            StringBuilder postFix = new StringBuilder();

            char incomingCharacter;

            // Creates a new Stack
            Stack<char> stack = new Stack<char>();

            // Iterates characters in inFix
            foreach (char character in inFix.ToCharArray())
            {
                // Checks if character is a number
                if (Char.IsNumber(character))
                {
                    postFix.Append(character);
                }
                // Checks if parantheses
                else if (character == '(')
                {
                    stack.Push(character);
                }
                // Removes all previous elements from Stack and puts them in front
                else if (character == ')')
                {
                    incomingCharacter = stack.Pop();
                    while (incomingCharacter != '(')
                    {
                        postFix.Append(incomingCharacter);
                        incomingCharacter = stack.Pop();
                    }
                }
                else
                {
                    // If and operator is found looks at the top of the stack
                    if (stack.Count != 0 && Predecessor(stack.Peek(), character))
                    {
                        incomingCharacter = stack.Pop();
                        // checks for while there are still incoming characters to be read
                        while (Predecessor(incomingCharacter, character))
                        {
                            postFix.Append(incomingCharacter);

                            // exits if there is nothing left in the stack
                            if (stack.Count == 0)
                            {
                                break;
                            }
                            incomingCharacter = stack.Pop();
                        }
                        stack.Push(character);
                    }
                    else
                    {
                        //If Stack is empty or the operator has precedence
                        stack.Push(character);
                    }
                }
            }
            while (stack.Count > 0)
            {
                incomingCharacter = stack.Pop();
                postFix.Append(incomingCharacter);
            }
            return postFix.ToString();
        }

        // compares the two operators and decides which has precedence
        private static bool Predecessor(char firstOperator, char secondOperator)
        {
            string operatorString = "(+-*/%";

            int primary, secondary;

            // "(" has less precedence
            int[] precedence = { 0, 12, 12, 13, 13, 13 };

            primary = operatorString.IndexOf(firstOperator);
            secondary = operatorString.IndexOf(secondOperator);

            // returns true if primary has greater precendence than secondary else returns false
            return (precedence[primary] >= precedence[secondary]) ? true : false;
        }
    }
}
