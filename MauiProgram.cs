using Microsoft.Extensions.Logging;

namespace Vieru_Marina_Lab7
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
                })

.ConfigureEssentials(essentials =>
 {
     essentials.UseMapServiceToken("FD568weS7n0iVa69IMrZ~DWukQbG5KTvVh1cN2WBwTQ~AmANpNGl_eWpUn5vqc04C-XRhwZSD-Iv4CxB_qPASlt8DKcmCv1AWgU1BTASdR7z");
 });
            return builder.Build();
        }
    }
}