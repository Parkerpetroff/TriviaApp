using System;
using Newtonsoft.Json;
using SQLite;

namespace TrivaApp.Models
{
	public class TriviaQuestion
	{
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [JsonProperty("question")]
        public string Question { get; set; }

        [JsonProperty("difficulty")]
        public string Difficulty { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("correct_answer")]
        public string CorrectAnswer { get; set; }

        [JsonProperty("incorrect_answer")]
        public string Incorrect_Answer { get; set; }

        public string UserAnswer { get; set; }
	}
}

