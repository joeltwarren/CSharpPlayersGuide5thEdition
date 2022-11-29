namespace TheDominionOfKings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Three kings, Melik, Casik, and Balik, are sitting around a table, debating who has the greatest kingdom among them. Each king rules an assortment of provinces,
             * duchies, and estates. Collectively, they agree to a point system that helps them judge whose kingdom is greatest. Every estate is worth 1 point, every duchy is worth
             * 3 points, and every province is worth 6 points. They just need a program that will allow them to enter their current holdings and compute a point total.
             * 
             * Objectives:
             * Create a program that allows users to enter how many provinces, duchies, and estates they have.
             * Add up the user's total score, giving 1 point per estate, 3 per duchy, and 6 per province.
             * Display the point total to the user.
             */

            // I am going to set this up so that each king can enter an amount and display all three totals and the winner not just one user

            // King Melik's turn
            Console.WriteLine("King Melik how many estates do you own?");
            // estates count
            int meliksEstates = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("King Melik how many duchies do you own?");
            // duchies count
            int meliksDuchies = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("King Melik how many Provinces do you own?");
            // province count
            int meliksProvinces = Convert.ToInt32(Console.ReadLine());

            // tally up the totals
            int meliksTotal = (meliksEstates * 1) + (meliksDuchies * 3) + (meliksProvinces * 6);


            // King Casik's turn
            Console.WriteLine("King Casik how many estates do you own?");
            // estates count
            int casiksEstates = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("King Casik how many duchies do you own?");
            // duchies count
            int casiksDuchies = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("King Casik how many Provinces do you own?");
            // province count
            int casiksProvinces = Convert.ToInt32(Console.ReadLine());

            // tally up the totals
            int casiksTotal = (casiksEstates * 1) + (casiksDuchies * 3) + (casiksProvinces * 6);


            // King Casik's turn
            Console.WriteLine("King Balik how many estates do you own?");
            // estates count
            int balicksEstates = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("King Balik how many duchies do you own?");
            // duchies count
            int balicksDuchies = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("King Balik how many Provinces do you own?");
            // province count
            int balicksProvinces = Convert.ToInt32(Console.ReadLine());

            // tally up the totals
            int balicksTotal = (balicksEstates * 1) + (balicksDuchies * 3) + (balicksProvinces * 6);

            // display the kings totals and determine the greates kingdom
            Console.WriteLine($"King Melik your kingdom has a worth of {meliksTotal} points");
            Console.WriteLine($"King Casik your kingdom has a worth of {casiksTotal} points");
            Console.WriteLine($"King Balick your kingdom has a worth of {balicksTotal} points");

            // and determine the greatest kingdom
            // variable to hold the greatest total and a variable to hold winners name
            int greatestTotalPoints;
            string greatestWinner;
            // this is using a if statement even though we have not covered them in the book technically the above code would satifsy the original request with only one Kings answers
            if (meliksTotal > casiksTotal && meliksTotal > balicksTotal)
            {
                greatestTotalPoints = meliksTotal;
                greatestWinner = "King Melik";
            }
            else if (casiksTotal > meliksTotal && casiksTotal > balicksTotal)
            {
                greatestTotalPoints = casiksTotal;
                greatestWinner = "King Casik";
            }
            else
            {
                greatestTotalPoints = balicksTotal;
                greatestWinner = "King Balick";
            }

            Console.WriteLine($"The Greatest points belong to {greatestWinner} with a total of {greatestTotalPoints}");

            

        }
    }
}