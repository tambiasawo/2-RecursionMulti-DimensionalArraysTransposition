using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    /// <summary>
    /// This class is used for solving a char array maze.
    /// You might want to add other methods to help you out.
    /// A print maze method would be very useful, and probably neccessary to print the solution.
    /// If you are real ambitious, you could make a seperate class to handle that.
    /// </summary>
    class MazeSolver
    {
        /// <summary>
        /// Class level memeber variable for the mazesolver class
        /// </summary>
        
        //Established a class level boolean to work in conjunction with the recursive loop.
        //Established class level Integers to set the maximum array values.
        char[,] maze;
        int xStart;
        int yStart;
        Boolean MazeSolved;
        Int32 maxY;
        Int32 maxX;

        /// <summary>
        /// Default Constuctor to setup a new maze solver.
        /// </summary>
        public MazeSolver()
        { }


        /// <summary>
        /// This is the public method that will allow someone to use this class to solve the maze.
        /// Feel free to change the return type, or add more parameters if you like, but it can be done
        /// exactly as it is here without adding anything other than code in the body.
        /// </summary>
        public void SolveMaze(char[,] maze, int xStart, int yStart)
        {
            //Assign passed in variables to the class level ones. It was not done in the constuctor so that
            //a new maze could be passed in to this solve method without having to create a new instance.
            //The variables are assigned so they can be used anywhere they are needed within this class.
            //It is possible that you will not need these class level ones and can get all of the work done
            //with the local ones. Regardless of how you implement it, here are the class level assignments.
            //Feel free to remove the class level variables and assignments if you determine that you don't need them.
            this.maze = maze;
            this.xStart = xStart;
            this.yStart = yStart;

            //Simplified variables.
            //Obtained the length and height of the 2d array that has been passed.
            //Set the maximum array lenght and height values.
            //Set the MazeSolved boolean to false to allow the recursive call to continue until it becomes true.
            Int32 x = xStart;
            Int32 y = yStart;
            Int32 rowLength = maze.GetLength(0);
            Int32 colLength = maze.GetLength(1);
            maxY = rowLength - 1;
            maxX = colLength - 1;
            MazeSolved = false;


            //Verifies that the start location is within the 2d array limits and begins the recursive call.
            //Otherwise it displays an error message stating that the 2d array has not been properly loaded or the start coordinates
            //are outside the 2d array limits.
            if (yStart <= maxY && yStart >= 0 && xStart <= maxX && xStart >= 0 && maze[y, x] == '.')
            {
                mazeTraversal(maze, y, x);

            }
            else
            {
                UserInterface.MazeError();
            }
            
            //Do work needed to use mazeTraversal recursive call and solve the maze.
        }


        /// <summary>
        /// This should be the recursive method that gets called to solve the maze.
        /// Feel free to change the return type if you like, or pass in parameters that you might need.
        /// This is only a very small starting point.
        /// </summary>
         
        //The recursive call that will only exit if the current location is on an outside wall of the maze.
        //It will continue to call itself until this condition has been meet or there is a stack overflow.
        private void mazeTraversal(char[,] maze, Int32 y, Int32 x)
        {
            //Implement maze traversal recursive call
            //Test to see if the current location is on an outside wall.
            //If so, place an "X" in that location and change the MazeSoved boolean which will stop the recursive call.
            if (y + 1 > maxY || y - 1 < 0 || x + 1 > maxX || x - 1 < 0)
            {
                maze[y, x] = 'X';
                MazeSolved = true;
            }
            //If the current location is not on an outside wall, then the maze must not be solved.
            //Continue the recursive call.
            //Once the MazeSolve boolen becomes true, the recursive call will end.
            if (!MazeSolved)
            {
                //If any location around the current location is a valid move, continue the recursive call.
                if (maze[y + 1, x] == '.' || maze[y, x + 1] == '.' || maze[y - 1, x] == '.' || maze[y, x - 1] == '.')
                {
                    //Place an "X" in the location of every valid move.
                    maze[y, x] = 'X';

                    //Down
                    //Test if there is a valid move in the location below of the current location.
                    //If this leads to a dead-end, place O's on the path that lead you there.
                    if (maze[y + 1, x] == '.')
                    {
                         mazeTraversal(maze, y + 1, x);
                        if (!MazeSolved)
                        {
                            maze[y +1, x] = 'O';
                        }

                    }
                    //Right
                    //Test if there is a valid move in the location to the right of the current location.
                    //If this leads to a dead-end, place O's on the path that lead you there.
                    if (maze[y, x + 1] == '.')
                    {
                        mazeTraversal(maze, y, x + 1);
                        if (!MazeSolved)
                        {
                            maze[y, x + 1] = 'O';
                        }
                    }
                    //Up
                    //Test if there is a valid move in the location above of the current location.
                    //If this leads to a dead-end, place O's on the path that lead you there.
                    if (maze[y - 1, x] == '.')
                    {
                        mazeTraversal(maze, y - 1, x);
                        if (!MazeSolved)
                        {
                            maze[y - 1, x] = 'O';
                        }
                    }
                    //Left
                    //Test if there is a valid move in the location to the left of the current location.
                    //If this leads to a dead-end, place O's on the path that lead you there.
                    if (maze[y, x - 1] == '.')
                    {
                        mazeTraversal(maze, y, x - 1);
                        if (!MazeSolved)
                        {
                            maze[y, x - 1] = 'O';
                        }
                    }
                }
            }
        }
    }
}