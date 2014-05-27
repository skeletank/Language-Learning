using MRB.LanguageLearning.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using MRB.LanguageLearning.Data.Entities;
using MRB.LanguageLearning.Data.Interfaces;

namespace MRB.LanguageLearning.Data
{
  public class DatabaseManager
  {
    #region Fields

    private const int MinimumCorrectVocabAnswers = 2;
    private const int MaximumStudyGroupSize = 15;

    private LanguageLearningDataContext _dataContext;
    private List<IVocabItem> _allVocabItems;

    #endregion

    #region Constructors

    public DatabaseManager()
    {
      _dataContext = new LanguageLearningDataContext();

      _allVocabItems = new List<IVocabItem>();
      _allVocabItems.AddRange(_dataContext.Verb_Regulars.Select(vr => new VerbVocab(vr)));
      _allVocabItems.AddRange(_dataContext.Noun_Regulars.Select(vr => new NounVocab(vr)));
    }

    #endregion

    #region Methods

    public IVocabItem GetRandomVocab(VocabStudyGroup selectedStudyGroup)
    {
      List<IVocabItem> studyPool = new List<IVocabItem>();

      foreach(IVocabItem vocabItem in selectedStudyGroup.VocabItems)
      {
        if(!vocabItem.IsCompleted)
          studyPool.Add(vocabItem);
      }

      Random random = new Random();
      int randomVocabIndex = random.Next(studyPool.Count());

      return studyPool.Skip(randomVocabIndex).FirstOrDefault();
    }

    public void UpdateVocabSuccessRate(IVocabItem vocabItem, bool isCorrect)
    {
      if (isCorrect)
        vocabItem.TallyCorrectAnswer();
    }

    public Verb_Regular GetRandomVerb()
    {
      IEnumerable<Verb_Regular> verbs = _dataContext.Verb_Regulars;

      Random random = new Random();
      int randomVerbIndex = random.Next(verbs.Count());

      return verbs.Skip(randomVerbIndex).FirstOrDefault();
    }

    public IEnumerable<VocabStudyGroup> GetVocabStudyGroups()
    {
      List<VocabStudyGroup> studyGroups = new List<VocabStudyGroup>();
      IEnumerable<IVocabItem> vocabOrderedAlphabetically = _allVocabItems.OrderBy(vr => vr.ForeignLanguageDefinition);

      studyGroups.Add(new VocabStudyGroup("All", vocabOrderedAlphabetically));

      int numberOfVocab = vocabOrderedAlphabetically.Count();
      int numberOfVocabGroups = (int)Math.Ceiling((double)numberOfVocab / (double)MaximumStudyGroupSize);

      for (int i = 0; i < numberOfVocabGroups; i++)
      {
        List<IVocabItem> vocabItems = new List<IVocabItem>();

        int vocabItemsToSkip = i * MaximumStudyGroupSize;
        vocabItems.AddRange(vocabOrderedAlphabetically.Skip(vocabItemsToSkip).Take(MaximumStudyGroupSize));

        string groupName = String.Format("{0} - {1}", vocabItems.First().ForeignLanguageDefinition, vocabItems.Last().ForeignLanguageDefinition);

        studyGroups.Add(new VocabStudyGroup(groupName, vocabItems));
      }


      return studyGroups;
    }

    #endregion
  }
}