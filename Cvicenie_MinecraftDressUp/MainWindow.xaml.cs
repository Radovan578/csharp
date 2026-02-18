using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cvicenie_MinecraftDressUp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string ImagePath { get; set; } = "C:\\Users\\tanuskar25\\source\\repos\\csharp\\codecraft\\Cvicenie_MinecraftDressUp\\images\\minecraft_armour_sheet_by_dragonshadow3_d8ebr67-414w-2x.png";

        public List<ArmorPart> Armors_Head { get; set; } = new List<ArmorPart>();
        List<ArmorPart> ArmorParts_Body { get; set; } = new List<ArmorPart>();
        List<ArmorPart> ArmorParts_Pant { get; set; } = new List<ArmorPart>();
        List<ArmorPart> ArmorParts_Leg { get; set; } = new List<ArmorPart>();

        public ArmorPart Head { get; set; }
        public ArmorPart Body { get; set; }
        public ArmorPart Pants { get; set; }
        public ArmorPart Leg { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Armors_Head.Add(new ArmorPart("Plesinka", 0, EArmorType.None, EArmorPartName.Head, 28, 29, 100, 90));
            Armors_Head.Add(new ArmorPart("Helma bronzova", 1, EArmorType.Bronze, EArmorPartName.Head, 28, 29, 100, 90));
            Armors_Head.Add(new ArmorPart("Helma retiazkova", 2, EArmorType.Chain, EArmorPartName.Head, 177, 29, 100, 90));
            Armors_Head.Add(new ArmorPart("Helma zelezna", 5, EArmorType.Iron, EArmorPartName.Head, 338, 29, 100, 90));
            Armors_Head.Add(new ArmorPart("Helma zlata", 10, EArmorType.Gold, EArmorPartName.Head, 505, 29, 100, 90));
            Armors_Head.Add(new ArmorPart("Helma diamantova", 20, EArmorType.Diamond, EArmorPartName.Head, 659, 29, 100, 90));
            Combox_HelmPicker.ItemsSource = Armors_Head;

            ArmorParts_Body.Add(new ArmorPart("Hola hrud", 0, EArmorType.None, EArmorPartName.Body, 0, 0, 0, 0));
            ArmorParts_Body.Add(new ArmorPart("Body bronzove", 5, EArmorType.Bronze, EArmorPartName.Body, 7, 136, 139, 130));
            ArmorParts_Body.Add(new ArmorPart("Body retiazkove", 10, EArmorType.Chain, EArmorPartName.Body, 159, 136, 139, 130));
            ArmorParts_Body.Add(new ArmorPart("Body zelezne", 15, EArmorType.Iron, EArmorPartName.Body, 321, 136, 139, 130));
            ArmorParts_Body.Add(new ArmorPart("Body zlate", 30, EArmorType.Gold, EArmorPartName.Body, 486, 136, 139, 130));
            ArmorParts_Body.Add(new ArmorPart("Body diamantove", 50, EArmorType.Diamond, EArmorPartName.Body, 639, 136, 139, 130));
            Combox_BodyPicker.ItemsSource = ArmorParts_Body;

            ArmorParts_Pant.Add(new ArmorPart("Trenky", 0, EArmorType.None, EArmorPartName.Pant, 0, 0, 0, 0));
            ArmorParts_Pant.Add(new ArmorPart("Nohavice bronzove", 2, EArmorType.Bronze, EArmorPartName.Pant, 26, 279, 100, 131));
            ArmorParts_Pant.Add(new ArmorPart("Nohavice retiazkove", 4, EArmorType.Chain, EArmorPartName.Pant, 179, 279, 100, 131));
            ArmorParts_Pant.Add(new ArmorPart("Nohavice zelezne", 8, EArmorType.Iron, EArmorPartName.Pant, 339, 279, 100, 131));
            ArmorParts_Pant.Add(new ArmorPart("Nohavice zlate", 15, EArmorType.Gold, EArmorPartName.Pant, 506, 279, 100, 131));
            ArmorParts_Pant.Add(new ArmorPart("Nohavice diamantove", 22, EArmorType.Diamond, EArmorPartName.Pant, 657, 279, 100, 131));
            Combox_PantsPicker.ItemsSource = ArmorParts_Pant;

            ArmorParts_Leg.Add(new ArmorPart("Sandale", 0, EArmorType.None, EArmorPartName.Leg, 0, 0, 0, 0));
            ArmorParts_Leg.Add(new ArmorPart("Topanky bronzove", 2, EArmorType.Bronze, EArmorPartName.Leg, 2, 425, 140, 100));
            ArmorParts_Leg.Add(new ArmorPart("Topanky retiazkove", 4, EArmorType.Chain, EArmorPartName.Leg, 159, 425, 140, 100));
            ArmorParts_Leg.Add(new ArmorPart("Topanky zelezne", 8, EArmorType.Iron, EArmorPartName.Leg, 319, 425, 140, 100));
            ArmorParts_Leg.Add(new ArmorPart("Topanky zlate", 15, EArmorType.Gold, EArmorPartName.Leg, 484, 425, 140, 100));
            ArmorParts_Leg.Add(new ArmorPart("Topanky diamantove", 22, EArmorType.Diamond, EArmorPartName.Leg, 636, 425, 140, 100));
            Combox_LegPicker.ItemsSource = ArmorParts_Leg;

        }
        private void UpdateLabels()
        {
            var playerSet = new List<ArmorPart>();

            if (Head != null)
                playerSet.Add(Head);
            if (Body != null)
                playerSet.Add(Body);
            if (Pants != null)
                playerSet.Add(Pants);
            if (Leg != null)
                playerSet.Add(Leg);



            var groupedItems = playerSet.GroupBy(p => p.ArmorType, (key, g) => new { ArmorType = key, Items = g.ToList() }).ToList();
            var multiplaierValue = groupedItems.OrderByDescending(x => x.Items.Count).First().Items.Count;
            Label_ArmorMultiplier.Content = multiplaierValue;

            var numberOfArmor = playerSet.Sum(x => x.ArmorPower);
            Label_ArmorPowerValue.Content = $"{numberOfArmor} (+{multiplaierValue * numberOfArmor})";
        }


        private void Combox_HelmPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ArmorPart armorPartH = Combox_HelmPicker.SelectedItem as ArmorPart;
            Head = armorPartH;

            if (armorPartH.ArmorType != EArmorType.None)
            {
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(ImagePath, UriKind.Absolute);
                bitmap.CacheOption = BitmapCacheOption.OnLoad; // aby sa súbor neu lockol
                bitmap.EndInit();
                bitmap.Freeze();
                var cropped = new CroppedBitmap(bitmap, new Int32Rect(armorPartH.XLeft, armorPartH.YTop, armorPartH.Width, armorPartH.Height));
                cropped.Freeze();
                Image_HelmetPlaceHolder.Source = cropped;
                Image_HelmetPlaceHolder.Visibility = Visibility.Visible;
            }
            else
            {
                Image_HelmetPlaceHolder.Visibility = Visibility.Hidden;
            }

            UpdateLabels();
        }

        private void Combox_BodyPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ArmorPart armorPartB = Combox_BodyPicker.SelectedItem as ArmorPart;
            Body = armorPartB;

            if (armorPartB.ArmorType != EArmorType.None)
            {
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(ImagePath, UriKind.Absolute);
                bitmap.CacheOption = BitmapCacheOption.OnLoad; // aby sa súbor neu lockol
                bitmap.EndInit();
                bitmap.Freeze();
                var cropped = new CroppedBitmap(bitmap, new Int32Rect(armorPartB.XLeft, armorPartB.YTop, armorPartB.Width, armorPartB.Height));
                cropped.Freeze();
                Image_BodyPlaceHolder.Source = cropped;
                Image_BodyPlaceHolder.Visibility = Visibility.Visible;
            }
            else
            {
                Image_BodyPlaceHolder.Visibility = Visibility.Hidden;
            }

            UpdateLabels();

        }

        private void Combox_PantsPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ArmorPart armorPartP = Combox_PantsPicker.SelectedItem as ArmorPart;
            Pants = armorPartP;

            if (armorPartP.ArmorType != EArmorType.None)
            {
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(ImagePath, UriKind.Absolute);
                bitmap.CacheOption = BitmapCacheOption.OnLoad; // aby sa súbor neu lockol
                bitmap.EndInit();
                bitmap.Freeze();
                var cropped = new CroppedBitmap(bitmap, new Int32Rect(armorPartP.XLeft, armorPartP.YTop, armorPartP.Width, armorPartP.Height));
                cropped.Freeze();
                Image_PantsPlaceHolder.Source = cropped;
                Image_PantsPlaceHolder.Visibility = Visibility.Visible;
            }
            else
            {
                Image_PantsPlaceHolder.Visibility = Visibility.Hidden;
            }

            UpdateLabels();
        }

        private void Combox_LegPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ArmorPart armorPartL = Combox_LegPicker.SelectedItem as ArmorPart;
            Leg = armorPartL;

            if (armorPartL.ArmorType != EArmorType.None)
            {
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(ImagePath, UriKind.Absolute);
                bitmap.CacheOption = BitmapCacheOption.OnLoad; // aby sa súbor neu lockol
                bitmap.EndInit();
                bitmap.Freeze();
                var cropped = new CroppedBitmap(bitmap, new Int32Rect(armorPartL.XLeft, armorPartL.YTop, armorPartL.Width, armorPartL.Height));
                cropped.Freeze();
                Image_LegPlaceHolder.Source = cropped;
                Image_LegPlaceHolder.Visibility = Visibility.Visible;
            }
            else
            {
                Image_LegPlaceHolder.Visibility = Visibility.Hidden;
            }

            UpdateLabels();
        }



    }
}