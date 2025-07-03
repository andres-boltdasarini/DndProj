using System;
using System.Collections.Generic;
using System.Linq;

namespace DndProj.Contracts.Models.Character
{
    public class Race
    {
        public string? Name { get; set; }
        public string? FeatureIncrease { get; set; }
        public string? Move { get; set; }
        public List<Spell> Spells { get; set; }

        public Race()
        {
            Spells = new List<Spell>();
        }
    }
}
