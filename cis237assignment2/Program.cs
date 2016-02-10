///Programmer:  Ryan Gowan
///Date:        2/9/2016
///POV:         What are you suppossed to learn from this project.
///                 Console app, if/else statements, 
///                 Recursion, Multi-Dimensional Arrays, and Transposition.
///             Populate an original 2D array, transpose it, and solve both mazes
///             using the same recursion call.
///             Display the results of both mazes.
///               
///BOV:         Purpose of this project, if any.
///                 The ability to solve a maze using recursion.
///                 The ability to populate a multi-dimensional array.
///                 The ability to transpose a multi-dimensional array.
///                 The ability to display information within the console terminal.

//  This project shows Documentation comments, above.
/*  Notes:
 *  ???/100
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    class Program
    {
        /// <summary>
        /// This is the main entry point for the program.
        /// You are free to add anything else you would like to this program,
        /// however the maze solving part needs to occur in the MazeSolver class.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            /// <summary>
            /// Starting Coordinates.
            /// </summary>
            const int X_START = 1;
            const int Y_START = 1;

            ///<summary>
            /// The first maze that needs to be solved.
            /// Note: You may want to make a smaller version to test and debug with.
            /// You don't have to, but it might make your life easier.
            /// </summary>
            char[,] maze1 = 
            { { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
            { '#', '.', '.', '.', '#', '.', '.', '.', '.', '.', '.', '#' },
            { '#', '.', '#', '.', '#', '.', '#', '#', '#', '#', '.', '#' },
            { '#', '#', '#', '.', '#', '.', '.', '.', '.', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '#', '#', '#', '.', '#', '.', '#' },
            { '#', '#', '#', '#', '.', '#', '.', '#', '.', '#', '.', '.' },
            { '#', '.', '.', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
            { '#', '#', '.', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '.', '.', '.', '.', '#', '.', '#' },
            { '#', '#', '#', '#', '#', '#', '.', '#', '#', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '.', '.', '#', '.', '.', '.', '#' },
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' } };

            
            //Create the second maze by transposing the first maze
            char[,] maze2 = transposeMaze(maze1);

            // Create a new instance of a mazeSolver.
            // Create a new instance of a ui.
            MazeSolver mazeSolver = new MazeSolver();
            UserInterface ui = new UserInterface();

            //Displays a message stating that this is the original unsolved maze.
            //Then displays the unsolved maze.
            UserInterface.OriginalMessage(maze1);
            
            
            // Tell the instance to solve the first maze with the passed maze, and start coordinates.
            //Starts the maze solving process by passing the original maze and the start coordinates
            //into the process.
            mazeSolver.SolveMaze(maze1, X_START, Y_START);

            //Displays a message stating that this is the solved original maze.
            //Then displays the solved maze.
            UserInterface.OriginalSolved(maze1);

            //Displays a message stating that this is the transposed unsolved maze.
            //Then displays the unsolved maze.
            UserInterface.TransposedMessage(maze2);

            //Solve the transposed maze.
            //Starts the maze solving process by passing the transposed maze and the start coordinates
            //into the process.
            mazeSolver.SolveMaze(maze2, X_START, Y_START);

            //Displays a message stating that this is the solved transposed maze.
            //Then displays the solved maze.
            UserInterface.TransposedSolved(maze2);

            //Pauses the program so the user can see the results.
            UserInterface.Pause();
        }

        /// <summary>
        /// This method will take in a 2 dimensional char array and return
        /// a char array maze that is flipped along the diagonal, or in mathematical
        /// terms, transposed.
        /// ie. if the array looks like 1, 2, 3
        ///                             4, 5, 6
        ///                             7, 8, 9
        /// The returned result will be:
        ///                             1, 4, 7
        ///                             2, 5, 8
        ///                             3, 6, 9
        /// The current return statement is just a placeholder so the program
        /// doesn't complain about no return value.
        /// </summary>
        /// <param name="mazeToTranspose"></param>
        /// <returns>transposedMaze</returns>
         
        //This process transposes the maze essentially swaping the x,y coordinate location.
        //Ex. coordinate [0,1] becomes [1,0].
        static char[,] transposeMaze(char[,] mazeToTranspose)
        {
            //Write code her to create a transposed maze.
            //Establishes the length and height of the 2d array that has been passed.
            //Creates a new array with the length and height swapped.
            //Populates the new 2d array with the transposed information.
            Int32 rowLength = mazeToTranspose.GetLength(0);
            Int32 colLength = mazeToTranspose.GetLength(1);
            char[,] transposedMaze = new char[colLength, rowLength];


            for (Int32 y = 0; y < colLength; y++)
            {
                for (Int32 x = 0; x < rowLength; x++)
                {
                    transposedMaze[y, x] = mazeToTranspose[x, y];
                }
            }
            return transposedMaze;
        }
    }
}
