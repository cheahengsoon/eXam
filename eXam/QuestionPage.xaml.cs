using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace eXam
{
	public partial class QuestionPage : ContentPage
	{
		public QuestionPage () {
			InitializeComponent ();
		}

		public QuestionPage (QuestionPageViewModel qpvm) : this() {
			BindingContext = qpvm;
		}
	}
}

