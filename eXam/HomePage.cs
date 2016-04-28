using System;

using Xamarin.Forms;

namespace eXam
{
	public class HomePage : ContentPage
	{
		public bool IsStartButtonEnabled
		{
			get { return btn.IsEnabled; }
			set { btn.IsEnabled = value; }
		}

		Button btn;

		public HomePage ()
		{

			NavigationPage.SetHasNavigationBar (this, false);
				
			var layout = new AbsoluteLayout();

			Content = layout;

			btn = new Button () {
				BackgroundColor = Color.FromHex("#FFC107"),
				TextColor = Color.White,
				Text = "Start eXam!",
				IsEnabled = false
			};

			var img = new Image () {
				Source = ImageSource.FromResource("eXam.Images.background.jpg"),
				Aspect = Aspect.AspectFill
			};
			layout.Children.Add (img, new Rectangle (0, 0, 1, 1), AbsoluteLayoutFlags.SizeProportional);

			layout.Children.Add(btn, new Rectangle(0.5, 0.5, 150, 60), AbsoluteLayoutFlags.PositionProportional);

			btn.Clicked += OnStartClicked;
		}


		async void OnStartClicked(object sender, EventArgs e) {
			var nav = DependencyService.Get<NavigationService>();
			if (nav != null)
				await nav.GotoPageAsync(AppPage.QuestionPage);
		}
	}
}


