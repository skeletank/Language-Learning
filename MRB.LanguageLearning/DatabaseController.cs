﻿using MRB.LanguageLearning.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace MRB.LanguageLearning
{
    public class DatabaseController
    {
        #region Fields

        private LanguageLearningDataContext _dataContext;

        #endregion

        #region Constructors

        public DatabaseController()
        {
            _dataContext = new LanguageLearningDataContext();
        }

        #endregion

        #region Methods

        public Verb_Regular GetRandomVerb(int? conjugationId = null)
        {
            IQueryable<Verb_Regular> regularVerbs = _dataContext.Verb_Regulars;

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
