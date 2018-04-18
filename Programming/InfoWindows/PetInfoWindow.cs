using DTamachi_wpf.Programming.CoreCostily;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DTamachi_wpf.Programming.Model
{
    class PetInfoWindow
    {
        StackPanel mother;
        StackPanel core = new StackPanel();
        MyInfoLabel name = new MyInfoLabel();
        MyInfoLabel hunger = new MyInfoLabel();
        MyInfoLabel health = new MyInfoLabel();
        MyInfoLabel level = new MyInfoLabel();
        MyInfoLabel exp = new MyInfoLabel();
        MyInfoLabel happines = new MyInfoLabel();
        MyInfoLabel sanity = new MyInfoLabel();
        MyInfoLabel clean = new MyInfoLabel();
        MyInfoLabel state = new MyInfoLabel();
        PetModel info;

        

        public PetInfoWindow(StackPanel mother, PetModel model)
        {
            this.mother = mother;
            info = model;

            name.FontSize = 16;
            UpdateLabels();
            
            //core.Background = Brushes.DarkRed;

            core.Children.Add(name);
            core.Children.Add(level);
            //core.Children.Add(exp);
            //core.Children.Add(state);
            //core.Children.Add(health);
            core.Children.Add(hunger);
            core.Children.Add(happines);
            //core.Children.Add(sanity);
            core.Children.Add(clean);

            mother.Children.Add(core);
        }


        public void Update()
        {
            UpdateLabels();
        }

        private void UpdateLabels()
        {
            name.Content = info.Name;
            hunger.Content = "Голод " + info.hunger.ToString("F1");
            //health.Content = "Здоровье " + info.health.ToString("F1");
            level.Content = info.level + " ур. "+info.exp+" ед.оп.";
            //exp.Content = info.exp + " ед. опыта";
            //state.Content = info.state+"/"+info.phase+"/"+info.ticksToFinish;
            happines.Content = "Настроение " + info.happines.ToString("F0");
            //sanity.Content = "Адекватность " + info.sanity;
            clean.Content = "Чистота " + info.clean.ToString("F0");
        }

        private void Remove()
        {
            mother.Children.Remove(core);
        }

    }
}
