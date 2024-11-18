using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasjans
{
    public enum Kolor
    {
        Clubs = 1,
        Spades = 2,
        Hearts = 3,
        Diamonds = 4
    }
    public enum Rank
    {
        Ace = 1,
        n2 = 2,
        n3 = 3,
        n4 = 4,
        n5 = 5,
        n6 = 6,
        n7 = 7,
        n8 = 8,
        n9 = 9,
        n10 = 10,
        Jack = 11,
        Queen = 12,
        King = 13
    }
    public class Karta
    {
        public Kolor Kolor { get; set; }
        public Rank Rank { get; set; }
        public bool Odkryta { get; set; }
        public Karta(Kolor kolor, Rank rank)
        {
            Kolor = kolor;
            Rank = rank;
            Odkryta = false;
        }
        public void Odkryj()
        {
            Odkryta = true;
        }
        public bool Barwa()
        {
            if (Kolor == (Kolor)1 || Kolor == (Kolor)2)
                return true;
            else
                return false;
        }
        public override string ToString()
        {
            if (Odkryta == false)
            {
                return "##";
            }
            else
            {
                string karta = "";
                switch (Kolor)
                {
                    case (Kolor)1:
                        {
                            karta += "♣";
                            break;
                        }
                    case (Kolor)2:
                        {
                            karta += "♠";
                            break;
                        }
                    case (Kolor)3:
                        {
                            karta += "♥";
                            break;
                        }
                    case (Kolor)4:
                        {
                            karta += "♦";
                            break;
                        }
                }
                switch (Rank)
                {
                    case (Rank)1:
                        {
                            karta += 'A';
                            break;
                        }

                    case (Rank)2:
                        {
                            karta += '2';
                            break;
                        }
                    case (Rank)3:
                        {
                            karta += '3';
                            break;
                        }
                    case (Rank)4:
                        {
                            karta += '4';
                            break;
                        }
                    case (Rank)5:
                        {
                            karta += '5';
                            break;
                        }
                    case (Rank)6:
                        {
                            karta += '6';
                            break;
                        }
                    case (Rank)7:
                        {
                            karta += '7';
                            break;
                        }
                    case (Rank)8:
                        {
                            karta += '8';
                            break;
                        }
                    case (Rank)9:
                        {
                            karta += '9';
                            break;
                        }
                    case (Rank)10:
                        {
                            karta += "10";
                            break;
                        }
                    case (Rank)11:
                        {
                            karta += 'J';
                            break;
                        }
                    case (Rank)12:
                        {
                            karta += 'Q';
                            break;
                        }
                    case (Rank)13:
                        {
                            karta += 'K';
                            break;
                        }
                }
                return karta;
            }
        }
    }
}
