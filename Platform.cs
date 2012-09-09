using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLiveCommandLine
{
    /// <summary>
    /// contains all the states of the cells and print out the game of life in the console 
    /// </summary>
    class Platform
    {
        private readonly int cols, rows;
        private int?[,] cells;

        public Platform(int x, int y)
        {
            cols = x;
            rows = y;
            CreatePlatform();
            print();
        }

        /// <summary>
        /// initialize all cells to 0 (dead)
        /// </summary>
        private void CreatePlatform()
        {
            cells = new int?[cols,rows]; 
            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    cells[x,y] = 0;
                }
            }
        }

        /// <summary>
        /// returns the state of all cells 
        /// </summary>
        /// <returns>a 2-dimensional array of int?</returns>
        public int?[,] GetCells()
        {
            return cells;
        }

        /// <summary>
        /// changes the state of cells in the list. 
        /// </summary>
        /// <param name="changes">a list containing information about the cells to change</param>
        public void ChangeCells(params CellStruct[] changes)
        {
            for (int i = 0; i<changes.Length; i++)
            {
                CellStruct change = changes[i];
                cells[change.GetX(), change.GetY()] = change.GetState();
            }
        }

        /// <summary>
        /// prints the state of all the cells
        /// </summary>
        public void print()
        {
            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    switch(cells[x,y]){
                        case 1: Console.Out.Write("¤"); break;
                        case null: Console.Out.Write("#"); break;
                        default: Console.Out.Write("-"); break;
                    };
                }
                Console.Out.Write("\n");
            }
            Console.ReadKey();
        }
    }
}
