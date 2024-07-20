using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerosQuest
{
    class barbarian:Character
    {
        private int _Rage;
        private int _MaxRage;

        public int Rage 
        {
            get => _Rage;
            set
            {
                if (value >= 0 )
                {
                    _Rage = value;
                }
            }
        }

        public barbarian(string name) : base(name)
        {
            MaxHealth = rng.Next(14, 19);
            MaxEnergy = rng.Next(8, 13);
            EnergyPotions = rng.Next(2, 4);
            HealthPotions = rng.Next(1, 3);
            _MaxRage = rng.Next(4, 9);
            Rage = 0;
            Health = MaxHealth;
            Energy = MaxEnergy;
        }

        public bool SwingAxe(Character pTarget)
        {
           
           

            // error string used to detect is anything is wrong
            string error = "";

            if (pTarget.Health <= 0)
            {
                error += pTarget.Name + " is already dead.";
            }

            if (Energy <= 0)
            {
                error += "You need at least 1 energy to swing your axe.";
            }

            if (pTarget == _Allied)
            {
                error += "You cannot attack " + pTarget.Name + " because you are allied with them this turn.";
            }

            // If anything is wrong output the error(s) and return false
            if (error.Length > 0)
            {
                Console.WriteLine(error);
                return false;
            }

            // nothing wrong, so do the action, output result and return true

            Console.WriteLine(Name + " swings his mighty axe at " + pTarget.Name);
            int damageMultiplier = 1;
            if (Rage >= _MaxRage)
            {
                Console.WriteLine("RAGING STRIKE - THIS STRIKE WILL DEAL DOUBLE DAMAGE!");
                damageMultiplier = 2;
                Rage = 0;
            }

            Energy--;

            int roll = rng.Next(1, 21);
            if (roll < 4)
            {
                Console.WriteLine("The axe misses " + pTarget.Name + " completely!");
                Rage += 4;
            }
            else if (roll < 9)
            {

                Console.WriteLine("The axe grazes " + pTarget.Name + "'s leg dealing " + (damageMultiplier * 2) + " damage!");
                pTarget.Health -= (damageMultiplier * 2);
                Rage += 3;
            }
            else if (roll < 17)
            {

                Console.WriteLine("The axe crashed into " + pTarget.Name + "'s torso dealing " + (damageMultiplier * 3) + " damage.");
                pTarget.Health -= (damageMultiplier * 3);
                Rage += 2;
            }
            else
            {
                Rage += 1;
                Console.WriteLine("The axe smashes into " + pTarget.Name + "'s head dealing " + (damageMultiplier * 4) + " damage.");
                pTarget.Health -= (damageMultiplier * 4);
            }

            Console.WriteLine("Your rage increases to " + Rage);
            return true;
        }
        public void OutputState()
        {
            base.OutputState(this.GetType().Name,0,Rage,0,_MaxRage);
        }
    }
}
