using GourmetGame.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.VisualBasic;

namespace GourmetGame
{
    public partial class MainWindow
    {
        MessageBoxResult resp;
        int respInt;
        string caption = "Gourmet Game";
        private void GuessFood(List<Food> foods)
        {
            var listSize = foods.Count - 1;
            int count;

            for (count = listSize; count > 0; count--)
            {
                resp = AskFood(foods, count, true);
                if (resp == MessageBoxResult.Yes)
                {
                    resp = AskFood(foods, count, false);

                    if (resp == MessageBoxResult.Yes)
                    {
                        IsDone();
                    }
                    else if (resp == MessageBoxResult.No && count == 0)
                    {
                        MakeFood(foods, count);
                    }
                }
            }

            if (count == 0)
            {
                resp = AskFood(foods, count, false);
                if (resp == MessageBoxResult.Yes)
                {
                    IsDone();
                }
                else
                {
                    MakeFood(foods, count);
                }
            }
        }

        private MessageBoxResult AskFood(List<Food> foods, int count, bool feature)
        {
            if (feature)
            {
                return MessageBox.Show("O prato que pensou é " + foods[count].Feature + "?", caption, MessageBoxButton.YesNo, MessageBoxImage.Question);
            }
            else
            {
                return MessageBox.Show("O prato que pensou é " + foods[count].Name + "?", caption, MessageBoxButton.YesNo, MessageBoxImage.Question);
            }
        }

        private void IsDone()
        {
            MessageBox.Show("Acertei de novo!", caption, MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        /*private void AddFood(List<Food> foods, int ordem)
        {
           // foods.Add(MakeFood(foods, ordem));
        }*/

        private void MakeFood(List<Food> foods, int ordem)
        {
            string nameFood;
            string feature;


            nameFood = Interaction.InputBox("Qual prato você pensou?", "Desisto");
            feature = Interaction.InputBox("O prato " + nameFood + " é _________ mas " + foods[ordem].Name + " não é", "Desisto");

            if (string.IsNullOrWhiteSpace(nameFood) && string.IsNullOrWhiteSpace(feature))
            {
                MessageBox.Show("A descrição ou nome não foi preenchido", caption, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Food food = new Food(nameFood, feature);
                foods.Add(food);
            }
        }
    }
}
