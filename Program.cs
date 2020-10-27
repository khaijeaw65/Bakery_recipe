using System;

namespace Bakery_shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] recipeName = new string[50];
            string[] recipeIngredient = new string[50];
            string[] recipeMethod = new string[50];
            string exit = "";

            recipeName[0] = "brownie";
            recipeIngredient[0] = "sugar flour egg oil cocoa powder";
            recipeMethod[0] = "เปิดเตาอบที่อุณหภูมิ 170 องศาเซลเซียส ใช้ถาดอบขนาด 26.5 x 16 ซม. และรองกระดาษไข" + " ต้มน้ำร้อนใส่หม้อ " + " นำเนย และช็อกโกแลตใส่ในอ่างผสม นำอ่างผสมไปวางบนหม้อน้ำร้อน รอให้เนยและช็อกโกแลตละลาย พักไว้" +
                            " นำไข่ไก่ และน้ำตาลมาใส่ในอ่างผสม และตีให้เข้ากัน ใส่ส่วนผสมเนยและช็อกโกแลตที่ละลายแล้วลงไป คนผสมให้เข้ากัน ผสมอย่าให้นานเกิน 30 วินาที เพราะจะทำให้บราวนี่ไม่ขึ้นหน้าฟิล์ม" +
                            " นำแป้ง ผงโกโก้ และเกลือมาร่อน แล้วนำไปใส่ในอ่างผสมของไข่ คนผสมให้เข้ากัน เทใส่ในถาดที่เตรียมไว้ นำเข้าเตาอบที่อุณหภูมิ 170 องศาเซลเซียส อบประมาณ 20-25 นาที เมื่ออบสุกแล้ว รอให้เย็นตัว แล้วนำเข้าช่องแช่แข็ง ประมาณ 1 ชั่วโมงก็จะสามารถนำมาตัดเสิร์ฟได้";

            do
            {
                string action = Menu();

                switch (action)
                {
                    case "1": searchRecipe(recipeName, recipeIngredient, recipeMethod); break;
                    case "2": AddRecipe(recipeName, recipeIngredient, recipeMethod); break;
                    case "3": EditRecipe(recipeName, recipeIngredient, recipeMethod); break;
                    default: Console.WriteLine("Mis match input"); break;
                }

                Console.Write("Exit? (y/n): ");
                exit = Console.ReadLine();
                Console.Clear();
            } while (!exit.Equals("y", StringComparison.OrdinalIgnoreCase));
        }

        public static string Menu()
        {
            Console.WriteLine("----Welcome to SF.Food----");
            Console.WriteLine("1: Search Food name :");
            Console.WriteLine("2: Add Recipe :");
            Console.WriteLine("3: Edit Recipe :");
            Console.Write("Please Choose:");
            string Choice = Console.ReadLine();

            while (Choice != "1" && Choice != "2" && Choice != "3")
            {
                Console.WriteLine("Wrong Key");
                Console.WriteLine("----Welcome to SF.Food----");
                Console.WriteLine("1: Search Food name :");
                Console.WriteLine("2: Add Recipe :");
                Console.WriteLine("3: Edit Recipe :");
                Console.Write("Please Choose:");
                Choice = Console.ReadLine();
            }

            return Choice;
        }

        public static void searchRecipe(string[] recipeName, string[] recipeIngredient, string[] recipeMethod)
        {

            //รับค่า ชื่อ ขนมจาก keyboard
            Console.Write("Please fill bakery name :");
            string name = Convert.ToString(Console.ReadLine());

            //เช็คว่ามีสูตรใน array หรือไม่
            if (RecipeExist(recipeName, name))
            {
                //ถ้ามี ให้ print ข้อมูลสูตรจาก array
                for (int index = 0; index < recipeName.Length; index++)
                {
                    if (name.Equals(recipeName[index]))
                    {
                        Console.WriteLine("---Recipe found---");
                        Console.WriteLine("Bekery name: " + recipeName[index]);
                        Console.WriteLine("Ingredient:");
                        Console.WriteLine(recipeIngredient[index]);
                        Console.WriteLine("Method:");
                        Console.WriteLine(recipeMethod[index]);
                        break;
                    }
                }
            }
            else
            {
                //ถ้าไม่มีให้ print ว่าหาไม่เจอ
                Console.WriteLine("--recipe not found--");
            }

        }

        public static void AddRecipe(string[] recipeName, string[] recipeIngredient, string[] recipeMethod)
        {
            string confirmChoice;
            do
            {
                Console.Write("Please enter recipe name for the recipe: ");
                string name = Console.ReadLine();

                while (RecipeExist(recipeName, name))
                {
                    Console.WriteLine("This recipe already exists please enter a recipe name again.");
                    Console.Write("Please enter recipe name for the recipe: ");
                    name = Console.ReadLine();
                }

                Console.Write("Enter ingredient use in this recipe (in long string): ");
                string addIngredient = Console.ReadLine();

                Console.Write("Enter method for this recipe (in long string): ");
                string addMethod = Console.ReadLine();

                Console.Write("confirm recipe data? (y/n): ");
                confirmChoice = Console.ReadLine();

                if (confirmChoice.Equals("y", StringComparison.OrdinalIgnoreCase))
                {
                    for (int index = 0; index < recipeName.Length; index++)
                    {
                        if (!name.Equals(recipeName[index]))
                        {
                            recipeName[index] = name;
                            recipeIngredient[index] = addIngredient;
                            recipeMethod[index] = addMethod;
                            break;
                        }
                    }
                }

            } while (!confirmChoice.Equals("y", StringComparison.OrdinalIgnoreCase));

        }

        public static void EditRecipe(string[] recipeName, string[] recipeIngredient, string[] recipeMethod)
        {
            string editIngredient = "";
            string editMethod = "";
            string confirmChoice = "";

            do
            {
                Console.Write("Please enter recipe name for editing: ");
                string name = Console.ReadLine();

                while (!RecipeExist(recipeName, name))
                {
                    Console.WriteLine("Recipe not found please enter recipe name again.");
                    Console.Write("Please enter bakery name for the recipe: ");
                    name = Console.ReadLine();
                }

                for (int index = 0; index < recipeName.Length; index++)
                {
                    if (name.Equals(recipeName[index]))
                    {
                        Console.WriteLine("Ingredient : ");
                        Console.WriteLine(recipeMethod[index]);
                        Console.WriteLine("Method : ");
                        Console.WriteLine(recipeMethod[index]);
                    }
                }

                Console.Write("Enter 1 for edit ingredient use in this recipe or 2 for edit method use in this recipe: ");
                string edit = Console.ReadLine();

                while (!edit.Equals("1") && !edit.Equals("2"))
                {
                    Console.WriteLine("Wrong input");
                    Console.Write("Enter 1 for edit ingredient use in this recipe or 2 for edit method use in this recipe: ");
                    edit = Console.ReadLine();
                }

                if (edit.Equals("1"))
                {
                    Console.Write("Enter ingredient use in this recipe: ");
                    editIngredient = Console.ReadLine();

                    Console.Write("confirm recipe data? (y/n): ");
                    confirmChoice = Console.ReadLine();

                    if (confirmChoice.Equals("y", StringComparison.OrdinalIgnoreCase))
                    {
                        for (int index = 0; index < recipeName.Length; index++)
                        {
                            if (name.Equals(recipeName[index]))
                            {
                                recipeIngredient[index] = editIngredient;
                                break;
                            }
                        }
                    }
                }
                else if (edit.Equals("2"))
                {
                    Console.Write("Enter method for this recipe (in long string): ");
                    editMethod = Console.ReadLine();

                    Console.Write("confirm recipe data? (y/n): ");
                    confirmChoice = Console.ReadLine();

                    if (confirmChoice.Equals("y"))
                    {
                        for (int index = 0; index < recipeName.Length; index++)
                        {
                            if (name.Equals(recipeName[index]))
                            {
                                recipeMethod[index] = editMethod;
                                break;
                            }
                        }
                    }
                }

            } while (!confirmChoice.Equals("y", StringComparison.OrdinalIgnoreCase));
        }

        public static bool RecipeExist(string[] recipeName, string name)
        {
            bool exist = false;

            foreach (string s in recipeName)
            {
                if (name.Equals(s))
                {
                    exist = true;
                    break;
                }
            }

            return exist;
        }
    }
}
