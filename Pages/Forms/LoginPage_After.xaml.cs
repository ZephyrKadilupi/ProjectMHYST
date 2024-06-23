using AlohaKit.Animations;
using ProjectMHYST.Pages.Subjects;
using ProjectMHYST.Resources.Values;

namespace ProjectMHYST.Pages.Forms;

public partial class LoginPage_After : ContentPage
{
	public LoginPage_After(String user)
	{
		InitializeComponent();

        ApplyThemeColors();

        showWelcomeText(user);

        PlayAnimations();
	}

    private void ApplyThemeColors()
    {
        string colortheme = Preferences.Default.Get("color_theme", "default-theme");
        AppThemeColors appThemeColors = new();
        Color[] selectedThemeColors = appThemeColors.GetColorArray(colortheme);

        stackMain.BackgroundColor = selectedThemeColors[1];
        borderCircle.BackgroundColor = selectedThemeColors[2];
        borderCircleDeco1.BackgroundColor = selectedThemeColors[2];
        borderCircleDeco2.BackgroundColor = selectedThemeColors[2];
        borderCircleDeco3.BackgroundColor = selectedThemeColors[2];
    }

    private void showWelcomeText(String user)
    {
        if (user != null)
        {
            lbWelcome.Text = user;
        }
    }

    private async void PlayAnimations()
    {
        await flexLogo.Animate(new FadeToAnimation() {
            Duration="500",
            Opacity=1,
            Delay=1000
        });

        await borderCircle.Animate(new FadeToAnimation(){
            Duration="300",
            Opacity=0.5
        });

        await borderCircleDeco3.Animate(new FadeToAnimation(){
            Duration="300",
            Opacity=0.3
        });

        await borderCircleDeco2.Animate(new FadeToAnimation(){
            Duration="300",
            Opacity=0.3
        });

        await borderCircleDeco1.Animate(new FadeToAnimation(){
            Duration="300",
            Opacity=0.3
        });

        await stackUserWelcome.Animate(new FadeToAnimation(){
            Duration="500",
            Opacity=1
        });

        await btnContinue.Animate(new FadeToAnimation(){
            Duration="500",
            Opacity=1
        });
    }

    public void actionContinue(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PrincipalSubjectListPage());
    }
}