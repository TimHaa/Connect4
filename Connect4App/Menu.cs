using System;
using System.Collections.Generic;
using System.Text;

namespace Connect4App
{
    class Menu
    {
        private List<Player> players = new List<Player>();//get, set
        public Menu(){ }

        public void StartGame()
        {
            Board b = new Board();
            players = SetPlayers();
            players.Shuffle();
            while (!b.PlayerWon)
            {
                foreach (Player p in players)
                {
                    b.GetInput(p.GetRow);
                    if (b.PlayerWon)
                    {
                        Console.WriteLine("Congratulations {0}, you won!", b.victorious);
                        break;
                    }
                }

            }
            Console.WriteLine("Want another Game? y/n");
            try
            {
                string nextGame = Console.ReadLine();
                if (nextGame == "y")
                {
                    StartGame();
                }
                else
                {
                    Console.WriteLine("Bye");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("That didn't work, bye");
            }
            
        }

        private List<Player> SetPlayers()
        {
            List<Player> plrs = new List<Player>();
            bool chooseAnother = true;
            while (chooseAnother)
            {
                Console.WriteLine("Choose the type of Player you want to add: ");
                switch (Console.ReadLine())
                {
                    case "human":
                        Console.Write("Enter the name: ");
                        string name = Console.ReadLine();
                        Console.Write("Choose a letter as Symbol: ");
                        string symbol = Console.ReadLine();
                        Player newGuy = new HumanPlayer(name, symbol);//name and symbol in constructor of human player or here?
                        plrs.Add(newGuy);
                        break;
                    case "rndBot":
                        Player newRnd = new RandomBot();
                        plrs.Add(newGuy);
                        break;
                    case "Bot":
                        Player newBot = new SmartBot();
                        plrs.Add(newGuy);
                        break;
                    case "s":
                        chooseAnother = false;
                        break;
                    default:
                        Console.WriteLine("1 for human Player - 2 for random Bot - 3 for smart Bot  - s to start the Game");
                        break;
                }
            }
            return plrs;
        }
        private static Random rng = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
