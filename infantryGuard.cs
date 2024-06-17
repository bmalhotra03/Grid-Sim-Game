// Author: Brij Malhotra
// Filename: infantryGuard.cs
// Version: Version 1
// Description: This is the class definition and implementation of the infantryGuard child object

// Class invariant:
//      Same as infantry invariant except that the constructor takes in a guard object that sets up the object
//      as part of a multiply inherited class structure. Objects can now block incoming attacks due to the cross
//      product functionality. The block functionality is based on the type of guard object passed through.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using infantryClass;

namespace P5
{
    public class infantryGuard : infantry
    {
        Guard shield;
        public infantryGuard(int r, int c, int[] art, Guard obj) : base(r, c, art)
        {
            shield = obj;
        }

        protected override void shoot()
        {
            shield.shieldDown();
            base.shoot();
        }

        protected override void hit()
        {
            shield.shieldUp(); 
            
            if (!shield.block(artillery.Count()))
            { 
                base.hit();
            }
        }

        public override void move(int x, int y)
        {
            shield.shieldDown();
            base.move(x, y);
        }

        public override void reset()
        {
            if(!isAlive())
            {
                shield.reset();
            }
            
            base.reset();
        }
    }
}


// Implementation invariant: 
//      Overriden functionality, reset also resets the shields. Rest remains the same as the infantry invariant.