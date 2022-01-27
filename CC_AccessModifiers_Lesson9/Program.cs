using System;

namespace CC_AccessModifiers_Lesson9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Foo();//by instance - nonstatic
            Goo();//By Class = static
            #region Static Keyword

            Person p1 = new Person("mordi");//1
            Person p2 = new Person();//1
            Person p3 = new Person();//1
            Person p4 = new Person();//1
            Console.WriteLine(Person.counter);//1
            //p1.IncreaseCounter();//p1.Counter = 2
            //p1.IncreaseCounter();//p1.Counter = 3
            //p1.IncreaseCounter();//p1.Counter = 4
            Console.WriteLine(Person.counter);//4
            
            Person.ResetCounter();
            p3.IncreaseCounter();
            Person.IncreaseInstanceAge(p3);
            p1.Equals(p2);
            Person.Equals(p3, p4);

            Console.WriteLine();

            
            #endregion


            #region Access Modifiers
            BankAccount ba = new BankAccount();
            BankAccount ba2 = new BankAccount(Permission.User);//"User";
            Program p10 = new Program();
            //ba.pasword = 10;//Error
            Permission baPermission = ba.GetPermission();
            Permission permission = Permission.Guest;
            MiniBankAccount miniBankAccount = new MiniBankAccount("asd");
            Console.WriteLine(miniBankAccount.GetType());//MiniBankAccount
            Console.WriteLine(miniBankAccount.GetType().GetType());//RuntimeType
            ClassFromAnotherProject cfap = new ClassFromAnotherProject();

            //Enum
            string nameFromEnum = Enum.GetName(typeof(Permission), 3);//null
            string nameFromEnum2 = Enum.GetName(permission.GetType(), 10);//Guest

            int valOfName = (int)Permission.User;
            string valOfName1 = Permission.User.ToString();
            double d = 14;
            int i = (int)d;

            #endregion
        }

        public void Foo()
        {
            Console.WriteLine("by instance");
        }

        public static void Goo()
        {
            Console.WriteLine("by class");
        }
    }

    public class Student
    {
        private int id;
        private string name;
        public static int counter;

        public Student(int id, string name)
        {
            this.id = id;
            this.name = name;
            counter++;
        }

        public static void ChangeName(Student s, string newName)
        {
            s.name = newName;
        }
    }
    public class Person
    {
        public string name;
        public int age;
        public static int counter;
        public static int[] idsArray;

        public Person()
        {
            Person.counter++;
        }

        public Person(string name)
        {
            this.name = name;
        }

        static Person()
        {
            idsArray = new int[200];
            counter = 100;
        }

        public void IncreaseCounter()
        {
            counter++;
        }

        public static void ResetCounter()
        {
            counter = 0;
        }

        public static void IncreaseInstanceAge(Person p)
        {
            p.age++;
        }
    }

    public class Circle
    {
        public double radius;
        public static double pie;

        public Circle()
        {
            //pie = 3.14;
        }

        static Circle()
        {
            pie = 4.14;
        }
        public void PrintPieValue()
        {
            Console.WriteLine(pie);
        }

    }

    #region Access Modifiers
    public class BankAccount
    {
        public string bankName;
        internal string interfield;
        protected string protectedField;
        private int password;
        private Permission permission;

        public BankAccount()
        {
            password = -1;
            bankName = "mizrahi";
        }

        public BankAccount(Permission permmission)
        {
            this.permission = permmission;
        }

        public Permission GetPermission()
        {
            return permission;
        }

        public bool ChangePassword(int oldPassword, int newPassword, long id)
        {
            if (oldPassword == password && id == 1827391213)
            {
                password = newPassword;
                //Write Log...
                return true;
            }
            else
            {
                Console.WriteLine("wrong details...");
                return false;
            }
        }
        public void DoWork()
        {
            if (permission == Permission.Guest)
            {
                Console.WriteLine("guest");
                return;
            }
            else if (permission == Permission.User)
            {
                Console.WriteLine("user");
                return;
            }
            else if (permission == Permission.Administrator)
            {
                Console.WriteLine("admin");
                return;
            }
            Console.WriteLine("unkown");
        }

    }

    public class MiniBankAccount : BankAccount
    {
        //public MiniBankAccount()
        //{
        //    //password = 10; Error
        //    //bankName = "leumi";
        //}

        public MiniBankAccount TryCreateInstance(/*.....*/)
        {
            return new MiniBankAccount("asd");
        }

        public MiniBankAccount(string s)
        {
            protectedField = s;
        }
    }

    internal class ClassFromAnotherProject
    {
        public string stamSade;
    }

    public enum Permission
    {
        Guest = 10,
        User = 12,
        Administrator = 14
    }

    public class BankAccountExr
    {
        public string bankName;
        private int accountNumber;
        private double balance;

        public BankAccountExr(string bankName, int accountNumber, double balance)
        {
            this.bankName = bankName;
            if (accountNumber.ToString().Length < 7)
                this.accountNumber = accountNumber;
            else
                Console.WriteLine("account Number too long...");
            if (balance < 100000 || balance > 10000000)
                balance = 0;
            this.balance = balance;
        }

        public void WithdrawOrDepositMoney(double amount, int accountNumber, long ownerId)
        {
            if (ownerId == 0 && accountNumber == 182736912)
                balance += amount;
            else
                Console.WriteLine("wrong details...");
        }
    }

    #endregion
}
