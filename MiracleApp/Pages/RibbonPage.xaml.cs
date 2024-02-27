using CommunityToolkit.Maui.Core.Platform;
using Core.Entity;
using Microsoft.Maui.Controls.Shapes;
using System.Security.Cryptography;

namespace MiracleApp.Pages;

public partial class RibbonPage : ContentPage
{
    public RibbonPage()
    {
        RibbonLib lib = new RibbonLib();
        lib.AddPostBtn.Clicked += AddNewPostButton_Clicked;
        lib.MainButton.Clicked += MainButton_Clicked;
        lib.PayButton.Clicked += PayButton_Clicked;
        lib.RibbonButton.Clicked += RibbonButton_Clicked;
        lib.ScheduleButton.Clicked += ScheduleButton_Clicked;
        lib.ReferenceButton.Clicked += ReferenceButton_Clicked;
        HorizontalStackLayout navbarOneStr = new HorizontalStackLayout()
        {
            Children = { lib.MainButton, lib.PayButton, lib.RibbonButton, lib.ScheduleButton, lib.ReferenceButton }
        };
        ScrollView scrol = new ScrollView()
        {
            Content = navbarOneStr,
            Orientation = ScrollOrientation.Horizontal,
            Margin = new Thickness(0, 24, 0, 0),
            HorizontalScrollBarVisibility = ScrollBarVisibility.Never,
            BackgroundColor = Color.FromRgba(66, 68, 90, 0)
        };
        StackLayout allContent = new StackLayout();
        Border avatarBorder = new Border()
        {
            Content = new Image()
            {
                WidthRequest = 60,
                HeightRequest = 60,
                Source = "avatar9num.jpg",
            },
            StrokeShape = new RoundRectangle { CornerRadius = 50 },
            WidthRequest = 60,
            HeightRequest = 60,
            Margin = new Thickness ( 24, 0, 0, 0)
        };
        Label userName = new Label()
        {
            Text = "User name",
            TextColor = Color.FromArgb("#FAE073"),
            FontSize = 18
        };
        Label time = new Label()
        {
            Text = "Time",
            TextColor = Color.FromArgb("#FAE073"),
            FontSize = 18
        };
        VerticalStackLayout nameAndTime = new VerticalStackLayout()
        {
            Children = { userName, time },
            Margin = new Thickness ( 6, 6, 0, 0 )
        };
        HorizontalStackLayout Profil = new HorizontalStackLayout()
        { 
            Children = { avatarBorder, nameAndTime},
            Margin = new Thickness (0, 0, 0, 12)
        };
        Label postText = new Label()
        {
            Text = "Вообщем то тут будет большой текст настоящего поста а это просто текст чтобы прверить как переносяться слова на след строку",
            TextColor = Color.FromArgb("#FAE073"),
            FontSize = 18,
            Margin = new Thickness(24, 0, 24, 0)
        };
        Label countLikes = new Label()
        {
            Text = "1K",
            TextColor = Color.FromArgb("#FAE073"),
            FontSize = 18,
            Margin = new Thickness(0, 0, 12, 0)
        };
        Label countDisLike = new Label()
        {
            Text = "1K",
            TextColor = Color.FromArgb("#FAE073"),
            FontSize = 18,
            Margin = new Thickness(0, 0, 12, 0)
        };
        Label countComment = new Label()
        {
            Text = "1K",
            TextColor = Color.FromArgb("#FAE073"),
            FontSize = 18,
            Margin = new Thickness(0, 0, 12, 0)
        };
        Label countComplaint = new Label()
        {
            Text = "1K",
            TextColor = Color.FromArgb("#FAE073"),
            FontSize = 18,
            Margin = new Thickness(0, 0, 12, 0)
        };
        Label userInfo = new Label()
        {
            Text = "1 курс, дизайн",
            TextColor = Color.FromArgb("#FAE073"),
            FontSize = 18
        };
        HorizontalStackLayout footer = new HorizontalStackLayout()
        {
            Children = { 
                lib.LikeButton,
                countLikes,
                lib.DisLikeButton,
                countDisLike,
                lib.CommentButton,
                countComment,
                lib.ComplaitButton,
                countComplaint,
                lib.BasketButton },
            Margin = new Thickness(0, 16, 0, 0)
        };






        VerticalStackLayout Post = new VerticalStackLayout()
        {
            Children = { Profil, postText, footer}
        };




        BackgroundImageSource = "bg.png";
        allContent.Children.Add(scrol);
        allContent.Children.Add(lib.AddPostBtn);
        allContent.Children.Add(Post);

        Content = allContent;
    }
    private void addPost(int lastIndex)
    {
        
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
    private void AddNewPostButton_Clicked(object sender, EventArgs e)
    {

    }
}