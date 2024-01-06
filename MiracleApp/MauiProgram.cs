using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace MiracleApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(Entry), (handler, view) =>
            {
#if ANDROID
                handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Argb(1, 250, 224, 115));
#endif
            });
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>().UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("QANELASBLACK.TTF", "QANELASBLACK");
                    fonts.AddFont("QANELASBLACKITALIC.TTF", "QANELASBLACKITALIC");
                    fonts.AddFont("QANELASBOLD.TTF", "QANELASBOLD");
                    fonts.AddFont("QANELASBOLDITALIC.TTF", "QANELASBOLDITALIC");
                    fonts.AddFont("QANELASEXTRABOLD.TTF", "QANELASEXTRABOLD");
                    fonts.AddFont("QANELASEXTRABOLDITALIC.TTF", "QANELASEXTRABOLDITALIC");
                    fonts.AddFont("QANELASHEAVY.TTF", "QANELASHEAVY");
                    fonts.AddFont("QANELASHEAVYITALIC.TTF", "QANELASHEAVYITALIC");
                    fonts.AddFont("QANELASLIGHT.TTF", "QANELASLIGHT");
                    fonts.AddFont("QANELASLIGHTITALIC.TTF", "QANELASLIGHTITALIC");
                    fonts.AddFont("QANELASMEDIUM.TTF", "QANELASMEDIUM");
                    fonts.AddFont("QANELASMEDIUMITALIC.TTF", "QANELASMEDIUMITALIC");
                    fonts.AddFont("QANELASREGULAR.TTF", "QANELASREGULAR");
                    fonts.AddFont("QANELASREGULARITALIC.TTF", "QANELASREGULARITALIC");
                    fonts.AddFont("QANELASSEMIBOLD.TTF", "QANELASSEMIBOLD");
                    fonts.AddFont("QANELASSEMIBOLDITALIC.TTF", "QANELASSEMIBOLDITALIC");
                    fonts.AddFont("QANELASTHIN.TTF", "QANELASTHIN");
                    fonts.AddFont("QANELASTHINITALIC.TTF", "QANELASTHINITALIC");
                    fonts.AddFont("QANELASULTRALIGHT.TTF", "QANELASULTRALIGHT");
                    fonts.AddFont("QANELASULTRALIGHTITALIC.TTF", "QANELASULTRALIGHTITALIC");
                    fonts.AddFont("NEUEMACHINA-BLACK.TTF", "NEUEMACHINA-BLACK");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
