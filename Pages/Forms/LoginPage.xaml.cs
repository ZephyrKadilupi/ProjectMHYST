using AlohaKit.Animations;
using ProjectMHYST.Resources.Values;

namespace ProjectMHYST.Pages.Forms;

public partial class LoginPage : ContentPage
{
    String user = "", password = "";

    public LoginPage()
	{
		InitializeComponent();

        ApplyThemeColors();
	}

    private void ApplyThemeColors()
    {
        string colortheme = Preferences.Default.Get("color_theme", "default-theme");
        AppThemeColors appThemeColors = new();
        Color[] selectedThemeColors = appThemeColors.GetColorArray(colortheme);

        scrollMain.BackgroundColor = selectedThemeColors[1];
        btnGoToSignUp.TextColor = selectedThemeColors[3];
    }

    public void goToSignUpPage(object sender, EventArgs e)
    {
        Navigation.PushAsync(new SignUpPage());
    }

    public void updateEntryValues(object sender, EventArgs e)
    {
        user = entryUser.Text;
        password = entryPassword.Text;

        btnLogIn.IsEnabled = !(user == "" || password == "");
    }

    public void goToAfterPage(object sender, EventArgs e)
    {
        Navigation.PushAsync(new LoginPage_After(user));
    }
}