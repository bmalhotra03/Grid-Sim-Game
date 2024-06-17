// Author: Brij Malhotra
// Filename: fighter.cs
// Version: Version 1
// Description: This is the class definition and implementation of the Fighter object

// Class invariant:
//      The Fighter class object instructor uses 2 integers as the x and y coordinates of the object, additionally
//      it takes in an integer array that sets the artillery which has the ammunition and strength of the object dependent on it and
//      sets an appropriate range based on those values.If values are out of bounds, they will be altered to fit the objects construction,
//      further more, if negative values are given, their absolute values are taken to have object creation. The class uses dependency injection,
//      specifically construction injection to create these objects. There are a variety of public functions the client can access; target() that
//      takes in the object you wish to attack along with the strength you want to hit it with. move() that takes in a new x and y coordinate to shift
//      the object's position. sum() returns the number of targets your object has vanquished. isAlive() and isActive() return booleans that indicate the
//      state of the object. Additionally, there are getX() and getY() functions that let the client get the current position of the object.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fighterClass
{
    public class fighter
    {
        protected int row;
        protected int column;
        protected int strength;
        protected int[] artillery;
        protected int range;
        protected int ammo;
        protected bool active;
        protected bool alive;
        protected int numVanquished;
        protected readonly int initialRow;
        protected readonly int initialColumn;
        protected readonly int initialStrength;
        protected readonly int initialAmmo;
        protected readonly int minStrength;
        protected const int BOUND = 150;

        // Pre conditions: None
        // Post conditions: Returns boolean value that indicates activity status
        public bool isActive()
        {
            return (isAlive() && ammo > initialAmmo / 5);
        }

        // Pre conditions: Object is in range in the target function
        // Post conditions: Updates ammunition of object calling target()
        protected virtual void shoot()
        {
            ammo--;

        }

        // Pre conditions: Object being hit is in range
        // Post conditions: Reduces the strength of the object being hit
        protected virtual void hit()
        {
            strength--;
        }

        // Pre conditions: None
        // Post conditions: Returns boolean that indicates whether the object is alive or dead
        public bool isAlive()
        {
            return (strength > minStrength);
        }

        // Pre conditions: Integers for the starting positions along with positive integers in the array
        //                 that set the artillery for the object
        // Post conditions: Object is created with given parameters and sets the values of other variables based on
        //                  the constructor injection
        public fighter(int r, int c, int[] art)
        {
            // Error design to check if coordinates are in the boundary and if array is empty

            if (Math.Abs(r) < BOUND)
            {
                r = r % BOUND;
            }

            if (Math.Abs(c) < BOUND)
            {
                c = c % BOUND;
            }

            if (art.Sum() == 0)
            {
                art = new int[1];
                art[0] = 3;
            }

            row = r;
            column = c;
            artillery = art;

            for (int i = 0; i < art.Count(); i++)
            {
                artillery[i] = Math.Abs(art[i]);
            }

            ammo = art.Sum();
            strength = art.Sum();
            range = ammo + strength;
            active = true;
            alive = true;
            initialAmmo = ammo;
            initialStrength = strength;
            initialColumn = c;
            initialRow = r;
            minStrength = (art[art.Count() - 1])/2;

        }

        // Pre conditions: 2 integers as parameters
        // Post conditions: Updates position of object if it is a legal move
        public virtual void move(int x, int y)
        {
            // Check if move is legal
            // ...

            if (Math.Abs(x) < BOUND)
            {
                x = x % BOUND;
            }

            if (Math.Abs(y) < BOUND)
            {
                y = y % BOUND;
            }

            // Update position
            if (isActive() && isAlive())
            {
                row = x;
                column = y;
            }

        }

        // Pre conditions: None
        // Post conditions: None
        public virtual void shift(int p)
        {
            // Alter aim according to value p
            // ...

        }

        // Pre conditions: Object to be hit should be passed as parameter
        // Post conditions: Function returns a boolean that indicates whether the object being hit has been vanquished or not
        public bool target(fighter obj)
        {
            // Check if target is within range
            // ...

            if (isActive() && isAlive() && inRange(obj.getX(), obj.getY()))
            {
                shoot();
                obj.hit();

                // Check if fighter can vanquish target
                // ...
                if (!obj.isAlive())
                {
                    numVanquished++;
                    return true;
                }

            }

            return false;
        }

        // Pre conditions: None
        // Post conditions: Returns an integer value that shows how many targets have been vanquished by the object calling the functions
        public virtual int sum()
        {
            // Return sum total of targets vanquished
            // ...
            return numVanquished;
        }

        // Pre conditions: Takes in the coordinates of the object being hit as parameters 
        // Post conditions: Returns boolean value that indicates whether object is in range or not so that it can be hit in target()
        protected virtual bool inRange(int x, int y)
        {
            return ((Math.Abs(row - x) < range) && (Math.Abs(column - y) < range));
        }

        // Pre conditions: None
        // Post conditions: Returns the X coordinate of the object
        public int getX()
        {
            return row;
        }

        // Pre conditions: None
        // Post conditions: Returns the Y coordinate of the object
        public int getY()
        {
            return column;
        }
    }
}


// Implementation invariant: 
//      The client is not able to use shift in the fighter class, once the object is created using constructor injection,
//      the values of strength and ammunition are derived from it and will be used for all other function invocations. 
//      target() will only hit an object if it is in range and it will reduce ammunition of the object using target and
//      simultaneously reduce the strength of the object being hit. The shift functionality for the fighter class does not
//      do anything to its aim according to the instructions provided.