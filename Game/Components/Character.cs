using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components
{
    public abstract class Character
    {
        private int _Health;
        private int _MinAttack;
        private int _MP;

        public string Name { get; set; }
        public int Level { get; set; }
        public int MaxHealth { get; set; }
        public int MaxAttack { get; set; }
        public int MaxMP { get; set; }
        public int Defense { get; set; }

        public int MinAttack
        {
            get { return _MinAttack; }
            set { _MinAttack = value > MaxAttack ? MaxAttack:value; }
        }


        public int Health
        {
            get { return _Health; }
            set { _Health = value <= MaxHealth ? value <0 ? 0:value : MaxHealth; }
        }
        public int MP
        {
            get { return _MP; }
            set { _MP = value <= MaxMP ? value < 0 ? 0 : value : MaxMP; }
        }

        public Character(string name, int level, int maxHealth, int health, int maxMP, int mp, int maxAttack, int minAttack, int defense)
        {
            Name = name;
            Level = level;
            MaxHealth = maxHealth;
            Health = health;
            MaxMP = maxMP;
            MP = mp;
            MaxAttack = maxAttack;
            MinAttack = minAttack;
            Defense = defense;
        }
    }
}
