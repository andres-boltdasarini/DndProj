using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;

namespace DndProj.Contracts.Models.Character
{
    public class AddCharacterRequest
    {
        public string? Name { get; set; }
        public string? Worldview { get; set; }
        public string? Gender { get; set; }
        public string? Background { get; set; }

        public int? Move { get; set; }
        public int? Helth { get; set; }
        public int? ClassArmor { get; set; }
        public int? Initiative { get; set; }
        public Profession? Profession { get; set; }
        public Race? Race { get; set; }
        public Skills? Skills { get; set; }
        public Characteristics? Characteristics { get; set; }


        public AddCharacterRequest()
        {
            Profession = new Profession();
            Race = new Race();
            Skills = new Skills();
            Characteristics = new Characteristics();
        }

    }
}
