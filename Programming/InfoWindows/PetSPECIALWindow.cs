using DTamachi_wpf.Programming.CoreCostily;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DTamachi_wpf.Programming
{
    class PetSPECIALWindow
    {
        StackPanel mother;
        StackPanel core = new StackPanel();
        MyInfoLabel helloWorld = new MyInfoLabel();
        MyInfoLabel strength = new MyInfoLabel();
        MyInfoLabel perception = new MyInfoLabel();
        MyInfoLabel endurance = new MyInfoLabel();
        MyInfoLabel charism = new MyInfoLabel();
        MyInfoLabel intellect = new MyInfoLabel();
        MyInfoLabel agility = new MyInfoLabel();
        MyInfoLabel luck = new MyInfoLabel();
        PetModel info;

        public PetSPECIALWindow(StackPanel mother, PetModel model)
        {
            this.mother = mother;
            info = model;
            helloWorld.Content = "helloworld";

            UpdateLabels();

            //core.Background = Brushes.DarkGreen;
            core.Margin = new Thickness(20, 30, 0, 0);
            core.Children.Add(strength);
            core.Children.Add(perception);
            core.Children.Add(endurance);
            //core.Children.Add(charism);
            core.Children.Add(intellect);
            //core.Children.Add(agility);
            //core.Children.Add(luck);

            Color c = Colors.Gray;
            c.A = 100;
            core.Background = new SolidColorBrush(c);

            mother.Children.Add(core);
        }

        public void Update()
        {
            UpdateLabels();
        }

        private void UpdateLabels()
        {
            strength.Content = "Сила\t\t" + info.strength.ToString("F1");
            perception.Content = "Восприятие\t" + info.perception.ToString("F1");
            endurance.Content = "Выносливость\t" + info.endurance.ToString("F1");
            //charism.Content = "Харизма\t\t" + info.charism;
            intellect.Content = "Интеллект\t" + info.intellect.ToString("F1");
            //agility.Content = "Ловкость\t" + info.agility;
            //luck.Content = "Удача\t\t" + info.luck;
        }

    }
}
