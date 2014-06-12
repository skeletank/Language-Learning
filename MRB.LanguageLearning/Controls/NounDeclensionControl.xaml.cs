using MRB.LanguageLearning.Data;
using MRB.LanguageLearning.Data.Entities;
using MRB.LanguageLearning.Data.Entities.Nouns;
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
  /// Interaction logic for NounDeclensionControl.xaml
  /// </summary>
  public partial class NounDeclensionControl : UserControl
  {
    #region Fields

    private DatabaseManager _databaseManager;
    private Noun_Regular _currentNoun;
    private Ending  _ending;

    private bool _hasBeenVerified = false;

    #endregion

    #region Constructors

    public NounDeclensionControl()
    {
      InitializeComponent();

      if (!DesignerProperties.GetIsInDesignMode(this))
      {
        _databaseManager = new DatabaseManager();

        ResetWithNewNoun();
      }
    }

    #endregion

    #region Event Handlers

    private void Declension_NewNounButton_Click(object sender, RoutedEventArgs e)
    {
      ResetWithNewNoun();
    }

    private void Declension_VerifyNounButton_Click(object sender, RoutedEventArgs e)
    {
      VerifyDeclension();
    }

    private void GuessDeclensionTextBox_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.Key == Key.Enter)
      {
        if (_hasBeenVerified)
          ResetWithNewNoun();
        else
          VerifyDeclension();
      }
    }

    #endregion

    #region Methods

    private void ResetWithNewNoun()
    {
      _ending = _databaseManager.GetRandomNounEnding();
      _currentNoun = _databaseManager.GetRandomNoun();

      GuessDeclensionTextBox.Text = String.Empty;
      GuessDeclensionTextBox.Foreground = Brushes.Black;

      NounLabel.Content = _currentNoun.Root + _currentNoun.Declension.Singular_Nominative_Ending;
      EndingLabel.Content = _ending.Display;

      CorrectDeclensionLabel.Content = String.Empty;

      _hasBeenVerified = false;
    }

    private void VerifyDeclension()
    {
      string correctDeclension = _currentNoun.Root + _currentNoun.GetNounEnding(_ending);

      Encoding latinEncoding = Encoding.GetEncoding("Windows-1252");

      byte[] latinBytes = latinEncoding.GetBytes(correctDeclension);

      string correctDeclension_NoAccents = Encoding.ASCII.GetString(latinBytes);

      bool isCorrect = GuessDeclensionTextBox.Text == correctDeclension_NoAccents;

      if (isCorrect)
        GuessDeclensionTextBox.Foreground = Brushes.Green;
      else
        GuessDeclensionTextBox.Foreground = Brushes.Red;

      CorrectDeclensionLabel.Content = correctDeclension;

      Declension_VerifyNounButton.IsEnabled = false;

      _hasBeenVerified = true;
    }

    #endregion
  }
}
