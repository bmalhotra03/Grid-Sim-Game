// Author: Brij Malhotra
// Filename: infantry.cs
// Version: Version 1
// Description: This is the class definition and implementation of the Infantry object

// Class invariant: 
//      Additional information to the fighter class: this will give information on overriden functions of the parent class.
//      The overriden functionality of move in the infantry class is the same to the fighter class, except it cannot reverse
//      after successive moves in a direction it was headed to first. The shift functionality takes an integer as a parameter
//      and sets the range to that so objects in that range can be targeted. Infantry objects are reset if they are inactive, 
//      their ammunition, strength and position are updated to the initial values that were set via the constructor injection. 

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fighterClass;

namespace infantryClass
{
    public class infantry : fighter
    {
        private bool trackX;
        private bool trackY;
        private bool movedX;
        private bool movedY;

        // Pre conditions: Same as fighter
        // Post conditions: Same as fighter
        public infantry(int r, int c, int[] art)
            : base(r, c, art)
        {
            movedX = false;
            movedY = false;
        }

        // Pre conditions: Object is inactive
        // Post conditions: Object is reset and its position and ammunition and strength are set to the intial values
        public virtual void reset()
        {
            if (!isActive())
            {
                row = initialRow;
                column = initialColumn;
                strength = initialStrength;
                ammo = initialAmmo;
            }
        }

        // Pre conditions: 2 integers as parameters to update the position
        // Post conditions: Object only updates its position if the coordinates given indicate that the object is not reversing
        public override void move(int x, int y)
        {

            if (!isActive() || !isAlive())
            {
                return;
            }

            // Determine whether the object is moving horizontally or vertically
            bool horizontal = x != row;
            bool vertical = y != column;

            // If the object is not currently moving, set its direction
            if (!horizontal && !vertical)
            {
                trackX = false;
                trackY = false;
            }
            else if (!movedX && horizontal)
            {
                trackX = x > row;
                movedX = true;
            }
            else if (!movedY && vertical)
            {
                trackY = y > column;
                movedY = true;
            }

            // Check whether the object is moving in the same direction as before
            bool sameX = horizontal && (x > row) == trackX;
            bool sameY = vertical && (y > column) == trackY;

            // If the object is moving in the same direction, perform the move
            if (sameX || sameY)
            {
                base.move(x, y);
            }
        }

        // Pre conditions: An integer is passed as a parameter that sets the range of the object
        // Post conditiosn: The object can hit targets that are within the range using target()
        public override void shift(int p)
        {
            // Enable infantry to attack any object within range p
            // Reset is called within the shift function
            reset();
            range = p;
        }
    }
}


// Implementation invariant:
//      Additional information in the fighter class: this will give information on overriden and added functionalities of the infantry class.
//      The move functionality of the infantry class tracks whether the object has been moved already before and further more checks to see if
//      the new coordinates indicate if the object is reversing, if so, it just does not move. The reset function is triggered in the shift()
//      function and goes through when the object is inactive, it sets the position and ammunition and strength of the object to its initial values.
//      The shift functionality alters the range of the object to the integer passed as a parameter. 