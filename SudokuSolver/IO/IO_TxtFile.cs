using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuSolver.IO
{
    class IO_txtFile : IO.IRead, IO.IWrite
    {

        public string Read()
        {
            string path = Get_path();
            string values = System.IO.File.ReadAllText(path);
            return values;
        }

        // Function receives path of file from file explorer
        public string Get_path()
        {
            OpenFileDialog pick_file = new OpenFileDialog();
            if (pick_file.ShowDialog() == DialogResult.OK)
                return pick_file.FileName;
            return "No Path";
        }


        public void Write(String outputString)
        {

        }

    }
}
