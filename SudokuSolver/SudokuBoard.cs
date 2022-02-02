using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class SudokuBoard
    {
        private readonly int amount;     // amount of cells in a row/column/box
        private int[,] board;            // sudoku board
        private long[] rows_values;      // bit representation of the values in each row
        private long[] cols_values;      // bit representation of the values in each column
        private long[] boxes_values;     // bit representation of the values in each box
        private long[] options;          // bit representation of the optional values in each cell
        //private static Stack<int> cells_changed; //Keeps track of the cells that were changed in the board during the backtracking. It keeps the placement of the cell in the board.
        private Stack<int> cells_changed; //Keeps track of the cells that were changed in the board during the backtracking. It keeps the placement of the cell in the board.


        //// Initialize stack
        //static SudokuBoard()
        //{
        //    cells_changed = new Stack<int>();
        //}

        public int[,] Board
        {
            get => board;
            set
            {
                board = value;
            }
        }

        public int Amount
        {
            get => amount;
        }

        public long[] Rows_values
        {
            get => rows_values;
            set
            {
                rows_values = value;
            }
        }

        public long[] Cols_values
        {
            get => cols_values;
            set
            {
                cols_values = value;
            }
        }

        public long[] Boxes_values
        {
            get => boxes_values;
            set
            {
                boxes_values = value;
            }
        }

        public long[] Options
        {
            get => options;
            set
            {
                options = value;
            }
        }

        public SudokuBoard(int amount)
        {
            this.amount = amount;
            board = new int[amount, amount];
            rows_values = new long[amount];
            cols_values = new long[amount];
            boxes_values = new long[amount];
            options = new long[amount];
            cells_changed = new Stack<int>();
        }


        // Fill board with integer representation of chars from given string
        public void fillBoard(String values)
        {
            for (int row = 0; row < amount; row++)
            {
                for (int col = 0; col < amount; col++)
                {
                    board[row, col] = ctoi(values[row * amount + col]);
                }
            }
        }


        public int getCell(int row, int col)
        {
            return board[row, col];
        }
        public void setCell(int row, int col, int value)
        {
            board[row, col] = value;
        }

        // Convert char to integer
        private int ctoi(Char c)
        {
            return (int)(c - '0');
        }

        // Returns the number of the box the cell resides in
        // box numbers: 0 to amount - 1
        public int CurrentBoxPosition(int row, int col)
        {
            int sqrt_amount = (int)Math.Sqrt(amount);

            return ((int)row / sqrt_amount) * sqrt_amount + ((int)col / sqrt_amount);
        }

        // Returns the cell at the upper left corner of the box.
        public (int row, int col) CellZeroOfBox(int row, int col)
        {
            (int row, int col) upper_left_cell;
            int box = CurrentBoxPosition(row, col);
            int sqrt_amount = (int)Math.Sqrt(amount);

            upper_left_cell.row = row / sqrt_amount * sqrt_amount;
            upper_left_cell.col = col / sqrt_amount * sqrt_amount;

            return upper_left_cell;
        }

        // Returns whether all placements of possible values in board are filled in long
        public bool isFull(long num)
        {
            if (Logic.BitHandler.CountSetBits(num) == amount)
                return true;
            return false;
        }
    }
}
