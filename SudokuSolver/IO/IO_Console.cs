using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.IO
{
    class IO_Console : IO.IRead, IO.IWrite
    {

        public string Read()
        {
            string line, input = "";
            Console.Write("Enter board string: ");
            while ((line = Console.ReadLine()) != null)
            {
                input += line;
            }
            return input;
        }

        public void Write(String outputString)
        {
            Console.WriteLine(outputString);
        }
    }
}
