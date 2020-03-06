using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Components
{
    public class Battle
    {
        public static void Encounter(Player playerOne, bool resumeStage)

        {

            Console.Clear();
            Console.WriteLine("Entering a battle!");

            Monster mons1 = GetMonster(playerOne);

            Console.WriteLine("You encounter a {0}!", mons1);
            Console.ReadKey();
            Console.Clear();

            bool endBattle = false;
            do
            {
                BattleMenu(playerOne, mons1);
                ConsoleKey userChoice = Console.ReadKey(true).Key;
                switch (userChoice)
                {
                    case ConsoleKey.A:

                        PlayerAttack(mons1, playerOne);
                        ScreenFlash(ConsoleColor.White);
                        BattleMenu(playerOne, mons1);
                        Thread.Sleep(1250);
                        if (mons1.Health <= 0)
                        {
                            Music.Sound("victory");
                            Console.WriteLine("You defeated {0}! And gained {1} XP and picked up {2} gold!", mons1.Name, mons1.XPDrop, mons1.GoldDrop);
                            WonBattle(playerOne);
                            playerOne.XP += mons1.XPDrop;
                            playerOne.Gold += mons1.GoldDrop;

                            double XPNeeded = Math.Pow(2, playerOne.Level);
                            if (XPNeeded <= playerOne.XP)
                            {
                                Player.LevelUp(playerOne);
                            }
                            else
                            {
                                Console.WriteLine("XP needed for next level {0}XP.", XPNeeded);
                            }
                            Console.WriteLine("Please wait while we load your loot...");
                            Thread.Sleep(4500);
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();
                            endBattle = true;
                        }
                        else
                        {

                            MonAttack(mons1, playerOne);
                            BattleMenu(playerOne, mons1);
                            if (playerOne.Health <= 0)
                            {
                                Console.Clear();
                                Console.WriteLine("Sadly our hero {0} has perished in the fight...", playerOne.Name);

                                Console.ReadKey();
                                resumeStage = false;
                                endBattle = true;

                            }
                        }
                        break;
                    case ConsoleKey.M:
                        // Console.WriteLine("Inventory broke");
                        Magic(playerOne, mons1);
                        // Console.ReadKey();
                        BattleMenu(playerOne, mons1);
                        
                        if (mons1.Health <= 0)
                        {
                            Music.Sound("victory");
                            Console.WriteLine("You defeated {0}! And gained {1} XP and picked up {2} gold!", mons1.Name, mons1.XPDrop, mons1.GoldDrop);
                            WonBattle(playerOne);
                            playerOne.XP += mons1.XPDrop;
                            playerOne.Gold += mons1.GoldDrop;

                            double XPNeeded = Math.Pow(2, playerOne.Level);
                            if (XPNeeded <= playerOne.XP)
                            {
                                Player.LevelUp(playerOne);
                            }
                            else
                            {
                                Console.WriteLine("XP needed for next level {0}XP.", XPNeeded);
                            }
                            Console.WriteLine("Please wait while we load your loot...");
                            Thread.Sleep(4500);
                            Console.Write("Press any key to continue.");
                            Console.ReadKey();
                            endBattle = true;
                        }
                        else
                        {

                            MonAttack(mons1, playerOne);
                            BattleMenu(playerOne, mons1);
                            if (playerOne.Health <= 0)
                            {
                                Console.Clear();
                                Console.WriteLine("Sadly our hero {0} has perished in the fight...", playerOne.Name);

                                Console.ReadKey();
                                resumeStage = false;
                                endBattle = true;

                            }
                        }
                        break;


                    case ConsoleKey.R:
                        Console.WriteLine("Running away is not something we do yet.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case ConsoleKey.H:
                        Console.WriteLine("Hail Mary!");
                        Thread.Sleep(1000);
                        Console.WriteLine("Looks like it didn't work...");
                        Console.ReadKey();
                        MonAttack(mons1, playerOne);
                        BattleMenu(playerOne, mons1);
                        if (playerOne.Health <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Sadly our hero {0} has perished in the fight...", playerOne.Name);

                            Console.ReadKey();
                            endBattle = true;

                        }
                        Console.Clear();
                        break;
                    default:
                        break;
                }//end switch

                Console.Clear();
            } while (!endBattle);
        }//end encounter
        public static int MonAttack(Monster mons, Player playerOne)
        {
            int randMonsAttack = new Random().Next(mons.Level + 1, mons.Level * 2 + 4);
            int damageDealt = randMonsAttack - playerOne.Defense;
            if (damageDealt < 0)
            {
                damageDealt = 1;
                Console.WriteLine("{0} attacks for 1!", mons.Name);
                Thread.Sleep(1250);
                ScreenFlash(ConsoleColor.White);
                playerOne.Health -= damageDealt;
            }

            else if (damageDealt == 0)
            {
                Console.WriteLine(mons.Name + " missed!");
                Thread.Sleep(1250);
                Console.Clear();
            }

            else
            {
                Console.WriteLine("{0} attacks for {1}!", mons.Name, damageDealt);
                Thread.Sleep(1250);
                ScreenFlash(ConsoleColor.White);
                playerOne.Health -= damageDealt;
            }
            return playerOne.Health;
        }

        public static int PlayerAttack(Monster mons, Player playerOne)
        {

            int randPlayerAttack = new Random().Next(playerOne.MinAttack, playerOne.MaxAttack);
            int damageDealt = randPlayerAttack - new Random().Next(1, mons.Level);
            if (damageDealt == 0)
            {
                Console.WriteLine("You missed!");
            }
            else
            {
                Console.WriteLine("{0} attacks for {1}!", playerOne.Name, damageDealt);
                Thread.Sleep(1250);
                ScreenFlash(ConsoleColor.White);
                mons.Health -= damageDealt;
                if (mons.Health < 0)
                {
                    mons.Health = 0;
                }
            }
            return mons.Health;
        }
        public static Monster GetMonster(Player playerOne)
        {
            int randMonsLevel = new Random().Next(playerOne.Level <= 3 ? 1 : playerOne.Level - 2, playerOne.Level + 2);
            int randMonsHealth = new Random().Next(randMonsLevel * 10, randMonsLevel * 15 <= randMonsLevel * 10 ? randMonsLevel * 10 + 1 : randMonsLevel * 10);
            int randMonsAttack = new Random().Next(randMonsLevel * 2, randMonsLevel * 2 + 4 <= randMonsLevel * 2 ? randMonsLevel * 2 + 1 : randMonsLevel * 2 + 4);
            int randMonsDefense = new Random().Next(randMonsLevel * 2, randMonsLevel * 2 + 4 <= randMonsLevel * 2 ? randMonsLevel * 2 + 1 : randMonsLevel * 2 + 4);
            int randMonsxpDrop = new Random().Next(randMonsLevel + 2, randMonsLevel * 2 <= randMonsLevel + 2 ? randMonsLevel + 2 + 1 : randMonsLevel * 2);
            int randMonsgoldDrop = new Random().Next(randMonsLevel + 2, randMonsLevel * 2 <= randMonsLevel + 2 ? randMonsLevel + 2 + 1 : randMonsLevel * 2);

            Monster mons1 = new Monster(GetMonsterName(playerOne), randMonsLevel, randMonsHealth, randMonsHealth, 0, 0, randMonsAttack, randMonsAttack, randMonsDefense, randMonsxpDrop, randMonsgoldDrop);
            return mons1;
        }//end GetMonster

        public static string GetMonsterName(Player playerOne)
        {
            string name;
            switch (playerOne.GameStage)
            {
                case 1:
                    string[] enemies = { "Goblin", "Orc", "Cheap Mercenary" };
                    Random rand = new Random();
                    int randomMon = new Random().Next(0, enemies.Length);
                    name = enemies[randomMon];
                    break;
                case 2:
                    string[] enemies2 = { "Mean chicken", "Rabid wolf" };
                    Random rand2 = new Random();
                    int randomMon2 = new Random().Next(0, enemies2.Length);
                    name = enemies2[randomMon2];
                    break;

                default:
                    name = "Unkown";
                    break;

            }
            return name;
        }

        public static void ScreenFlash(ConsoleColor color)
        {
            Console.Clear();
            Console.BackgroundColor = color;
            Console.Clear();
            Thread.Sleep(20);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Thread.Sleep(20);
            Console.BackgroundColor = color;
            Console.Clear();
            Thread.Sleep(20);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

        }//end ScreenFlash()

        public static void BattleMenu(Player playerOne, Monster monster)
        {
            Console.WriteLine(@"
    _________________________________________________________________________________________________________
    ||    
    ||       Hero: {0}  Health:{1}/{5}     MP:{6}/{7}                 Monster: {2}  Health:{3}     
    ||
    ||
    ||
    ||      {8}                                         
    ||                  
    ||
    ||
    ||
    ||                          A)ttack     M)agic     R)unaway    H)ail Mary!!!", playerOne.Name, playerOne.Health, monster.Name, monster.Health, 
    
    @"
    ||     .~@@@     ^             
    ||     $ nn]    //
    ||     $_ -)   //
    ||     | CR  <cu>
    ||     | m//|III
    ||     8^*3| V
    ||    /./ HH
    ||   V/  bbDD"
    , playerOne.MaxHealth, playerOne.MP, playerOne.MaxMP, EnemyArt(monster));
        }//end Class Battles
        public static void WonBattle(Player playerOne)
        {
            string[] wonBattle = new string[9];
            Random rand = new Random();
            int randSpeech = rand.Next(wonBattle.Length);

            wonBattle[0] = "Way to go!";
            wonBattle[1] = $"{playerOne.Name}, you did it!";
            wonBattle[2] = $"And with {playerOne.Health} health to spare!";
            wonBattle[3] = "Nice work!";
            wonBattle[4] = "Need to take a nap after that one?";
            wonBattle[5] = "Piece of cake!";
            wonBattle[6] = $"Does {playerOne.Name} need to take a break?!";
            wonBattle[7] = "Not Bad!";

            Console.WriteLine(wonBattle[randSpeech]);
        }//end WonBattle
        public static void InventoryUse(Player playerOne)
        {
            Console.WriteLine("What would you like to use?");
            int counter = 0;
            foreach (Item item in playerOne.PlayerItems)
            {

                counter++;
                Console.WriteLine(counter + " " + item);

            }
            ConsoleKey userChoice = Console.ReadKey().Key;
            //switch (userChoice)
            //{
            //    case ConsoleKey.A:
            //        playerOne.PlayerItems.Remove(playerOne.PlayerItems[]);
            //        break;
            //    case 2:
            //        playerOne.PlayerItems.Remove(playerOne.PlayerItems[2]);
            //        break;
            //    default:
            //        break;
            //}

        }
        public static void Magic(Player playerOne, Monster mons)
        {
            Console.WriteLine("Select the spell you wish to cast.\n" +
                "H)eal 1MP\n" +
                "F)ireball 1MP");
            ConsoleKey userChoice = Console.ReadKey(true).Key;
            switch (userChoice)
            {
                case ConsoleKey.H:
                    Console.WriteLine("Heal for 15 health!");
                    Thread.Sleep(1000);
                    Music.Sound("magicHeal");
                    ScreenFlash(ConsoleColor.Cyan);
                    playerOne.Health += 15;
                    playerOne.MP -= 1;
                    Music.Sound("battle");
                    break;
                case ConsoleKey.F:
                    Console.WriteLine("Sparks fizzle and...");
                    Thread.Sleep(1000);
                    ScreenFlash(ConsoleColor.DarkYellow);
                    mons.Health -= 15;
                    playerOne.MP -= 1;
                    break;
                default:
                    break;
            }//end switch
        }//end Magic()

        public static string EnemyArt(Monster mons)
        {
            string artWork = "";

            //"Goblin", "Orc", "Cheap Mercenary""Mean chicken", "Rabid wolf"
            if (mons.Name == "Goblin")
            {
                artWork = @"
    ||                                                         ^ n -.                               
    ||     .~@@@     ^                                        % o  , )
    ||     $ nn]    //                                       <      |                                
    ||     $_ -)   //                                     /|   \-  /  
    ||     | CR  <cu>                                     ||    |$$\
    ||     | m//|III                                      <&> _ /    } 
    ||     8^*3| V                                         I   (@@@@/
    ||    /./ HH                                                HHHH    
    ||   V/  bbDD                                             {{MMD)
    ||";


            }
            else if ((mons.Name == "Mean chicken"))
            {
                artWork = @"
    ||
    ||     .~@@@     ^
    ||     $ nn]    //
    ||     $_ -)   //                                    M
    ||     | CR  <cu>                                  <' m
    ||     | m//|III                                    h  \___ MM
    ||     8^*3| V                                      /    ZZZZ   
    ||    /./ HH                                       (_____ZZ
    ||   V/  bbDD                                       _|_|
    ||";

            }
            else
                artWork = @"
    ||     .~@@@     ^
    ||     $ nn]    //
    ||     $_ -)   //                                    
    ||     | CR  <cu>                                  
    ||     | m//|III                                   
    ||     8^*3| V                                      
    ||    /./ HH                                       
    ||   V/  bbDD                                                                  
    ||";



            return artWork;

        }

    }//end Battle()

}//end namespace 
