using CommunityToolkit.Maui.Core.Platform;
using Core.Entity;
using Microsoft.Maui.Controls.Shapes;
using System.Security.Cryptography;

namespace MiracleApp
{
    public class RibbonLib
    {
        static Style ThinButton = new Style(typeof(Button))
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
                    Value = 50
                },
                new Setter
                {
                    Property = Button.BorderWidthProperty,
                    Value = 2
                },
                new Setter
                {
                    Property = Button.FontSizeProperty,
                    Value = 24
                },
                new Setter
                {
                    Property = Button.PaddingProperty,
                    Value = 10
                }
            }
        };
        public Button AddPostBtn = new Button()
        {
            ImageSource = "addpostico.png",
            WidthRequest = 52,
            HeightRequest = 52,
            CornerRadius = 16,
            BorderColor = Color.FromRgba("#FAE073"),
            BorderWidth = 2,
            Margin = new Thickness(358, 14, 72, 4),
            BackgroundColor = Color.FromRgba(66, 68, 90, 0)
        };
        public Button MainButton = new Button()
        {
            Text = "Главная",
            Style = ThinButton,
            Margin = 12
        };
        public Button PayButton = new Button()
        {
            Text = "Оплата",
            Style = ThinButton,
            Margin = 12
        };
        public Button RibbonButton = new Button()
        {
            Text = "Лента",
            Style = ThinButton,
            Margin = 12
        };
        public Button ScheduleButton = new Button()
        {
            Text = "Расписание",
            Style = ThinButton,
            Margin = 12
        };
        public Button ReferenceButton = new Button()
        {
            Text = "Справки",
            Style = ThinButton,
            Margin = 12
        };
        static Style footerStyle = new Style(typeof(Button))
        {
            Setters =
            {
                new Setter
                {
                    Property= Button.WidthRequestProperty,
                    Value = 35
                },
                new Setter
                {
                    Property = Button.HeightRequestProperty,
                    Value = 28
                },
                new Setter
                {
                    Property = Button.MarginProperty,
                    Value = new Thickness(0, 0, 3, 0)
                },
                new Setter
                {
                    Property = Button.BackgroundColorProperty,
                    Value = Color.FromRgba(66, 68, 90, 0)
                }
            }
        };
        public Button LikeButton = new Button()
        {
            ImageSource = "likeico.jpg",
            Style = footerStyle,
            Margin = new Thickness(24, 0, 0, 0)
        };
        public Button CommentButton = new Button()
        {
            ImageSource = "commentico.jpg",
            Style = footerStyle
        };
        public Button ComplaitButton = new Button()
        {
            ImageSource = "complaitico.jpg",
            Style = footerStyle
        };
        public Button BasketButton = new Button()
        {
            ImageSource = "basketico.jpg",
            Style = footerStyle
        };
        public Button DisLikeButton = new Button()
        {
            ImageSource = "dislikeico.jpg",
            Style = footerStyle
        };

    }
}
