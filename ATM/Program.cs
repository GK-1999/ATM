using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

public class cardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;
    public cardHolder(String cardNum, int pin,String firstName,String lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }
    public String getNum() { return cardNum; }
    public int getPin() { return pin; }
    public String getFirstName() { return firstName; }
    public String getLastName() { return lastName; }
    public double getBalance() { return balance; }

    public void setNum(String newCardNum){cardNum = newCardNum;}
    public void setPin(int newpin) {pin = newpin;}
    public void setFirstName(String newfirstName) {firstName = newfirstName;}
    public void setLastName(String newlastName) {lastName = newlastName;}
    public void setBalance(double newbalance) {balance = newbalance;}

    public static void Main(String[] args)
    {
        void printOptions() 
        { 
            Console.WriteLine("Choose:\n1.Deposit\n2.Withdraw\n3.Show Balance\n4.Exit");
        }

        void deposit(cardHolder currentUser) 
        {
            Console.WriteLine("Enter the amount you want to deposit...");
            Double deposit = Double.Parse(Console.ReadLine())  + currentUser.getBalance();
            currentUser.setBalance(deposit);
            Console.WriteLine("Amount Deposited Sucessfully\nCurrent Balance : " + currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("Enter Amount to Withdraw...");
            double withdraw = Double.Parse(Console.ReadLine());

            if(withdraw > currentUser.getBalance())
            {
                Console.WriteLine("Unable to Withdraw\nInsufficient Balance..");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdraw);
                Console.WriteLine("Wintdraw Sucessful \nYou're Current Balance is "+ currentUser.getBalance());
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("You're Current Balance is " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder> ();
        cardHolders.Add(new cardHolder("999991111100000", 1111, "Miya", "Chang", 150.33));
        cardHolders.Add(new cardHolder("999991111100001", 1112, "Jaxson", "Hays", 321.45));
        cardHolders.Add(new cardHolder("999991111100002", 1113, "Elian", "Bruce", 800.96));
        cardHolders.Add(new cardHolder("999991111100003", 1114, "Violet", "Harris", 350.82));
        cardHolders.Add(new cardHolder("999991111100004", 1115, "Frida", "Jones", 950.80));

        Console.WriteLine("------------ATM------------");
        Console.WriteLine("Please Insert Your Debit Card...");
        String debitCardNum = "";

        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum );

                if (currentUser != null) { break; }
                else { Console.WriteLine("Invalid Card"); }
            }
            catch { Console.WriteLine("Card Not Recognized..."); }
        }

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;

        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());

                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Invalid Pin"); }
            }
            catch { Console.WriteLine("Incorrect Pin. Please Try again....."); }
        }

        Console.WriteLine("Welcome " + currentUser.getFirstName() + " "+ currentUser.getLastName());
        int option = 0;
        do 
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }

            switch(option)
            {
                case 1:
                    deposit(currentUser);
                    break;
                case 2:
                    withdraw(currentUser);
                    break;
                case 3:
                    balance(currentUser);
                    break;
                case 4:
                    break;

                default:
                    option = 0;
                    Console.WriteLine("Invalid Option Selected...");
                    break;
            }
        } while (option != 4);
    }
}