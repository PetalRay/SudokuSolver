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
            Console.Write("Enter board string: ");
            return Console.ReadLine();
        }

        public void Write(String outputString)
        {
            Console.WriteLine(outputString);
        }
    }
}
