using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLiveCommandLine
{
    class Engine
    {
        private Platform platform;
        private int?[,] cells;
        private List<CellStruct> changes = new List<CellStruct>();

        public Engine(Platform pl)
        {
            platform = pl;
        }

        static void Main(string[] args)
        {
            Console.Out.WriteLine("hejsa");
            //Platform platform = new Platform(int.Parse(args[0]), int.Parse(args[1]));
            Platform platform = new Platform(10, 10);
            Engine engine = new Engine(platform);
        }

        private void RunCycle()
        {
            cells = platform.GetCells();

            for (int x = 0; x < cells.GetLength(0); x++)
            {

                for (int y = 0; y < cells.GetLength(1); y++)
                {
                    UpdateCell(x, y);
                }
            }

            platform.ChangeCells(changes.ToArray());

        }

        private void UpdateCell(int x, int y)
        {
            int[] data = GetSurroundingCells(x, y);

            switch (cells[x, y])
            {
                //dead cell
                case 0:
                    {
                        if (data[1] >= 3)
                        {
                            changes.Add(new CellStruct(x, y, 1));
                            return;
                        }
                    } break;

                //living cell
                case 1:
                    {
                        if (data[0] <= 1 || data[0] >= 4)
                        {
                            changes.Add(new CellStruct(x, y, 0));
                            return;
                        }
                        for (int i = 0; i < data[2]; i++)
                        {
                            Random random = new Random();
                            if (random.NextDouble() < 0.5)
                                changes.Add(new CellStruct(x, y, null));
                        }
                    } break;

                //zombie cell - nothing happends
                default: return;
            }

        }


        /// <summary>
        /// detects the states of a given positions surrounding cells 
        /// </summary>
        /// <param name="x">position x of the cell</param>
        /// <param name="y">position y of the cell</param>
        /// <returns>number of dead, alive and zombie cells</returns>
        private int[] GetSurroundingCells(int x, int y)
        {
            int alive = 0, dead = 0, zombie = 0;

            for (int i = x - 1; i <= x + 1; i++)
            {
                if (i < 0 || i > cells.GetLength(0)) continue;

                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (j < 0 || j > cells.GetLength(1)) continue;
                    if (i == x && j == y) continue;

                    if (cells[x, y] == 0) dead++;
                    if (cells[x, y] == 1) alive++;
                    if (cells[x, y] == null) zombie++;
                }
            }

            int[] surCells = { dead, alive, zombie };
            return surCells;
        }
    }
}
