using MRB.LanguageLearning.Data.Entities.PersonalPronouns.Characteristics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRB.LanguageLearning.Data.Entities.PersonalPronouns
{
  public class PersonalPronoun
  {
    #region Fields

    private Case _case;
    private Number _number;
    private Person _person;
    private string _name;

    private static List<PersonalPronoun> _allPersonalPronouns = new List<PersonalPronoun>();

    #endregion

    #region Constructors

    static PersonalPronoun()
    {
      _allPersonalPronouns.Add(new PersonalPronoun(Case.Nominative, Number.Singular, Person._1st, "ego"));
      _allPersonalPronouns.Add(new PersonalPronoun(Case.Nominative, Number.Plural, Person._1st, "nōs"));
      _allPersonalPronouns.Add(new PersonalPronoun(Case.Nominative, Number.Singular, Person._2nd, "tū"));
      _allPersonalPronouns.Add(new PersonalPronoun(Case.Nominative, Number.Plural, Person._2nd, "vōs"));
      _allPersonalPronouns.Add(new PersonalPronoun(Case.Genitive, Number.Singular, Person._1st, "meī"));
      _allPersonalPronouns.Add(new PersonalPronoun(Case.Genitive, Number.Plural, Person._1st, "nostrī"));
      _allPersonalPronouns.Add(new PersonalPronoun(Case.Genitive, Number.Singular, Person._2nd, "tuī"));
      _allPersonalPronouns.Add(new PersonalPronoun(Case.Genitive, Number.Plural, Person._2nd, "vestrī"));
      _allPersonalPronouns.Add(new PersonalPronoun(Case.Dative, Number.Singular, Person._1st, "mihi"));
      _allPersonalPronouns.Add(new PersonalPronoun(Case.Dative, Number.Plural, Person._1st, "nōbīs"));
      _allPersonalPronouns.Add(new PersonalPronoun(Case.Dative, Number.Singular, Person._2nd, "tibi"));
      _allPersonalPronouns.Add(new PersonalPronoun(Case.Dative, Number.Plural, Person._2nd, "vōbīs"));
      _allPersonalPronouns.Add(new PersonalPronoun(Case.Accusative, Number.Singular, Person._1st, "mē"));
      _allPersonalPronouns.Add(new PersonalPronoun(Case.Accusative, Number.Plural, Person._1st, "nōs"));
      _allPersonalPronouns.Add(new PersonalPronoun(Case.Accusative, Number.Singular, Person._2nd, "tē"));
      _allPersonalPronouns.Add(new PersonalPronoun(Case.Accusative, Number.Plural, Person._2nd, "vōs"));
      _allPersonalPronouns.Add(new PersonalPronoun(Case.Ablative, Number.Singular, Person._1st, "mē"));
      _allPersonalPronouns.Add(new PersonalPronoun(Case.Ablative, Number.Plural, Person._1st, "nōbīs"));
      _allPersonalPronouns.Add(new PersonalPronoun(Case.Ablative, Number.Singular, Person._2nd, "tē"));
      _allPersonalPronouns.Add(new PersonalPronoun(Case.Ablative, Number.Plural, Person._2nd, "vōbīs"));
    }

    private PersonalPronoun(Case personalPronounCase, Number number, Person person, string name)
    {
      _case = personalPronounCase;
      _number = number;
      _person = person;
      _name = name;
    }

    #endregion

    #region Properties

    public static IEnumerable<PersonalPronoun> All
    {
      get { return _allPersonalPronouns; }
    }

    public Case Case
    {
      get { return _case; }
    }

    public Number Number
    {
      get { return _number; }
    }

    public Person Person
    {
      get { return _person; }
    }

    public string Name
    {
      get { return _name; }
    }

    public string Display
    {
      get
      {
        string number = Enum.GetName(typeof(Number), _number);
        string personalPronounCase = Enum.GetName(typeof(Case), _case);
        string person = Enum.GetName(typeof(Person), _person);

        return String.Format("{0} - {1} Person - {2}", personalPronounCase, person, number);
      }
    }

    #endregion
  }
}
