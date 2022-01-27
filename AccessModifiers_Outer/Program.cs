using CC_AccessModifiers_Lesson9;
using System;

namespace AccessModifiers_Outer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount ba = new BankAccount();
            ba.bankName = "from outer";
            
            MiniBankAccount mba = new MiniBankAccount("");
            mba.bankName = "asda";
            //ClassFromAnotherProject cf = new ClassFromAnotherProject();
        }
        Permission p = Permission.User;


    }

    public class BankAccount2 : BankAccount
    {
        string bank2;
        public BankAccount2()
        {
            protectedField = "";
        }
    }
}
