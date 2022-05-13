using System;

namespace WriteToFile
{
    
    public class Program
    {
        
        public static void Main(string[] args)
        {

            String Answer;

            // Console.WriteLine("Testing. Does this work?");

            //START THE MESSAGE
            Console.WriteLine("Welcome to Login Manager!");
            Console.WriteLine("Do you want to log into an existing account? (N for creating a new account.) Y/N");
            Answer = Console.ReadLine();


            //CHECKING FOR ANSWER
            while (Answer != "Y" && Answer != "N")
            {
                Console.WriteLine("[Please input a correct Value (Y or N). (Case sensitive)]");
                Console.WriteLine("Do you want to log into an existing account? (N for creating a new account.) Y/N");
                Answer = Console.ReadLine();
            }
            if (Answer == "Y")
            {
                Console.WriteLine("You have logged in!");
            }else if (Answer == "N")
            {
                Console.WriteLine("You have created a new account!");
            }


            


            Console.ReadKey();

            
        }

        // void StartMessage()
        // {
        //     Console.WriteLine("Welcome to Login Manager!");
        //     Console.WriteLine("Do you want to log into an existing account? (N for creating a new account.) Y/N");
        //     Answer = Console.ReadLine();
        // }

        // void LoginOrCreate()
        // {
        //     while (Answer != "Y" || Answer != "N")
        //     {
        //         Console.WriteLine("[Please input a correct Value (Y or N). (Case sensitive)]");
        //     }
        //     if (Answer == "Y")
        //     {
        //         Console.WriteLine("You have logged in!");
        //     }else if (Answer == "N")
        //     {
        //         Console.WriteLine("You have created a new account!");
        //     }
        // }

    }
}