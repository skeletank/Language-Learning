using MRB.LanguageLearning.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRB.LanguageLearning.Data.Entities.Nouns
{
  public class NounVocab : VocabItem
  {
    #region Fields

    private Noun_Regular _regularNoun;

    #endregion

    #region Constructors

    public NounVocab(Noun_Regular regularNoun)
    {
      _regularNoun = regularNoun;
    }

    #endregion

    #region Overrides

    public override string KnownLanguageDefinition
    {
      get { return _regularNoun.EnglishDefinition; }
    }

    public override string ForeignLanguageDefinition
    {
      get { return _regularNoun.Root + _regularNoun.Declension.Singular_Nominative_Ending; }
    }

    #endregion
  }
}
