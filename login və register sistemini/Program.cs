public class Program
{
    static void Main(string[] args)
    {
        List<LoginSystem> users = new List<LoginSystem>();
        users.Add(new LoginSystem("admin", "admin", "admin@gmail.com", "admin123"));
        Console.WriteLine("Commands You can use: \n1. /register\n2. /login\n3. /exit");
        while (true)
        
        {

            
            string command = Console.ReadLine();
            if (command == "/exit")
            {
                break;

            }
            else if (command == "/register")
            {
                Console.WriteLine("Enter Name :");
                string RegisterName = Console.ReadLine();
                bool CheckName = ResisterValidation.IsNameLengthTrue(RegisterName);

                Console.WriteLine("Enter Surname :");
                string RegisterSurname = Console.ReadLine();
                bool CheckSurname = ResisterValidation.IsSurnameTrue(RegisterSurname);

                Console.WriteLine("Enter Mail:");
                string RegisterMail = Console.ReadLine();
                bool CheckMail_one = ResisterValidation.IsMailTrue(RegisterMail);
                bool CheckMail_two = true;
                foreach (LoginSystem user in users)
                {
                    if (user._email == RegisterName)

                    {
                        CheckMail_two = false;
                    }

                }
                Console.WriteLine("Enter Password :");
                string RegisterPassword = Console.ReadLine();
   
                Console.WriteLine("Enter Password Again:");
                string RegisterPasswordAgain = Console.ReadLine();
                bool Checkpassword_one = ResisterValidation.IsPasswordTrue(RegisterPassword) ;
                bool Checkpassword_two = RegisterPassword == RegisterPasswordAgain;
                if ( CheckName && CheckSurname&& CheckMail_one  && CheckMail_two && Checkpassword_one && Checkpassword_two)
                {
               
                    users.Add(new LoginSystem(RegisterName, RegisterSurname, RegisterMail, RegisterPassword));
                    Console.WriteLine("You successfully registered, now you can login with your new account!");
                }
                else
                {   if(!CheckName)
                    {
                        Console.WriteLine("Name Length is not True");

                    }
                    if (!CheckSurname)
                    {
                        Console.WriteLine("Surname Length is not True");

                    }
                    if (!CheckMail_one)
                    {
                        Console.WriteLine("Mail is not valid");

                    }
                    if (!CheckMail_two)
                    {
                        Console.WriteLine("This email has already been registered");

                    }
                    if(!Checkpassword_one)
                    {
                        Console.WriteLine("Password cannot be Null");

                    }
                    if (!Checkpassword_two)
                    {
                        Console.WriteLine("Passwords is not same ");

                    }

                }






            }
            else if (command == "/login")
            {
                Console.WriteLine("Enter Mail:");
                string mail = Console.ReadLine();
                Console.WriteLine("Enter Password :");
                string password = Console.ReadLine();
                bool login = false;
                foreach(LoginSystem user in users)
                {
                    if(user._email == mail && password == user._password)
                    {
                        Console.WriteLine($"Welcome to your account {user._name } {user._surname}!");
                        login = true;
                    }

                }
                if(!login)
                {
                    Console.WriteLine("Please Enter valid Mail or valid Password");
                }
            }
            else
            {
                Console.WriteLine("Please , Enter valid command.");
            }


        }
    }
}
public class LoginSystem
{
    public string _name ;
    public string _surname ;
    public string _email ;
    public string _password ;
    public  LoginSystem(string name, string surname, string email, string password)
   
    {
        _name = name;
        _surname = surname;
        _email = email;
        _password = password;

    }
    
}
public class ResisterValidation 
    
{
    
    public static bool IsNameLengthTrue(string name)
    {
        if (3 <= name.Length && name.Length <= 30)
        { return true; }
        else
        { return false; }
    }
    public static bool IsSurnameTrue(string surname)
    {
        if (3 <= surname.Length && surname.Length <= 30)
        { return true; }
        else
        { return false; }
    }
    public static bool IsMailTrue(string mail)
    {

        for (int i = 0; i < mail.Length; i++)
        {
            if (mail[i] == '@')
            {
                return true;
            }
        }

        return false;
    }
    public static bool IsPasswordTrue(string password)
    {
        if (password != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

