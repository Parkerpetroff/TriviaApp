using System;
using System.Collections;
using System.Collections.Generic;

namespace TrivaApp.Models
{
	public class TriviaHTTPResponse
	{
		public string response_code { get; set; }
		public IEnumerable<TriviaQuestion> results{get;set;} 

	}
}

