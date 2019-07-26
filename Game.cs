using System;
using System.Collections.Generic;

namespace GameApp
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int PlayingTime { get; set; }
        public int NumberOfPlayers { get; set; }
         public List<Player> Players { get; set; } = new List<Player>();

        public static Game CreateGame(int id, string name)
        {
            var game = new Game();
            game.Id = id;
            game.Name = name;
            game.Age = 10;
            game.PlayingTime = 0;
            game.NumberOfPlayers = 1;
            
            return game;
        }

        public Game SetAge(int minumAgeToPlay)
        {
            Age = minumAgeToPlay;

            return this;
        }


        public Game SetName(string name)
        {
            Name = name;

            return this;
        }

        public Game SetPlayingTime(int howLongDoesGameLast)
        {
            PlayingTime = howLongDoesGameLast;

            return this;
        }

        public Game SetNumberOfPlayers(int numberOfPlayers)
        {
            if(numberOfPlayers < 0 || numberOfPlayers > 50)
                throw new ArgumentException("Number of Players must be greater than 0 and less than 50");

            NumberOfPlayers = numberOfPlayers;

            return this;
        }

    }

}