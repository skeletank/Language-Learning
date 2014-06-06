using MRB.LanguageLearning.Data.Entities;
using MRB.LanguageLearning.Data.Entities.Verb;
using MRB.LanguageLearning.Data.Entities.Verb.Characteristics;
using System;
namespace MRB.LanguageLearning.Data
{
  partial class Verb_Regular
  {
    public string GetVerbEnding(Ending ending)
    {
      string verbEnding = null;

      if(ending.Voice == Voice.Active)
      {
        if(ending.Tense == Tense.Present)
        {
          if(ending.Number == Number.Singular)
          {
            if(ending.Person == Person._1st)
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
          else if(ending.Number == Number.Plural)
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
}
