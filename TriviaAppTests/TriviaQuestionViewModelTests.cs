using System;
using TrivaApp;
using TrivaApp.Models;
using TrivaApp.ViewModels;
using Xamarin.Forms;

namespace TriviaAppTests
{
    [TestClass]
    public class TriviaQuestionViewModelTests
    {
        [TestMethod]
        public void TestCorrectTrueFirstAnswer()
        {
            // Arrange
            var viewModel = GetViewModel();

            // Act
            viewModel.TrueCommand.Execute(null);

            //Assert
            Assert.AreSame(viewModel.TriviaQuestion.UserAnswer, viewModel.TriviaQuestion.CorrectAnswer);
        }

        private static TriviaQuestionViewModel GetViewModel()
        {
            var questions = GenerateMockTriviaQuestions();
            var localStorageService = new MockLocalStorageService();
            return new TriviaQuestionViewModel(null, questions, localStorageService:localStorageService);
        }

        private static List<TriviaQuestion> GenerateMockTriviaQuestions()
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
    }
}

