using AlohaKit.Animations;
using ProjectMHYST.Resources.Values;

namespace ProjectMHYST.Pages.Forms;

public partial class LoginPage : ContentPage
{
    public LoginPage()
	{
		InitializeComponent();

        ApplyThemeColors();

        PlayFadeInAnimation();
    }
    private void PlayFadeInAnimation()
    {
        scrollMain.Animate(new FadeInAnimation() { Delay=200 });
    }

    private void ApplyThemeColors()
    {
        string colortheme = Preferences.Default.Get("color_theme", "default-theme");
        AppThemeColors appThemeColors = new();
        Color[] selectedThemeColors = appThemeColors.GetColorArray(colortheme);

        scrollMain.BackgroundColor = selectedThemeColors[1];
        btnGoToSignUp.TextColor = selectedThemeColors[2];
    }

    public void GoToSignUpPage(object sender, EventArgs e)
    {
        Navigation.PushAsync(new SignUpPage());
    }

    public void UpdateEntryValues(object sender, EventArgs e)
    {
        string user = entryUser.Text;
        string password = entryPassword.Text;

        btnLogin.IsEnabled = user != "" && password != "";
    }

    public async void TryLogin(object sender, EventArgs e)
    {
        string user = entryUser.Text;
        string password = entryPassword.Text;
        bool result = Convert.ToString(await SecureStorage.Default.GetAsync(user)) == password;

        if (result)
        {
            await SecureStorage.SetAsync("oauth_token", user);
            await Navigation.PushAsync(new LoginPage_After(user));
        }
        else
        {
            string message = "Los datos introducidos no son correctos, por favor inténtelo de nuevo.";
            await DisplayAlert("Usuario o Contraseña Incorrectos", message, "Ok");
        }
    }
}