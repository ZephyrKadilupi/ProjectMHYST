using AlohaKit.Animations;
using AlohaKit.Animations.Helpers;
using Android.Views;
using ProjectMHYST.Resources.Values;
using ProjectMHYST.Pages.Subjects.Algebra;

namespace ProjectMHYST.Pages.Subjects.ContentViews;

public partial class TopicList_AlgebraView : ContentView
{
	public TopicList_AlgebraView()
	{
		InitializeComponent();

		PlayFadeInAnimation();

		ApplyThemeColors();
	}

    private void ApplyThemeColors()
    {
        string colortheme = Preferences.Default.Get("color_theme", "default-theme");
        AppThemeColors appThemeColors = new();
        Color[] selectedThemeColors = appThemeColors.GetColorArray(colortheme);

        var borders = VisualTreeHelper.GetChildren<Border>(this);

        foreach ( var border in borders ) //Aplicar el color a cada uno de los <Border>
        {
            border.Stroke = selectedThemeColors[2];
            border.Margin = 5;
        }
    }

    private void PlayFadeInAnimation()
    {
		stackMain.Animate(new FadeInAnimation() { Delay=200 });
    }

    private async void GoToPascalsTriangle(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Algebra_PascalsTrianglePage());
    }
}