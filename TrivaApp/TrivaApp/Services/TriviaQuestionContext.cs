using System;
using SQLiteNetExtensions.Extensions;
using System.Collections.Generic;
using Xamarin.Forms;
using TrivaApp.Models;

namespace TrivaApp.Services
{

    public class TriviaQuestionContext
    {
        private static TriviaQuestionContext instance;

        public static TriviaQuestionContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TriviaQuestionContext();
                }
                return instance;
            }
        }

        private SQLite.SQLiteConnection connection;

        private TriviaQuestionContext()
        {
            connection = DependencyService.Get<ISQLite>().GetSQLiteConnection();
            CreateTableIfNotExist();
        }

        private void CreateTableIfNotExist()
        {

            bool isTableNotExist = false;

            try
            {
                var test = connection.Table<TriviaQuestion>().FirstOrDefault();
            }
            catch
            {
                isTableNotExist = true;
            }
            if (isTableNotExist)
            {
                connection.CreateTable<TriviaQuestion>();
            }

        }

        public List<TriviaQuestion> GetAllTriviaQuestions()
        {
            return ReadOperations.GetAllWithChildren<TriviaQuestion>(connection);
        }


        public void UpdateTriviaQuestion(TriviaQuestion triviaQuestion)
        {
            WriteOperations.UpdateWithChildren(connection, triviaQuestion);
        }

        public void InsertTriviaQuestions(List<TriviaQuestion> triviaQuestion)
        {
            foreach (TriviaQuestion question in triviaQuestion)
            {
                WriteOperations.InsertWithChildren(connection, question);
            }
        }

        public void ResetDatabase()
        {
            WriteOperations.DeleteAll(connection, ReadOperations.GetAllWithChildren<TriviaQuestion>(connection));
        }
    }
}

