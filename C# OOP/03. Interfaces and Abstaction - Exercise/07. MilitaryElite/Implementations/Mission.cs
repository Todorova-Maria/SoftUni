﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MilitaryElite
{
    public class Mission : IMission
    {
        public Mission(string codeName, State state)
        {
            CodeName = codeName;
            State = state;
        }

        public string CodeName { get; set; }
        public State State { get; set; }

       

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State}";
        }
    }
}
