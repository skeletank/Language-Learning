using MRB.LanguageLearning.Data;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MRB.LanguageLearning.Controls
{
    /// <summary>
    /// Interaction logic for NounVocabControl.xaml
    /// </summary>
    public partial class NounVocabControl : UserControl
    {
        #region Fields

        private DatabaseController _databaseController = new DatabaseController();

        private Noun_Regular _currentNoun;

        private int _questionsAsked = 0;
        private int _questionsCorrect = 0;

        private bool _hasBeenVerified = false;

        #endregion

        #region Constructors

        public NounVocabControl()
        {
            InitializeComponent();

            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                DeclensionComboBox.ItemsSource = _databaseController.GetAllDeclensions();
                DeclensionComboBox.DisplayMemberPath = "Name";

                DeclensionComboBox.SelectedIndex = 0;

                ResetWithNewNoun();
            }
        }

        #endregion

        #region Event Handlers

        private void NewNounButton_Click(object sender, RoutedEventArgs e)
        {
            ResetWithNewNoun();
        }

        private void VerifyNounButton_Click(object sender, RoutedEventArgs e)
        {
            VerifyAnswer();
        }

        private void ResetScoreButton_Click(object sender, RoutedEventArgs e)
        {
            ScoreValueLabel.Content = String.Empty;
        }

        private void DeclensionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ResetWithNewNoun();
        }

        private void GuessNounTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (_hasBeenVerified)
                    ResetWithNewNoun();
                else
                    VerifyAnswer();
            }
        }

        #endregion

        #region Methods

        private void UpdateScore(Noun_Regular Noun, bool isCorrect)
        {
            _databaseController.UpdateNounSuccessRate(Noun, isCorrect);

            if (isCorrect)
                _questionsCorrect++;

            _questionsAsked++;

            ScoreValueLabel.Content = String.Format("{0} of {1}", _questionsCorrect, _questionsAsked);
        }

        private void ResetWithNewNoun()
        {
            Declension selectedDeclension = (Declension)DeclensionComboBox.SelectedItem;

            _currentNoun = _databaseController.GetRandomNoun(selectedDeclension.Id);

            GivenNounLabel.Content = _currentNoun.Root + _currentNoun.Declension.Singular_Nominative_Ending;

            GuessNounTextBox.Text = String.Empty;
            GuessNounTextBox.Foreground = Brushes.Black;

            CorrectNounLabel.Content = String.Empty;

            VerifyNounButton.IsEnabled = true;

            _hasBeenVerified = false;
        }

        private void VerifyAnswer()
        {
            bool isCorrect = String.Compare(_currentNoun.EnglishDefinition, GuessNounTextBox.Text, true) == 0;

            if (isCorrect)
                GuessNounTextBox.Foreground = Brushes.Green;
            else
                GuessNounTextBox.Foreground = Brushes.Red;

            UpdateScore(_currentNoun, isCorrect);

            CorrectNounLabel.Content = _currentNoun.EnglishDefinition;

            VerifyNounButton.IsEnabled = false;

            _hasBeenVerified = true;
        }

        #endregion
    }
}
