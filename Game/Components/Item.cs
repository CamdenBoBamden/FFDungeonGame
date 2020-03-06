using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components
{
    public abstract class Item
    {
        public string Name { get; set; }
        public string Id { get; set; }
       
        public Item(string name, string id)
        {
            Name = name;
            Id = id;    
        }
        public override string ToString()
        {
            return Name;
        }
    }//end public class Item
}
