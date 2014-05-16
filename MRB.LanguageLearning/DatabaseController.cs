using MRB.LanguageLearning.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using MRB.LanguageLearning.Utility;

namespace MRB.LanguageLearning
{
    public class DatabaseController
    {
        #region Fields

        private const int MinimumVerbTries = 2;

        private LanguageLearningDataContext _dataContext;
        private Dictionary<Verb_Regular, VerbStatistics> _verbSuccessRates = new Dictionary<Verb_Regular, VerbStatistics>();

        #endregion

        #region Constructors

        public DatabaseController()
        {
            _dataContext = new LanguageLearningDataContext();

            Table<Verb_Regular> regularVerbs = _dataContext.Verb_Regulars;

            foreach (Verb_Regular verb in regularVerbs)
                _verbSuccessRates.Add(verb, new VerbStatistics());
        }

        #endregion

        #region Methods

        public void UpdateVerbSuccessRate(Verb_Regular regularVerb, bool isCorrect)
        {
            VerbStatistics statistics = _verbSuccessRates[regularVerb];
            statistics.NumberOfGuesses++;

            if(isCorrect)
                statistics.NumberOfCorrectGuesses++;
        }

        public Verb_Regular GetRandomVerb(int? conjugationId = null)
        {
            List<Verb_Regular> verbStudyPool = new List<Verb_Regular>();

            foreach (var verbSuccessRate in _verbSuccessRates.Where(vsr => conjugationId == null || vsr.Key.ConjugationFK == conjugationId))
            {
                VerbStatistics statistics = verbSuccessRate.Value;
                int probabilityOfVerb = 100 -  (statistics.NumberOfGuesses >= 2 ? statistics.PercentCorrect : 0);

                for (int i = 0; i < probabilityOfVerb; i++)
                    verbStudyPool.Add(verbSuccessRate.Key);
            }

            IEnumerable<Verb_Regular> regularVerbs = verbStudyPool;

            if (conjugationId != null)
                regularVerbs = regularVerbs.Where(rv => rv.ConjugationFK == conjugationId);

            Random random = new Random();
            int randomVerbIndex = random.Next(regularVerbs.Count());

            return regularVerbs.Skip(randomVerbIndex).FirstOrDefault();
        }

        public IEnumerable<Conjugation> GetAllConjugations()
        {
            return _dataContext.Conjugations;
        }

        #endregion
    }
}
