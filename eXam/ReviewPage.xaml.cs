using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;

namespace eXam
{
	public partial class ReviewPage : ContentPage
	{
		public ReviewPage () {
			InitializeComponent ();
		}

		public ReviewPage(ReviewPageViewModel rpvm) : this(){
			BindingContext = rpvm;
			this.Title = rpvm.QuestionViewModels.Count (x => x.IsCorrect) + " correct out of " + rpvm.QuestionViewModels.Count + " questions"; 
			listQuestions.ItemTapped += OnListItemTapped;
		}

		void OnListItemTapped (object sender, ItemTappedEventArgs e) {
			var qqvm = (QuizQuestionViewModel)e.Item;

			if(qqvm != null)
				this.DisplayAlert("Explanation", qqvm.Explanation, "OK");
		}
	}
}

