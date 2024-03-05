using System;
using System.ComponentModel.Design;
using System.Data;

class Food
{
    protected string protein;
    protected string starch;
    protected string vegetable;

    public Food()
    {
        protein = "";
        starch = "";
        vegetable = "";
    }

    public Food(string protein, string starch, string vegetable)
    {
        this.protein = protein;
        this.starch = starch;
        this.vegetable = vegetable;
    }
    public string getProtein()
    {
        return protein;
    }
    public string getStarch()
    {
        return starch;
    }
    public string getVegetable()
    {
        return vegetable;
    }
    public void setProtein(string protein)
    {
        this.protein = protein;
    }
    public void setStarch(string starch)
    {
        this.starch = starch;
    }
    public void setVegetable(string vegetable)
    {
        this.vegetable = vegetable;
    }
    public virtual void addIngredient()
    {
        Console.Write("Protein?");
        setProtein(Console.ReadLine());
        Console.Write("Starch?");
        setStarch(Console.ReadLine());
        Console.Write("Vegetable?");
        setVegetable(Console.ReadLine());
    }
    public virtual void Print()
    {
        Console.WriteLine();
        Console.WriteLine($"Protein:{protein}");
        Console.WriteLine($"Starch: {starch}");
        Console.WriteLine($"Vegetable: {vegetable}");
    }

}
class Burger : Food
{
    protected string dairy;
    protected string sauce;

    public Burger() : base()
    {
        dairy = "";
        sauce = "";
    }
    public Burger(string protein, string starch, string vegetable, string dairy, string sauce) : base(protein, starch, vegetable)
    {
        this.dairy = dairy;
        this.sauce = sauce;
    }
    public void setDairy(string dairy)
    {
        this.dairy = dairy;
    }
    public void setSauce(string sauce)
    {
        this.dairy = dairy;
    }
    public string getDairy()
    {
        return dairy;
    }
    public string getSauce()
    {
        return sauce;
    }
    public override void addIngredient()
    {
        base.addIngredient();
        Console.WriteLine("Dairy?");
        setDairy(Console.ReadLine());
        Console.WriteLine("Sauce?");
        setSauce(Console.ReadLine());
    }
    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Dairy: {dairy}");
        Console.WriteLine($"Sauce: {sauce}");
        Console.WriteLine();
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("How many food recipes would you like to enter?");
        int maxRecipes;
        while (!int.TryParse(Console.ReadLine(), out maxRecipes))
            Console.WriteLine("Please enter a whole number!");
        Food[] recp = new Food[maxRecipes];
        Console.WriteLine("How many burger recipes would you like to enter?");
        int maxBurger;
        while (!int.TryParse(Console.ReadLine(), out maxBurger)) ;
        Console.WriteLine("Please enter a whole number!");
        Burger[] burg = new Burger[maxBurger];

        int choice, recNum, type;
        int foodCount = 0, burgCount = 0;
        choice = Menu();
        while (choice != 4)
        {
            Console.WriteLine("Enter 1 for generic food recipe, enter 2 for burger recipe");
            while (!int.TryParse(Console.ReadLine(), out type))
                Console.WriteLine("1 for food or 2 for burger!");
            try
            {
                switch (choice)
                {
                    case 1:
                        if (type == 2)
                        {
                            if (burgCount <= maxBurger)
                            {
                                burg[burgCount] = new Burger();
                                burg[burgCount].addIngredient();
                                burgCount++;
                            }
                            else
                                Console.WriteLine("The maximum number of burger recipes has been added");
                        }
                        else
                        {
                            if (foodCount <= maxRecipes)
                            {
                                recp[foodCount] = new Food();
                                recp[foodCount].addIngredient();
                                foodCount++;
                            }
                            else
                                Console.WriteLine("The maximum number of food recipes has been added");
                        }
                        break;
                    case 2:
                        Console.Write("Enter the recipe number you would like to change.");
                        while (!int.TryParse(Console.ReadLine(), out recNum)) ;
                        Console.WriteLine("Enter the recipe number you would like to change");
                        recNum--;
                        if (type == 1)
                        {
                            while (recNum > foodCount - 1 || recNum < 0)
                            {
                                Console.WriteLine("The number you entered was out of range, please try again");
                                while (!int.TryParse(Console.ReadLine(), out recNum))
                                    Console.Write("Enter the recipe number you want to change");
                                recNum--;
                            }
                            recp[recNum].addIngredient();
                        }
                        else
                        {
                            while (recNum > burgCount - 1 || recNum < 0)
                            {
                                Console.Write("The number you enter was out of range, please try again");
                                while (!int.TryParse(Console.ReadLine(), out recNum))
                                    Console.WriteLine("Enter the recipe number you want to change");
                                recNum--;
                            }
                            burg[recNum].addIngredient();
                        }
                        break;
                    case 3:
                        if (type == 1)
                        {
                            for (int i = 0; i < foodCount; i++)
                                recp[i].Print();
                        }
                        else
                        {
                            for (int i = 0; i < burgCount; i++)
                            {
                                burg[i].Print();
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("You entered an incorrect number, please try again");
                        break;
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            choice = Menu();
        }
    }
    private static int Menu()
    {
        Console.WriteLine("Please make a selection from the menu");
        Console.WriteLine("1-Add  2-Change  3-Print  4-Quit");
        int selection = 0;
        while (selection < 1 || selection > 4)
            while (!int.TryParse(Console.ReadLine(), out selection))
                Console.WriteLine("1-Add  2-Change  3-Print  4-Quit");
        return selection;
    }
}