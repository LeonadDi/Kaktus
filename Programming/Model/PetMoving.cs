using DTamachi_wpf.Programming.CoreCostily;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTamachi_wpf.Programming.Model
{
    public class PetMoving
    {



        public Coords getCenter(Coords cords, int width, int height)
        {
            Coords toReturn = new Coords();
            toReturn.setX(cords.getX() + (width / 2));
            toReturn.setY(cords.getY() + (height / 2));

            return toReturn;
        }





    }
}
