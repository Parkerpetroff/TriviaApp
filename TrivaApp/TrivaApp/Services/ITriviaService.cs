using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrivaApp.Models;

namespace TrivaApp.Services
{
	public interface ITriviaService
	{
        Task<IEnumerable<TriviaQuestion>> GetTriviaQuestions();
    }
}

