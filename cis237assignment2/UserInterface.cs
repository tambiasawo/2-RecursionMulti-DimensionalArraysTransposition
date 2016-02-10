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

        //Establishes the length and height of the 2d array.
        //Displays the maze that has been passed.
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
            Console.WriteLine(Environment.NewLine);
        }

        //Displays an error message stating that the 2d array has not been properly loaded or the start coordinates
        //are outside the 2d array limits.
        public static void MazeError()
        {
            Console.WriteLine("Your maze was not loaded successfully or the start coordinates are outside the array range.");
        }

        //Displays a message telling the user that this is the original maze and then displays the maze.
        public static void OriginalMessage(char[,] maze)
        {
            Console.WriteLine("Original Maze");
            PrintMaze(maze);
        }

        //Displays a message telling the user that this is the solved original maze and then displays the maze.
        public static void OriginalSolved(char[,] maze)
        {
            Console.WriteLine("Original Maze - Solved");
            PrintMaze(maze);
        }

        //Displays a message telling the user that this is the transposed maze and then displays the maze.
        public static void TransposedMessage(char[,] maze)
        {
            Console.WriteLine("Transposed Maze");
            PrintMaze(maze);
        }

        //Displays a message telling the user that this is the solved transposed maze and then displays the maze.
        public static void TransposedSolved(char[,] maze)
        {
            Console.WriteLine("Transposed Maze - Solved");
            PrintMaze(maze);
        }

        //Stops the program so the user can view the results of the program.
        //Allows the program to finish once the user presses a key.
        public static void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
