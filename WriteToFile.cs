using System;
using System.IO;
using System.Threading.Tasks;

namespace WriteToFile
{
    
    public class Program
    {
        
        public static void Main(string[] args)
        {

            string Answer;
            string NewUsername;
            string NewPassword;
            string NewName;
            // string File = "Data.txt";

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
                //Console.WriteLine("You have created a new account!");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Welcome to the account setup wizard!");

                Console.WriteLine("Please input your new username: ");
                NewUsername = Console.ReadLine();
                // await File.WriteAllTextAsync("WriteText.txt", NewUsername);
                MyAsync(NewUsername);
                

                Console.WriteLine("Please input your new password: ");
                NewPassword = Console.ReadLine();
                //await File.WriteAllTextAsync("WriteText.txt", NewPassword);
                MyAsync(NewPassword);

                Console.WriteLine("Please input your name: ");
                NewName = Console.ReadLine();
                //await File.WriteAllTextAsync("WriteText.txt", NewName);
                MyAsync(NewName);
                
            }

     


            Console.ReadKey();

            
        }


        // public static async Task MyAsync(string ThingToAppend)
        // {
        //     StreamWriter file = new StreamWriter("Data.txt", append: true);
        //     await file.WriteLineAsync(ThingToAppend);
        //     //file.WriteLineAsync(ThingToAppend); 
        //     file.Close();
        // }

        public static async void MyAsync(string ThingToAppend)
        {
            StreamWriter file = new StreamWriter("Data.txt", append: true);
            await file.WriteLineAsync(ThingToAppend);
            //file.WriteLineAsync(ThingToAppend); 
            file.Close();
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