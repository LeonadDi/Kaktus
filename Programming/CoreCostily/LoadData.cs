using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTamachi_wpf.Programming.CoreCostily
{
    class LoadData
    {

        public string Name;
        public int level;
        public int expirience;
        public float happines;
        public float hunger;
        public float clean;
        public float strength;
        public float perception;
        public float endurance;
        public float intellect;

        public void setThis(string n, int lvl, int exp, float hap, float hun, float cle, float str, float per, float end, float inte)
        {
            Name = n;
            level = lvl;
            expirience = exp;
            happines = hap;
            hunger = hun;
            clean = cle;
            strength = str;
            perception = per;
            endurance = end;
            intellect = inte;
        }

        


    }
}
