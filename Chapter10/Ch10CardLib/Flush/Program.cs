using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ch10CardLib;

namespace Flush
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck myDeck = new Deck();
            myDeck.Shuffle();
            Random myRandom = new Random();

            Card[] fiveCard = new Card[5];
            bool noFlush = true;
            for(int i=0;i<10;++i)
            {
                bool sameSuit = true;
                int randomNum = myRandom.Next(52);
                fiveCard[0] = myDeck.GetCard(randomNum);
                for(int j=1;j<5;++j)
                {
                    randomNum = myRandom.Next(52);
                    fiveCard[j] = myDeck.GetCard(randomNum);
                    if (fiveCard[j].suit != fiveCard[0].suit)
                    {
                        sameSuit = false;
                        break;
                    }
                }
                if(sameSuit)
                {
                    noFlush = false;
                    for(int j=0;j<5;++j)
                    {
                        Console.WriteLine(fiveCard[j].ToString());
                    }
                    Console.WriteLine("Flush!");
                }
            }
            if(noFlush)
            {
                Console.WriteLine("No Flush");
            }
            Console.ReadKey();
        }
    }
}
