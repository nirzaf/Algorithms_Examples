using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Grid_Based
{

    /// <summary>
    /// NOTICE; (0,0) is top left corner so y while icreasing it goes down instead of up in the classsical geometry
    /// </summary>
    public class Power_of_Thor___Episode_1___Codoingame
    {
        public static void MoveThor()
        {
            string[] inputs = new string[4];
            inputs[0] = Console.ReadLine();
            inputs[1] = Console.ReadLine();
            inputs[2] = Console.ReadLine();
            inputs[3] = Console.ReadLine();
            int lightX = int.Parse(inputs[0]); // the X position of the light of power
            int lightY = int.Parse(inputs[1]); // the Y position of the light of power
            int initialTX = int.Parse(inputs[2]); // Thor's starting X position
            int initialTY = int.Parse(inputs[3]); // Thor's starting Y position

            int thorX = initialTX;
            int thorY = initialTY;

            // game loop
            while (true)
            {
                // The remaining amount of turns Thor can move. Do not remove this line.
                //int remainingTurns = int.Parse(Console.ReadLine());

                string directionX = "";
                string directionY = "";

                if (thorX > lightX)
                {
                    directionX = "W";
                    thorX--;
                }
                else if (thorX < lightX)
                {
                    directionX = "E";
                    thorX++;
                }

                if (thorY > lightY)
                {
                    directionY = "N";
                    thorY--;
                }
                else if (thorY < lightY)
                {
                    directionY = "S";
                    thorY++;
                }
                else
                {
                    break;
                }

                // A single line providing the move to be made: N NE E SE S SW W or NW
                Console.WriteLine(directionY + directionX);
            }


            //BRUTE FORCE SOLUTION
            //if (lightX < initialTx && lightY < initialTy)
            //{
            //    initialTx -= 1;
            //    initialTy -= 1;
            //    Console.WriteLine("NW");
            //}
            //else if (lightX > initialTx && lightY < initialTy)
            //{
            //    initialTx += 1;
            //    initialTy -= 1;
            //    Console.WriteLine("NE");
            //}
            //else if (lightX < initialTx && lightY > initialTy)
            //{
            //    initialTx -= 1;
            //    initialTy += 1;
            //    Console.WriteLine("SW");
            //}
            //else if (lightX > initialTx && lightY > initialTy)
            //{
            //    initialTx += 1;
            //    initialTy += 1;
            //    Console.WriteLine("SE");
            //}
            //else if (lightX == initialTx && lightY < initialTy)
            //{
            //    initialTy -= 1;
            //    Console.WriteLine("N");
            //}
            //else if (lightX == initialTx && lightY > initialTy)
            //{
            //    initialTy -= 1;
            //    Console.WriteLine("S");
            //}
            //else if (lightX < initialTx && lightY == initialTy)
            //{
            //    initialTx -= 1;
            //    Console.WriteLine("W");
            //}
            //else if (lightX > initialTx && lightY == initialTy)
            //{
            //    initialTx += 1;
            //    Console.WriteLine("E");
            //}
            //else
            //{
            //    break;
            //}
        }

        public static string MoveThor2(ValueTuple<int, int> thor, ValueTuple<int, int> light)
        {
            string result = "";

            while(thor.Item1 != light.Item1 || thor.Item2 != light.Item2)
            {
                if(thor.Item1 != light.Item1)
                {
                    if (thor.Item1 > light.Item1)
                    {
                        result += "W";
                        thor.Item1--;
                    }
                    else if (thor.Item1 < light.Item1)
                    {
                        result += "E";
                        thor.Item1++;
                    }
                }
                
                if(thor.Item2 != light.Item2)
                {
                    if (thor.Item2 > light.Item2)
                    {
                        result += "N";
                        thor.Item2--;
                    }
                    else if (thor.Item2 < light.Item2)
                    {
                        result += "S";
                        thor.Item2++;
                    }
                }
            }

            return result;
        }
    }
}
