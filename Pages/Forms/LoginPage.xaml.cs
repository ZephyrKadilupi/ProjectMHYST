namespace ProjectMHYST.Pages.Forms;

public partial class LoginPage : ContentPage
{
    String user = "", password = "";

    public LoginPage()
	{
		InitializeComponent();
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