using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace Cvicenie_Pokemon
{
    /// <summary>
    /// Interaction logic for Window_Fight.xaml
    /// </summary>
    public partial class Window_Fight : Window
    {
        //public Window_Fight(string myText)

        public Hero MyActualHero { get; set; }
        public Enemy Enemy { get; set; }
        public Window_Fight(Hero hero, Enemy enemy)
        {
            InitializeComponent();
            //Label_myText.Content = myText;

            MyActualHero = hero;
            Enemy = enemy;


            ProgressBar_Hero.Value = hero.Health;
            ProgressBar_Hero.Maximum = hero.Health_Max;

            ProgressBar_Enemy.Value = enemy.Health_Max;
            ProgressBar_Enemy.Maximum = enemy.Health_Max;

            ProgressBar_Energy.Value = hero.Energy;
            ProgressBar_Energy.Maximum = hero.Energy;
        }

        private void ProgressBar_Hero_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            HeroAttackEnemy(1);
            EnemyAttackHero();
            CheckHealthStatus();

        }
        private void HeroAttackEnemy(int damageScale)
        {
            
            if (MyActualHero.Energy < 0)
            {
                Label_GameStatus.Content = "Nemas energiu";
                return;
            }
            else
            {
                Enemy.Health_Max -= MyActualHero.Health_Max * damageScale;
                ProgressBar_Enemy.Value = Enemy.Health_Max;
                MyActualHero.Energy -= 500 * damageScale;
                ProgressBar_Energy.Value = MyActualHero.Energy;
            }
        }

        private void EnemyAttackHero()
        {
            MyActualHero.Health -= Enemy.Damage;
            ProgressBar_Hero.Value = MyActualHero.Health;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            HeroAttackEnemy(2);
            EnemyAttackHero();
            CheckHealthStatus();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            HeroAttackEnemy(5);
            EnemyAttackHero();
            CheckHealthStatus();
        }
        private void CheckHealthStatus()
        {
            if (MyActualHero.Health <= 0)
            {
                Label_GameStatus.Content = "Loser";
            }
            if (Enemy.Health_Max <= 0)
            {
                Label_GameStatus.Content = "Winner";
            }
        }
    }
}
