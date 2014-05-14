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
    /// Interaction logic for VerbConjugationControl.xaml
    /// </summary>
    public partial class VerbConjugationControl : UserControl
    {
        #region Fields

        private DatabaseController _databaseController = new DatabaseController();
        private Verb_Regular _currentVerb;

        #endregion

        #region Constructors

        public VerbConjugationControl()
        {
            InitializeComponent();

            if (!DesignerProperties.GetIsInDesignMode(this))
                ResetWithNewVerb();
        }

        #endregion

        #region Event Handlers

        private void Conjugation_NewVerbButton_Click(object sender, RoutedEventArgs e)
        {
            ResetWithNewVerb();
        }

        private void Conjugation_ShowCorrectAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            FirstPersonSingularTextBox.Foreground = Brushes.Blue;
            FirstPersonSingularTextBox.Text = _currentVerb.Root + _currentVerb.Conjugation.Present_1stPerson_Singular_Active_Ending;

            FirstPersonPluralTextBox.Foreground = Brushes.Blue;
            FirstPersonPluralTextBox.Text = _currentVerb.Root + _currentVerb.Conjugation.Present_1stPerson_Plural_Active_Ending;

            SecondPersonSingularTextBox.Foreground = Brushes.Blue;
            SecondPersonSingularTextBox.Text = _currentVerb.Root + _currentVerb.Conjugation.Present_2ndPerson_Singular_Active_Ending;

            SecondPersonPluralTextBox.Foreground = Brushes.Blue;
            SecondPersonPluralTextBox.Text = _currentVerb.Root + _currentVerb.Conjugation.Present_2ndPerson_Plural_Active_Ending;

            ThirdPersonSingularTextBox.Foreground = Brushes.Blue;
            ThirdPersonSingularTextBox.Text = _currentVerb.Root + _currentVerb.Conjugation.Present_3rdPerson_Singular_Active_Ending;

            ThirdPersonPluralTextBox.Foreground = Brushes.Blue;
            ThirdPersonPluralTextBox.Text = _currentVerb.Root + _currentVerb.Conjugation.Present_3rdPerson_Plural_Active_Ending;
        }

        private void Conjugation_VerifyVerbButton_Click(object sender, RoutedEventArgs e)
        {
            ValidateSingleConjugation(FirstPersonSingularTextBox, _currentVerb.Root, _currentVerb.Conjugation.Present_1stPerson_Singular_Active_Ending);
            ValidateSingleConjugation(FirstPersonPluralTextBox, _currentVerb.Root, _currentVerb.Conjugation.Present_1stPerson_Plural_Active_Ending);
            ValidateSingleConjugation(SecondPersonSingularTextBox, _currentVerb.Root, _currentVerb.Conjugation.Present_2ndPerson_Singular_Active_Ending);
            ValidateSingleConjugation(SecondPersonPluralTextBox, _currentVerb.Root, _currentVerb.Conjugation.Present_2ndPerson_Plural_Active_Ending);
            ValidateSingleConjugation(ThirdPersonSingularTextBox, _currentVerb.Root, _currentVerb.Conjugation.Present_3rdPerson_Singular_Active_Ending);
            ValidateSingleConjugation(ThirdPersonPluralTextBox, _currentVerb.Root, _currentVerb.Conjugation.Present_3rdPerson_Plural_Active_Ending);
        }

        #endregion

        #region Methods

        private void ResetWithNewVerb()
        {
            _currentVerb = _databaseController.GetRandomVerb();

            FirstPersonSingularTextBox.Text = String.Empty;
            FirstPersonSingularTextBox.Foreground = Brushes.Black;

            FirstPersonPluralTextBox.Text = String.Empty;
            FirstPersonPluralTextBox.Foreground = Brushes.Black;

            SecondPersonSingularTextBox.Text = String.Empty;
            SecondPersonSingularTextBox.Foreground = Brushes.Black;

            SecondPersonPluralTextBox.Text = String.Empty;
            SecondPersonPluralTextBox.Foreground = Brushes.Black;

            ThirdPersonSingularTextBox.Text = String.Empty;
            ThirdPersonSingularTextBox.Foreground = Brushes.Black;

            ThirdPersonPluralTextBox.Text = String.Empty;
            ThirdPersonPluralTextBox.Foreground = Brushes.Black;

            VerbToConjugateLabel.Content = _currentVerb.Infinitive;
            RootOfVerbToConjugateLabel.Content = _currentVerb.Conjugation.Name;
        }

        private static void ValidateSingleConjugation(TextBox inputTextbox, string root, string ending)
        {
            string correctConjugation = root + ending;

            Encoding latinEncoding = Encoding.GetEncoding("Windows-1252");

            byte[] latinBytes = latinEncoding.GetBytes(correctConjugation);

            string correctConjugation_NoAccents = Encoding.ASCII.GetString(latinBytes);

            bool isCorrect = inputTextbox.Text == correctConjugation_NoAccents;

            if (isCorrect)
                inputTextbox.Foreground = Brushes.Green;
            else
                inputTextbox.Foreground = Brushes.Red;
        }

        #endregion
    }
}
