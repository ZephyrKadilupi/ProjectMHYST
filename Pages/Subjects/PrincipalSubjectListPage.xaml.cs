namespace ProjectMHYST.Pages.Subjects;

public partial class PrincipalSubjectListPage : ContentPage
{
	int dialog_index = 0;
	string[] dialog = [
    "—¡Has llegado! Me temo que tienes mucho por aprender, ¿o no?",
	"*Suspiro*",
    "—¿Qué quieres repasar hoy?",
	"",
    "—No me toques... Eso es de mala educación...",
    "—¿Q-Quieres parar de una vez?"];

	public PrincipalSubjectListPage()
	{
		InitializeComponent();
	}


	private void NextDialogue(object sender, EventArgs e)
	{
		if (dialog_index < 3)
		{
			dialog_index++;
			lbDialogue.Text = dialog[dialog_index];
			if (dialog_index == 3) btnContinueDialogue.IsVisible = false;
		}
	}

	private void SpecialTouchedDialogue(object sender, EventArgs e) 
	{
		if (dialog_index >= 3)
		{
			dialog_index++;
            if (dialog_index < 6) lbDialogue.Text = dialog[dialog_index];
        }
	}

	private async void GoToUserPreferences(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new Forms.UserPreferencesPage());
	}
}