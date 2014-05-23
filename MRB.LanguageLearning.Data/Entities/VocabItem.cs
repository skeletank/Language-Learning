using MRB.LanguageLearning.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRB.LanguageLearning.Data.Entities
{
  public abstract class VocabItem : IVocabItem
  {
    #region Fields

    private int _numberOfGuesses = 0;
    private int _numberOfCorrectGuesses = 0;

    #endregion

    #region IVocabItem Implementation

    public abstract string KnownLanguageDefinition
    {
      get;
    }

    public abstract string ForeignLanguageDefinition
    {
      get;
    }

    public int NumberOfCorrectAnswers
    {
      get { return _numberOfCorrectGuesses; }
    }

    public int PercentCorrect
    {
      get
      {
        double percentCorrect = _numberOfGuesses == 0 ? 0 : _numberOfCorrectGuesses / _numberOfGuesses;
        return ((int)Math.Round(percentCorrect)) * 100;
      }
    }

    public void TallyCorrectAnswer()
    {
      _numberOfCorrectGuesses++;
      _numberOfGuesses++;
    }

    public void TallyWrongAnswer()
    {
      _numberOfGuesses++;
    }

    #endregion
  }
}
