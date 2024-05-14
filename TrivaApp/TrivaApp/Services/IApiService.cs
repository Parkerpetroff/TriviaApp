using System;
using System.Threading.Tasks;
using TrivaApp.Models;

namespace TrivaApp.Services
{
	public interface IApiService
	{
        Task<string> GetAsync(string uri);
    }
}

