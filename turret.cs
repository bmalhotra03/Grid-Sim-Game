// Author: Brij Malhotra
// Filename: turret.cs
// Version: Version 1
// Description: This is the class definition and implementation of the Turret object

// Class invariant:
//      Additional information to the fighter class: this will give information on overriden functions of the parent class.
//      Turrets may not move, once the function is called a number of times that exceeds the threshold of the failed requests
//      for the object, it permanently dies. Turrets may only shoot in rows and cannot target objects that are not in the same row.
//      The shift functionality takes an integer as its parameter which then sets the range of the turret. Inactive and dead turrets
//      (NOTE: not permanently dead turrets) revive themselves and then their strength and ammunition is set as a fraction of its initial
//      values. The max failed requests for the object are calculated by taking the modulus of the artillery array values summed up with 5.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fighterClass;

namespace turretClass
{
    public class turret : fighter
    {

        private int failedRequests;
        private int maxFailedRequests;
        private bool permamentDead;

        // Pre conditions: Same as fighter
        // Post conditions: Same as fighter, sets the bound for failed requests
        public turret(int r, int c, int[] art)
            : base(r, c, art)
        {
            failedRequests = 0;
            permamentDead = false;
            maxFailedRequests = ammo % 5;
        }

        // Pre conditions: Object is either inactive or dead
        // Post conditions: Sets objects ammunition and strength to half of the initial values
        public virtual void revive()
        {
            if ((!isActive() || !isAlive()) && !permamentDead)
            {
                strength = (initialStrength / 2);
                ammo = (initialAmmo / 2);
            }
        }

        // Pre conditions: None
        // Post conditions: Object permanently dies once function is called more than the maximum failed requests bound
        public override void move(int x, int y)
        {
            // Turrets may not move
            failedRequests++;
            if (failedRequests >= maxFailedRequests)
            {
                permamentDead = true;
                strength = 0;
                ammo = 0;
            }

        }

        // Pre conditions: Integer value to set range
        // Post conditions: Changes pre-set value of object's range to the one passed in the parameter
        public override void shift(int p)
        {
            // Enable turret to attack only targets in rows at distance p
            // Revive is called in the shift function
            revive();
            range = p;
        }

        // Pre conditions: Same as fighter
        // Post conditions: Function checks if the object to be hit is in the same row and then it gets hit in target()
        protected override bool inRange(int x, int y)
        {
            return ((column == y && Math.Abs(row - x) < range) || row == x && Math.Abs(row - y) < range);

        }
    }
}

// Implementation invariant: 
//      Additional information in the fighter class: this will give information on overriden and added functionalities of the turret class.
//      Once invalid requests exceed the bound for the object, it permanently dies and cannot be revived, the inRange() for the turret
//      makes sure that the object being targeted is in the same row as that is the required prerequisite of the turret class. The revive functionality
//      is called within the shift() function which then revives the object and sets its strength and ammuniition to a fraction of the
//      initial values. 