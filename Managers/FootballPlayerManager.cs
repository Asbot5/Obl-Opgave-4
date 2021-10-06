using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OblFootballPlayer;

namespace FootballPlayerREST
{
    public class FootballPlayerManager
    {
        private static int _nextId = 1;
        private static readonly List<FootballPlayer> PlayerList = new List<FootballPlayer>
        {
            new FootballPlayer {Id = _nextId++, Name = "Asmus", Price = 1000000, ShirtNumber = 5},
            new FootballPlayer {Id = _nextId++, Name = "Jens", Price = 100, ShirtNumber = 10},
        };

        public List<FootballPlayer> GetAll()
        {
                return new List<FootballPlayer>(PlayerList);
        }

        public FootballPlayer GetById(int id)
        {
            return PlayerList.Find(player => player.Id == id);
        }

        public FootballPlayer Add(FootballPlayer newPlayer)
        {
            newPlayer.Id = _nextId++;
            PlayerList.Add(newPlayer);
            return newPlayer;
        }

        public FootballPlayer Delete(int id)
        {
            FootballPlayer player = PlayerList.Find(player1 => player1.Id == id);
            if (player == null) return null;
            PlayerList.Remove(player);
            return player;
        }

        public FootballPlayer Update(int id, FootballPlayer updates)
        {
            FootballPlayer player = PlayerList.Find(player1 => player1.Id == id);
            if (player == null) return null;
            player.Name = updates.Name;
            player.Price = updates.Price;
            player.ShirtNumber = updates.ShirtNumber;
            return player;
        }
    }
}