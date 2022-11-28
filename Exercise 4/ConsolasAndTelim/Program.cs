namespace ConsolasAndTelim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * These lands have not seen Programming in a long time due to the blight of the Uncoded One. Even old programs are now curmbling to bits. Your skills
             * with Programming are only fledling now, but you can still make a difference in these people's lives. Maybe someday soon, your skills will have grown strong enough
             * to take on the Uncoded One directly. But for now, you decided to what you can to help.
             * In the nearby city of Consolas, food is running short. Telim has a magic oven that can produce bread from thin air. His is willing to share, but Telim is an
             * Execlian, and Excelians love paperwork; they demand it for all transactions - no exceptions. Telim will share his bread with the city if you can build
             * a program that lets him enther the names of those receiving it. 
             * 
             * Objectives:
             * Make a program that runs taking the name of a user and noting it out on the screen for Telim.
             */
            Console.WriteLine("Welcome to Telim's who am I servering today?");
            string user = Console.ReadLine()!;
            Console.WriteLine($"Your bread is ready {user}. Thank you come again!\n");
            Console.WriteLine("You have just gained 50XP");
            Console.WriteLine("Total XP: 200");
        }
    }
}