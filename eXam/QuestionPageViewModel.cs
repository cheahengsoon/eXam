using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace eXam {
	public class QuestionPageViewModel : INotifyPropertyChanged {
		public Game Game;
		public event PropertyChangedEventHandler PropertyChanged;

		public string Question { 
			get { 
				return Game.CurrentQuestion.Question;
			}
		}

		public string Response { 
			get{
				if (Game.CurrentResponse == null)
					return string.Empty;
				return Game.CurrentResponse == Game.CurrentQuestion.Answer ? "Correct!" : "Incorrect!";
			} 
		}

		public Command TrueSelected { get; set; }
		public Command FalseSelected{ get; set; }
		public Command NextSelected { get; set; }

		public bool IsTrueFalseEnabled {
			get {
				return Game.CurrentResponse == null;
			}
		}

		public QuestionPageViewModel () { }

		public QuestionPageViewModel(Game game){
			Game = game;
			Game.Restart();

			TrueSelected = new Command(OnTrue);
			FalseSelected = new Command(OnFalse);
			NextSelected = new Command(OnNext, OnCanExecuteNext);
		}

		void RaiseAllPropertiesChanged () {
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(""));
		}

		void OnTrue() {
			Game.OnTrue();
			RaiseAllPropertiesChanged ();
			NextSelected.ChangeCanExecute();
		}

		void OnFalse() {
			Game.OnFalse();
			RaiseAllPropertiesChanged ();
			NextSelected.ChangeCanExecute();
		}

		async void OnNext() {
			if (Game.NextQuestion() == true) {
				NextSelected.ChangeCanExecute();
				RaiseAllPropertiesChanged();
			}
			else {
				var nav = DependencyService.Get<NavigationService>();
				if (nav != null)
					await nav.GotoPageAsync(AppPage.ReviewPage);
			}
		}

		bool OnCanExecuteNext() {
			return Game.CurrentResponse != null;
		}
	}
}

