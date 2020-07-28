using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Grid_Based
{
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
    }
}
