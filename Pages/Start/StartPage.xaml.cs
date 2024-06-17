using ProjectMHYST.Pages.Forms;
using AlohaKit.Animations;

namespace ProjectMHYST.Pages.Start;

public partial class StartPage : ContentPage
{
	public StartPage()
	{
		InitializeComponent();
	}

    public async void goToLoginPage(Object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }

    public async void goToSignUpPage(Object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SignUpPage());
    }

    public async void triggerStartAnimations(object sender, EventArgs e)
    {
        //Fade In para el Logo y el Texto
        FadeToAnimation Mhyst_FadeToAnimation = new()
        {
            Duration = "500",
            Opacity = 1
        };

        //Fade In & Out para el Logo de los Gaznápiros
        FadeToAnimation imgTeam_FadeInAnimation = new()
        {
            Delay = 4000,
            Duration = "1000",
            Opacity = 1
        };

        FadeToAnimation imgTeam_FadeOutAnimation = new()
        {
            Delay = 1000,
            Duration = "1000",
            Opacity = 0
        };

        //Fade In para los botones
        FadeToAnimation btnLogin_FadeInAnimation = new()
        {
            Duration = "500",
            Opacity = 1
        };

        FadeToAnimation btnSignUp_FadeInAnimation = new()
        {
            Duration = "500",
            Opacity = 1
        };

        //Ejecutar las animaciones una detrás de otra.
        await imgTeam.Animate(imgTeam_FadeInAnimation);
        await imgTeam.Animate(imgTeam_FadeOutAnimation);
        await imgMhyst.Animate(Mhyst_FadeToAnimation);
        await lbMhyst.Animate(Mhyst_FadeToAnimation);
        await btnLogin.Animate(btnLogin_FadeInAnimation);
        await btnSignUp.Animate(btnSignUp_FadeInAnimation);
    }
}