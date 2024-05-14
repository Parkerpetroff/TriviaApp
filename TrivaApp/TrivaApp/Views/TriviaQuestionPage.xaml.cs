using System;
using System.Collections.Generic;
using TrivaApp.Models;
using TrivaApp.ViewModels;
using Xamarin.Forms;

namespace TrivaApp.Views
{	
	public partial class TriviaQuestionPage : ContentPage
	{	
		public TriviaQuestionPage (List<TriviaQuestion> triviaQuestion)
		{
			InitializeComponent ();
			BindingContext = new TriviaQuestionViewModel(Navigation, triviaQuestion);

        }
	}
}

