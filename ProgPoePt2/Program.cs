using ProgPoePt2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgPoePt2
{
    class Program
    {
        private static int opt = 0;
        public static Tools tool = new Tools();

        static Recipe rec; 

        static void Main(string[] args)
        {
            opt = 1;

            while (opt > 0)
            {
                opt = tool.Introduction();
                switch (opt)
                {
                    case 1:
                        rec = new Recipe(); // Assign a new instance to the rec variable
                        Tools tools = new Tools();

                        Console.WriteLine("what is the name of your recipe ");
                        rec.name = Console.ReadLine();

                        Console.WriteLine("how many ingrediants would you like to add");
                        int? res = int.Parse(Console.ReadLine());

                        for (int i = 0; i < res; i++)
                        {
                            Ingrediant ing = new Ingrediant();

                            Console.WriteLine("What is the name of your ingrediant ?");
                            ing.ingName = Console.ReadLine();

                            Console.WriteLine("What is the unit of measurement you would like to use ?" +
                                              "Choose between teaspoons, tablespoons and cups");
                            ing.uOm = Console.ReadLine();

                            Console.WriteLine("What is the qantity of your ingrediant ");
                            ing.quanity = int.Parse(Console.ReadLine());

                            Console.WriteLine("How many calaories in this particular ingrediant ?");
                            ing.cal = int.Parse(Console.ReadLine());

                            Console.WriteLine("What food group is your ingrediant ?");
                            ing.foodGroup = Console.ReadLine();

                            rec.Ingrediants.Add(ing);
                            rec.BackUpIngrediants.Add(ing);
                        }
                        
                        tool.CaloriesExceeded += (recipeName, totalCalories) =>
                        {
                            Console.WriteLine($"Alert: The total calories in the recipe {recipeName} have exceeded 300. Total calories: {totalCalories}");
                        };



                        tool.CheckCalories(rec);
                        

                       
                        tool.Recipes.Add(rec);
                        

                      


                       

                       
                        
                      
                        

                        break;

                    case 2:
                        Console.WriteLine("what is thge name of the recipe you would like to change ?");
                        string name = Console.ReadLine();
                        Console.WriteLine("what numer would yo ulike to scale up the ingrediants by");
                        int factor = int.Parse(Console.ReadLine());
                        tool.ChangeQuantities(name, factor);
                        break;

                    case 3:

                        tool.PrintReciepe(rec);
                        break;


                    case 4:

                        Console.WriteLine("please enter the name of the reciep");

                        Console.WriteLine("total amount of calaries are:" + tool.CalculateTotalCalories(Console.ReadLine()));

                        break;



                        break;


                    case 5:

                        tool.PrintRecipesAlphabetically();

                        break;


                    case 6:
                        opt = 0;
                        break;

                    
                        

 





                }
            }
        }
    }

}


