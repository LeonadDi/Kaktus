using DTamachi_wpf.Programming.CoreCostily;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace DTamachi_wpf.Programming.Model
{
    class PetWindow
    {
        Grid mother;
        Border border;
        PetModel model;
        StackPanel core;
        Button eat_Button;
        Button wash_Button;
        Button read_Button;
        Button dance_Button;
        Button dumbbell_Button;
        private StackPanel forContent = new StackPanel();
        private StackPanel forButtons = new StackPanel();

       

        PetInfoWindow pw;
        PetSPECIALWindow ps;

        public PetWindow(Grid mother, PetModel model)
        {
            this.mother = mother;
            this.model = model;
            core = new StackPanel();
            coreSet();

            forContent.Orientation = Orientation.Horizontal;

            pw = new PetInfoWindow(forContent, model);
            ps = new PetSPECIALWindow(forContent, model);


            eat_Button = new DButton();
            eat_Button.Content = "Еда";
            eat_Button.PreviewMouseLeftButtonDown += eat_Button_e;
            forButtons.Children.Add(eat_Button);

            wash_Button = new DButton();
            wash_Button.Content = "Купание";
            wash_Button.PreviewMouseLeftButtonDown += wash_Button_e;
            forButtons.Children.Add(wash_Button);

            read_Button = new DButton();
            read_Button.Content = "Книга";
            read_Button.PreviewMouseLeftButtonDown += read_Button_e;
            forButtons.Children.Add(read_Button);

            /*dance_Button = new DButton();
            dance_Button.Content = "Танцевать";
            dance_Button.PreviewMouseLeftButtonDown += dance_Button_e;
            forButtons.Children.Add(dance_Button);*/

            dumbbell_Button = new DButton();
            dumbbell_Button.Content = "Гантели";
            dumbbell_Button.PreviewMouseLeftButtonDown += dumbbell_Button_e;
            forButtons.Children.Add(dumbbell_Button);

            /*Button idle = new Button();
            idle.Content = "Неподвижно";
            idle.PreviewMouseLeftButtonDown += set_idle;
            Button follow_Mouse = new Button();
            follow_Mouse.Content = "Следовать за мышью";
            follow_Mouse.PreviewMouseLeftButtonDown += set_follow;*/
            //Button random_Movement = new Button();
            //random_Movement.Content = "Произвольное перемещение";
            //random_Movement.PreviewMouseLeftButtonDown += set_follow;

            /*StackPanel move_types = new StackPanel();
            move_types.Orientation = Orientation.Horizontal;
            move_types.Children.Add(idle);
            move_types.Children.Add(follow_Mouse);
            //move_types.Children.Add(random_Movement);
            forButtons.Children.Add(move_types);*/


            border = new Border();
            //border.BorderBrush = Brushes.Red;
            border.BorderBrush = Brushes.DarkGray;
            border.BorderThickness = new Thickness(4);
            border.CornerRadius = new CornerRadius(10);
            border.Padding = new Thickness(10);
            //Color c = Colors.DarkRed;
            Color c = Colors.LightGray;
            c.A = 230;
            border.Background = new SolidColorBrush(c);//Brushes.DarkCyan;
            //border.Opacity = 0.5;
            border.Width = core.Width;//300;
            border.VerticalAlignment = VerticalAlignment.Top;
            border.HorizontalAlignment = HorizontalAlignment.Left;

            Thickness margin = core.Margin;
            margin.Left = model.X - 150;
            margin.Top = model.Y - 430;
            border.Margin = margin;

            core.Children.Add(forContent);
            core.Children.Add(forButtons);
            border.Child = core;

            border.Height = core.Height;

            mother.Children.Add(border);

        }
        
        public void Update()
        {
            pw.Update();
            ps.Update();
        }

        public void Remove()
        {
            mother.Children.Remove(border);
        }

        private void coreSet()
        {
            Thickness margin = core.Margin;
            margin.Left = model.X + 0;
            margin.Top = model.Y - 100;
            //core.Width = 400;
            //core.Margin = margin;
            //border.Margin = margin;
            core.VerticalAlignment = VerticalAlignment.Top;
            core.HorizontalAlignment = HorizontalAlignment.Left;
            //core.Background = Brushes.DarkRed;
        }

        private void eat_Button_e(object sender, System.EventArgs e)
        {
            model.state = Programming.PetModel.State.Eating;
            model.phase = Programming.PetModel.Phase.Beggining;
        }
        private void wash_Button_e(object sender, System.EventArgs e)
        {
            model.state = Programming.PetModel.State.Washing;
            model.phase = Programming.PetModel.Phase.Beggining;
        }
        private void read_Button_e(object sender, System.EventArgs e)
        {
            model.state = Programming.PetModel.State.Reading;
            model.phase = Programming.PetModel.Phase.Beggining;
        }
        private void dumbbell_Button_e(object sender, System.EventArgs e)
        {
            model.state = Programming.PetModel.State.Dumbbell;
            model.phase = Programming.PetModel.Phase.Beggining;
        }
        /*private void dance_Button_e(object sender, System.EventArgs e)
        {
            model.state = Programming.PetModel.State.Dance;
            model.phase = Programming.PetModel.Phase.Beggining;
        }*/
        private void set_idle(object sender, System.EventArgs e)
        {
            model.movetype = PetModel.MoveType.Stay;
        }
        private void set_follow(object sender, System.EventArgs e)
        {
            model.movetype = PetModel.MoveType.Mouse;
        }

        public void set_Starter(int X, int Y) {

        }
    }
    
}
