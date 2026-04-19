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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Game3
{
    using System.Windows.Threading;
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int tenthOfSecondsElapsed;
        int matchesFound;
        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick;
            SetUpGame();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tenthOfSecondsElapsed++;
            timeTextBlock.Text = (tenthOfSecondsElapsed / 10F).ToString("0.0s");
            if (matchesFound == 8)
            {
                timer.Stop();
                timeTextBlock.Text = timeTextBlock.Text + " - Jogar novamente?";
            }
        }

        private void SetUpGame()
        {
            List<string> animalEmoji = new List<string>() //Lista de oito pares de emoji
            {
                "🐶", "🐶",
                "🐺", "🐺",
                "🐨", "🐨",
                "🐼", "🐼",
                "🐉", "🐉",
                "🐮", "🐮",
                "🐭", "🐭",
                "🐗", "🐗",

            };

            Random random = new Random(); //Gerador de números aleatórios 

            foreach(TextBlock textBlock in mainGrid.Children.OfType <TextBlock>()) //Para cada textbox na grade principal, repete as declarações 
            {
                if (textBlock.Name != "timeTextBlock")
                {
                    textBlock.Visibility = Visibility.Visible;
                    int index = random.Next(animalEmoji.Count); //Escolhe um número aleatório entre 0 e o número do emoji que ficou na lista, e o chama de index
                    string nextEmoji = animalEmoji[index]; //Usa o número aleatório index para obter um emoji aleatório 
                    textBlock.Text = nextEmoji; //Atualiza o textbox com um emoji aleatório
                    animalEmoji.RemoveAt(index); //Remove o emoji aleatório da lista
                }
            }

            timer.Start();
            tenthOfSecondsElapsed = 0;
            matchesFound = 0;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        TextBlock lastTextBlockClicked;
        bool findingMatch = false;

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock; if (findingMatch == false)
            {
                textBlock.Visibility = Visibility.Hidden;
                lastTextBlockClicked = textBlock;
                findingMatch = true;
            }
            else if (textBlock.Text == lastTextBlockClicked.Text)
            {
                matchesFound++;
                textBlock.Visibility = Visibility.Hidden;
                findingMatch = false;
            }
            else
            {
                lastTextBlockClicked.Visibility = Visibility.Visible;
                findingMatch = false;
            }
        }

        private void timeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (matchesFound == 8)
            {
                SetUpGame();
            }
           
        }
    }
}
