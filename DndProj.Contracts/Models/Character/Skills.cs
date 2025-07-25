﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DndProj.Contracts.Models.Character
{
    // могут зависеть от множества факторов, включая Базовые характеристики, Владение навыком, Экспертиза
    public class Skills
    {
        public int? Athletics { get; set; }


        public int? Acrobatics { get; set; }

        public int? SleightOfHand { get; set; }

        public int? Stealth { get; set; }


        public int? Arcana { get; set; }

        public int? History { get; set; }

        public int? Nature { get; set; }

        public int? Religion { get; set; }

        public int? Investigation { get; set; }


        public int? Perception { get; set; }

        public int? Survival { get; set; }

        public int? Medicine { get; set; }

        public int? Insight { get; set; }

        public int? AnimalHandling { get; set; }


        public int? Deception { get; set; }

        public int? Intimidation { get; set; }

        public int? Performance { get; set; }

        public int? Persuasion { get; set; }
    }
}
