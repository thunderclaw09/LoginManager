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

            string Username;
            string Password;

            string UsernameFile = "Usernames.txt";
            string PasswordsFile = "Passwords.txt";
            string NamesFile = "Names.txt";

            bool HasUsername = false;
            bool HasPassword = false;

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
                // Console.WriteLine("You have logged in!");
                //string[] lines = File.ReadAllLines("Data.txt");
                // for(int i = 0; i < lines.Length; i++)
                // {
                //     Console.WriteLine(lines[i]);
                // }

                Console.WriteLine("Please input your username:");
                Username = Console.ReadLine();
                
                Console.WriteLine("Please input your password:");
                Password = Console.ReadLine();

                string[] UsernameArray = File.ReadAllLines(UsernameFile);

                for (int i = 0; i < UsernameArray.Length; i++)
                {
                    string line = UsernameArray[i];
                    if (Username == line)
                    {
                        Console.WriteLine("You have a username entry!");
                        HasUsername = true;
                    }
                }

                if (HasUsername == true)
                {
                    Console.WriteLine("You are now logged in! (No password yet.)");
                }else
                {
                    Console.WriteLine("You either do not have an account yet or you didn't put in your username correctly.");
                }




            }else if (Answer == "N")
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Welcome to the account setup wizard!");

                Console.WriteLine("Please input your new username: ");
                NewUsername = Console.ReadLine();
                MyAsync(NewUsername, UsernameFile);
                

                Console.WriteLine("Please input your new password: ");
                NewPassword = Console.ReadLine();
                MyAsync(NewPassword, PasswordsFile);

                Console.WriteLine("Please input your name: ");
                NewName = Console.ReadLine();
                MyAsync(NewName, NamesFile);
                
            }

     

            Console.WriteLine("Press Enter to continue...");
            Console.ReadKey();

            
        }

        public static async void MyAsync(string ThingToAppend, string File)
        {
            StreamWriter file = new StreamWriter(File, append: true);
            await file.WriteLineAsync(ThingToAppend);
            file.Close();
        }






    }
}