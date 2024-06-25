using AlohaKit.Animations;
using Microsoft.Maui.Controls;
using ProjectMHYST.Resources.Values;
using System.Reflection;

namespace ProjectMHYST.Pages.Forms;

public partial class SignUpPage : ContentPage
{
    string name = "", user = "", email = "", tel = "", password = "", cpassword = "";

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

        lbNameTip.TextColor = selectedThemeColors[2];
        lbUserTip.TextColor = selectedThemeColors[2];
        lbEmailTip.TextColor = selectedThemeColors[2];
        lbTelTip.TextColor = selectedThemeColors[2];
        lbPasswordTip.TextColor = selectedThemeColors[2];
        lbCPasswordTip.TextColor = selectedThemeColors[2];
    }

    private void goToLoginPage(object sender, EventArgs e)
    {
        Navigation.PushAsync(new LoginPage());
    }

    private void updateEntryValues(object sender, EventArgs e)
    {
        //Actualiza los valores en base a su respectivo Input
        name = entryName.Text;
        lbNameTip.Text = ValidateValue("name", name);

        user = entryUser.Text;
        lbUserTip.Text = ValidateValue("user", user);

        email = entryEmail.Text;
        lbEmailTip.Text = ValidateValue("email", email);

        tel = entryTel.Text;
        lbTelTip.Text = ValidateValue("tel", tel);

        password = entryPassword.Text;
        lbPasswordTip.Text = ValidateValue("password", password);

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
                lbCPasswordTip.Text = string.Empty;
            }
            else
            {
                vslConfirmPassword.BackgroundColor = Color.FromRgba("#FF606040");
                lbCPasswordTip.Text = "Las contraseñas no coinciden.";
            }
        }
    }

    private string ValidateValue(string type, string value)
    {
        AppValidation appValidation = new();

        if (value == null) value = string.Empty;
        string message = "ERROR";

        switch (type)
        {
            case "name":
                if (value.Length == 0)
                    message = "El nombre no puede estar vacío";
                else
                    message = string.Empty;
                break;

            case "user":
                if (value.Length == 0)
                    message = "El usuario no puede estar vacío";
                else
                    message = string.Empty;
                break;

            case "email":
                if (value.Length == 0)
                    message = "El correo electrónico no puede estar vacío";
                else if (!appValidation.ValidateEmail(email))
                    message = "El correo electrónico debe contener @ y acabar en \".com\".";
                else
                    message = string.Empty;
                break;

            case "tel":
                if (value.Length == 0)
                    message = "El número de teléfono no puede estar vacío";
                else if (appValidation.FormatTelNumber(tel).Length != 10)
                    message = "El número de teléfono (" + appValidation.FormatTelNumber(tel) + ") debe tener 10 números.";
                else
                    message = string.Empty;
                break;

            case "password":
                if (value.Length == 0)
                    message = "La contraseña no puede estar vacía";
                else if (value.Length < 8)
                    message = "La contraseña debe tener al menos 8 caracteres";
                else if (appValidation.ValidatePassword(password) != string.Empty)
                    message = appValidation.ValidatePassword(password);
                else
                    message = string.Empty;
                break;
        }

        return message;
    }

    private void undoNext(object sender, EventArgs e)
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

    private void actionNext(object sender, EventArgs e)
    {
        //Primero evalua si los entry se encuentran vacios
        if (buttonNext.Text != "Registrarse")
        {
            if (name == "" || user == "" || email == "" || tel == "")
            {
                DisplayAlert("Formato Inválido", "Por favor, rellene todos los espacios.", "OK");
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

                //Mostrar el botón de regresar
                imagebuttonReturn.IsVisible = true;

                //Cambiar Texto del Botón
                buttonNext.Text = "Registrarse";
            }
        }
        else
        {
            bool[] v = [
                ValidateValue("name", name) == string.Empty,
                ValidateValue("user", user) == string.Empty,
                ValidateValue("email", email) == string.Empty,
                ValidateValue("tel", tel) == string.Empty,
                ValidateValue("password", password) == string.Empty,
                password == cpassword
                ];

            if (v[0] && v[1] && v[2]  && v[3] && v[4] && v[5])
            {
                TrySignUp();
            }
            else
            {
                string message = "Los valores introducidos no son válidos, por favor, siga las indicaciones" +
                    " e inténtelo de nuevo.";
                DisplayAlert("Error", message, "Ok");
            }
        }
    }

    private async void TrySignUp()
    {
        await SecureStorage.Default.SetAsync(user, password);

        await Navigation.PushAsync(new SignUpPage_After());
    }
}