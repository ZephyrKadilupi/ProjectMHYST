using ProjectMHYST.Pages.Subjects;

namespace ProjectMHYST.Pages.Forms;

public partial class LoginPage_After : ContentPage
{
	public LoginPage_After(String user)
	{
		InitializeComponent();

        showWelcomeText(user);
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