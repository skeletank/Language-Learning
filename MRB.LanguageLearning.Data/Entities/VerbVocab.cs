using MRB.LanguageLearning.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRB.LanguageLearning.Data.Entities
{
  public class VerbVocab : VocabItem
  {
    #region Fields

    private Verb_Regular _regularVerb;

    #endregion

    #region Constructors

    public VerbVocab(Verb_Regular regularVerb)
    {
      _regularVerb = regularVerb;
    }

    #endregion

    #region Overrides

    public override string KnownLanguageDefinition
    {
      get { return _regularVerb.EnglishDefinition; }
    }

    public override string ForeignLanguageDefinition
    {
      get { return _regularVerb.Infinitive; }
    }

    #endregion
  }
}
