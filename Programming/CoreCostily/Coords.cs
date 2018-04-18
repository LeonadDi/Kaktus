using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTamachi_wpf.Programming.CoreCostily
{
    public class Coords
    {
        public Coords() {}
        public Coords(int xx, int yy)
        {
            x = xx;
            y = yy;
        }
        private int x, y;

        public int getX()
        {
            return x;
        }
        public void setX(int a)
        {
            x = a;
        }
        public int getY()
        {
            return y;
        }
        public void setY(int a)
        {
            y = a;
        }
        public void set(int ax, int ay) {
            x = ax;
            y = ax;
        }
    }
}
