using MRB.LanguageLearning.Data.Entities;
using MRB.LanguageLearning.Data.Entities.Verb;
using MRB.LanguageLearning.Data.Entities.Verb.Characteristics;
using System;

using VerbEnding = MRB.LanguageLearning.Data.Entities.Verb.Ending;
using VerbNumber = MRB.LanguageLearning.Data.Entities.Verb.Characteristics.Number;

using NounEnding = MRB.LanguageLearning.Data.Entities.Noun.Ending;
using NounNumber = MRB.LanguageLearning.Data.Entities.Noun.Characteristics.Number;
using MRB.LanguageLearning.Data.Entities.Noun.Characteristics;

namespace MRB.LanguageLearning.Data
{
  partial class Verb_Regular
  {
    public string GetVerbEnding(VerbEnding ending)
    {
      string verbEnding = null;

      if (ending.Voice == Voice.Active)
      {
        if (ending.Tense == Tense.Present)
        {
          if (ending.Number == VerbNumber.Singular)
          {
            if (ending.Person == Person._1st)
            {
              verbEnding = Conjugation.Present_1stPerson_Singular_Active_Ending;
            }
            else if (ending.Person == Person._2nd)
            {
              verbEnding = Conjugation.Present_2ndPerson_Singular_Active_Ending;
            }
            else if (ending.Person == Person._3rd)
            {
              verbEnding = Conjugation.Present_3rdPerson_Singular_Active_Ending;
            }
          }
          else if (ending.Number == VerbNumber.Plural)
          {
            if (ending.Person == Person._1st)
            {
              verbEnding = Conjugation.Present_1stPerson_Plural_Active_Ending;
            }
            else if (ending.Person == Person._2nd)
            {
              verbEnding = Conjugation.Present_2ndPerson_Plural_Active_Ending;
            }
            else if (ending.Person == Person._3rd)
            {
              verbEnding = Conjugation.Present_3rdPerson_Plural_Active_Ending;
            }
          }
        }
      }

      return verbEnding;
    }
  }

  partial class Noun_Regular
  {
    public string GetNounEnding(NounEnding ending)
    {
      string nounEnding = null;

      if (ending.Number == NounNumber.Singular)
      {
        if (ending.Case == Case.Nominative)
        {
          nounEnding = Declension.Singular_Nominative_Ending;
        }
        else if (ending.Case == Case.Genitive)
        {
          nounEnding = Declension.Singular_Genitive_Ending;
        }
        else if (ending.Case == Case.Dative)
        {
          nounEnding = Declension.Singular_Dative_Ending;
        }
        else if (ending.Case == Case.Accusative)
        {
          nounEnding = Declension.Singular_Accusative_Ending;
        }
        else if (ending.Case == Case.Ablative)
        {
          nounEnding = Declension.Singular_Ablative_Ending;
        }
        else if (ending.Case == Case.Vocative)
        {
          nounEnding = Declension.Singular_Vocative_Ending;
        }
      }
      else if(ending.Number == NounNumber.Plural)
      {
        if (ending.Case == Case.Nominative)
        {
          nounEnding = Declension.Plural_Nominative_Ending;
        }
        else if (ending.Case == Case.Genitive)
        {
          nounEnding = Declension.Plural_Genitive_Ending;
        }
        else if (ending.Case == Case.Dative)
        {
          nounEnding = Declension.Plural_Dative_Ending;
        }
        else if (ending.Case == Case.Accusative)
        {
          nounEnding = Declension.Plural_Accusative_Ending;
        }
        else if (ending.Case == Case.Ablative)
        {
          nounEnding = Declension.Plural_Ablative_Ending;
        }
        else if (ending.Case == Case.Vocative)
        {
          nounEnding = Declension.Plural_Vocative_Ending;
        }
      }

      return nounEnding;
    }
  }
}
