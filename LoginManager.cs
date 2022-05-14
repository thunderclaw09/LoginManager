using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace WriteToFile
{
    public class Variables
    {
        public async void MyAsync(string ThingToAppend, string File)
        {
            StreamWriter file = new StreamWriter(File, append: true);
            await file.WriteLineAsync(ThingToAppend);
            file.Close();
        }


    }

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

            bool HasUsername = false;
            bool HasPassword = false;

            Variables variables = new Variables();

            string UsernamesFile = "Usernames.txt"; 
            string PasswordsFile = "Passwords.txt";
            string NamesFile = "Names.txt";

            string[] UsernameArray = File.ReadAllLines(UsernamesFile);
            string[] PasswordArray = File.ReadAllLines(PasswordsFile);
            string[] NameArray = File.ReadAllLines(NamesFile);

            Features features = new Features();
            int indexOfName = features.IndexOfName;






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

                Console.WriteLine("\n");
                Console.WriteLine("Please input your username:");
                Username = Console.ReadLine();

                Console.WriteLine("\n");
                Console.WriteLine("Please input your password:");
                Password = Console.ReadLine();


                for (int i = 0; i < UsernameArray.Length; i++)
                {
                    string line = UsernameArray[i];
                    if (Username == line)
                    {
                        HasUsername = true;
                        indexOfName = i;
                    }
                }

                if (HasUsername == true)
                {

                    string line = PasswordArray[indexOfName];
                    if (Password == line)
                    {
                        HasPassword = true;
                    }

                    if (HasPassword == true)
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("You have successfully logged in!");
                        Name = NameArray[indexOfName];
                        Console.WriteLine("Welcome, "+Name);

                        features.Choice();

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
                variables.MyAsync(NewUsername, UsernamesFile);

                Console.WriteLine("\n");
                Console.WriteLine("Please input your new password: ");
                NewPassword = Console.ReadLine();
                variables.MyAsync(NewPassword, PasswordsFile);

                Console.WriteLine("\n");
                Console.WriteLine("Please input your name: ");
                NewName = Console.ReadLine();
                variables.MyAsync(NewName, NamesFile);

                Console.WriteLine("\n");
                Console.WriteLine("You have successfully created an account. Restart the console to be able to log in!");

            }


            Console.WriteLine("\n");
            Console.WriteLine("Press Enter to exit...");
            Console.ReadKey();


        }



    }








    public class Features
    {
        public int IndexOfName;
        
        public void Choice()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("=============================================");
            Console.WriteLine("=============================================");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("Here are your choices:");

            Console.WriteLine("\n1 Delete your account.");
            Console.WriteLine("2 Change your name.");
            Console.WriteLine("3 Exit out of Session.");

            string ans = Console.ReadLine();

            while (ans != "1" && ans != "2" && ans!="3")
            {
                Console.WriteLine("\n");
                Console.WriteLine("Please put in a correct integer.");
                ans = Console.ReadLine();
            }

            if (ans == "1")
            {
                Console.WriteLine("---------------------------------------------");
                DeleteAccount();
            }else if (ans == "2")
            {
                Console.WriteLine("---------------------------------------------");
                ChangeName();
                Choice();
            }else if (ans == "3")
            {
                //No code goes here. This makes it exit.
            }



        }

        public void DeleteAccount()
        {
            Console.WriteLine("Are you sure you want to delete your account? Y/N");
            string Response = Console.ReadLine();

            if (Response == "Y")
            {
                List<string> UsernameFile = File.ReadAllLines("Usernames.txt").ToList();
                UsernameFile.RemoveAt(IndexOfName);
                File.WriteAllLines("Usernames.txt", UsernameFile.ToArray());

                List<string> PasswordFile = File.ReadAllLines("Passwords.txt").ToList();
                PasswordFile.RemoveAt(IndexOfName);
                File.WriteAllLines("Passwords.txt", PasswordFile.ToArray());

                List<string> NameFile = File.ReadAllLines("Names.txt").ToList();
                NameFile.RemoveAt(IndexOfName);
                File.WriteAllLines("Names.txt", NameFile.ToArray());

                Console.WriteLine("Your account was deleted successfully.");

            }else if (Response == "N")
            {
                Console.WriteLine("Ok. Exiting out of session.");
                Choice();
            }
        }

        public void ChangeName()
        {
            Console.WriteLine("Your name was changed successfully.");
        }

    }
}