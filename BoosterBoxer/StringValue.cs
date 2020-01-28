using System;
using System.Collections.Generic;
using System.Text;

namespace BoosterBoxer
{
    public class StringValue : System.Attribute
    {
        private readonly string value;

        public StringValue(string _value)
        {
            value = _value;
        }

        public string Value
        {
            get { return value; }
        }
    }
}
