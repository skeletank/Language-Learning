using MRB.LanguageLearning.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace MRB.LanguageLearning.Controls
{
  /// <summary>
  /// Interaction logic for VerbVocabControl.xaml
  /// </summary>
  public partial class VerbVocabControl : UserControl
  {
    #region Fields

    private DatabaseController _databaseController = new DatabaseController();

    private Verb_Regular _currentVerb;

    private int _questionsAsked = 0;
    private int _questionsCorrect = 0;

    private bool _hasBeenVerified = false;

    #endregion

    #region Constructors

    public VerbVocabControl()
    {
      InitializeComponent();

      if (!DesignerProperties.GetIsInDesignMode(this))
      {
        ConjugationComboBox.ItemsSource = _databaseController.GetAllConjugations();
        ConjugationComboBox.DisplayMemberPath = "Name";

        ConjugationComboBox.SelectedIndex = 0;

        ResetWithNewVerb();
      }
    }

    #endregion

    #region Event Handlers

    private void NewVerbButton_Click(object sender, RoutedEventArgs e)
    {
      ResetWithNewVerb();
    }

    private void VerifyVerbButton_Click(object sender, RoutedEventArgs e)
    {
      VerifyAnswer();
    }

    private void ResetScoreButton_Click(object sender, RoutedEventArgs e)
    {
      ScoreValueLabel.Content = String.Empty;
    }

    private void ConjugationComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      ResetWithNewVerb();
    }

    private void GuessVerbTextBox_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.Key == Key.Enter)
      {
        if (_hasBeenVerified)
          ResetWithNewVerb();
        else
          VerifyAnswer();
      }
    }

    #endregion

    #region Methods

    private void UpdateScore(Verb_Regular verb, bool isCorrect)
    {
      _databaseController.UpdateVerbSuccessRate(verb, isCorrect);

      if (isCorrect)
      {
        _questionsCorrect++;
      }

      _questionsAsked++;

      ScoreValueLabel.Content = String.Format("{0} of {1}", _questionsCorrect, _questionsAsked);
    }

    private void ResetWithNewVerb()
    {
      Conjugation selectedConjugation = (Conjugation)ConjugationComboBox.SelectedItem;

      _currentVerb = _databaseController.GetRandomVerb(selectedConjugation.Id);

      GivenVerbLabel.Content = _currentVerb.Infinitive;

      GuessVerbTextBox.Text = String.Empty;
      GuessVerbTextBox.Foreground = Brushes.Black;

      CorrectVerbLabel.Content = String.Empty;

      VerifyVerbButton.IsEnabled = true;

      _hasBeenVerified = false;
    }

    private void VerifyAnswer()
    {
      bool isCorrect = String.Compare(_currentVerb.EnglishDefinition, GuessVerbTextBox.Text, true) == 0;

      if (isCorrect)
        GuessVerbTextBox.Foreground = Brushes.Green;
      else
        GuessVerbTextBox.Foreground = Brushes.Red;

      UpdateScore(_currentVerb, isCorrect);

      CorrectVerbLabel.Content = _currentVerb.EnglishDefinition;

      VerifyVerbButton.IsEnabled = false;

      _hasBeenVerified = true;
    }

    #endregion
  }
}
