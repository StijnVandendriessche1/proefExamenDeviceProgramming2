using System;
using System.Collections.Generic;
using System.Text;

namespace proefExamen.Models
{
    public class Area
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
