using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuSolver.IO
{
    class IO_txtFile : IO.IRead, IO.IWrite
    {
        private string filePath;

        public string Read()
        {
            Get_Path();
            if (!filePath.Contains(".txt"))
                throw new Exceptions.InvalidInputException("Invalid file type was given.\nOnly .txt can be read.");
            string values = System.IO.File.ReadAllText(filePath);
            return values;
        }

        // Function receives path of file from file explorer
        private void Get_Path()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
            }
            else
            {
                Console.WriteLine("Don't Get path");
                filePath = "No Path";
            }
        }


        public void Write(String outputString)
        {
            SolvedFileName();
            File.WriteAllText(filePath, outputString);
        }

        private void SolvedFileName()
        {
            filePath = filePath.Replace(".txt", "Solved.txt");
        }


    }
}
