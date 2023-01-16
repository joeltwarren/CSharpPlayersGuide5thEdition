using System;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace PackingInventory
{
    internal class Program
    {
        /* You know you have a long, dangerous journey ahead of you to travel to and repair the Fountain of Objects. You decide to build some classes and objects to manage your inventory
         *  to prepare for the trip.
         *  
         *  You decide to create a Pack class to help in holding your items. Each pack has three limits: the total numbers of items it can hold, the weight it can carry, and volume.
         *  Each item has a weight and volume, and you must not overload a pack by adding to many items, to much weight, or too much volume.
         *  
         *  There are many item types that you might add to your inventory, each their own class in the inventory system. You must include the following items as a minimum
         *  1. arrow - weight of 0.1 and volume of .05
         *  2. bow - weight of 1 and volume of 4
         *  3. rope - weight of 1 and a volume of 1.5
         *  4. water - weight of 2 and a volume of 3
         *  5. food - weight of 1 and a volume of .5
         *  6. sword - weight of 5 and a volume of 3
         *  
         *  Objectives:
         *  
         *  Create an InventoryItem class that represents any of the different item types. This class must represent the item's weight and volume, which is needed at creation time (constructor).
         *  
         *  Create derived classes for each of the types of items aboce. Each class should pass the correct weight and volume to the base class constructor but should be creatable themselves
         *  with a parameterless constructor. (for example, new Rope() or new Sword()).
         *  
         *  Build a pack class that can store an array of items. The total number of items, the maximum weight, and the maximum volume are provided at creation time and cannot change after.
         *  
         *  Make a public bool Add(InventoryItem item) method to Pack that allows you to add items of any type to the pack's contents. This method should fail ( return false and not modify
         *  the pack's fields) if adding the item would cause it to exceed the pack's item, weight, or volume limits.
         *  
         *  Add properties to Pack that allow it to report the current item count, weight, and volume and limits of each.
         *  
         *  Create a program that creates a new pack and then allow the user to add (or attempt to add) items chosen from a menu.
         */
        static void Main(string[] args)
        {
            // initilazition of Object that work with packs
            Validation validator = new Validation();
            Bow bow = new Bow();
            Arrow arrow = new Arrow();
            Sword sword = new Sword();
            WoodenRoundShield shield = new WoodenRoundShield();
            Rope rope = new Rope();
            BedRoll bedroll = new BedRoll();
            Water water = new Water();
            Food food = new Food();

            Console.WriteLine("Welcome to the inventory management system!");

            Console.WriteLine("Please create your backpack you may choose from a prebuilt or define your own!");
            Console.WriteLine("Enter 1 for defining your own backpack.");
            Console.WriteLine("Enter 2 for a prebuilt archers backpack.");
            Console.WriteLine("Enter 3 for a prebuilt swordsman backpack.");
            Console.WriteLine("Enter 4 for a prebuilt adventurers backpack.");
            Console.WriteLine("Enter 5 for a prebuilt dugeonneers backpack.");
            
            string userInput = Console.ReadLine()!;
            while(userInput != "1" && userInput != "2" & userInput != "3" && userInput != "4" && userInput != "5") 
            {
                Console.Write("Please choose a valid option: 1, 2, 3, 4, or 5 ");
                userInput= Console.ReadLine()!;
            }
            Pack backPack = userInput switch // if the user selected 1 to create a pack I am using the _ default leg to catch it.
            {
                
                "2" => Pack.CreateArchersBackpack(),
                "3" => Pack.CreateSwordsManBackpack(),
                "4" => Pack.CreateAdventuresBackpack(),
                "5" => Pack.CreateDugeoneersBackpack(),
                _ => new Pack(validator.RequireValidDouble("Enter the max pounds of weight the pack can carry: "), validator.RequireValidDouble("Enter the max volume in cubic inches of the pack: "), validator.RequireValidInt("Enter the max number of items it can carry: "))
            } ;
            Console.Clear();
            Console.WriteLine($"Your backpack is now ready to use!");
            bool addItems = true;
            while (addItems) 
            {
                Console.WriteLine($"The backpack contains {backPack.currentPackItems}  items out of the maximum of {backPack.maxItems} items");
                Console.WriteLine($"The backpack contains {backPack.currentPackWeight} lbs out of the maximum weight of {backPack.maxWeight} lbs");
                Console.WriteLine($"The backpack contains {backPack.currentPackVolume} cubic inches out of the maximum volume of {backPack.maxVolume} cubic inches");
                Console.WriteLine($"{backPack.ToString()}");
                Console.Write("Would you like to add more items to your pack? (yes or no) ");
                userInput = Console.ReadLine()!;
                while (userInput.ToLower() != "yes" && userInput.ToLower() != "no") 
                {
                    Console.Write("Please enter yes or no! ");
                    userInput= Console.ReadLine()!;
                }
                if (userInput == "no") 
                {
                    addItems = false; 
                }
                else 
                {
                    Console.WriteLine("Choose a item you would like to add.");
                    Console.WriteLine($"1: Bow - Weigth: {bow.weight} Volume: {bow.volume}");
                    Console.WriteLine($"2: Arrow - Weigth: {arrow.weight} Volume: {arrow.volume}");
                    Console.WriteLine($"3: Sword - Weigth: {sword.weight} Volume: {sword.volume}");
                    Console.WriteLine($"4: Shield - Weigth: {shield.weight} Volume: {shield.volume}");
                    Console.WriteLine($"5: Rope - Weigth: {rope.weight} Volume: {rope.volume}");
                    Console.WriteLine($"6: Bedroll - Weigth: {bedroll.weight} Volume: {bedroll.volume}");
                    Console.WriteLine($"7: Food - Weigth: {food.weight} Volume: {food.volume}");
                    Console.WriteLine($"8: Water - Weigth: {water.weight} Volume: {water.volume}");
                    userInput = Console.ReadLine()!;
                    int userMenuSelection;
                    while (!int.TryParse(userInput, out userMenuSelection)) 
                    {
                        Console.WriteLine("Choose a valid option 1, 2, 3, 4, 5, 6, 7, 8");
                        while (userMenuSelection < 1 && userMenuSelection > 8) 
                        {
                            Console.WriteLine("Choose a valid option 1, 2, 3, 4, 5, 6, 7, 8"); 
                        }
                    }
                    InventoryItem item = userMenuSelection switch 
                    {
                        1 => new Bow(),
                        2 => new Arrow(),
                        3 => new Sword(),
                        4 => new WoodenRoundShield(),
                        5 => new Rope(),
                        6 => new BedRoll(),
                        7 => new Food(),
                        8 => new Water()
                    };
                    Console.Clear();
                    if (backPack.Add(item))
                    {
                        Console.WriteLine("Item added.");
                    }
                    else Console.WriteLine("Item will not fit.");
                    Console.Write("Press any key to continue: ");
                    Console.ReadKey();
                }
            }
            

        }
        /// <summary>
        /// This is the base class for all inventory items. It will require all base requirments for inventory items to create any item.
        /// </summary>
        public class InventoryItem
        {
            // Inventory item properties
            public double weight { get; protected set; } // required item weight
            public double volume { get; protected set; } // required item volume

            /// <summary>
            /// Constructor for an inventory item
            /// </summary>
            /// <param name="weight">Items required weight</param>
            /// <param name="volume">Items required volume</param>
            public InventoryItem(double weight, double volume) // constructor for any item with required weight and volume parameters
            {
                this.weight = weight; // sets the items weight
                this.volume = volume; // sets the items volume
            }
        }
        /// <summary>
        /// base arrow class
        /// </summary>
        public class Arrow : InventoryItem
        {
            public Arrow() : base(.1, .05) // creates a new arrow and its base weight and volume requirements
            {

            }

        }
        /// <summary>
        /// base bow class
        /// </summary>
        public class Bow : InventoryItem
        {
            public Bow() : base(1, 4) // creates a new bow and its base weight and volume requirements
            {

            }

        }
        /// <summary>
        /// base rope class
        /// </summary>
        public class Rope : InventoryItem
        {
            public Rope() : base(1, 1.5) // creates a new rope and its base weight and volume requirements
            {

            }

        }
        /// <summary>
        /// base water class
        /// </summary>
        public class Water : InventoryItem
        {
            public Water() : base(2, 3) // creates a new water and its base weight and volume requirements
            {

            }

        }
        /// <summary>
        /// base food class
        /// </summary>
        public class Food : InventoryItem
        {
            public Food() : base(1, .5) // creates a new food and its base weight and volume requirements
            {

            }

        }
        /// <summary>
        /// base sword class
        /// </summary>
        public class Sword : InventoryItem
        {
            public Sword() : base(5, 3) // creates a new sword and its base weight and volume requirements
            {

            }

        }
        /// <summary>
        /// base class for a round wooden shield
        /// </summary>
        public class WoodenRoundShield : InventoryItem
        {
            public WoodenRoundShield() : base(3, 5) // creates a new wooden round shield and includes its base weight and volume requirements
            {

            }
        }
        /// <summary>
        /// base class for a bedroll
        /// </summary>
        public class BedRoll : InventoryItem
        {
            public BedRoll() : base(1, 5) // creates a new bed roll and includes its base weight and volume requirements
            {

            }
        }
        /// <summary>
        /// The pack class will be the base class for all requirements related to packs that will be created. All other packs will inherit from this class.
        /// </summary>
        public class Pack
        {
            // inventory array of type InventoryItem
            private InventoryItem[] _inventory; // array of inventory items that is instantiated through the consturctor

            // properties
            public double maxWeight { get; protected set; } // maximum weight of the pack
            public double maxVolume { get; protected set; } // maximum volume of the pack
            public int maxItems { get; protected set; } // maximum number of items in the pack
            public double currentPackItems { get; private set; } = 0; // current number of items in the pack
            public double currentPackWeight { get; private set; } = 0; // current pack weight
            public double currentPackVolume { get; private set; } = 0; // current pack volume

            /// <summary>
            /// Pack constructor
            /// </summary>
            /// <param name="maxWeight">max weight of pack</param>
            /// <param name="maxVolume">max volume of pack</param>
            /// <param name="maxItems">max number of items of pack</param>
            public Pack(double maxWeight, double maxVolume, int maxItems) // constructor
            {
                this.maxWeight = maxWeight;
                this.maxVolume = maxVolume;
                this.maxItems = maxItems;
                _inventory = new InventoryItem[maxItems];

            }
            /// <summary>
            /// used to add single items to the backpack
            /// </summary>
            /// <param name="item">item to add</param>
            /// <returns>Bool: true if added false if failed</returns>
            public bool Add(InventoryItem item) // method to add items and return to the user if the item is added or not
            {
                if (currentPackItems + 1 <= maxItems && currentPackWeight + item.weight <= maxWeight && currentPackVolume + item.volume <= maxVolume)
                {
                    int index = 0; // used to hold the index value of the current while loop check
                    while (_inventory[index] != null) { index++; } // search for the first item that is considered to be blank or empty in the inventory array
                    _inventory[index] = item; // take the first empty spot and add the new item to inventory
                    currentPackItems++; // add to the number of items in the pack
                    currentPackWeight += item.weight; // add the items weight to the bag
                    currentPackVolume += item.volume; // add the items volume to the bag
                    return true;
                }
                else return false;

            }
            /// <summary>
            /// Used to add multiple items to the backpack inventory
            /// </summary>
            /// <param name="item">item to add</param>
            /// <param name="quantity">number of item to add</param>
            /// <returns>Bool: true if added false if failed</returns>
            public bool AddMultiple(InventoryItem item, int quantity) // method to add multiple items and return true if the item was added
            {
                if (currentPackItems + quantity <= maxItems && currentPackWeight + (item.weight * quantity) <= maxWeight && currentPackVolume + (item.volume * quantity) <= maxVolume)
                {
                    int index = 0;// used to hold the index value of the current while loop check
                    while (_inventory[index] != null) { index++; } // search for the first item considered blank or empty
                    int counter = 0; // counter to keep track of number of items added
                    while (counter < quantity)
                    {
                        _inventory[index] = item; // add the item to the inventory array at the specified index
                        counter++; // update the counter to keep track of how many items have been entered
                        index++; // keep updating the index so we don't overwrite the previous entry
                        currentPackItems++; // add to the number of items in the pack
                        currentPackWeight += item.weight; // add the items weight to the bag
                        currentPackVolume += item.volume; // add the items volume to the bag
                    }
                    return true;
                }
                else return false;

            }
            /// <summary>
            /// Allows for testing the inventory array for null or a particular index for null
            /// </summary>
            /// <returns>inventory array</returns>
            public InventoryItem[] GetInventory() // returns the array of InventoryItem this will give me access to the inventory checking for null.
            {
                return _inventory;
            }

            /// <summary>
            /// This creates a prefilled archers backpack
            /// </summary>
            /// <returns>predefined archers backpack</returns>
            public static Pack CreateArchersBackpack() 
            {
                Pack pack = new Pack(25, 50, 50); // new pack item is created and then prefilled with equipment ( bow, 30 arrows, 1 food, 2 water, bedroll, rope)
                pack.AddMultiple(new Water(), 2); // add two water items
                pack.Add(new Food()); // add one food item
                pack.Add(new Bow()); // add one bow item
                pack.Add(new BedRoll()); // add one bedroll
                pack.Add(new Rope()); // add a rope to the pack
                pack.AddMultiple(new Arrow(), 30); // add 30 arrows

                return pack;
            }
            /// <summary>
            /// Used to create a prefilled Swordsman Backpack
            /// </summary>
            /// <returns>predefined Swordsman Backpack</returns>
            public static Pack CreateSwordsManBackpack() // new pack item is created and then prefilled with equipment ( sword, Shield, 2 food, 2 water, bedroll, rope)
            {
                Pack pack = new Pack(30, 40, 30);
                pack.AddMultiple(new Water(), 2); // add two water items
                pack.AddMultiple(new Food(), 2); // add two food items
                pack.Add(new Sword()); // add one sword item
                pack.Add(new WoodenRoundShield()); // add one shield item
                pack.Add(new BedRoll()); // add one bedroll
                pack.Add(new Rope()); // add a rope to the pack

                return pack;
            }

            /// <summary>
            /// Used to create a prefilled Adventures Backpack
            /// </summary>
            /// <returns>predefined AdventuresBackpack</returns>
            public static Pack CreateAdventuresBackpack() // new pack item is created and then prefilled with equipment ( 5 food, 5 water, bedroll, 2 rope)
            {
                Pack pack = new Pack(50, 70, 50);
                pack.AddMultiple(new Water(), 5); // add five water items
                pack.AddMultiple(new Food(), 5); // add five food items
                pack.Add(new BedRoll()); // add one bedroll
                pack.AddMultiple(new Rope(), 2); // add two rope items

                return pack;
            }

            /// <summary>
            /// Used to create a prefilled Dugeoneers Backpack
            /// </summary>
            /// <returns>predefined Dugeoneers Backpack</returns>
            public static Pack CreateDugeoneersBackpack() 
            {
                Pack pack = new Pack(65, 90, 70);
                pack.AddMultiple(new Water(), 3); // add three water items
                pack.AddMultiple(new Food(), 3); // add three food items
                pack.Add(new BedRoll()); // add one bedroll
                pack.AddMultiple(new Rope(), 2); // add two rope items
                pack.Add(new Sword()); // add a sword
                pack.Add(new Bow()); // add a bow
                pack.Add(new WoodenRoundShield()); // add a shield
                pack.AddMultiple(new Arrow(), 20); // add 20 arrows

                return pack;
            }
            /// <summary>
            /// Overridden ToString for displaying backpack contents
            /// </summary>
            /// <returns>prebuilt string of backpack contents</returns>
            public override string ToString() // overriding the tostring method to allow the backpack contents to be displayed.
            {

                // ints below this line are used to tally item totals in the pack
                int arrows = 0;
                int bow = 0;
                int rope = 0;
                int sword = 0;
                int woodenroundshield = 0;
                int water = 0;
                int food = 0;
                int bedroll = 0;
                // end of tally ints

                
                foreach (InventoryItem item in _inventory) // used to tally totals using the (IS) keyword which checks to see if an item is a particular type or a derived type of the particular type
                {
                    if (item is Bow) // if (item.GetType() == typeof(Bow)) -> an alternative method that looks for an exact match rather than allowing a derived type
                    {
                        bow++;
                    }
                    if (item is Arrow)
                    {
                        arrows++;
                    }
                    if (item is Sword)
                    {
                        sword++;
                    }
                    if (item is WoodenRoundShield)
                    {
                        woodenroundshield++;
                    }
                    if (item is Water)
                    {
                        water++;
                    }
                    if (item is Food)
                    {
                        food++;
                    }
                    if (item is Rope)
                    {
                        rope++;
                    }
                    if (item is BedRoll)
                    {
                        bedroll++;
                    }
                }
                
                StringBuilder stringBuilder = new StringBuilder(); // used a string builder as it is faster than concatenation

                stringBuilder.Append($"Your pack contains the following items:\n");
                if (bow > 0)
                {
                    stringBuilder.Append($"Bow: {bow}\n");
                }
                if (arrows > 0)
                {
                    stringBuilder.Append($"Arrow: {arrows}\n");
                }
                if (sword > 0)
                {
                    stringBuilder.Append($"Sword: {sword}\n");
                }
                if (woodenroundshield > 0)
                {
                    stringBuilder.Append($"Wooden Round Shield: {woodenroundshield}\n");
                }
                if (rope > 0)
                {
                    stringBuilder.Append($"Rope: {rope}\n");
                }
                if (bedroll > 0)
                {
                    stringBuilder.Append($"Bedroll: {bedroll}\n");
                }
                if (water > 0)
                {
                    stringBuilder.Append($"Water: {water}\n");
                }
                if (food > 0)
                {
                    stringBuilder.Append($"Food: {food}\n");
                }

                if (arrows == 0 && bow == 0 && rope == 0 && sword == 0 && woodenroundshield == 0 && water == 0 && food == 0 && bedroll == 0) 
                {
                    return "Your backpack is empty!";
                }
                else return stringBuilder.ToString();
            }
        }
        /// <summary>
        /// Validation class for various validation requirements
        /// </summary>
        public class Validation 
        {
            /// <summary>
            /// constructor is paramaterless
            /// </summary>
            public Validation() { } // parameterless constructor

            /// <summary>
            /// Requires a valid Double from the user
            /// </summary>
            /// <param name="askUsersQuestion">Question to ask user for the double</param>
            /// <returns>valid double from users input</returns>
            public double RequireValidDouble(string askUsersQuestion) 
            {
                double toReturn; // valid double to return
                string usersInput; // users response
                Console.Write(askUsersQuestion); // qusetion to ask the user for a valid double
                usersInput = Console.ReadLine()!; // caputure users input
                while (!double.TryParse(usersInput, out toReturn)) // while you cannot parse the usersinput into a double keep going
                {
                    Console.WriteLine("Please enter a valid number! ");
                    usersInput = Console.ReadLine()!;
                }
                
                return toReturn; // return the valid double
            }

            /// <summary>
            /// Requires a valid int from the user
            /// </summary>
            /// <param name="askUsersQuestion">Question to ask user for the int</param>
            /// <returns>valid int from users input</returns>
            public int RequireValidInt(string askUsersQuestion) 
            {
                int toReturn; // valid int to return
                string usersInput; // users response
                Console.Write(askUsersQuestion); // qusetion to ask the user for a valid int
                usersInput = Console.ReadLine()!; // caputure users input
                while (!int.TryParse(usersInput, out toReturn)) // while you cannot parse the usersinput into a int keep going
                {
                    Console.WriteLine("Please enter a valid number! ");
                    usersInput = Console.ReadLine()!;
                }
                return toReturn;
            }
        
        }
    }        
}