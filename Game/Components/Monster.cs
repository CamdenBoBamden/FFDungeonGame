using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components
{
    public class Monster : Character
    {
        public int XPDrop { get; set; }
        public int GoldDrop { get; set; }


        public Monster(string name, int level, int maxHealth, int health, int maxMP, int mp, int maxAttack, int minAttack, int defense, int xpDrop, int goldDrop) : base(name,
            level, maxHealth, health, maxMP, mp, maxAttack, minAttack, defense)
        {
            XPDrop = xpDrop;
            GoldDrop = goldDrop;          
        }

        public override string ToString()
        {
            return string.Format("{0} monster level {1}", Name, Level);
        }      
    }    
}
