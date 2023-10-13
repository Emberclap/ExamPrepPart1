using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingSystem
{
    public class VendingMachine
    {

        public VendingMachine(int buttoncapacity)
        {
            ButtonCapacity = buttoncapacity;
            Drinks = new List<Drink>();

        }
        public int ButtonCapacity { get; set; }
        public List<Drink> Drinks { get; set; }
        public int GetCount => Drinks.Count;


        public void AddDrink(Drink drink)
        {
            if (GetCount < ButtonCapacity)
            {
                Drinks.Add(drink);
            }
        }
        public bool RemoveDrink(string name)
        {
            foreach (Drink drink in Drinks)
            {
                if (drink.Name == name)
                {
                    Drinks.Remove(drink);
                    return true;
                }
            }
            return false;
        }

        public Drink GetLongest()
        {
            Drink drink = Drinks.MaxBy(x => x.Volume);
            return drink;
        }
        public Drink GetCheapest()
        {
            Drink drink = Drinks.MinBy(x => x.Price);
            return drink;
        }
        public string BuyDrink(string name)
        {
            Drink drink = Drinks.Find(x => x.Name == name);
            return drink.ToString().TrimEnd();
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Drinks available:");
            foreach (Drink drink in Drinks)
            {
                sb.AppendLine(drink.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
