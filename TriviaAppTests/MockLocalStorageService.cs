using System;
using TrivaApp.Models;
using TrivaApp.Services;

namespace TriviaAppTests
{
    public class MockLocalStorageService : ILocalStorageService
	{
		public MockLocalStorageService()
		{
		}

        public List<TriviaQuestion> GetAllTriviaQuestions()
        {
           return new List<TriviaQuestion>()
            {
                new TriviaQuestion()
                {
                    Question = "This is true",
                    CorrectAnswer = "True",
                    Incorrect_Answer = "False",
                    Category = "Category",
                    Difficulty = "Easy",
                    UserAnswer = ""
                }
            };
        }

        public void SaveTriviaQuestions(List<TriviaQuestion> questions)
        {
           
        }

        public void UpdateTriviaQuestion(TriviaQuestion question)
        {
            
        }
    }
}

