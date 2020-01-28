using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace BoosterBoxer
{
    public static class Consts
    {
        public enum CardType
        {
            [StringValue("Normal Monster")] NormalMonster,
            [StringValue("Effect Monster")] EffectMonster,
            [StringValue("Fusion Monster")] FusionMonster,
            [StringValue("Fusion/Effect Monster")] FusionEffectMonster,
            [StringValue("Toon Monster")] ToonMonster,
            [StringValue("Ritual Monster")] RitualMonster,
            [StringValue("Ritual/Effect Monster")] RitualEffectMonster,
            [StringValue("Union Monster")] UnionMonster,
            [StringValue("Spirit Monster")] SpiritMonster,
            [StringValue("Gemini Monster")] GeminiMonster,
            [StringValue("Synchro Monster")] SynchroMonster,
            [StringValue("Synchro/Effect Monster")] SynchroEffectMonster,
            [StringValue("Tuner Monster")] TunerMonster,
            [StringValue("Tuner/Effect Monster")] TunerEffectMonster,
            [StringValue("Spell")] Spell,
            [StringValue("Trap")] Trap,
            [StringValue("")] Null
        }

        public enum Rarity
        {
            [StringValue("Secret Rare")] SecretRare,
            [StringValue("Ultra Rare")] UltraRare,
            [StringValue("Ultra Rare/Ulti")] UltraUltimate,
            [StringValue("Super Rare")] SuperRare,
            [StringValue("Super Rare/Ulti")] SuperUltimate,
            [StringValue("Rare")] Rare,
            [StringValue("Rare/Ultimate R")] RareUltimate,
            [StringValue("Short-Print Com")] ShortPrint,
            [StringValue("Super Short-Pri")] SuperShortPrint,
            [StringValue("Common")] Common,
            [StringValue("")] Null,
        }

        public enum Attrib
        {
            [StringValue("Dark")] Dark,
            [StringValue("Light")] Light,
            [StringValue("Earth")] Earth,
            [StringValue("Fire")] Fire,
            [StringValue("Water")] Water,
            [StringValue("Wind")] Wind,
            [StringValue("")] Null,
        }

        public enum CardClass
        {
            [StringValue("Aqua")] Aqua,
            [StringValue("Beast")] Beast,
            [StringValue("Beast-Warrior")] BeastWarrior,
            [StringValue("Dinosaur")] Dinosaur,
            [StringValue("Dragon")] Dragon,
            [StringValue("Fairy")] Fairy,
            [StringValue("Fiend")] Fiend,
            [StringValue("Fish")] Fish,
            [StringValue("Insect")] Insect,
            [StringValue("Machine")] Machine,
            [StringValue("Plant")] Plant,
            [StringValue("Psychic")] Psychic,
            [StringValue("Pyro")] Pyro,
            [StringValue("Reptile")] Reptile,
            [StringValue("Rock")] Rock,
            [StringValue("Sea Serpent")] SeaSerpent,
            [StringValue("Spellcaster")] Spellcaster,
            [StringValue("Thunder")] Thunder,
            [StringValue("Warrior")] Warrior,
            [StringValue("Winged Beast")] WingedBeast,
            [StringValue("Wyrm")] Wyrm,
            [StringValue("Zombie")] Zombie,
            [StringValue("Continuous")] Continuous,
            [StringValue("Equip")] Equip,
            [StringValue("Quick-Play")] QuickPlay,
            [StringValue("Field")] Field,
            [StringValue("Ritual")] Ritual,
            [StringValue("Counter")] Counter,
            [StringValue("")] Null,
        }

        public static CardType getCardTypeByStringValue(string stringValue)
        {
            foreach(CardType t in Enum.GetValues(typeof(CardType)))
            {
                string tstring = GetStringValue(t);
                if(stringValue == tstring)
                {
                    return t;
                }
            }
            return CardType.Null;
        }

        public static Rarity getRarityByStringValue(string stringValue)
        {
            foreach (Rarity r in Enum.GetValues(typeof(Rarity)))
            {
                string rstring = GetStringValue(r);
                if (stringValue == rstring)
                {
                    return r;
                }
            }
            return Rarity.Null;
        }

        public static Attrib getAttribByStringValue(string stringValue)
        {
            foreach (Attrib a in Enum.GetValues(typeof(Attrib)))
            {
                string astring = GetStringValue(a);
                if (stringValue == astring)
                {
                    return a;
                }
            }
            return Attrib.Null;
        }

        public static CardClass getClassByStringValue(string stringValue)
        {
            foreach (CardClass c in Enum.GetValues(typeof(CardClass)))
            {
                string cstring = GetStringValue(c);
                if (stringValue == cstring)
                {
                    return c;
                }
            }
            return CardClass.Null;
        }

        public static string GetStringValue(Enum value)
        {
            string output = null;
            Type type = value.GetType();

            FieldInfo fi = type.GetField(value.ToString());
            StringValue[] attrs = fi.GetCustomAttributes(typeof(StringValue),false) as StringValue[];
            if (attrs.Length > 0)
            {
                output = attrs[0].Value;
            }

            return output;
        }
    }
}
