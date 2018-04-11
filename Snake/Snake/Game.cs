using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Game
    {
        public Direction SnakeDirection;
        bool IsGameOver { get; set; }
        bool DidHitWall { get; set; }
        Dictionary<string,bool> Eaten { get; set; }
        int GameSpeed { get; }

        public Game(Snake snake, Board board)
        {
            // set the snake in the middle of the board
            snake.XPosition = board.Boardwidth / 2;
            snake.YPosition = board.Boardheight / 2;

            // set defaults
            //game is in play, no history of moves, snake length is 1 and game speed is 75
            IsGameOver = false;
            DidHitWall = false;
            Eaten = new Dictionary<string, bool>();
            GameSpeed = 75;
            snake.Length = 1;

            //do not show the cursor and initialize a variable for key input
            Console.CursorVisible = false;
            ConsoleKeyInfo command;

            while (!IsGameOver)
            {
                // Ask the user to enter a character to use as the snake
                Console.WriteLine("Hey, write a character to use as a snake");
                snake.SnakeHead = Console.ReadLine();
                // clear the console, set the title bar, and draw the board
                Console.Clear();
                Console.Title = "Use 'a', 's','d', and 'w' to steer. ";
                board.DrawBoard();


                //clear move history, and add current position, then draw the snake
                Eaten.Clear();
                Eaten.Add(snake.XPosition.ToString() + snake.YPosition.ToString(), true);
                snake.DrawSnake();

                //wait for the player to move 
                WaitForMove();

                //set the speed by checking for keystrokes at the gamespeed in miliseconds
                DateTime nextCheck = DateTime.Now.AddMilliseconds(GameSpeed);

                while(!IsGameOver && !DidHitWall)
                {
                    //Display the length at the top of the screen 
                    Console.Title = "Score: " + snake.Length.ToString();

                    //wait for the next time you can check for keys 
                    while(nextCheck > DateTime.Now)
                    {
                        // see if the player has changed direction
                        if (Console.KeyAvailable)
                        {
                            //read the key and map it to a direction 
                            command = Console.ReadKey(true);
                            MapCommandToDirection(command);
                        }
                    }

                    if (!IsGameOver)
                    {
                        ChangeDirection(snake,board);
                        
                        if (!DidHitWall)
                        {
                            //format the current positions to two rounded digits 
                            string positions = snake.XPosition.ToString("00") + snake.YPosition.ToString("00");
                            //if the snake hasn't been to the current positions, add the length and keep going
                            if (!Eaten.ContainsKey(positions))
                            {
                                snake.Length++;
                                Eaten.Add(positions, true);
                                snake.DrawSnake();
                            }
                            //otherwise say they hit the wall
                            else
                            {
                                DidHitWall = true;
                            }
                        }

                        nextCheck = DateTime.Now.AddMilliseconds(GameSpeed);
                    }


                }

                if (DidHitWall)
                {
                    Console.Title = "YOU DIED! Score: " + snake.Length.ToString();
                    WaitForMove();
                }
            }
        }

        // wait for player to enter a key
        public void WaitForMove()
        {
            // stall the thread until the player enters a key
            while (!Console.KeyAvailable)
            {
                System.Threading.Thread.Sleep(10);
            }
        }


        // map the key command to the direction 
        public void MapCommandToDirection(ConsoleKeyInfo command)
        {
            switch (command.KeyChar)
            {
                case 'w':
                    SnakeDirection = Direction.Up;
                    break;
                case 's':
                    SnakeDirection = Direction.Down;
                    break;
                case 'a':
                    SnakeDirection = Direction.Left;
                    break;
                case 'd':
                    SnakeDirection = Direction.Right;
                    break;
                case 'q':
                    IsGameOver = true;
                    break;
            }
        }

        //Change the coordinates of the Snake and check if it hit the wall 
        public void ChangeDirection(Snake snake, Board board)
        {
            switch (SnakeDirection)
            {
                case Direction.Up:
                    if (snake.YPosition > 1)
                    {
                        snake.YPosition--;
                    }
                    else
                    {
                        DidHitWall = true;
                    }
                    break;
                case Direction.Down:
                    if (snake.YPosition < board.Boardheight - 3)
                    {
                        snake.YPosition++;
                    }
                    else
                    {
                        DidHitWall = true;
                    }
                    break;
                case Direction.Left:
                    if (snake.XPosition > 1)
                    {
                        snake.XPosition--;
                    }
                    else
                    {
                        DidHitWall = true;
                    }
                    break;
                case Direction.Right:
                    if (snake.XPosition < board.Boardwidth - 2)
                    {
                        snake.XPosition++;
                    }
                    else
                    {
                        DidHitWall = true;
                    }
                    break;
            }
        }
       
    }
}
