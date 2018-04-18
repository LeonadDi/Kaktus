using DTamachi_wpf.Programming.CoreCostily;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTamachi_wpf.Programming
{
    class PetModel
    {
        public string Name;
        public float speed = 1f;

        public float verticalVelocity = 0f;

        //public float speed = 2.40f;
        public Coords cords;


        public int curX = 100;      //pixel X
        public int curY = 100;      //pixel Y
        public float X = 100;       //virtual X
        public float Y = 100;       //virtual Y
        public int offsetX;
        public int offsetY;

        

        public int width = 100;
        public int height = 500;
        /*public int xOffset = 50;
        public int yOffset = 250;*/
        public int mxOffset;
        public int myOffset;

        public State state = State.Nothing;
        public Phase phase = Phase.None;
        public MoveType movetype = MoveType.Stay;
        public int ticksToFinish = 0;

        public enum State
        {
            Nothing,
            Idle,
            Carry,
            Eating,
            Washing,
            Reading,
            Dumbbell,
            Dance
        }
        public enum Phase
        {
            None,
            Beggining,
            Process,
            Ending
        }
        public enum MoveType
        {
            Mouse,
            Static,
            Stay
        }
        
        public void setSize(Coords toSet)
        {
            width = toSet.getX();
            height = toSet.getY();
        }

        //  дефаулт
        public PetModel()
        {
            Name = "Кактус";
            /*cords = new Coords();
            cords.set(100, 100);*/

            level = 1;
            expirience = 0;
            hunger = 50;
            health = 100;
            happines = 50;
            sanity = 100;
            clean = 50;

            strength = 0;
            perception = 0;
            endurance = 0;
            charism = 999;
            intellect = 0;
            agility = 999;
            luck = 999;
        }

        //  подгрузка
        public PetModel(LoadData ld)
        {
            Name = ld.Name;
            //cords = new Coords();
            //cords.set(100, 100);

            level = ld.level;
            expirience = ld.expirience;
            hunger = ld.hunger;

            happines = ld.happines;

            clean = ld.clean;

            strength = ld.strength;
            perception = ld.perception;
            endurance = ld.endurance;
            
            intellect = ld.intellect;
            
            
        }

        public float hunger;
        public float health;
        public int level;
        private int expirience;
        public int exp
        {
            get
            {
                return expirience;
            }
            set
            {
                expirience = value;
                if (expirience >= level*100)
                {
                    expirience = expirience - level * 100;
                    level++;
                }
            }
        }
        public float happines;
        public float sanity;
        public float clean;
        //голод  V
        //здоровье  V
        //уровень
        //опыт
        //настроение
        //адекватность
        //чистота  V


        //запилить полноценную РПГ систему (спэшл)

        //сила
        //восприятие
        //выносливость
        //харизма (!?)
        //интеллект  V
        //ловкость
        //удача
        public float strength;
        public float perception;
        public float endurance;
        public float charism;
        public float intellect;
        public float agility;
        public float luck;

    }
}
