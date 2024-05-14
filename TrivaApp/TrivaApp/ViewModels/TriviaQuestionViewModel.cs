using System.Collections.Generic;
using System.Windows.Input;
using TrivaApp.Models;
using TrivaApp.Services;
using Xamarin.Forms;

namespace TrivaApp.ViewModels
{
    public class TriviaQuestionViewModel : PageViewModel
    {

        private TriviaQuestion _triviaQuestion;
        public TriviaQuestion TriviaQuestion
        {
            get => _triviaQuestion;
            set
            {
                _triviaQuestion = value;
                OnPropertyChanged();
            }
        }

        private string _question;
        public string Question
        {
            get => _question;
            set
            {
                _question = value;
                OnPropertyChanged();
            }
        }

        private List<TriviaQuestion> _questionList;
        public List<TriviaQuestion> QuestionList
        {
            get => _questionList;
            set
            {
                _questionList = value;
                OnPropertyChanged();
            }
        }

        private string _resultText;
        public string ResultText
        {
            get => _resultText;
            set
            {
                _resultText = value;
                OnPropertyChanged();
            }
        }

        public int Index;
        public ICommand TrueCommand { get; set; }

        public ICommand FalseCommand { get; set; }

        public ICommand NextCommand { get; set; }

        public ICommand BackCommand { get; set; }

        private readonly ILocalStorageService _localStorageService;


        public TriviaQuestionViewModel(INavigation navigation,
            List<TriviaQuestion> questionList,
            ILocalStorageService localStorageService = null) :
            base(navigation)

        {
            _localStorageService = localStorageService ?? DependencyService.Get<ILocalStorageService>();
            Index = 0;
            QuestionList = questionList;
            ResetAnswerUI();
            TrueCommand = new Command(() => CheckAnswerResponse("True"));
            FalseCommand = new Command(() => CheckAnswerResponse("False"));
            NextCommand = new Command(GoNext);
            BackCommand = new Command(GoBack);
        }

        private void CheckAnswerResponse(string response)
        {
            TriviaQuestion.UserAnswer = response;
            _localStorageService.UpdateTriviaQuestion(TriviaQuestion);
            UpdateResponseLabel();
        }

        private void UpdateResponseLabel()
        {
            if (TriviaQuestion.UserAnswer == null || TriviaQuestion.UserAnswer == "")
            {
                ResultText = "";
            }
            else
            {
                if (TriviaQuestion.UserAnswer == TriviaQuestion.CorrectAnswer)
                {
                    ResultText = "Correct you answered: " + TriviaQuestion.UserAnswer;
                }
                else
                {
                    ResultText = "Incorrect you answered: " + TriviaQuestion.UserAnswer;
                }
            }

        }

        private void ResetAnswerUI()
        {
            TriviaQuestion = QuestionList[Index];
            Question = System.Net.WebUtility.HtmlDecode(TriviaQuestion.Question);
            UpdateResponseLabel();
        }

        private void GoNext()
        {

            if (Index < QuestionList.Count - 1)
            {
                Index++;
                ResetAnswerUI();
            }

        }

        private void GoBack()
        {

            if (Index > 0)
            {
                Index--;
                ResetAnswerUI();
            }
        }
    }
}

