using AlohaKit.Animations;
using ProjectMHYST.Resources.Values;

namespace ProjectMHYST.Pages.Subjects.Algebra;

public partial class Algebra_PascalsTrianglePage : ContentPage
{
	public Algebra_PascalsTrianglePage()
	{
		InitializeComponent();

        ApplyThemeColors();

        PlayFadeInAnimation();
	}

    private void ApplyThemeColors()
    {
        string colortheme = Preferences.Default.Get("color_theme", "default-theme");
        AppThemeColors appThemeColors = new();
        Color[] selectedThemeColors = appThemeColors.GetColorArray(colortheme);

        stackMain.BackgroundColor = selectedThemeColors[1];
        borderTitleContainer.Stroke = selectedThemeColors[2];
        borderTitleContainer.BackgroundColor = selectedThemeColors[0];
    }

    private void PlayFadeInAnimation()
    {
        stackMain.Animate(new FadeInAnimation() { Delay=200 });
    }
}