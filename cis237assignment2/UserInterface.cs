using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    class UserInterface
    {
        // Default Constuctor to setup a new user Interface.
        public UserInterface()
            {}

        public static void PrintMaze(char[,] maze)
        {
            Int32 rowLength = maze.GetLength(0);
            Int32 colLength = maze.GetLength(1);

            for (Int32 y = 0; y < rowLength; y++)
            {
                for (Int32 x = 0; x < colLength; x++)
                {
                    Console.Write(String.Format("{0} ", maze[y, x]));
                }
                Console.Write(Environment.NewLine);
            }
            //Console.ReadLine(); Used to pause the program for testing.
            Console.WriteLine(Environment.NewLine);
        }

        public static void OriginalMessage(char[,] maze)
        {
            Console.WriteLine("Original Maze");
            PrintMaze(maze);
        }

        public static void OriginalSolved(char[,] maze)
        {
            Console.WriteLine("Original Maze - Solved");
            PrintMaze(maze);
        }

        public static void TransposedMessage(char[,] maze)
        {
            Console.WriteLine("Transposed Maze");
            PrintMaze(maze);
        }

        public static void TransposedSolved(char[,] maze)
        {
            Console.WriteLine("Transposed Maze - Solved");
            PrintMaze(maze);
        }
    }
}
