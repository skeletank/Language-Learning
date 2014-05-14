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
        private Verb_Regular _conjugation_CurrentVerb;

        #endregion

        #region Constructors

        public MainWindow()
        {
            InitializeComponent();

            Conjugation_ResetWithNewVerb();
        }

        #endregion

        #region Event Handlers

        private void Conjugation_NewVerbButton_Click(object sender, RoutedEventArgs e)
        {
            Conjugation_ResetWithNewVerb();
        }

        private void Conjugation_ShowCorrectAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            FirstPersonSingularTextBox.Foreground = Brushes.Blue;
            FirstPersonSingularTextBox.Text = _conjugation_CurrentVerb.Root + _conjugation_CurrentVerb.Conjugation.Present_1stPerson_Singular_Active_Ending;

            FirstPersonPluralTextBox.Foreground = Brushes.Blue;
            FirstPersonPluralTextBox.Text = _conjugation_CurrentVerb.Root + _conjugation_CurrentVerb.Conjugation.Present_1stPerson_Plural_Active_Ending;

            SecondPersonSingularTextBox.Foreground = Brushes.Blue;
            SecondPersonSingularTextBox.Text = _conjugation_CurrentVerb.Root + _conjugation_CurrentVerb.Conjugation.Present_2ndPerson_Singular_Active_Ending;

            SecondPersonPluralTextBox.Foreground = Brushes.Blue;
            SecondPersonPluralTextBox.Text = _conjugation_CurrentVerb.Root + _conjugation_CurrentVerb.Conjugation.Present_2ndPerson_Plural_Active_Ending;

            ThirdPersonSingularTextBox.Foreground = Brushes.Blue;
            ThirdPersonSingularTextBox.Text = _conjugation_CurrentVerb.Root + _conjugation_CurrentVerb.Conjugation.Present_3rdPerson_Singular_Active_Ending;

            ThirdPersonPluralTextBox.Foreground = Brushes.Blue;
            ThirdPersonPluralTextBox.Text = _conjugation_CurrentVerb.Root + _conjugation_CurrentVerb.Conjugation.Present_3rdPerson_Plural_Active_Ending;
        }

        private void Conjugation_VerifyVerbButton_Click(object sender, RoutedEventArgs e)
        {
            bool isFirstPersonSingularCorrect = 
                FirstPersonSingularTextBox.Text == _conjugation_CurrentVerb.Root + _conjugation_CurrentVerb.Conjugation.Present_1stPerson_Singular_Active_Ending;

            if (isFirstPersonSingularCorrect)
                FirstPersonSingularTextBox.Foreground = Brushes.Green;
            else
                FirstPersonSingularTextBox.Foreground = Brushes.Red;

            bool isFirstPersonPluralCorrect =
                FirstPersonPluralTextBox.Text == _conjugation_CurrentVerb.Root + _conjugation_CurrentVerb.Conjugation.Present_1stPerson_Plural_Active_Ending;

            if (isFirstPersonPluralCorrect)
                FirstPersonPluralTextBox.Foreground = Brushes.Green;
            else
                FirstPersonPluralTextBox.Foreground = Brushes.Red;

            bool isSecondPersonSingularCorrect =
                SecondPersonSingularTextBox.Text == _conjugation_CurrentVerb.Root + _conjugation_CurrentVerb.Conjugation.Present_2ndPerson_Singular_Active_Ending;

            if (isSecondPersonSingularCorrect)
                SecondPersonSingularTextBox.Foreground = Brushes.Green;
            else
                SecondPersonSingularTextBox.Foreground = Brushes.Red;

            bool isSecondPersonPluralCorrect =
                SecondPersonPluralTextBox.Text == _conjugation_CurrentVerb.Root + _conjugation_CurrentVerb.Conjugation.Present_2ndPerson_Plural_Active_Ending;

            if (isSecondPersonPluralCorrect)
                SecondPersonPluralTextBox.Foreground = Brushes.Green;
            else
                SecondPersonPluralTextBox.Foreground = Brushes.Red;

            bool isThirdPersonSingularCorrect =
                ThirdPersonSingularTextBox.Text == _conjugation_CurrentVerb.Root + _conjugation_CurrentVerb.Conjugation.Present_3rdPerson_Singular_Active_Ending;

            if (isThirdPersonSingularCorrect)
                ThirdPersonSingularTextBox.Foreground = Brushes.Green;
            else
                ThirdPersonSingularTextBox.Foreground = Brushes.Red;

            bool isThirdPersonPluralCorrect =
                ThirdPersonPluralTextBox.Text == _conjugation_CurrentVerb.Root + _conjugation_CurrentVerb.Conjugation.Present_3rdPerson_Plural_Active_Ending;

            if (isThirdPersonPluralCorrect)
                ThirdPersonPluralTextBox.Foreground = Brushes.Green;
            else
                ThirdPersonPluralTextBox.Foreground = Brushes.Red;
        }

        #endregion

        #region Methods

        private void Conjugation_ResetWithNewVerb()
        {
            _conjugation_CurrentVerb = _databaseController.GetRandomVerb();

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

            VerbToConjugateLabel.Content = _conjugation_CurrentVerb.Infinitive;
            RootOfVerbToConjugateLabel.Content = _conjugation_CurrentVerb.Conjugation.Name;
        }

        #endregion
    }
}
