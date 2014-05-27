using MRB.LanguageLearning.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRB.LanguageLearning.Data.Entities
{
  public class VocabStudyGroup
  {
    #region Fields

    private readonly string _groupName;
    private readonly IEnumerable<IVocabItem> _vocabItems;

    #endregion

    #region Constructors

    public VocabStudyGroup(string groupName, IEnumerable<IVocabItem> vocabItems)
    {
      _groupName = groupName;
      _vocabItems = vocabItems;
    }

    #endregion

    #region Properties

    public string GroupName
    {
      get { return _groupName; }
    }

    public bool IsCompleted
    {
      get 
      {
        foreach(IVocabItem vocabItem in _vocabItems)
        {
          if (!vocabItem.IsCompleted)
            return false;
        }

        return true;
      }
    }

    public IEnumerable<IVocabItem> VocabItems
    {
      get { return _vocabItems; }
    }

    #endregion
  }
}
