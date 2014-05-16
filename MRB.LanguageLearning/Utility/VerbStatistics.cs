using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRB.LanguageLearning.Utility
{
    class VerbStatistics
    {
        #region Fields

        private int _numberOfGuesses = 0;
        private int _numberOfCorrectGuesses = 0;

        #endregion

        #region Properties

        public int NumberOfCorrectGuesses
        {
            get { return _numberOfCorrectGuesses; }
            set { _numberOfCorrectGuesses = value; }
        }

        public int NumberOfGuesses
        {
            get { return _numberOfGuesses; }
            set { _numberOfGuesses = value; }
        }

        public int PercentCorrect
        {
            get 
            {
                double percentCorrect = _numberOfGuesses == 0 ? 0 : _numberOfCorrectGuesses / _numberOfGuesses;
                return ((int)Math.Round(percentCorrect)) * 100;
            }
        }

        #endregion
    }
}
