using MRB.LanguageLearning.Data;
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

namespace MRB.LanguageLearning
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Fields

        private DatabaseController _databaseController = new DatabaseController();
        private Verb_Regular _currentVerb;
        private int _questionsAsked = 0;
        private int _questionsCorrect = 0;

        #endregion

        #region Constructors

        public MainWindow()
        {
            InitializeComponent();

            ResetWithNewVerb();
        }

        #endregion

        #region Event Handlers

        private void NewVerbButton_Click(object sender, RoutedEventArgs e)
        {
            ResetWithNewVerb();
        }

        private void ShowCorrectAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            GuessVerbTextBox.Foreground = Brushes.Blue;
            GuessVerbTextBox.Text = _currentVerb.EnglishDefinition;
        }

        private void VerifyVerbButton_Click(object sender, RoutedEventArgs e)
        {
            bool isCorrect = String.Compare(_currentVerb.EnglishDefinition, GuessVerbTextBox.Text, true) == 0;

            if (isCorrect)
                GuessVerbTextBox.Foreground = Brushes.Green;
            else
                GuessVerbTextBox.Foreground = Brushes.Red;

            UpdateScore(isCorrect);
        }

        private void ResetScoreButton_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        #region Methods

        private void UpdateScore(bool isCorrect)
        {
            if (isCorrect)
                _questionsCorrect++;

            _questionsAsked++;

            ScoreValueLabel.Content = String.Format("{0} of {1}", _questionsCorrect, _questionsAsked);
        }

        private void ResetWithNewVerb()
        {
            _currentVerb = _databaseController.GetRandomVerb();

            GuessVerbTextBox.Text = String.Empty;
            GuessVerbTextBox.Foreground = Brushes.Black;

            GivenVerbLabel.Content = _currentVerb.Infinitive;
        }

        #endregion
    }
}
