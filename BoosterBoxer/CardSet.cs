using System;
using System.Collections.Generic;
using System.Text;

namespace BoosterBoxer
{
    public class CardSet
    {
        private string name;
        private string abbreviation;
        private int cardsPerPack;

        public CardSet(string _name, string _abbreviation, int _cpp)
        {
            name = _name;
            abbreviation = _abbreviation;
            cardsPerPack = _cpp;
        }

        public string toString
        {
            get { return $"{name} ({abbreviation})"; }
        }
        
        public string getName
        {
            get { return name; }
        }

        public string getAbbreviation
        {
            get { return abbreviation; }
        }

        public int getCardsPerPack()
        {
            return cardsPerPack;
        }
    }
}
