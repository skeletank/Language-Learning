using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRB.LanguageLearning.Data.Interfaces
{
  public interface IVocabItem
  {
    string KnownLanguageDefinition { get; }
    string ForeignLanguageDefinition { get; }
    int NumberOfCorrectAnswers { get; }
    bool IsCompleted { get; }

    void TallyCorrectAnswer();
  }
}
