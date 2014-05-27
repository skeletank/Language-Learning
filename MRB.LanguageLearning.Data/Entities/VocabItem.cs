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

    private const int MinimumCorrectVocabAnswers = 2;

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

    public bool IsCompleted
    {
      get { return _numberOfCorrectGuesses >= MinimumCorrectVocabAnswers; }
    }

    public void TallyCorrectAnswer()
    {
      _numberOfCorrectGuesses++;
    }

    #endregion
  }
}
