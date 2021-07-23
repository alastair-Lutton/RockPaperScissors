﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Game___RockPaperScissors.Models
{
    public class RockPaperScissors
    {
        public int PlayerScore { get; set; }
        public int ComputerScore { get; set; }
        public string PlayerChoice { get; set; }
        public string Result { get; set; }
        [Display(Name = "Let computer play for me")]
        public bool ComputerVsComputer { get; set; }
    }

    public class GameEnums
    {
        public enum GameChoice { Rock, Paper, Scissors };

    }
}