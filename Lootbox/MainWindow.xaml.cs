using LootBox.classes;


namespace LootBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        Logging _log = new Logging();

        public MainWindow()
        {
            InitializeComponent();
            Ss();
        }

        private void Ss(string prefix = "LBIN")
        {
            var currentEventIdentifier = prefix + "00069420";
            for (int index = 0; index < 5; index++)
            {
                currentEventIdentifier = EventIncrementer.Instance.EventSequence(currentEventIdentifier);
                _log.Log(Logging.LogLevel.Information, "LBIN: " + currentEventIdentifier);

                //Console.WriteLine(currentEventIdentifier);  
                //Show a messagebox displaying the contents of the string: currentEventIdentifier
                //MessageBox.Show(currentEventIdentifier);
            }
        }
    }
}