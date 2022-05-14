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
            string Name;

            string UsernamesFile = "Usernames.txt";
            string PasswordsFile = "Passwords.txt";
            string NamesFile = "Names.txt";

            bool HasUsername = false;
            bool HasPassword = false;

            int IndexOfName = 0;



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

                Console.WriteLine("\n");
                Console.WriteLine("Please input your username:");
                Username = Console.ReadLine();
                
                Console.WriteLine("\n");
                Console.WriteLine("Please input your password:");
                Password = Console.ReadLine();

                string[] UsernameArray = File.ReadAllLines(UsernamesFile);
                string[] PasswordArray = File.ReadAllLines(PasswordsFile);
                string[] NameArray = File.ReadAllLines(NamesFile);

                for (int i = 0; i < UsernameArray.Length; i++)
                {
                    string line = UsernameArray[i];
                    if (Username == line)
                    {
                        // Console.WriteLine("\n");
                        // Console.WriteLine("You have a username entry!");
                        HasUsername = true;
                        IndexOfName = i;
                    }
                }

                if (HasUsername == true)
                {
                    // Console.WriteLine("You are now logged in! (No password yet.)");
                    // for (int i = 0; i < PasswordArray.Length; i++)
                    // {
                    //     string line = PasswordArray[i];
                    //     if (Password == line)
                    //     {
                    //         // Console.WriteLine("You have a password entry!");
                    //         HasPassword = true;
                    //     }
                    // }

                    string line = PasswordArray[IndexOfName];
                    if (Password == line)
                    {
                        HasPassword = true;
                    }

                    if (HasPassword == true)
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("You have successfully logged in!");
                        Name = NameArray[IndexOfName];
                        Console.WriteLine("Welcome, "+Name);
                    }else
                    {
                        Console.WriteLine("You have not put in a correct password.");
                    }
                    
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
                MyAsync(NewUsername, UsernamesFile);
                
                Console.WriteLine("\n");
                Console.WriteLine("Please input your new password: ");
                NewPassword = Console.ReadLine();
                MyAsync(NewPassword, PasswordsFile);

                Console.WriteLine("\n");
                Console.WriteLine("Please input your name: ");
                NewName = Console.ReadLine();
                MyAsync(NewName, NamesFile);

                Console.WriteLine("\n");
                Console.WriteLine("You have successfully created an account. Restart the console to be able to log in!");
                
            }

     
            Console.WriteLine("\n");
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