using CommunityToolkit.Maui.Views;
using System.Timers;

namespace MiracleApp.Pages;

public partial class LoadingPage : Popup
{
    private static System.Timers.Timer aTimer;
    int count;
    public LoadingPage()
    {
        InitializeComponent();
    }

    private void Popup_Opened(object sender, CommunityToolkit.Maui.Core.PopupOpenedEventArgs e)
    {
        image.Source = "loading_1.png";
        count++;
        aTimer = new System.Timers.Timer(60);
        aTimer.Elapsed += OnTimedEvent;
        aTimer.AutoReset = true;
        aTimer.Enabled = true;
        aTimer.Start();
    }

    private void OnTimedEvent(object sender, ElapsedEventArgs e)
    {
        Dispatcher.Dispatch(() =>
        {
            switch (count)
            {
                case 0:
                    {
                        count++;
                        image.Source = "loading_1.png";
                    }
                    break;
                case 1:
                    {
                        count++;
                        image.Source = "loading_2.png";
                    }
                    break;
                case 2:
                    {
                        count++;
                        image.Source = "loading_3.png";
                    }
                    break;
                case 3:
                    {
                        count++;
                        image.Source = "loading_4.png";
                    }
                    break;
                case 4:
                    {
                        count++;
                        image.Source = "loading_5.png";
                    }
                    break;
                case 5:
                    {
                        count++;
                        image.Source = "loading_6.png";
                    }
                    break;
                case 6:
                    {
                        count++;
                        image.Source = "loading_7.png";
                    }
                    break;
                case 7:
                    {
                        count++;
                        image.Source = "loading_8.png";
                    }
                    break;
                case 8:
                    {
                        count++;
                        image.Source = "loading_9.png";
                    }
                    break;
                case 9:
                    {
                        count++;
                        image.Source = "loading_10.png";
                    }
                    break;
                case 10:
                    {
                        count++;
                        image.Source = "loading_11.png";
                    }
                    break;
                case 11:
                    {
                        count++;
                        image.Source = "loading_12.png";
                    }
                    break;
                case 12:
                    {
                        count++;
                        image.Source = "loading_13.png";
                    }
                    break;
                case 13:
                    {
                        count++;
                        image.Source = "loading_14.png";
                    }
                    break;
                case 14:
                    {
                        count++;
                        image.Source = "loading_15.png";
                    }
                    break;
                case 15:
                    {
                        count++;
                        image.Source = "loading_16.png";
                    }
                    break;
                case 16:
                    {
                        count++;
                        image.Source = "loading_17.png";
                    }
                    break;
                case 17:
                    {
                        count++;
                        image.Source = "loading_18.png";
                    }
                    break;
                case 18:
                    {
                        count++;
                        image.Source = "loading_19.png";
                    } 
                    break;
                case 19:
                    {
                        count++;
                        image.Source = "loading_20.png";
                    }
                    break;
                case 20:
                    {
                        count++;
                        image.Source = "loading_21.png";
                    }
                    break;
                case 21:
                    {
                        count++;
                        image.Source = "loading_22.png";
                    }
                    break;
                case 22:
                    {
                        count++;
                        image.Source = "loading_23.png";
                    }
                    break;
                case 23:
                    {
                        count++;
                        image.Source = "loading_24.png";
                    }
                    break;
                case 24:
                    {
                        count = 0;
                    }
                    break;
            }
        });
    }
}