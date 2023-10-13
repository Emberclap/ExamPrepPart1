namespace _01._Monster_Extermination
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
           
            int[] monsterArmor = Console.ReadLine()
                .Split(",",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> monsters = new Queue<int>(monsterArmor);
            
            int[] soldierStrikeImpact = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> strikes = new Stack<int>(soldierStrikeImpact);
            int killedMonsters = 0;
            while (strikes.Count > 0 && monsters.Count > 0)
            {
                int armour = monsters.Peek();
                int strike = strikes.Peek();

                if (strike >= armour)
                {
                    killedMonsters++;
                    strike -= armour;

                    if (strike == 0)
                    {
                        strikes.Pop();
                        monsters.Dequeue();
                    }
                    else
                    {
                        monsters.Dequeue();
                        if (strikes.Count == 1)
                        {
                            strikes.Pop();
                            strikes.Push(strike);
                            continue;
                        }
                        else
                        {
                            strikes.Pop();
                            int tempStrike = strike;
                            strikes.Push(strikes.Pop() + tempStrike);
                        }
                    }
                }
                else
                {
                    armour = monsters.Dequeue() - strikes.Pop();
                    if (armour > 0)
                    {
                        monsters.Enqueue(armour);
                    }
                }
                
                
            }
            if (monsters.Count < 1)
            {
                Console.WriteLine($"All monsters have been killed!");
            }
            if (strikes.Count < 1)
            {
                Console.WriteLine("The soldier has been defeated.");
            }
            Console.WriteLine($"Total monsters killed: {killedMonsters}");

        }
    }
}