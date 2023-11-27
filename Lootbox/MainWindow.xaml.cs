﻿using System.Windows;
using LootBox.classes;

namespace LootBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Ss();

        }

        private void Ss()
        {
           var currentEventIdentifier = "LBI00069420";  
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