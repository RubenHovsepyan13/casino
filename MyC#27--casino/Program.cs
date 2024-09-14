using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyC_27__casino
{
    class Bet
    {
        public int Amount { get; set; }

        public Bet(int amount)
        {
            Amount = amount;
        }
        public virtual bool IsWinningBet(int diceRoll)
        {
            return false;
        }
        public virtual int Payout()
        {
            return Amount * 2;
        }
    }
    class NumberBet : Bet
    {
        public NumberBet(int amount, int number) : base(amount)
        {
            Number = number;
        }
        public int Number { get; set; }
        public override bool IsWinningBet(int diceRoll)
        {
            return Number == diceRoll;
        }
        public override int Payout()
        {
            return Amount * 6;
        }
    }
    class OddBet : Bet
    {
        public OddBet(int amount) : base(amount)
        {
        }
        public override bool IsWinningBet(int diceRoll)
        {
            return diceRoll % 2 != 0;
        }
    }
    class EvenBet : Bet
    {
        public EvenBet(int amount) : base(amount)
        {
        }
        public override bool IsWinningBet(int diceRoll)
        {
            return diceRoll % 2 == 0;
        }
    }
    class Casino
    {
        private int _balance;
        public Casino(int initialBalance)
        {
            _balance = initialBalance;
        }
        public void PlaceBet(Bet bet)
        {
            if (bet.Amount > _balance)
            {
                Console.WriteLine("Anbavarar mijocner");
                return;
            }
            _balance -= bet.Amount;
            Random random = new Random();
            int randomNumber = random.Next(1, 7);
            if (bet.IsWinningBet(randomNumber))
            {
                Console.WriteLine($"Number: {randomNumber}");
                Console.WriteLine("You Wine");
                _balance += bet.Payout();
            }
            else
            {
                Console.WriteLine($"Number: {randomNumber}");
                Console.WriteLine("You Lose");
            }
        }
        public void ShowBalance()
        {
            Console.WriteLine($"Your balance: {_balance}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("kodem avelacre");
            Casino balance = new Casino(1000);
            int yntrutyun;
            Console.WriteLine("stexe");
            do
            {
                balance.ShowBalance();
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("Yntri xaxy");
                Console.WriteLine();
                Console.WriteLine("1 : Zar");
                Console.WriteLine();
                Console.WriteLine("2 : zuyg");
                Console.WriteLine();
                Console.WriteLine("3 : kent");
                Console.WriteLine();
                Console.WriteLine("0 : Exit");
                Bet bet = null;

                yntrutyun = Convert.ToInt32(Console.ReadLine());
                if (yntrutyun == 1)
                {
                    Console.WriteLine("yntri 1 - 6 mihat tiv");
                    int tiv = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("stavket");
                    int stavka = Convert.ToInt32(Console.ReadLine());
                    bet = new NumberBet(stavka, tiv);
                }
                else if (yntrutyun == 2)
                {
                    Console.WriteLine("stavket");
                    int stavka = Convert.ToInt32(Console.ReadLine());
                    bet = new EvenBet(stavka);
                }
                else if (yntrutyun == 3)
                {
                    Console.WriteLine("stavket");
                    int stavka = Convert.ToInt32(Console.ReadLine());
                    bet  = new OddBet(stavka);
                }
                else
                {
                    Console.WriteLine("Mersi xaxi hamr");
                }
               balance.PlaceBet(bet);
            }
            while (yntrutyun != 0);
        }
    }
}
