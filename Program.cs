using System;
using static System.Console;
using static System.ConsoleColor;
using System.Linq;
using System.Collections.Generic;

namespace GameApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var playGame = new PlayGameService();

            //load games will look for a File on disk and it it exists it will load and return those games
            //if the file doesnt exist, it will load a set of default games
            var games = playGame.LoadGames();

            Print($"Found {games.Count()} games", Green);

            Print("Would you like to add more games?");

            if (ReadLine() == "y")
            {
                Print("What is the game called?", Magenta);

                var gameName = ReadLine();

                Print("How many players are required?");

                var playersRequired = Convert.ToInt32(ReadLine());

                var newGame = Game.CreateGame(games.Count() + 1, gameName)
                                    .SetNumberOfPlayers(playersRequired);

                games.Add(newGame);
            }

            Print("Would you like to save your games?");

            if (ReadLine() == "y")
            {
                playGame.SaveGames(games);
            }

            Print("Would you like to make changes to any game details?");

            //if they say yes, list the games by ID
            if (ReadLine() == "y")
            {
                WriteLine("What game would you like to edit?");

                var editGames = playGame.LoadGames();

                foreach (var game in editGames)
                {
                    Print($"{game.Id} - {game.Name}", Cyan);
                }

                var gameToEditId = Convert.ToInt16(ReadLine());

                var gameToEdit = games.FirstOrDefault(f => f.Id == gameToEditId);

                WriteLine("What property would you like to Edit?");

                var gameProperty = ReadLine();

                if (gameProperty == "name")
                {
                    WriteLine("What would you like to change the name to?");
                    var editName = ReadLine();

                    gameToEdit.SetName(editName);
                }


                 playGame.SaveGames(games);
            }
            //ask them for the ID, get the game and print all of the props eg:

            // foreach (var game in games)
            // {
            //     Print($"{game.Id} - {game.Name}", Cyan);
            // }

            //Id: 3
            //Name: Tennis
            //Age: 10
            //Players: 2
            //
            //What property do you want to set?
            //Age
            //What is the new value?
            //15

            //at this point you will set the Age property to 15, then save the changes


            PlayNewGame();
        }

        private static void PlayNewGame()
        {
            Print("Please choose a game to play:", Green);

            var playGame = new PlayGameService();
            var games = playGame.LoadGames();

            foreach (var game in games)
            {
                Print($"{game.Id} - {game.Name}", Cyan);
            }

            var gameToPlayId = Convert.ToInt16(ReadLine());

            var gameToPlay = games.FirstOrDefault(f => f.Id == gameToPlayId);

            Print($"We are going to play {gameToPlay.Name}. Please ensure you have {gameToPlay.NumberOfPlayers} players to begin", Green);

            Print($"{Environment.NewLine}{Environment.NewLine}{Environment.NewLine}. Press enter to play a new game..{Environment.NewLine}");

            ReadLine();

            PlayNewGame();
        }


        private static void Print(string text, ConsoleColor color)
        {
            ForegroundColor = color;
            Print(text);
        }

        private static void Print(string text)
        {
            WriteLine(text);
            ResetColor();
        }
    }
}
