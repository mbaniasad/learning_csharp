using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ProgramStructure
{
    class GetText
    {
        public void PrintText()
        {
            String input = "";
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Please enter your Text");
                input = Console.ReadLine();
                if (String.IsNullOrEmpty(input))
                {
                    input = "Input is Empty";
                    Console.WriteLine(input);
                    break;
                }
                Console.WriteLine(input);
            }
            Console.ReadLine();
        }
    }
}
