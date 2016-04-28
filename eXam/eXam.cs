using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Reflection;
using System.IO;
using Plugin.Connectivity;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.Net.Http;

[assembly: XamlCompilationAttribute(XamlCompilationOptions.Compile)]

namespace eXam
{
	public class App : Application {
		public static Game CurrentGame { get; private set; }
		HomePage homePage;

		public App () {
			// The root page of your application
			MainPage = new NavigationPage(homePage = new HomePage());
			DependencyService.Register<NavigationService>();
		}

		protected override async void OnStart () {
			// Handle when your app starts
			var fileHelper = DependencyService.Get<IFileHelper>();

			string questionsText;

			if (CrossConnectivity.Current.IsConnected == true) {
				questionsText = await new HttpClient().GetStringAsync(JsonQuestionsUri);
			}
			else {
				questionsText = await fileHelper.LoadLocalFileAsync("cachedquestions.json");

				if (string.IsNullOrWhiteSpace(questionsText)) {
					var assembly = typeof(App).GetTypeInfo().Assembly;
					using (var stream = assembly.GetManifestResourceStream("eXam.Data.questions.json")) {
						questionsText = new StreamReader(stream).ReadToEnd();
					}
				}
			}

			var questions = JsonConvert.DeserializeObject<List<QuizQuestion>>(questionsText);
			CurrentGame = new Game(questions);

			homePage.IsStartButtonEnabled = true;
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

		static Uri JsonQuestionsUri {
			get {
				return new Uri("https://www.dropbox.com/s/racrgjrsq2xcwdu/questions.json?raw=1"); 
			}
		}
	}
}

