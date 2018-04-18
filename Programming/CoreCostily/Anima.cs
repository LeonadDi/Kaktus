using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace DTamachi_wpf.Programming.CoreCostily
{
    class Anima
    {

        BitmapImage[] a;// = new BitmapImage[20];
        int cur = 0;
        int ticksToWait = 60/3;
        int passed = 0;

        private Coords fq;

        public Anima(string param)
        {

            switch (param)
            {
                case "carry":
                    a = new BitmapImage[1];
                    a[0] = new BitmapImage(new Uri("Graphics/Carry/carry.png", UriKind.Relative));
                    ticksToWait = 60 / 3;
                    break;
                case "idle":
                    a = new BitmapImage[2];
                    a[0] = new BitmapImage(new Uri("Graphics/Idle/idle1.png", UriKind.Relative));
                    a[1] = new BitmapImage(new Uri("Graphics/Idle/idle2.png", UriKind.Relative));
                    ticksToWait = 60 / 3;
                    break;

                case "eat":
                    a = new BitmapImage[2];
                    a[0] = new BitmapImage(new Uri("Graphics/Eat/eat1.png", UriKind.Relative));
                    a[1] = new BitmapImage(new Uri("Graphics/Eat/eat2.png", UriKind.Relative));
                    ticksToWait = 60 / 3;
                    break;

                case "walk":
                    a = new BitmapImage[2];
                    a[0] = new BitmapImage(new Uri("Graphics/Walk/walk1.png", UriKind.Relative));
                    a[1] = new BitmapImage(new Uri("Graphics/Walk/walk2.png", UriKind.Relative));
                    ticksToWait = 60 / 3;
                    break;

                case "fall":
                    a = new BitmapImage[1];
                    a[0] = new BitmapImage(new Uri("Graphics/Fall/fall.png", UriKind.Relative));
                    ticksToWait = 60 / 3;
                    break;


                case "nap":
                    a = new BitmapImage[2];
                    a[0] = new BitmapImage(new Uri("Graphics/Nap/nap1.png", UriKind.Relative));
                    a[1] = new BitmapImage(new Uri("Graphics/Nap/nap2.png", UriKind.Relative));
                    ticksToWait = 60 / 1;
                    break;

                case "wash":
                    a = new BitmapImage[2];
                    a[0] = new BitmapImage(new Uri("Graphics/Wash/wash1.png", UriKind.Relative));
                    a[1] = new BitmapImage(new Uri("Graphics/Wash/wash2.png", UriKind.Relative));
                    ticksToWait = 60 / 3;
                    break;

                case "read":
                    a = new BitmapImage[6];
                    a[0] = new BitmapImage(new Uri("Graphics/Read/read1.png", UriKind.Relative));
                    a[1] = new BitmapImage(new Uri("Graphics/Read/read2.png", UriKind.Relative));
                    a[2] = new BitmapImage(new Uri("Graphics/Read/read1.png", UriKind.Relative));
                    a[3] = new BitmapImage(new Uri("Graphics/Read/read2.png", UriKind.Relative));
                    a[4] = new BitmapImage(new Uri("Graphics/Read/read3.png", UriKind.Relative));
                    a[5] = new BitmapImage(new Uri("Graphics/Read/read4.png", UriKind.Relative));
                    ticksToWait = 60 / 3;
                    break;

                case "dumbbell":
                    a = new BitmapImage[2];
                    a[0] = new BitmapImage(new Uri("Graphics/Dumbbell/dumbbell1.png", UriKind.Relative));
                    a[1] = new BitmapImage(new Uri("Graphics/Dumbbell/dumbbell2.png", UriKind.Relative));
                    ticksToWait = 60 / 3;
                    break;

                case "dance":
                    a = new BitmapImage[1];
                    a[0] = new BitmapImage(new Uri("Graphics/secpic.jpg", UriKind.Relative));
                    ticksToWait = 60 / 3;
                    break;

                default:
                    break;
            }

        }

        public Anima()
        {
            //a[0] = new BitmapImage(new Uri("Graphics/cat.png", UriKind.Relative));

            /*a[0] = new BitmapImage(new Uri("Graphics/Eat/1.png", UriKind.Relative));
            a[1] = new BitmapImage(new Uri("Graphics/Eat/2.png", UriKind.Relative));
            a[2] = new BitmapImage(new Uri("Graphics/Eat/3.png", UriKind.Relative));
            a[3] = new BitmapImage(new Uri("Graphics/Eat/4.png", UriKind.Relative));*/
            /*petSprite.Source = new BitmapImage(
                new Uri("Graphics/original.gif", UriKind.Relative));*/
        }

        public void start()
        {
            cur = 0;
            passed = 0;
        }

        public Coords getSize()
        {
            fq = new Coords();

            int e = a[0].PixelWidth;
            int f = a[0].PixelHeight;

            fq.setX(e);
            fq.setY(f);
            return fq;
        }

        public BitmapImage getNext()
        {

            if (passed >= ticksToWait)
            {
                passed = 0;
                if (cur < a.Length)
                {
                    return a[cur++];
                }
                else
                {
                    cur = 0;
                    return a[cur];
                }

            }
            passed++;

            if (cur>=a.Length){cur = 0;}
            
            return a[cur];
            
        }




    }
}
