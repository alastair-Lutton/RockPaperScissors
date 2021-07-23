using Game___RockPaperScissors.Models;
using System;
using System.Web.Mvc;
using static Game___RockPaperScissors.Models.GameEnums;

namespace Game___RockPaperScissors.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            RockPaperScissors model = new RockPaperScissors();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(string playerChoice, RockPaperScissors model)
        {
            Random random = new Random();
            model.ComputerVsComputer = false;
            GameChoice playerChoiceEnum;
            if (String.IsNullOrEmpty(playerChoice))
            {
                playerChoiceEnum = GetComputerChoice(random);
                model.ComputerVsComputer = true;
            }
            else
            {
                playerChoiceEnum = (GameChoice)Enum.Parse(typeof(GameChoice), playerChoice);
            }
            var computerChoice = GetComputerChoice(random);
            model = PlayGame("Player", "Computer", playerChoiceEnum, computerChoice, model);

            ModelState.Clear();
            return View(model);
        }

        private bool GetWinner(GameChoice playerOneChoice, GameChoice playerTwoChoice)
        {
            return (playerOneChoice == GameChoice.Rock && playerTwoChoice == GameChoice.Scissors
                    ||
                    (playerOneChoice == GameChoice.Paper && playerTwoChoice == GameChoice.Rock)
                    ||
                    (playerOneChoice == GameChoice.Scissors && playerTwoChoice == GameChoice.Paper));
        }

        private RockPaperScissors PlayGame(string nameOne, string nameTwo, GameChoice playerOneChoice, GameChoice playerTwoChoice, RockPaperScissors model)
        {
            string result;
            if (playerOneChoice == playerTwoChoice)
            {
                result = "Draw!";
            }
            else
            {
                if (GetWinner(playerOneChoice, playerTwoChoice))
                {
                    model.PlayerScore++;              
                    result = String.Format("{0} wins!", nameOne);
                }
                else
                {
                    model.ComputerScore++;
                    result = String.Format("{0} wins!", nameTwo);
                }
            }
            ViewBag.OnePlayed = String.Format("{0} played {1}", nameOne, playerOneChoice.ToString().ToLower());
            ViewBag.TwoPlayed = String.Format("{0} played {1}", nameTwo, playerTwoChoice.ToString().ToLower());
            model.Result = result;
            return model;
        }

        public GameChoice GetComputerChoice(Random random)
        {
            Array values = Enum.GetValues(typeof(GameChoice));
            GameChoice outcome = (GameChoice)values.GetValue(random.Next(values.Length));
            return outcome;
        }
    }
}