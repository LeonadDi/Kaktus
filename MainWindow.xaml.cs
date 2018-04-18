using DTamachi_wpf.Programming.CoreCostily;
using DTamachi_wpf.Programming.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DTamachi_wpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        Pet pet;
        
        bool b;

        public MainWindow()
        {
            InitializeComponent();
            this.Width = SystemParameters.WorkArea.Width;
            this.Height = SystemParameters.WorkArea.Height;
            this.Top = SystemParameters.WorkArea.Top;
            this.Left = SystemParameters.WorkArea.Left;


            LoadData ld = new LoadData();

            if  (File.Exists(@"save.sav"))
            {

                string[] lines = System.IO.File.ReadAllLines(@"save.sav");

                ld.setThis(
                    lines[0],
                    int.Parse(lines[1]),
                    int.Parse(lines[2]),
                    float.Parse(lines[3]),
                    float.Parse(lines[4]),
                    float.Parse(lines[5]),
                    float.Parse(lines[6]),
                    float.Parse(lines[7]),
                    float.Parse(lines[8]),
                    float.Parse(lines[9])
                    );

                pet = new Pet(mainGrid, ld);


            }
            else
            {

                pet = new Pet( mainGrid );

                using (FileStream fs = File.Create(@"save.sav"))
                { 
                    //fs.Write(info, 0, info.Length);
                }


            }
            

            b = System.Windows.Input.Mouse.Capture(this);
            
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000/60);
            timer.Start();
        }

        

//...

        private void timer_Tick(object sender, EventArgs e)
        {
            Point a = Programming.Model.MouseUstarevshy.GetMousePosition();
            Point b;
            String buffer;
            if (System.Windows.Input.Mouse.GetPosition(wind).X == 0 && System.Windows.Input.Mouse.GetPosition(wind).Y == 0
                || MouseStorage.capt)
            {
                wind.CaptureMouse();
                b = System.Windows.Input.Mouse.GetPosition(wind);
                wind.ReleaseMouseCapture();
                buffer = "\n force capture";
            }
            else
            {
                b = System.Windows.Input.Mouse.GetPosition(wind); //System.Windows.Input.Mouse.GetPosition(wind);
                buffer = "\n easy capture";
            }

           
            

            label1.Content = "Absolute/first method\n" + a.X + "\n" + a.Y + "\nwindow/second method\n" + b.X + "\n" + b.Y + "\n" + buffer +"\n";


            MouseStorage.currentMousePos = b;
            pet.Update();
            
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            

            

            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            pet.model.state = Programming.PetModel.State.Eating;
            pet.model.phase = Programming.PetModel.Phase.Beggining;
        }
    }
}
