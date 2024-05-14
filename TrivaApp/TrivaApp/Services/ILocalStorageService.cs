using System;
using System.Collections.Generic;
using TrivaApp.Models;

namespace TrivaApp.Services
{
	public interface ILocalStorageService
	{
		void SaveTriviaQuestions(List<TriviaQuestion> questions);
        List<TriviaQuestion> GetAllTriviaQuestions();
		void UpdateTriviaQuestion(TriviaQuestion question);
    }
}

