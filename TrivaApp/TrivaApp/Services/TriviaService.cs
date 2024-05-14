using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TrivaApp.Models;
using TrivaApp.Services;
using Xamarin.Forms;

[assembly:Dependency(typeof(TriviaService))]
namespace TrivaApp.Services
{
    public class TriviaService : ITriviaService
    {
        private readonly IApiService ApiService;
        private readonly ILocalStorageService localStorageService;

        public TriviaService()
        {
            ApiService = DependencyService.Get<IApiService>();
            localStorageService = DependencyService.Get<ILocalStorageService>();
        }

        public async Task<IEnumerable<TriviaQuestion>> GetTriviaQuestions()
        {
            //Check for saved questions, grab from api if none
            var savedQuestions = localStorageService.GetAllTriviaQuestions();
            if (savedQuestions != null && savedQuestions.Count > 0)
            {
                return savedQuestions;
            }
            else
            {
                var res = await ApiService.GetAsync("https://opentdb.com/api.php?amount=10&type=boolean");
                var questions = JsonConvert.DeserializeObject<TriviaHTTPResponse>(res).results;
                localStorageService.SaveTriviaQuestions(questions.ToList());
                return questions;
            }
        }
    }
}

