using AlohaKit.Animations;
using Microsoft.Maui.Controls;
using ProjectMHYST.Resources.Values;

namespace ProjectMHYST.Pages.Forms;

public partial class SignUpPage : ContentPage
{
    String name = "", user = "", email = "", tel = "", password = "", cpassword = "";

    public SignUpPage()
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
        btnGoToLoginPage.TextColor = selectedThemeColors[2];
    }

    public void goToLoginPage(object sender, EventArgs e)
    {
        Navigation.PushAsync(new LoginPage());
    }

    public void updateEntryValues(object sender, EventArgs e)
    {
        name = entryName.Text;
        user = entryUser.Text;
        email = entryEmail.Text;
        tel = entryTel.Text;
    }

    public void undoNext(object sender, EventArgs e)
    {
        //Volver a mostrar los Entry que ya fueron respondidos
        vslName.IsVisible = true;
        vslUser.IsVisible = true;
        vslEmail.IsVisible = true;
        vslTel.IsVisible = true;

        //Esconder los Input Faltantes
        vslPassword.IsVisible = false;
        vslConfirmPassword.IsVisible = false;

        //Esconder el bot?n de regresar
        imagebuttonReturn.IsVisible = false;

        //Cambiar Texto del Bot?n
        buttonNext.Text = "Siguiente";
    }

    public void actionNext(object sender, EventArgs e)
    {
        //Primero evalua si los entry se encuentran vacios
        if (name == "" || user == "" || email == "" || tel == "")
        {
            DisplayAlert("Formato Inv?lido", "Por favor, rellene todos los espacios.", "OK");
        }
        else
        {
            //Esconder los Entry que ya fueron respondidos
            vslName.IsVisible = false;
            vslUser.IsVisible = false;
            vslEmail.IsVisible = false;
            vslTel.IsVisible = false;

            //Mostrar los Input Faltantes
            vslPassword.IsVisible = true;
            vslConfirmPassword.IsVisible = true;

            //Mostrar el bot?n de regresar
            imagebuttonReturn.IsVisible = true;

            //Cambiar Texto del Bot?n
            buttonNext.Text = "Registrarse";
        }
    }

    public void validatePassword(object sender, EventArgs e)
    {
        password = entryPassword.Text;
        cpassword = entryConfirmPassword.Text;

        if (password == "" && cpassword == "")
        {
            vslConfirmPassword.BackgroundColor = Color.FromRgba("#00000000");
        }
        else
        {
            if (password == cpassword)
            {
                vslConfirmPassword.BackgroundColor = Color.FromRgba("#60FF6040");
            }
            else
            {
                vslConfirmPassword.BackgroundColor = Color.FromRgba("#FF606040");
            }
        }
    }
}