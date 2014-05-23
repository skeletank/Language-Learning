using MRB.LanguageLearning.Data;
using MRB.LanguageLearning.Data.Entities;
using MRB.LanguageLearning.Data.Interfaces;
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
  /// Interaction logic for VocabControl.xaml
  /// </summary>
  public partial class VocabControl : UserControl
  {
    #region Fields

    private DatabaseManager _databaseManager;

    private IVocabItem _currentVocabItem;

    private int _questionsAsked = 0;
    private int _questionsCorrect = 0;

    private bool _hasBeenVerified = false;

    #endregion

    #region Constructors

    public VocabControl()
    {
      InitializeComponent();

      if (!DesignerProperties.GetIsInDesignMode(this))
      {
        _databaseManager = new DatabaseManager();

        StudyGroupComboBox.ItemsSource = _databaseManager.GetVocabStudyGroups();
        StudyGroupComboBox.DisplayMemberPath = "GroupName";
        StudyGroupComboBox.SelectedIndex = 0;

        ResetWithNewVocab();
      }
    }

    #endregion

    #region Event Handlers

    private void NewVocabButton_Click(object sender, RoutedEventArgs e)
    {
      ResetWithNewVocab();
    }

    private void VerifyVocabButton_Click(object sender, RoutedEventArgs e)
    {
      VerifyAnswer();
    }

    private void ResetScoreButton_Click(object sender, RoutedEventArgs e)
    {
      ScoreValueLabel.Content = String.Empty;
    }

    private void StudyGroupComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      ResetWithNewVocab();
    }

    private void GuessForeignVocabTextBox_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.Key == Key.Enter)
      {
        if (_hasBeenVerified)
          ResetWithNewVocab();
        else
          VerifyAnswer();
      }
    }

    #endregion

    #region Methods

    private void UpdateScore(IVocabItem vocabItem, bool isCorrect)
    {
      _databaseManager.UpdateVocabSuccessRate(vocabItem, isCorrect);

      if (isCorrect)
        _questionsCorrect++;

      _questionsAsked++;

      ScoreValueLabel.Content = String.Format("{0} of {1}", _questionsCorrect, _questionsAsked);
    }

    private void ResetWithNewVocab()
    {
      VocabStudyGroup selectedStudyGroup = (VocabStudyGroup)StudyGroupComboBox.SelectedItem;

      _currentVocabItem = _databaseManager.GetRandomVocab(selectedStudyGroup);

      ForeignVocabLabel.Content = _currentVocabItem.ForeignLanguageDefinition;

      GuessKnownVocabTextBox.Text = String.Empty;
      GuessKnownVocabTextBox.Foreground = Brushes.Black;

      CorrectKnownVocabLabel.Content = String.Empty;

      VerifyVocabButton.IsEnabled = true;

      _hasBeenVerified = false;
    }

    private void VerifyAnswer()
    {
      bool isCorrect = String.Compare(_currentVocabItem.KnownLanguageDefinition, GuessKnownVocabTextBox.Text, true) == 0;

      if (isCorrect)
        GuessKnownVocabTextBox.Foreground = Brushes.Green;
      else
        GuessKnownVocabTextBox.Foreground = Brushes.Red;

      UpdateScore(_currentVocabItem, isCorrect);

      CorrectKnownVocabLabel.Content = _currentVocabItem.KnownLanguageDefinition;

      VerifyVocabButton.IsEnabled = false;

      _hasBeenVerified = true;
    }

    #endregion
  }
}
