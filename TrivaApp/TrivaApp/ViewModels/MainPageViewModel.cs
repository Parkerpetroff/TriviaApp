using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using TrivaApp.Services;
using TrivaApp.Views;
using Xamarin.Forms;

namespace TrivaApp.ViewModels
{
    public class MainPageViewModel : PageViewModel
    {
        private readonly ITriviaService triviaService;

        public ICommand StartCommand { get; set; }

        public MainPageViewModel(INavigation navigation) :
            base(navigation)
        {
            triviaService = DependencyService.Get<ITriviaService>();

            StartCommand = new Command(async () => await StartTrivaQuestions());
        }

        public async Task StartTrivaQuestions()
        {
            var questionList = await triviaService.GetTriviaQuestions();

            await Navigation.PushAsync(new TriviaQuestionPage(questionList.ToList()));
        }
    }
}

