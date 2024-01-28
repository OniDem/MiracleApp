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
        image.Source = "load1.svg";
        count = 1;
        aTimer = new System.Timers.Timer(70);
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
                        image.Source = "load1.svg";
                    }
                    break;
                case 1:
                    {
                        count++;
                        image.Source = "load2.svg";
                    }
                    break;
                case 2:
                    {
                        count++;
                        image.Source = "load3.svg";
                    }
                    break;
                case 3:
                    {
                        count++;
                        image.Source = "load4.svg";
                    }
                    break;
                case 4:
                    count = 0;
                    break;
            }
        });
    }
}