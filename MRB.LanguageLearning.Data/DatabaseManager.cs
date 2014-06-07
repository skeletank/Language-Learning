using MRB.LanguageLearning.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using MRB.LanguageLearning.Data.Entities;
using MRB.LanguageLearning.Data.Interfaces;
using MRB.LanguageLearning.Data.Entities.Verb;
using MRB.LanguageLearning.Data.Entities.Noun;

using VerbEnding = MRB.LanguageLearning.Data.Entities.Verb.Ending;
using VerbNumber = MRB.LanguageLearning.Data.Entities.Verb.Characteristics.Number;

using NounEnding = MRB.LanguageLearning.Data.Entities.Noun.Ending;
using NounNumber = MRB.LanguageLearning.Data.Entities.Noun.Characteristics.Number;
using MRB.LanguageLearning.Data.Entities.Verb.Characteristics;
using MRB.LanguageLearning.Data.Entities.Noun.Characteristics;

namespace MRB.LanguageLearning.Data
{
  public class DatabaseManager
  {
    #region Fields

    private const int MinimumCorrectVocabAnswers = 2;
    private const int MaximumStudyGroupSize = 15;

    private static Random RandomNumberGenerator = new Random();

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

      int randomVocabIndex = RandomNumberGenerator.Next(studyPool.Count());

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

      int randomVerbIndex = RandomNumberGenerator.Next(verbs.Count());

      return verbs.Skip(randomVerbIndex).FirstOrDefault();
    }

    public Noun_Regular GetRandomNoun()
    {
      IEnumerable<Declension> declensions = _dataContext.Declensions;
      int randomDeclensionIndex = RandomNumberGenerator.Next(declensions.Count());

      Declension declension = declensions.Skip(randomDeclensionIndex).First();

      IEnumerable<Noun_Regular> nouns = _dataContext.Noun_Regulars.Where(n => n.DeclensionFK == declension.Id);
      int randomNounIndex = RandomNumberGenerator.Next(nouns.Count());

      return nouns.Skip(randomNounIndex).First();
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

    public VerbEnding GetRandomVerbEnding()
    {
      Array tenses = Enum.GetValues(typeof(Tense));
      Tense randomTense = (Tense)tenses.GetValue(RandomNumberGenerator.Next(tenses.Length));

      Array voices = Enum.GetValues(typeof(Voice));
      Voice randomVoice = (Voice)voices.GetValue(RandomNumberGenerator.Next(voices.Length));

      Array persons = Enum.GetValues(typeof(Person));
      Person randomPerson = (Person)persons.GetValue(RandomNumberGenerator.Next(persons.Length));

      Array numbers = Enum.GetValues(typeof(VerbNumber));
      VerbNumber randomNumber = (VerbNumber)numbers.GetValue(RandomNumberGenerator.Next(numbers.Length));

      return new VerbEnding(randomNumber, randomPerson, randomTense, randomVoice);
    }

    public NounEnding GetRandomNounEnding()
    {
      Array cases = Enum.GetValues(typeof(Case));
      Case randomCase = (Case)cases.GetValue(RandomNumberGenerator.Next(cases.Length));

      Array numbers = Enum.GetValues(typeof(NounNumber));
      NounNumber randomNumber = (NounNumber)numbers.GetValue(RandomNumberGenerator.Next(numbers.Length));

      return new NounEnding(randomNumber, randomCase);
    }

    #endregion
  }
}