using System.Security.Cryptography;

namespace MiracleApp.Pages;

public partial class RibbonPage : ContentPage
{
	public RibbonPage() 
	{
        InitializeComponent();
        Style ThinButton = new Style(typeof(Button))
		{
			Setters =
			{
				new Setter
				{
					Property = Button.BackgroundColorProperty,
					Value = Color.FromRgba(66, 68, 90, 0)
				},
				new Setter
				{
					Property = Button.TextColorProperty,
					Value = Color.FromRgba("#FAE073")
				},
				new Setter
				{
					Property = Button.BorderColorProperty,
					Value = Color.FromRgba("#FAE073")
				},
				new Setter
				{
					Property = Button.FontFamilyProperty,
					Value = "QANELASREGULAR.TTF"
				},
				new Setter
				{
					Property = Button.CornerRadiusProperty,
					Value = "50"
				},
				new Setter
				{
					Property = Button.BorderWidthProperty,
					Value = "2"
				},
				new Setter
				{
					Property = Button.FontSizeProperty,
					Value = "24"
				},
				new Setter
				{
					Property = Button.PaddingProperty,
					Value = "17,9"
				}
			}
		};
		Button MainButton = new Button()
		{
			Text = "Главная",
			Style = ThinButton,
			Margin = 12
        };
		MainButton.Clicked += MainButton_Clicked;
		Button PayButton = new Button()
		{
			Text = "Оплата",
			Style = ThinButton,
			Margin = 12
		};
		PayButton.Clicked += PayButton_Clicked;
		Button RibbonButton = new Button()
		{
			Text = "Лента",
			Style = ThinButton,
			Margin = 12
		};
		RibbonButton.Clicked += RibbonButton_Clicked;
		Button ScheduleButton = new Button()
		{
			Text = "Расписание",
			Style = ThinButton,
			Margin = 12
		};
		ScheduleButton.Clicked += ScheduleButton_Clicked;
		Button ReferenceButton = new Button()
		{
			Text = "Справки",
			Style = ThinButton,
			Margin = 12
		};
		ReferenceButton.Clicked += ReferenceButton_Clicked;
        HorizontalStackLayout navbarOneStr = new HorizontalStackLayout()
		{
			Children = { MainButton, PayButton, RibbonButton }
		};
		HorizontalStackLayout navbarTwoStr = new HorizontalStackLayout()
		{
			Children = { ScheduleButton, ReferenceButton }
		};
		VerticalStackLayout allContent = new VerticalStackLayout();
		allContent.Add(navbarOneStr);
		allContent.Add(navbarTwoStr);
		Content = allContent;
		
	}
	private void MainButton_Clicked(object sender, EventArgs e) =>
		Navigation.PushAsync(new MainPage());
	private void PayButton_Clicked(object sender, EventArgs e) =>
		Navigation.PushAsync(new PayPage());
	private void RibbonButton_Clicked(object sender, EventArgs e) =>
		Navigation.PushAsync(new RibbonPage());
	private void ScheduleButton_Clicked(object sender, EventArgs e) =>
		Navigation.PushAsync(new SchedulePage());
    private void ReferenceButton_Clicked(object sender, EventArgs e) =>
        Navigation.PushAsync(new NotificationsPage());

}