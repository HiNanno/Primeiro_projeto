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
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetUpGame();
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
                int index = random.Next(animalEmoji.Count); //Escolhe um número aleatório entre 0 e o número do emoji que ficou na lista, e o chama de index
                string nextEmoji = animalEmoji[index]; //Usa o número aleatório index para obter um emoji aleatório 
                textBlock.Text = nextEmoji; //Atualiza o textbox com um emoji aleatório
                animalEmoji.RemoveAt(index); //Remove o emoji aleatório da lista
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
