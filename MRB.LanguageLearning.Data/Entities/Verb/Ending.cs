using MRB.LanguageLearning.Data.Entities.Verb.Characteristics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRB.LanguageLearning.Data.Entities.Verb
{
  public class Ending
  {
    #region Fields

    private Number _number;
    private Person _person;
    private Tense _tense;
    private Voice _voice;

    #endregion

    #region Constructors

    public Ending(Number number, Person person, Tense tense, Voice voice)
    {
      _number = number;
      _person = person;
      _tense = tense;
      _voice = voice;
    }

    #endregion

    #region Properties

    public Number Number
    {
      get { return _number; }
    }

    public Person Person
    {
      get { return _person; }
    }

    public Tense Tense
    {
      get { return _tense; }
    }

    public Voice Voice
    {
      get { return _voice; }
    }

    public string Display
    {
      get
      {
        string number = Enum.GetName(typeof(Number), _number);
        string person = Enum.GetName(typeof(Person), _person);
        string tense = Enum.GetName(typeof(Tense), _tense);
        string voice = Enum.GetName(typeof(Voice), _voice);

        return String.Format("{0} Tense {1} Voice {2} Person {3}", tense, voice, person, number);
      }
    }

    #endregion
  }
}
