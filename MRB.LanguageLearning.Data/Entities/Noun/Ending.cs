using MRB.LanguageLearning.Data.Entities.Noun.Characteristics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRB.LanguageLearning.Data.Entities.Noun
{
  public class Ending
  {
    #region Fields

    private Number _number;
    private Case _case;

    #endregion

    #region Constructors

    public Ending(Number number, Case nounCase)
    {
      _number = number;
      _case = nounCase;
    }

    #endregion

    #region Properties

    public Number Number
    {
      get { return _number; }
    }

    public Case Case
    {
      get { return _case; }
    }

    public string Display
    {
      get
      {
        string number = Enum.GetName(typeof(Number), _number);
        string nounCase = Enum.GetName(typeof(Case), _case);

        return String.Format("{0} Case {1}", nounCase, number);
      }
    }

    #endregion
  }
}
