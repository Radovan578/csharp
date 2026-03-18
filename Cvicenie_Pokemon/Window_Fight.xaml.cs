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
        int round;
        int roundsToHard = 0;

        private readonly Brush off = Brushes.DimGray;
        private readonly Brush red = Brushes.Red;
        private readonly Brush yellow = Brushes.Yellow;
        private readonly Brush green = Brushes.Green;
        public Window_Fight(Hero hero, Enemy enemy)
        {
            InitializeComponent();
            //Label_myText.Content = myText;

            MyActualHero = hero;
            Enemy = enemy;


            ProgressBar_Hero.Value = hero.Health_Max;
            ProgressBar_Hero.Maximum = hero.Health_Max;

            ProgressBar_Enemy.Value = enemy.Health_Max;
            ProgressBar_Enemy.Maximum = enemy.Health_Max;

            ProgressBar_Energy.Value = hero.Energy;
            ProgressBar_Energy.Maximum = hero.Energy;
            HPLabels();
        }
        private void SetAllOff()
        {
            ProgressBar_Hero.Foreground = off;
            ProgressBar_Hero.Foreground = off;
            ProgressBar_Hero.Foreground = off;
        }
        private void HPLabels()
        {
            Label_HeroHP.Content = $"{MyActualHero.Health} / {MyActualHero.Health_Max}";
            Label_EnemyHP.Content = $"{Enemy.Health_Max} / {Enemy.Health_Max}";
        }
        
        private void ProgressBar_Hero_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            if (ProgressBar_Hero.Value > 50)
            {
                ProgressBar_Hero.Foreground = green;
            }
            else if (ProgressBar_Hero.Value <= 50)
            {
                ProgressBar_Hero.Foreground = yellow;
            }
            else if (MyActualHero.Health <= 30)
            {
                ProgressBar_Hero.Foreground = red;
            }
            else if (ProgressBar_Enemy.Value <= 0)
            {
                SetAllOff();
            }
        }
        private void ProgressBar_Enemy_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            if (ProgressBar_Enemy.Value > 50)
            {
                ProgressBar_Enemy.Foreground = green;
            }
            else if (ProgressBar_Enemy.Value <= 50)
            {
                ProgressBar_Enemy.Foreground = yellow;
            }
            else if (ProgressBar_Enemy.Value <= 30)
            {
                ProgressBar_Hero.Foreground = red;
            }
            else if (ProgressBar_Enemy.Value <= 0)
            {
                SetAllOff();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            roundsToHard--;
            HeroAttackEnemy(1);
            EnemyAttackHero();
            CheckHealthStatus();
            HPLabels();
        }
        private void HeroAttackEnemy(int damagescale)
        {
            round++;

            int critical = 3;
            Random random = new Random();
            Random randomMiss = new Random();

            int missChance = randomMiss.Next(1, 4);
            int CriticalDMGchance = random.Next(0, 11);
            if (missChance == 3)
            {
                MessageBox.Show("Netrafil si");

                MyActualHero.Energy -= 10;
                ProgressBar_Energy.Value = MyActualHero.Energy;
                HPLabels();
                return;

            }
            else
            {
                if (MyActualHero.Energy <= 0)
                {
                    MessageBox.Show("Nemas energiu");
                    HPLabels();
                    return;

                }

                else
                {
                    if (CriticalDMGchance == 5)
                    {
                        Enemy.Health_Max -= MyActualHero.Damage * damagescale * critical;
                        ProgressBar_Enemy.Value = Enemy.Health_Max;
                        MyActualHero.Energy -= 60;
                        ProgressBar_Energy.Value = MyActualHero.Energy;
                        MessageBox.Show("CRITICAL HIT!!!");
                        HPLabels();
                    }
                    else
                    {
                        Enemy.Health_Max -= MyActualHero.Damage * damagescale;
                        ProgressBar_Enemy.Value = Enemy.Health_Max;
                        MyActualHero.Energy -= 20 * damagescale;
                        ProgressBar_Energy.Value = MyActualHero.Energy;
                        HPLabels();
                    }
                }
            }
        }

        private void EnemyAttackHero()
        {
            MyActualHero.Health -= Enemy.Damage;
            ProgressBar_Hero.Value = MyActualHero.Health;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            roundsToHard--;
            HeroAttackEnemy(2);
            EnemyAttackHero();
            CheckHealthStatus();
            HPLabels();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (roundsToHard >= 1)
            {
                MessageBox.Show("musis pockat este " + roundsToHard.ToString() + " kol");
                return;
            }
            else
            {
                HeroAttackEnemy(5);
                EnemyAttackHero();
                CheckHealthStatus();
                HPLabels();
                Random randomRounds = new Random();
                roundsToHard = randomRounds.Next(0, 5);
            }
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
       
        private void HeroHeal()
        {
            MyActualHero.Health += 5;
            ProgressBar_Hero.Value = MyActualHero.Health;
            MyActualHero.Energy += 2;
            ProgressBar_Energy.Value = MyActualHero.Energy;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            HeroHeal();
            HPLabels();
        }

        private void RestartGame()
        {
            MyActualHero.Health = MyActualHero.Health_Max;
            MyActualHero.Energy = MyActualHero.Energy_Max;

            ProgressBar_Hero.Value = MyActualHero.Health_Max;
            ProgressBar_Hero.Maximum = MyActualHero.Health_Max;

            ProgressBar_Enemy.Value = Enemy.Health_Max;
            ProgressBar_Enemy.Maximum = Enemy.Health_Max;

            ProgressBar_Energy.Value = MyActualHero.Energy;
            ProgressBar_Energy.Maximum = MyActualHero.Energy;

            Label_GameStatus.Content = "Game restarted";
            HPLabels();
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            RestartGame();
        }
        

    }
}
