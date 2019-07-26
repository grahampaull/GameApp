using System.Collections.Generic;
using static System.IO.File;
using Newtonsoft.Json;

namespace GameApp
{
    public class PlayGameService
    {
        private string fileName = "GameData.json";
        private static List<Game> SeedInitialGames()
        {
            var scrabble = Game.CreateGame(1, "Scrabble")
                            .SetAge(8)
                            .SetNumberOfPlayers(2)
                            .SetPlayingTime(30);

            var chess = Game.CreateGame(2, "Chess")
                            .SetAge(8)
                            .SetNumberOfPlayers(2)
                            .SetPlayingTime(60);

            var football = Game.CreateGame(3, "Football")
                            .SetAge(8)
                            .SetNumberOfPlayers(22)
                            .SetPlayingTime(30);

            var rugby = Game.CreateGame(4, "Rugby")
                            .SetPlayingTime(80)
                            .SetAge(12)
                            .SetNumberOfPlayers(22);

            var cricket = Game.CreateGame(4, "Cricket")
                            .SetPlayingTime(60)
                            .SetAge(8)
                            .SetNumberOfPlayers(12);

            var hockey = Game.CreateGame(5, "Hockey")
                            .SetPlayingTime(35)
                            .SetAge(15)
                            .SetNumberOfPlayers(24);

            var listOfGames = new List<Game>();
            
            listOfGames.Add(scrabble);
            listOfGames.Add(chess);
            listOfGames.Add(football);
            listOfGames.Add(cricket);
            listOfGames.Add(hockey);

            return listOfGames;

        }

        public void SaveGames(List<Game> games)
        {
            var dataAsString = JsonConvert.SerializeObject(games);

            WriteAllText(fileName, dataAsString);
        }

        public List<Game> LoadGames()
        {
            //if games.txt exists, open
            if(Exists(fileName))
            {
                var dataAsString = ReadAllText(fileName);

                var dataAsObject = JsonConvert.DeserializeObject<List<Game>>(dataAsString);

                return dataAsObject;
            }
            else
            {
                var defaultGames = SeedInitialGames();

                return defaultGames;
            }
            
        }
    }

}