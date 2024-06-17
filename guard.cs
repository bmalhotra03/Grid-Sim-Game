// Author: Brij Malhotra
// Filename: guard.cs
// Version: Version 1
// Description: This is the class definition and implementation of the Guard parent

// Class invariant:
//      The guard object takes in an integer array that stands in as a shield for the object. A guard object 
//      may be reset if it is not alive. Additionally, it has a block functionality which blocks attacks on the
//      object, if a successful hit is there on the object, the number of shields decreases by 1. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P5
{
    public class Guard
    {
        public bool up;
        public bool alive;
        public int numShields;
        public int[] orig;
        protected int initialNumShields;
        protected int[] shield;

        public void shieldUp()
        {
            if (up || isAlive()) { return ; }
            
            for (int i = 0; i < shield.Count(); i++)
            {
                if (shield[i] >  0)
                {
                    up = true;
                    return;
                }

            }

        }

        public void shieldDown()
        {
            up = false;
            return;
        }

        protected bool isAlive()
        {
            return (numShields > (shield.Count()/2));
        }

        public virtual bool block(int x)
        {
            if (Math.Abs(x) > shield.Count())
            {
                x = Math.Abs(x) % shield.Count();
            }

            if (x <= shield.Count()){
                if (up && isAlive())
                {
                    shield[x]--;
                    return true;
                } else
                {
                    numShields--;
                    up = false;
                    return false;
                }
            }
            return false;
        }

        public Guard(int[] s)
        {
            if (s.Sum() == 0)
            {
                s = new int[1];
                s[0] = 3;
            }

            shield = s;
            orig = s;
            initialNumShields = orig.Count();
            numShields = s.Count();
            alive = true;
            up = true;
        }

        public void reset()
        {
            if (!isAlive())
            {
                numShields = initialNumShields;
                up = true;
                for (int i = 0; i < initialNumShields; i++) 
                {
                    shield[i] = orig[i];
                }
            }
        }
    }
}


// Implementation invariant: 
//      The shield is derived from the number of values in the array. The reset function works when the object is not alive.
//      An object is not alive when the number of shields is less than half of the initial shield count. The parameter passed
//      through to block determines what shield will be used.