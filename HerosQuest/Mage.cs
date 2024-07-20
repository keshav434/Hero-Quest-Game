using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerosQuest
{
    class mage:Character
    {
        public mage(string name) : base(name)
        {
            MaxHealth = rng.Next(8, 11);
            MaxEnergy = rng.Next(6, 13);
            EnergyPotions = rng.Next(1, 3);
            HealthPotions = rng.Next(2, 4);
            Health = MaxHealth;
            Energy = MaxEnergy;
        }

        public bool ThrowFireball(Character pTarget)
        {
           
           

            // error string used to detect is anything is wrong
            string error = "";

            if (pTarget.Health <= 0)
            {
                error += pTarget.Name + " is already dead.";
            }

            if (Energy <= 0)
            {
                error += "You need at least 1 energy to throw a fireball.";
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
            int roll = rng.Next(1, 21);

            if (roll == 3)
            {
                Console.WriteLine("The fireball misses " + pTarget.Name + " completely!");
            }
            else if (roll < 7)
            {
                Console.WriteLine("The fireball grazes " + pTarget.Name + "'s limb dealing 1 damage.");
                pTarget.Health -= 1;
            }
            else if (roll < 17)
            {
                Console.WriteLine("The fireball hits " + pTarget.Name + "'s  torso dealing 2 damage!");
                Energy++;
            }
            else
            {
                Console.WriteLine("The fireball hits " + pTarget.Name + "'s  head dealing 3 damage!");
                pTarget.Health -= 3;
            }

            _Allied = null;
            return true;
        }

        public bool HealPlayer(Character pTarget)
        {
          
           
            // error string used to detect is anything is wrong
            string error = "";

            if (pTarget.Health <= 0)
            {
                error += pTarget.Name + " is already dead.";
            }

            if (Energy <= 0)
            {
                error += "You need at least 1 energy to heal a player.";
            }

            // If anything is wrong output the error(s) and return false
            if (error.Length > 0)
            {
                Console.WriteLine(error);
                return false;
            }

            // nothing wrong, so do the action, output result and return true
            pTarget.Health += rng.Next(3, 7);
            if (pTarget != this)
            {
                pTarget._Allied = this;
            }
            return true;
        }
        public void OutputState()
        {
            base.OutputState(this.GetType().Name,0,0,0,0);
        }
    }
}
