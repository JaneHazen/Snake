using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Game
    {
        public enum Direction
        {
            Up,
            Down,
            Right,
            Left
        }

        
        public Game(Snake snake, Board board)
        {
            bool IsGameOver = false;
            bool DidHitWall = false;
            int GameSpeed = 75;
            snake.XPosition = board.Boardwidth / 2;
            snake.YPosition = board.Boardheight / 2;
            Direction direction = Direction.Up; 
            Console.CursorVisible = false;
            ConsoleKeyInfo command;
            Dictionary<string, bool> eaten = new Dictionary<string, bool>();

            while (!IsGameOver)
            {
                Console.Clear();
                board.DrawBoard();

                DidHitWall = false;
                direction = Direction.Up;
                eaten.Clear();
                snake.XPosition = board.Boardwidth / 2;
                snake.YPosition = board.Boardheight / 2;
                eaten.Add(snake.XPosition.ToString("00") + snake.YPosition.ToString("00"), true);

                Console.SetCursorPosition(snake.XPosition, snake.YPosition);
                snake.DrawSnake();

                while (!Console.KeyAvailable)
                {
                    System.Threading.Thread.Sleep(10);
                }

                command = Console.ReadKey(true);
                switch (command.KeyChar)
                    {
                        case 'w':
                            direction = Direction.Up; 
                            break;
                        case 's':
                            direction = Direction.Down; 
                            break;
                        case 'a':
                            direction = Direction.Left;
                            break;
                        case 'd':
                            direction = Direction.Right; 
                            break;
                    }

                DateTime nextCheck = DateTime.Now.AddMilliseconds(GameSpeed);

                while(!IsGameOver && !DidHitWall)
                {
                    while(nextCheck > DateTime.Now)
                    {
                        if (Console.KeyAvailable)
                        {
                            command = Console.ReadKey(true);
                            switch (command.KeyChar)
                            {
                                case 'w':
                                    direction = Direction.Up;
                                    break;
                                case 's':
                                    direction = Direction.Down;
                                    break;
                                case 'a':
                                    direction = Direction.Left;
                                    break;
                                case 'd':
                                    direction = Direction.Right;
                                    break;
                            }
                        }
                    }

                    if (!IsGameOver)
                    {
                        string key = "";
                        switch (direction)
                        {
                            case Direction.Up: 
                                if( snake.YPosition > 1)
                                {
                                    snake.YPosition--;
                                }
                                else
                                {
                                    DidHitWall = true; 
                                }
                                break;
                            case Direction.Down: 
                                if( snake.YPosition < board.Boardheight - 3)
                                {
                                    snake.YPosition++;
                                }
                                else
                                {
                                    DidHitWall = true;
                                }
                                break;
                            case Direction.Left:
                                if( snake.XPosition > 1)
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
                        if (!DidHitWall)
                        {
                            key = snake.XPosition.ToString("00") + snake.YPosition.ToString("00");
                            if (!eaten.ContainsKey(key))
                            {
                                snake.Length++;
                                eaten.Add(key, true);
                                Console.SetCursorPosition(snake.XPosition, snake.YPosition);
                                snake.DrawSnake();
                            }
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
                    Console.WriteLine($"Dead at {snake.Length}");
                }
            }
        }
       
    }
}
