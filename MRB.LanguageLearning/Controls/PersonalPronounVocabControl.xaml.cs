using MRB.LanguageLearning.Data;
using MRB.LanguageLearning.Data.Entities;
using MRB.LanguageLearning.Data.Entities.PersonalPronouns;
using MRB.LanguageLearning.Data.Entities.Verbs;
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
  /// Interaction logic for PersonalPronounVocabControl.xaml
  /// </summary>
  public partial class PersonalPronounVocabControl : UserControl
  {
    #region Fields

    private DatabaseManager _databaseManager;
    private PersonalPronoun  _personalPronoun;

    private bool _hasBeenVerified = false;

    #endregion

    #region Constructors

    public PersonalPronounVocabControl()
    {
      InitializeComponent();

      if (!DesignerProperties.GetIsInDesignMode(this))
      {
        _databaseManager = new DatabaseManager();

        ResetWithNewPersonalPronoun();
      }
    }

    #endregion

    #region Event Handlers

    private void NewPersonalPronounButton_Click(object sender, RoutedEventArgs e)
    {
      ResetWithNewPersonalPronoun();
    }

    private void VerifyPersonalPronounButton_Click(object sender, RoutedEventArgs e)
    {
      VerifyPersonalPronoun();
    }

    private void GuessPersonalPronounTextBox_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.Key == Key.Enter)
      {
        if (_hasBeenVerified)
          ResetWithNewPersonalPronoun();
        else
          VerifyPersonalPronoun();
      }
    }

    #endregion

    #region Methods

    private void ResetWithNewPersonalPronoun()
    {
      _personalPronoun = _databaseManager.GetRandomPersonalPronoun();

      GuessPersonalPronounTextBox.Text = String.Empty;
      GuessPersonalPronounTextBox.Foreground = Brushes.Black;

      PersonalPronounLabel.Content = _personalPronoun.Display;

      CorrectPersonalPronounLabel.Content = String.Empty;

      _hasBeenVerified = false;
    }

    private void VerifyPersonalPronoun()
    {
      string correctPersonalPronoun = _personalPronoun.Name;

      Encoding latinEncoding = Encoding.GetEncoding("Windows-1252");

      byte[] latinBytes = latinEncoding.GetBytes(correctPersonalPronoun);

      string correctPersonalPronoun_NoAccents = Encoding.ASCII.GetString(latinBytes);

      bool isCorrect = GuessPersonalPronounTextBox.Text == correctPersonalPronoun_NoAccents;

      if (isCorrect)
        GuessPersonalPronounTextBox.Foreground = Brushes.Green;
      else
        GuessPersonalPronounTextBox.Foreground = Brushes.Red;

      CorrectPersonalPronounLabel.Content = correctPersonalPronoun;

      VerifyPersonalPronounButton.IsEnabled = false;

      _hasBeenVerified = true;
    }

    #endregion
  }
}
