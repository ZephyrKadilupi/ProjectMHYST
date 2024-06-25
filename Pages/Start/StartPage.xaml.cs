using ProjectMHYST.Pages.Forms;
using AlohaKit.Animations;
using ProjectMHYST.Resources.Values;
using Android.App.Admin;

namespace ProjectMHYST.Pages.Start;

public partial class StartPage : ContentPage
{
    public StartPage()
    {
        InitializeComponent();

        ApplyThemeColors();
    }

    bool already_animated = false;

    private void ApplyThemeColors()
    {
        string colortheme = Preferences.Default.Get("color_theme", "default-theme");
        AppThemeColors appThemeColors = new();
        Color[] selectedThemeColors = appThemeColors.GetColorArray(colortheme);

        layoutMain.BackgroundColor = selectedThemeColors[1];
        borderCircleIllustration.BackgroundColor = selectedThemeColors[0];
    }

    private async void OnStart(object sender, EventArgs e)
    {
        bool logged = await SecureStorage.Default.GetAsync("oauth_token") != null;

        if (imgMhyst.Opacity == 0) already_animated = false;

        /*
         * En Resumen: SecureStorage guarda un string en una localización que tiene un nombre justo de
         * la misma manera que Preferences, solo con la diferencia de que SecureStorage.Default.Set()
         * no te permite retornar un valor en caso de que la localización no tenga ningún valor asociado...
         * 
         * Acá se usa para buscar si en la localización "oauth_token" ya existe un valor, si no existe,
         * entonces será null y el boolean será false, en caso contrario, true.
         * 
         * Esa localización contendrá el usuario de la persona (aunque lo ideal sería colocar un código
         * personalizado generado automáticamente).
         */

        if (!already_animated)
        {
            //Ejecutar las animaciones una detrás de otra.
            await imgTeam.Animate(new FadeToAnimation()
            {
                Delay = 3000,
                Duration = "1000",
                Opacity = 1
            });
            await imgTeam.Animate(new FadeToAnimation()
            {
                Delay = 1000,
                Duration = "1000",
                Opacity = 0
            });

            if (logged) already_animated = true;
        }

        if (!logged) //Si el usuario no está loggeado
        { //Muestra los botones de Registrarse/Iniciar Sesión
            if (!already_animated) 
            { 
                await imgMhyst.Animate(new FadeToAnimation()
                {
                    Duration = "500",
                    Opacity = 1
                });

                await lbMhyst.Animate(new FadeToAnimation()
                {
                    Duration = "500",
                    Opacity = 1
                });

                await borderCircleIllustration.Animate(new FadeToAnimation()
                {
                    Duration = "500",
                    Opacity = 0.3
                });

                await imgIllustration.Animate(new FadeToAnimation()
                {
                    Duration = "500",
                    Opacity = 1
                });

                await btnLogin.Animate(new FadeToAnimation()
                {
                    Duration = "500",
                    Opacity = 1
                });

                await btnSignUp.Animate(new FadeToAnimation()
                {
                    Duration = "500",
                    Opacity = 1
                });

                already_animated = true;
            }       
        }
        else
        { //Si ya lo está, lo lleva a la página de temas
            await Navigation.PushAsync(new Subjects.PrincipalSubjectListPage());
        }
    }

    private async void goToLoginPage(Object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }

    private async void goToSignUpPage(Object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SignUpPage());
    }

    private async void ResetFlags(object sender, EventArgs e)
    {
        string txt = "¿Quieres fingir que nada ha pasado y resetear las flags de los eventos? Esto no afectara las " +
            "preferencias guardadas como la paleta de colores o la foto de perfil";

        bool ans = await DisplayAlert("¿Resetear Flags?", txt, "Ajá", "Nop");

        if (ans) Preferences.Default.Set("cat_fled_away", false);
    }
}