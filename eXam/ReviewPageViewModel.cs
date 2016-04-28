using System;
using System.Collections.Generic;

namespace eXam
{
	public class ReviewPageViewModel
	{
		public  List<QuizQuestionViewModel> QuestionViewModels { get; set; }	

		public ReviewPageViewModel (Game game) {
			QuestionViewModels = new List<QuizQuestionViewModel> ();
			for (int i = 0; i < game.NumberOfQuestions; i++) {
				QuestionViewModels.Add(new QuizQuestionViewModel(game.Questions[i], game.Responses[i]));
			}
		}
	}
}

