using AlohaKit.Animations;
using ProjectMHYST.Resources.Values;

namespace ProjectMHYST.Pages.Forms;

public partial class SignUpPage_After : ContentPage
{
	public SignUpPage_After()
	{
		InitializeComponent();

        ApplyThemeColors();

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

    private async void PlayAnimations()
    {
        await flexLogo.Animate(new FadeToAnimation()
        {
            Duration="500",
            Opacity=1,
            Delay=1000
        });

        await borderCircle.Animate(new FadeToAnimation()
        {
            Duration="300",
            Opacity=0.5
        });

        await borderCircleDeco3.Animate(new FadeToAnimation()
        {
            Duration="300",
            Opacity=0.3
        });

        await borderCircleDeco2.Animate(new FadeToAnimation()
        {
            Duration="300",
            Opacity=0.3
        });

        await borderCircleDeco1.Animate(new FadeToAnimation()
        {
            Duration="300",
            Opacity=0.3
        });

        await lbSuccess.Animate(new FadeToAnimation()
        {
            Duration="500",
            Opacity=1
        });

        await btnContinue.Animate(new FadeToAnimation()
        {
            Duration="500",
            Opacity=1
        });
    }

    public void actionContinue(object sender, EventArgs e)
    {
        Navigation.PopToRootAsync();
    }
}