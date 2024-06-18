using Microsoft.Extensions.Logging;

namespace ProjectMHYST
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");

                    //Adición de Fuentes
                    //Kalam
                    fonts.AddFont("Kalam-Light.ttf", "KalamLight");
                    fonts.AddFont("Kalam-Bold.ttf", "KalamBold");
                    fonts.AddFont("Kalam-Regular.ttf", "KalamRegular");

                    //Lexend
                    fonts.AddFont("Lexend-Light.ttf", "LexendLight");
                    fonts.AddFont("Lexend-Medium.ttf", "LexendMedium");
                    fonts.AddFont("Lexend-Regular.ttf", "LexendRegular");

                    //Overpass
                    fonts.AddFont("Overpass-Light.ttf", "OverpassLight");
                    fonts.AddFont("Overpass-Regular.ttf", "OverpassRegular");
                    fonts.AddFont("Overpass-SemiBold.ttf", "OverpassSemibold");
                    fonts.AddFont("Overpass-Black.ttf", "OverpassBlack");

                    //Montserrat Alternates
                    fonts.AddFont("MontserratAlternates-SemiBold.ttf", "MontserratAlternatesSemibold");
                    fonts.AddFont("MontserratAlternates-Regular.ttf", "MontserratAlternatesRegular");
                    fonts.AddFont("MontserratAlternates-Medium.ttf", "MontserratAlternatesMedium");

                    //Zilla Slab
                    fonts.AddFont("ZillaSlab-SemiBold.ttf", "ZillaSlabSemibold");
                    fonts.AddFont("ZillaSlab-Regular.ttf", "ZillaSlabBlack");
                    fonts.AddFont("ZillaSlab-Medium.ttf", "ZillaSlabMedium");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
