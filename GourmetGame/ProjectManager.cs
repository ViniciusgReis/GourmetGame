using GourmetGame.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GourmetGame
{
    public class ProjectManager
    {
        int resp;

        Food typePasta = new Food("Pasta", "");
        Food notTypePasta = new Food("Chocolate Cake", "");

        List<Food> optionPasta = new List<Food>();
        List<Food> optionNotPasta = new List<Food>();

        private void GuessFood(List<Food> foods)
        {
            var listSize = foods.Count - 1;
            int count;

            for (count = listSize; count > 0; count--)
            {
                resp = AskFood(foods, count, true);
                if (resp == 1)
                {
                    resp = AskFood(foods, count, false);

                    if (resp == 1)
                    {
                        Acertei();
                    }
                    else if (resp == 0 && count == 0)
                    {
                        AddFood(foods, count);
                    }
                }
            }

            if (count == 0)
            {
                resp = AskFood(foods, count, false);
                if (resp == 1)
                {
                    Acertei();
                }
                else
                {
                    AddFood(foods, count);
                }
            }
        }

        private int AskFood(List<Food> foods, int count, bool feature)
        {
            string resp;
            if (feature)
            {
                Console.WriteLine("O prato que pensou é {0} ?", foods[count].Feature);
                resp = Console.ReadLine();

                if (resp == "sim")
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                Console.WriteLine("O prato que pensou é {0} ?", foods[count].Name);
                resp = Console.ReadLine();
                if (resp == "sim")
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        private void Acertei()
        {
            Console.WriteLine("Acertei!");
        }

        private void AddFood(List<Food> foods, int ordem)
        {
            foods.Add(MakeFood(foods, ordem));
        }

        private Food MakeFood(List<Food> foods, int ordem)
        {
            Console.WriteLine("Desisto. Qual prato você pensou?\n");
            string nameFood = Console.ReadLine();

            Console.WriteLine("O prato {0} é _________ mas {1} não é", nameFood, foods[ordem]);
            string specify = Console.ReadLine();
            Food food = new Food(nameFood, specify);

            return food;
        }
    }
}
