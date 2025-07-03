using System;
using System.Collections.Generic;
using System.Linq;

namespace DndProj.Contracts.Models.Character
{
    // могут зависеть от множества факторов, включая расу, класс, уровень, черты
    public class Feature
    {
        public int? Strength { get; set; }

        public int? Dexterity { get; set; }

        public int? Vitality { get; set; }

        public int? Intelligence { get; set; }

        public int? Wisdom { get; set; }

        public int? Charisma { get; set; }
    }
}
