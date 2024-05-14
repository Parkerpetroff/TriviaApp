using System;
using System.Collections.Generic;
using TrivaApp.Models;
using TrivaApp.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocalStorageService))]
namespace TrivaApp.Services
{
    public class LocalStorageService : ILocalStorageService
    {
        public LocalStorageService()
        {
        }

        public List<TriviaQuestion> GetAllTriviaQuestions()
        {
            return TriviaQuestionContext.Instance.GetAllTriviaQuestions();
        }

        public void SaveTriviaQuestions(List<TriviaQuestion> questions)
        {
            TriviaQuestionContext.Instance.InsertTriviaQuestions(questions);
        }

        public void UpdateTriviaQuestion(TriviaQuestion question)
        {
            TriviaQuestionContext.Instance.UpdateTriviaQuestion(question);
        }
    }
}

