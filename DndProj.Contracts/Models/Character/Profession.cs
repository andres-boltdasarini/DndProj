using System;
using System.Collections.Generic;
using System.Linq;

namespace DndProj.Contracts.Models.Character
{
    public class Profession
    {
        public string? Name { get; set; }
        public int? Experience { get; set; }
        public int? Level { get; set; }
        public List<Spell> Spells { get; set; }

        public Profession()
        {
            Spells = new List<Spell>();
        }
    }
}
