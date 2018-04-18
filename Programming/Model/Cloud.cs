using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace DTamachi_wpf.Programming.Model
{
    class Cloud
    {
        PetModel model;
        Image cloud;
        public BitmapImage[] a;
        private CloudAction NeedToDisplay = CloudAction.Nothing;
        enum CloudAction
        {
            Nothing,
            Hungry,
            Unclean
        }

        public Cloud(PetModel model, Image cloud)
        {
            
            this.cloud = cloud;
            this.model = model;

            a = new BitmapImage[3];
            a[0] = new BitmapImage(new Uri("Graphics/Clouds/cloud1.png", UriKind.Relative));
            a[1] = new BitmapImage(new Uri("Graphics/Clouds/cloud2.png", UriKind.Relative));
            a[2] = new BitmapImage(new Uri("Graphics/Clouds/cloud3.png", UriKind.Relative));
            
        }



        public void Update()
        {
            cloud.Width = 80;
            cloud.Height= 70;
            Thickness margin = cloud.Margin;

            margin.Left = model.curX + model.offsetX + 20;
            margin.Top = model.curY - model.height - 20;

            cloud.Margin = margin;


            if (model.hunger > 40)
            {
                NeedToDisplay = CloudAction.Hungry;
            }
            else if (model.clean < 40)
            {
                NeedToDisplay = CloudAction.Unclean;
            }
            else
            {
                NeedToDisplay = CloudAction.Nothing;
            }
        }

        public void getCloud()
        {
            switch (NeedToDisplay)
            {
                case CloudAction.Nothing:
                    cloud.Source = null;
                    break;
                case CloudAction.Hungry:
                    cloud.Source = a[1];
                    break;
                case CloudAction.Unclean:
                    cloud.Source = a[0];
                    break;
                default:
                    break;
            }
        }
       



    }
}
