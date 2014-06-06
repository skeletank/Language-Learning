using MRB.LanguageLearning.Data;
using MRB.LanguageLearning.Data.Entities;
using MRB.LanguageLearning.Data.Entities.Verb;
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
  /// Interaction logic for VerbConjugationControl.xaml
  /// </summary>
  public partial class VerbConjugationControl : UserControl
  {
    #region Fields

    private DatabaseManager _databaseManager;
    private Verb_Regular _currentVerb;
    private Ending  _ending;

    private bool _hasBeenVerified = false;

    #endregion

    #region Constructors

    public VerbConjugationControl()
    {
      InitializeComponent();

      if (!DesignerProperties.GetIsInDesignMode(this))
      {
        _databaseManager = new DatabaseManager();

        ResetWithNewVerb();
      }
    }

    #endregion

    #region Event Handlers

    private void Conjugation_NewVerbButton_Click(object sender, RoutedEventArgs e)
    {
      ResetWithNewVerb();
    }

    private void Conjugation_VerifyVerbButton_Click(object sender, RoutedEventArgs e)
    {
      VerifyConjugation();
    }

    private void GuessConjugationTextBox_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.Key == Key.Enter)
      {
        if (_hasBeenVerified)
          ResetWithNewVerb();
        else
          VerifyConjugation();
      }
    }

    #endregion

    #region Methods

    private void ResetWithNewVerb()
    {
      _ending = _databaseManager.GetRandomVerbEnding();
      _currentVerb = _databaseManager.GetRandomVerb();

      GuessConjugationTextBox.Text = String.Empty;
      GuessConjugationTextBox.Foreground = Brushes.Black;

      VerbLabel.Content = _currentVerb.Infinitive;
      EndingLabel.Content = _ending.Display;

      CorrectConjugationLabel.Content = String.Empty;

      _hasBeenVerified = false;
    }

    private void VerifyConjugation()
    {
      string correctConjugation = _currentVerb.Root + _currentVerb.GetVerbEnding(_ending);

      Encoding latinEncoding = Encoding.GetEncoding("Windows-1252");

      byte[] latinBytes = latinEncoding.GetBytes(correctConjugation);

      string correctConjugation_NoAccents = Encoding.ASCII.GetString(latinBytes);

      bool isCorrect = GuessConjugationTextBox.Text == correctConjugation_NoAccents;

      if (isCorrect)
        GuessConjugationTextBox.Foreground = Brushes.Green;
      else
        GuessConjugationTextBox.Foreground = Brushes.Red;

      CorrectConjugationLabel.Content = correctConjugation;

      Conjugation_VerifyVerbButton.IsEnabled = false;

      _hasBeenVerified = true;
    }

    #endregion
  }
}
