namespace Memory
{
    static internal class PlayersManager
    {
        const string databaseFile = "players.txt";
        public static void AddPlayerToDatabase(Player player)
        {
            if (!System.IO.File.Exists(databaseFile))
            {
                using (System.IO.StreamWriter stream = System.IO.File.CreateText(databaseFile))
                {
                    stream.WriteLine(player.ToString());
                }
            }

            using (System.IO.StreamWriter stream = System.IO.File.AppendText(databaseFile))
            {
                stream.WriteLine(player.ToString());
            }
        }

        public static bool CheckPlayerIdExists(string id)
        {
            bool result = false;
            if (!System.IO.File.Exists(databaseFile))
            {
                return false;
            }
            using (System.IO.StreamReader reader = System.IO.File.OpenText(databaseFile))
            {
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    string[] player_info = line.Split(',');
                    if (player_info[2] == id)
                    {
                        return true;
                    }
                }
            }

            return result;
        }

        public static bool CheckPlayerEmailExists(string email)
        {
            bool result = false;
            if (!System.IO.File.Exists(databaseFile))
            {
                return false;
            }
            using (System.IO.StreamReader reader = System.IO.File.OpenText(databaseFile))
            {
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    string[] player_info = line.Split(',');
                    if (player_info[4] == email)
                    {
                        return true;
                    }
                }
            }

            return result;
        }

        public static bool IsValidLogin(string id, string password)
        {
            bool result = false;

            if (!System.IO.File.Exists(databaseFile))
            {
                return false;
            }
            using (System.IO.StreamReader reader = System.IO.File.OpenText(databaseFile))
            {
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    string[] player_info = line.Split(',');
                    if (player_info[2] == id && player_info[3] == password)
                    {
                        return true;
                    }
                }
            }

            return result;
        }

        public static Player GetLoggedPalyer(string id, string password)
        {
            Player result = null;

            if (!System.IO.File.Exists(databaseFile))
            {
                return null;
            }
            using (System.IO.StreamReader reader = System.IO.File.OpenText(databaseFile))
            {
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    string[] player_info = line.Split(',');
                    if (player_info[2] == id && player_info[3] == password)
                    {
                        Player player = new Player(player_info[0], player_info[1], player_info[2], player_info[3], player_info[4]);
                        player.BestTime = float.Parse(player_info[5]);
                        return player;
                    }
                }
            }

            return result;
        }

        public static System.Collections.Generic.List<Player> GetPlayers()
        {
            System.Collections.Generic.List<Player> result = new System.Collections.Generic.List<Player>();

            if (!System.IO.File.Exists(databaseFile))
            {
                return null;
            }
            using (System.IO.StreamReader reader = System.IO.File.OpenText(databaseFile))
            {
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    string[] player_info = line.Split(',');
                    Player player = new Player(player_info[0], player_info[1], player_info[2], player_info[3], player_info[4]);
                    player.BestTime = float.Parse(player_info[5]);
                    result.Add(player);
                }
            }
            return result;
        }
    }
}
