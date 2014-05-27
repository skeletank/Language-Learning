using MRB.LanguageLearning.Data.Entities;
using System;
namespace MRB.LanguageLearning.Data
{
  partial class Verb_Regular
  {
    public string GetVerbTenseEnding(VerbTense verbTense)
    {
      string verbTenseEnding;

      switch(verbTense)
      {
        case VerbTense.ActiveVoice1stPersonSingular:
          verbTenseEnding = Conjugation.Present_1stPerson_Singular_Active_Ending;
          break;
        case VerbTense.ActiveVoice2ndPersonSingular:
          verbTenseEnding = Conjugation.Present_2ndPerson_Singular_Active_Ending;
          break;
        case VerbTense.ActiveVoice3rdPersonSingular:
          verbTenseEnding = Conjugation.Present_3rdPerson_Singular_Active_Ending;
          break;
        case VerbTense.ActiveVoice1stPersonPlural:
          verbTenseEnding = Conjugation.Present_1stPerson_Plural_Active_Ending;
          break;
        case VerbTense.ActiveVoice2ndPersonPlural:
          verbTenseEnding = Conjugation.Present_2ndPerson_Plural_Active_Ending;
          break;
        case VerbTense.ActiveVoice3rdPersonPlural:
          verbTenseEnding = Conjugation.Present_3rdPerson_Plural_Active_Ending;
          break;
        default:
          throw new ArgumentException();
      }

      return verbTenseEnding;
    }
  }
}
