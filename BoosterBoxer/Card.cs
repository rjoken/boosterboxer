using System;
using System.Collections.Generic;
using System.Text;

namespace BoosterBoxer
{
    public class Card
    {
        string cardID;
        string name;
        Consts.CardType cardType;
        Consts.Rarity rarity;
        Consts.Attrib attribute;
        Consts.CardClass cardClass;
        string level;
        string attack;
        string defense;
        string cardText;

        public Card(string cardID, string name, Consts.CardType cardType, Consts.Rarity rarity, Consts.Attrib attribute, 
            Consts.CardClass cardClass, string level, string attack, string defense, string cardText)
        {
            this.cardID = cardID;
            this.name = name;
            this.cardType = cardType;
            this.rarity = rarity;
            this.attribute = attribute;
            this.cardClass = cardClass;
            this.level = level;
            this.attack = attack;
            this.defense = defense;
            this.cardText = cardText;
        }

        public string displayName { get { return name; } }
        
        public string getCardID()
        {
            return cardID;
        }

        public Consts.Rarity getRarity()
        {
            return rarity;
        }

        public Consts.CardType getType()
        {
            return cardType;
        }

        public Consts.Attrib getAttrib()
        {
            return attribute;
        }

        public Consts.CardClass getClass()
        {
            return cardClass;
        }

        public string getLevel()
        {
            return level;
        }

        public string getAttack()
        {
            return attack;
        }

        public string getDefense()
        {
            return defense;
        }

        public string getCardText()
        {
            return cardText;
        }

    }
}
