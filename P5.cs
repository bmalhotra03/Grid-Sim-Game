// Author: Brij Malhotra
// Filename: P5.cs
// Version: Version 1
// Description: Driver file for the multiply inherited class objects. It creates a heterogeneous collection of fighter + guard objects and simulates their
//              functionalities. There is a getObject function that returns the type of object being created. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using fighterClass;
using turretClass;
using infantryClass;
using P5;

namespace P5
{
    class P5
    {
        private const int MAXARR = 15;

        public static fighter GetFighter()
        {
            Random rnd = new Random();
            int obj = rnd.Next(1, 6);

            if (obj == 1)
            {
                int arrSize = rnd.Next(3, 7);
                int[] arr = new int[arrSize];
                for (int i = 0; i < arrSize; i++)
                {
                    arr[i] = rnd.Next(1, 100);
                }

                return new fighter(rnd.Next(-150, 150), rnd.Next(-150, 150), arr);
            }
            else if (obj == 2)
            {
                int arrSize = rnd.Next(3, 7);
                int[] arr = new int[arrSize];
                for (int i = 0; i < arrSize; i++)
                {
                    arr[i] = rnd.Next(1, 100);
                }

                return new turret(rnd.Next(-150, 150), rnd.Next(-150, 150), arr);
            }
            else if (obj == 3)
            {
                int arrSize = rnd.Next(3, 7);
                int[] arr = new int[arrSize];
                for (int i = 0; i < arrSize; i++)
                {
                    arr[i] = rnd.Next(1, 100);
                }

                return new infantry(rnd.Next(-150, 150), rnd.Next(-150, 150), arr);
            }
            else if (obj == 4)
            {
                int arrSize = rnd.Next(3, 7);
                int[] arr = new int[arrSize];
                for (int i = 0; i < arrSize; i++)
                {
                    arr[i] = rnd.Next(1, 100);
                }

                return new fighterGuard(rnd.Next(-150, 150), rnd.Next(-150, 150), arr, GetGuard(arrSize));
            }
            else if (obj == 5)
            {
                int arrSize = rnd.Next(3, 7);
                int[] arr = new int[arrSize];
                for (int i = 0; i < arrSize; i++)
                {
                    arr[i] = rnd.Next(1, 100);
                }

                return new turretGuard(rnd.Next(-150, 150), rnd.Next(-150, 150), arr, GetGuard(arrSize));
            }
            else if (obj == 6)
            {
                int arrSize = rnd.Next(3, 7);
                int[] arr = new int[arrSize];
                for (int i = 0; i < arrSize; i++)
                {
                    arr[i] = rnd.Next(1, 100);
                }

                return new infantryGuard(rnd.Next(-150, 150), rnd.Next(-150, 150), arr, GetGuard(arrSize));
            }
            else
            { throw new Exception("No object created"); }

        }

        public static Guard GetGuard(int x)
        {
            Random rnd = new Random();
            int obj = rnd.Next(1, 3);

            if (obj == 1)
            {
                int arrSize = rnd.Next(1, 5);
                int[] shield = new int[arrSize];
                for (int i = 0; i < arrSize; i++)
                {
                    shield[i] = rnd.Next(1, 10);
                }

                return new Guard(shield);
            }
            else if (obj == 2)
            {
                int arrSize = rnd.Next(1, 5);
                int[] shield = new int[arrSize];
                for (int i = 0; i < arrSize; i++)
                {
                    shield[i] = rnd.Next(1, 10);
                }

                return new skipGuard(shield);
            } 
            else if (obj == 3)
            {
                int arrSize = rnd.Next(1, 5);
                int[] shield = new int[arrSize];
                for (int i = 0; i < arrSize; i++)
                {
                    shield[i] = rnd.Next(1, 10);
                }

                return new quirkyGuard(shield);
            } 
            else 
            { throw new Exception("No object created"); }

        }
        static void Main()
        {
            fighter[] heteroDB = new fighter[MAXARR];

            for (int i = 0; i < MAXARR; i++)
            {
                heteroDB[i] = GetFighter();
            }

            // Simulate objects using the public functionalities of their class
            // Random iterations of the turns that objects take
            Random rand = new Random();

            int simulations = rand.Next(25, 1000);

            for (int i = 0; i < MAXARR; i++)
            {

                for (int j = 0; j < simulations; j++)
                {
                    // Random number created to use different functionalities
                    int simFunc = rand.Next(1, 4);

                    if (simFunc == 1)
                    {
                        heteroDB[i].move(rand.Next(-150, 150), rand.Next(-150, 150));
                        heteroDB[i].getX();
                        heteroDB[i].getY();
                    }
                    else if (simFunc == 2)
                    {
                        heteroDB[i].target(heteroDB[rand.Next(1, MAXARR)]);
                    }
                    else if (simFunc == 3)
                    {
                        heteroDB[i].sum();
                    }
                    else if (simFunc == 4)
                    {
                        heteroDB[i].shift(rand.Next(1, 150));
                    }
                    else
                    {
                        throw new Exception("No function used");
                    }
                }
            }

            // Zero out objects

            for (int i = 0; i < MAXARR; i++)
            {
                heteroDB[i] = null;
            }
        }
    }
}
