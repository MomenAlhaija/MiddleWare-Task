using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Polymorephism
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Recipe> recipes = new List<Recipe>()
            {
                new Pizza(),
                new Falafel(),
                new Spaghetti()
            };
            foreach (var recipe in recipes)
            {
                Console.WriteLine("##########################################");  
                Console.WriteLine(recipe.GetType().Name);
                Console.WriteLine("------------------------------------------");
                Console.WriteLine(recipe.Prepare());
            }
        }
    }
   public abstract class Recipe
    {
     public abstract string Prepare();
    }
    public class Pizza: Recipe
    {
        public override string Prepare()
        {
            return "1-Place your pizza stone in a cold oven.\n" +
                "2-Preheat to 500 F. Once the oven is preheated, so is the stone.\n" +
                "3-Slide the pizza onto the stone.\n" +
                "4-Bake until cheese is lightly browned.\n " +
                "4-Remove the pizza and turn off the oven.\n" +
                "5-When cool, brush the stone, don't wash it.";
        }
    }
    public class Falafel: Recipe
    {
        public override string Prepare()
        {
            return "1. Always use dry chickpeas. Dry chickpeas, that have been soaked in water for 24 hours, will give you the best texture and flavor. Dry chickpeas are naturally starchy and will help your falafels to stay well formed. If you use canned chickpeas, your falafel will disintegrate in the frying oil.\n" +
                "2. Chill the falafel mixture. Chilling for at least 1 hour helps with the shaping. And good news is, you can make the falafel mixture one  night in advance and chill overnight.\n" +
                "3. Add baking powder to the falafel mixture before forming into balls/patties. As a raising agent, baking powder here helps make the falafel on the fluffy side.\n" +
                "4. Fry in bubbling oil, and do not crowd the saucepan. For perfectly crispy falafel, sadly, the best option is deep frying. The cooking oil should be hot and gently bubbling, but not too hot that the falafel disintegrate. If you need to, use a deep fry-safe thermometer (affiliate link); it should read around 375 degrees F (for my stove, that is medium-high heat.)\n" +
                "5- Once cooked, falafel should be crispy and medium brown on the outside, fluffy and light green on the inside.\n";
        }
    }
    public class Spaghetti: Recipe
    {
        public override string Prepare()
        {
            return "1-Pasta Recipes Like Grandma Used to Make\n" +
                "2-15 Foods You've Been Cooking Wrong This Entire Time\n" +
                "3-The Best Italian Restaurant in Every State\n" +
                "4-You've Been Defrosting Your Food All Wrong — Here's How to Do It Right\n" +
                "5-Ree Drummond and 16 Other Celebrity Chefs on the Perfect Scrambled Eggs\n" +
                "6-Read More: https://www.thedailymeal.com/how-cook-perfect-spaghetti";
        }
    }
}
