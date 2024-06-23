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
	}

    private void ApplyThemeColors()
    {
        string colortheme = Preferences.Default.Get("color_theme", "default-theme");
        AppThemeColors appThemeColors = new();
        Color[] selectedThemeColors = appThemeColors.GetColorArray(colortheme);

        stackMain.BackgroundColor = selectedThemeColors[1];
    }

    public void showWelcomeText(String user)
    {
        if (user != null)
        {
            lbWelcome.Text = user;
        }
    }

    public void actionContinue(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PrincipalSubjectListPage());
    }
}