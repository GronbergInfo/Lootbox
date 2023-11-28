using System.Windows;
using LootBox.classes;

namespace LootBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            //Ss();

        }

        private void Ss(string prefix = "LBI")
        {
           var currentEventIdentifier = prefix + "00069420";  
            for (int index = 0; index < 5; index++)  
            {  
                currentEventIdentifier = EventIncrementer.Instance.EventSequence(currentEventIdentifier);  
                //Console.WriteLine(currentEventIdentifier);  
                //Show a messagebox displaying the contents of the string: currentEventIdentifier
                MessageBox.Show(currentEventIdentifier);
                
            }  
        }
    }
}