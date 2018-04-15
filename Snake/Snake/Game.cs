using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake.Interfaces;

namespace Snake
{
    public class Game
    {
        // this holds all of the console input
        private IInputProvider inputProvider;
        //this shows everything from the console output
        private IOutputProvider outputProvider;
        // this holds the snake instance
        private ISnake snake;
        //this holds the board
        private IBoard board;

        // default constructor
        public Game() : this(
                new InputProvider(),
                new ConsoleOutputProvider(),
                new Snake(),
                new Board() )
        {
        }

        //this is for testing
        public Game(
                IInputProvider inputProvider,
                IOutputProvider outputProvider,
                ISnake snake,
                IBoard board
            )
        {
            this.inputProvider = inputProvider;
            this.outputProvider = outputProvider;
            this.snake = snake != null ? snake : null;
            this.board = board;
        }


        public Direction SnakeDirection;
        bool IsGameOver { get; set; }
        bool DidHitWall { get; set; }
        Dictionary<string,bool> Eaten { get; set; }
        int GameSpeed { get; set;  }
            // find the default color of the board
        public ConsoleColor dftForeColor = Console.ForegroundColor;
        public ConsoleColor dftBackColor = Console.BackgroundColor;

 

        public void StartGame(Snake snake, Board board)
        {
            // set the snake in the middle of the board
            snake.XPosition = board.Boardwidth / 2;
            snake.YPosition = board.Boardheight / 2;

            CustomizeSnake();

            // set defaults
            //game is in play, no history of moves, snake length is 1 and game speed is 75
            IsGameOver = false;
            DidHitWall = false;
            Eaten = new Dictionary<string, bool>();
            int GameSpeed = 75;
            snake.Length = 1;

            //do not show the cursor and initialize a variable for key input
            Console.CursorVisible = false;
            ConsoleKeyInfo command;

            while (!IsGameOver)
            {
                
                // clear the console, set the title bar, and draw the board
                outputProvider.Clear();
                outputProvider.CreateTitle(Message.Instructions);
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
                    outputProvider.CreateTitle(Message.Score + snake.Length.ToString());

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
                    outputProvider.CreateTitle(Message.You_Died + snake.Length.ToString());
                    SetConsoleToDefault();
                    outputProvider.WriteLine(Message.SkullArt);
                    JustWait();
                    IsGameOver = true;
                }
            }
            if (IsGameOver)
            {
                SetConsoleToDefault();
                outputProvider.CreateTitle(Message.Youre_Done + snake.Length.ToString());
                outputProvider.Write(Message.SnakeArt);
                JustWait();
            }
        }

        // customize snake from input provider 
        private void CustomizeSnake()
        {
            // Ask the user to enter a character to use as the snake
            outputProvider.WriteLine(Message.Make_A_Character);
            string snakeHead = inputProvider.Read();
            Snake snake = new Snake(snakeHead);
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

        public void JustWait()
        {
            System.Threading.Thread.Sleep(2000);
        }

        public void SetConsoleToDefault()
        {
            outputProvider.SetForegroundColor(dftForeColor);
            outputProvider.SetBackgroundColor(dftBackColor);
            outputProvider.Clear();
            outputProvider.SetCursorPosition(0, 0);
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
