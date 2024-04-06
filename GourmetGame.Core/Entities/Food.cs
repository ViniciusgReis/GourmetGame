using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GourmetGame.Core.Entities
{
    public class Food
    {
        public Food(string name, string feature)
        {
            Name = name;
            Feature = feature;
        }

        public string Name { get; private set; }
        public string Feature { get; private set; }
    }
}
