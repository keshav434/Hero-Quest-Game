using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerosQuest
{
    class ranger : Character
    {

        private int _NumberOfArrows;
        private int _MaxNumberOfArrows;


        private bool setMaxNumberOfArrowsOnce = false;


        public int NumberOfArrows 
        {
            get => _NumberOfArrows;
            set
            {
                if (value >= 0 || value <= MaxNumberOfArrows)
                {
                    _NumberOfArrows = value;
                }
            }
        }

        public int MaxNumberOfArrows
        {
            get => _MaxNumberOfArrows;
            set
            {
                if (setMaxNumberOfArrowsOnce == false)
                {

                    _MaxNumberOfArrows = value;
                    setMaxNumberOfArrowsOnce = true;
                }
            }
        }

        public ranger(string name) : base(name)
        {
            MaxHealth = rng.Next(10, 15);
            MaxEnergy = rng.Next(4, 9);
            EnergyPotions = rng.Next(1, 4);
            HealthPotions = rng.Next(1, 4);
            MaxNumberOfArrows = rng.Next(4, 9);
            NumberOfArrows = MaxNumberOfArrows;
            Health = MaxHealth;
            Energy = MaxEnergy;
        }

        public bool FireBow(Character pTarget)
        {
           

            // error string used to detect is anything is wrong
            string error = "";

            if (NumberOfArrows == 0)
            {
                error += "You have no arrows to fire!\r\n";
            }

            if (Energy < 1)
            {
                error += "You need at least 1 energy to use a bow.\r\n";
            }

            if (pTarget == _Allied)
            {
                error += "You cannot attack " + pTarget + " because you are allied with them this turn.";
            }

            // If anything is wrong output the error(s) and return false
            if (error.Length > 0)
            {
                Console.WriteLine(error);
                return false;
            }

            // nothing wrong, so do the action, output result and return true
            NumberOfArrows--;
            Energy--;
            Console.WriteLine(Name + " releases a deadly arrow towards the " + pTarget.Name);

            int roll = rng.Next(1, 21);

            if (roll < 4)
            {
                Console.WriteLine("The arrow misses " + pTarget.Name + " completely!");
            }
            else if (roll < 7)
            {
                Console.WriteLine("The arrow grazes " + pTarget.Name + "'s limb dealing 1 damage.");
                pTarget.Health -= 1;
            }
            else if (roll < 13)
            {
                Console.WriteLine("The arrow hits " + pTarget.Name + "'s  torso dealing 2 damage!");
                Console.WriteLine("You regain 1 energy.");
                pTarget.Health -= 2;
                Energy++;
            }
            else
            {
                Console.WriteLine("The arrow hits " + pTarget.Name + "'s  head dealing 3 damage!");
                Console.WriteLine("You regain 2 energy.");
                Energy += 2;
                pTarget.Health -= 3;
            }

            _Allied = null;
            return true;
        }

        public bool PickUpArrows()
        {
         

            // error string used to detect is anything is wrong
            string error = "";

            if (Energy < 1)
            {
                error += "You need at least 1 energy to pick up arrows.";
            }

            // If anything is wrong output the error(s) and return false
            if (error.Length > 0)
            {
                Console.WriteLine(error);
                return false;
            }

            // nothing wrong, so do the action, output result and return true
            Energy--;

            int minimumArrows = Math.Min(2, MaxNumberOfArrows - NumberOfArrows);
            int arrowsCollected = rng.Next(minimumArrows, MaxNumberOfArrows - NumberOfArrows);
            NumberOfArrows += arrowsCollected;
            Console.WriteLine(Name + " the ranger picked up " + arrowsCollected + " and now has " + NumberOfArrows + "/" + MaxNumberOfArrows);
            return true;
        }

        public void OutputState()
        {
            base.OutputState(this.GetType().Name,MaxNumberOfArrows,0, NumberOfArrows, 0);
        }
    }
}
