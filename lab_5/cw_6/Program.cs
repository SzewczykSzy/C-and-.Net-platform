using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw_6
{
    internal class Program
    {
        public class Stack {

            public List<int> items;
            public Stack() 
            { 
                items = new List<int>();
            }

            public void AddItem(int item) 
            {
                items.Add(item);
            }
            public void DeleteItem() 
            {
                if (items.Count > 0)
                {
                    items.RemoveAt(0);
                }
            }

            public int ShowTheNumberOfItems() 
            {
                return items.Count;
            }

            public int ShowMinItem() {
                return items.Min();
            }

            public int ShowMaxItem() {
                return items.Max();
            }

            public int FindAnItem(int item) {
                int index = items.IndexOf(item);
                return index >= 0 ? index + 1 : -1;
            }

            public void PrintAllItems() 
            {
                foreach (var item in items)
                {
                    Console.Write(item + " ");
                }
            }

            public void ClearAll() 
            { 
                items.Clear();
            }
        }
        static void AddEvenItemsToStack(Stack sourceStack, ref Stack stack_3)
        {
            for (int i = 0; i < sourceStack.ShowTheNumberOfItems(); i++)
            {
                int item = sourceStack.items[i];
                if (stack_3.FindAnItem(item) == -1 && item%2 == 0)
                {
                    stack_3.AddItem(item);
                }
            }
        }
        static void Main(string[] args)
        {
            Stack stack_1 = new Stack();
            Stack stack_2 = new Stack();
            Random random = new Random();

            for (int i = 0; i < 100; i++)
            {
                stack_1.AddItem(random.Next(1, 100));
                stack_2.AddItem(random.Next(1, 100));
            }

            Stack stack_3 = new Stack();
            AddEvenItemsToStack(stack_1, ref stack_3);
            AddEvenItemsToStack(stack_2, ref stack_3);

            Console.WriteLine("\nStack 1 (100 losowych wartości):");
            stack_1.PrintAllItems();

            Console.WriteLine("\nStack 2 (100 losowych wartości):");
            stack_2.PrintAllItems();

            Console.WriteLine("\nStack 3 (parzyste wartości bez powtórzeń):");
            stack_3.PrintAllItems();

            Console.ReadLine();
        }
    }
}
