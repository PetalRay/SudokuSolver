using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.IO
{
    class IO_Manager
    {
        private IRead reader;
        private IWrite writer;

        public IO_Manager() { }

        public string ReadInput()
        {

            string IO_method;

            Console.WriteLine("Please enter how you'd like to provide the contents of the sudoku table.\nPress:\nC - for console\nT - for txt file from");
            IO_method = Console.ReadLine();

            if (IO_method.Length > 1 || !Char.IsLetter(IO_method[0]))
                throw new Exceptions.InvalidInputException("Invalid request was entered");
            if (IO_method.Equals("C"))
            {
                reader = new IO.IO_Console();
                writer = (IWrite)(reader);
            }
            else if (IO_method.Equals("T"))
            {
                reader = new IO.IO_txtFile();
                writer = (IWrite)(reader);
            }
            else
                throw new Exceptions.InvalidInputException("Invalid request was entered. Only T or C ");

            return reader.Read();
        }

        public void WriteSolution(string solution)
        {
            writer.Write(solution);
        }
    }
}
