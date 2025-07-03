using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;

namespace DndProj.Contracts.Models.Character
{
    public class CharacterCreationRequest
    {
        public string? Name { get; set; }
        public string? Worldview { get; set; }
        public string? Gender { get; set; }
        public string? Background { get; set; }

        public int? Move { get; set; }
        public int? Health { get; set; } 
        public int? ClassArmor { get; set; }
        public int? Initiative { get; set; }

        public Race? Race { get; set; }
        public Skills? Skills { get; set; }
        public Feature? Feature { get; set; }
        public List<Profession> Professions { get; set; }

        public CharacterCreationRequest()
        {
            Professions = new List<Profession>();
            Race = new Race();
            Skills = new Skills();
            Feature = new Feature();
        }

    }
}
