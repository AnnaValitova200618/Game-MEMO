using Game_MEMO.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
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

namespace Game_MEMO
{
    /// <summary>
    /// Логика взаимодействия для GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        static Random random = new Random();
        int bordersCount = 0;
        SoundPlayer Malina;
        public string stumb { get; set; }
        public GamePage(MainWindowVM mainWindowVM)
        {
            
            InitializeComponent();
            bordersCount = grid1.Children.Count;
            Malina = new SoundPlayer(System.IO.Path.Combine(Environment.CurrentDirectory, @"Music\Smeshh.wav"));
            Malina.Play();
            var borders = grid1.Children.OfType<Border>().ToList();
            string url = Environment.CurrentDirectory;
            stumb = System.IO.Path.Combine(url, "Views/2fc62fb50b4cf870e740710aedb1108d.jpg");

            for (int i = 0; i < grid1.Children.Count; i++)
            {
                ((Border)grid1.Children[i]).Background = new ImageBrush(new BitmapImage(
                                new Uri(stumb, UriKind.Relative)));
            }
            string nusha = System.IO.Path.Combine(url, "LolCircle/16-76.jpg");
            string barash = System.IO.Path.Combine(url, "LolCircle/5192516146ea439c724d668d1747a3fa.jpg");
            string krosh = System.IO.Path.Combine(url, "LolCircle/2370285f8b6a9b6016edb37f8878be0e.jpg");
            string egic = System.IO.Path.Combine(url, "LolCircle/1649569140_2-kartinkof-club-p-ugarnie-kartinki-yezhik-iz-smesharikov-2.jpg");
            string bibi = System.IO.Path.Combine(url, "LolCircle/3-39.jpg");
            string karkar = System.IO.Path.Combine(url, "LolCircle/images.jpg");
            string sowunia = System.IO.Path.Combine(url, "LolCircle/bc63a4489e2310f408559112ee6d07ce.jpg");
            string pin = System.IO.Path.Combine(url, "LolCircle/1648731221_1-kartinkof-club-p-kartinki-smeshnie-pin-iz-smesharikov-1.png");
            string loshash = System.IO.Path.Combine(url, "LolCircle/olen.jpg");
            string kopatch = System.IO.Path.Combine(url, "LolCircle/1648702212_12-kartinkof-club-p-kartinki-smeshnie-kopatich-13.jpg");

            
            List<string> smeshariki = new List<string> { nusha, barash, krosh, egic, bibi, karkar, sowunia, pin, loshash, kopatch };

            foreach (var img in smeshariki)
            {
                var border = borders[random.Next(0, borders.Count)];
                border.Tag = img;
                borders.Remove(border);

                border = borders[random.Next(0, borders.Count)];
                border.Tag = img;
                borders.Remove(border);
            }
            DataContext = this;
        }

        Border lastRevert;

        private void mOUSEdOWN(object sender, MouseButtonEventArgs e)
        {
            
            
                ((Border)sender).Background = new ImageBrush(new BitmapImage(new Uri(
                    ((Border)sender).Tag.ToString(), UriKind.Absolute)));

                if (lastRevert != null)
                {
                    if (lastRevert.Tag.ToString() == ((Border)sender).Tag.ToString())
                    {
                        lastRevert.MouseDown -= mOUSEdOWN;
                        ((Border)sender).MouseDown -= mOUSEdOWN;
                        bordersCount = bordersCount - 2;
                        lastRevert = null;
                        if(bordersCount == 0)
                            {
                                Malina.Stop();
                                MessageBox.Show("STOP", Title="STOP",MessageBoxButton.OK,MessageBoxImage.Stop);
                                NavigationService.GoBack();
                            }
                            
                        return;
                    }
                    else
                    {
                        var first = lastRevert;
                        var second = ((Border)sender);
                        Task task = new Task(() => {
                        Task.Delay( 500).ContinueWith(s =>
                        {
                            Dispatcher.Invoke(() =>
                            {
                                first.Background = new ImageBrush(new BitmapImage(
                                    new Uri(stumb, UriKind.Relative)));
                                second.Background = new ImageBrush(new BitmapImage(
                                    new Uri(stumb, UriKind.Relative)));
                            });
                        });
                        });
                        task.Start();
                        lastRevert = null;
                        return;
                    }
               
            }
            lastRevert = ((Border)sender);

        }
    }
}
