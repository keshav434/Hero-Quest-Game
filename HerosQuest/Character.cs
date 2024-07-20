using System;
using System.Text.RegularExpressions;

namespace HerosQuest
{
    public class Character
    {
        public Random rng = new Random();

        private string _Name;
        private int _Health;
        private int _MaxHealth;
        private int _Energy;
        private int _MaxEnergy;
        private int _EnergyPotions;
        private int _HealthPotions;


        public Character _Allied;
        private bool setNameOnce = false;
        private bool setMaxHealthOnce = false;
        private bool setMaxEnergyOnce = false;
        public int MaxEnergy 
        {
            get => _MaxEnergy;
            set
            {
                if (setMaxEnergyOnce == false)
                {

                    _MaxEnergy = value;
                    setMaxEnergyOnce = true;
                }
            }
        }
        public int MaxHealth
        {
            get => _MaxHealth;
            set
            {
                if (setMaxHealthOnce == false)
                {

                    _MaxHealth = value;
                    setMaxHealthOnce = true;
                }
            }
        }
        
        public int EnergyPotions 
        {
            get => _EnergyPotions;
            set
            {
                if (value >= 0 || value <= _EnergyPotions)
                {
                    _EnergyPotions = value;
                }
            }
        }
        public int HealthPotions
        {
            get => _HealthPotions;
            set
            {
                if (value >= 0 )
                {
                    _HealthPotions = value;
                }
            }
        }
        public int Health
        {
            get => _Health;
            set
            {
                if (value >= 0 || value <= MaxHealth)
                {
                    _Health = value;
                }
            }

        }
        public int Energy
        { 
            get => _Energy;
            set
            {
                if (value >= 0 || value <= MaxEnergy)
                {
                    _Energy = value;
                }
            }
        }
        public string Name 
        { 
            get => _Name;
            set
            {
                Regex namepattern = new Regex(@"^[a-zA-Z]*$");

                if (setNameOnce == false)
                {
                    if (namepattern.IsMatch(value) && value.Length >= 1)
                    {
                        _Name = value;
                        setNameOnce = true;
                    }
                    else
                    {
                        throw new Exception("Name can not contain number & special character");

                    }
                }
            }


        }

        public Character(string pName)
        {
            Name = pName;

           
        }

        public Character()
        {
        }

        public bool TakeEnergyPotion()
        {
            // error string used to detect is anything is wrong
            string error = "";

            if (EnergyPotions < 1)
            {
                error += "You do not have any energy potions left.\r\n";
            }

            if (Energy < 1)
            {
                error += "You need at least 1 energy to use a potion.\r\n";
            }

            // If anything is wrong output the error(s) and return false
            if (error.Length > 0)
            {
                Console.WriteLine(error);
                return false;
            }

            // nothing wrong, so do the action, output result and return true
            Energy--;
            Energy += MaxEnergy / 2;
            Console.WriteLine("You take an energy potion.");
            Console.WriteLine("Your energy is now " + Energy);
            return true;
        }

        public bool TakeHealthPotion()
        {
            // error string used to detect is anything is wrong
            string error = "";

            if (HealthPotions < 1)
            {
                error += "You do not have any health potions left.\r\n";
            }

            if (Energy < 1)
            {
                error += "You need at least 1 energy to use a potion.\r\n";
            }

            // If anything is wrong output the error(s) and return false
            if (error.Length > 0)
            {
                Console.WriteLine(error);
                return false;
            }

            // nothing wrong, so do the action, output result and return true
            Energy--;
            Health += MaxHealth / 2;
            Console.WriteLine("You take a health potion.");
            Console.WriteLine("Your health is now " + Health);
            return true;
        }

        public void Rest()
        {
            int energy = 3 + rng.Next(4);
            int health = 3 + rng.Next(4);
            Energy += (energy);
            Health += (health);

            Console.WriteLine("You are well rested.");
            Console.WriteLine("Your energy has increased by {0} to {1} / {2}.", energy, Energy, MaxEnergy);
            Console.WriteLine("Your health has increased by {0} to {1} / {2}.", health, Health, MaxHealth);
        }




        /// <summary>
        /// Outputs the state of this instance of character to the console
        /// </summary>
        public void OutputState(string _CharacterType,int _MaxNumberOfArrows,int _Rage, int _NumberOfArrows, int _MaxRage)
        {
            string output = Name + " the " + _CharacterType + ":" + Health + "/" + MaxHealth + " Health. " + Energy + "/" + MaxEnergy + " Energy. ";
            if (_CharacterType == "ranger")
            {
                output += _NumberOfArrows + "/" + _MaxNumberOfArrows + " arrows.";
            }
            else if (_CharacterType == "barbarian")
            {
                output += _Rage + "/" + _MaxRage + " rage.";
            }

            output += "\r\n" + Name + " has " + HealthPotions + " health potions and " + EnergyPotions + " energy potions.\r\n";

            if (_Allied != null)
            {
                output += Name + " is currently allied with " + _Allied.Name;
            }

            Console.WriteLine(output);
        }
    }
}
