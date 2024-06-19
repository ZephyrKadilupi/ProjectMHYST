using ProjectMHYST.Pages.Subjects.ContentViews;

namespace ProjectMHYST.Pages.Subjects;

public partial class PrincipalSubjectListPage : ContentPage
{
	public PrincipalSubjectListPage()
	{
		InitializeComponent();

		LoadSubjectContentPage();
	}

	private async void GoToUserPreferences(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new Forms.UserPreferencesPage());
	}

	private void LoadSubjectContentPage()
	{
		ContentView contentView = new Misc_WelcomeView();
		containerSubjectContentView.Content = contentView;
	}

	//Métodos de los ImageButtons

	private void showAlgebraContent(object sender, EventArgs e)
	{
        ContentView contentView = new TopicList_AlgebraView();
        containerSubjectContentView.Content = contentView;
    }

    private void showTrigonometryContent(object sender, EventArgs e)
    {
    }

    private void showAnalyticGeometryContent(object sender, EventArgs e)
    {
    }

    private void showCalculusContent(object sender, EventArgs e)
    {
    }

    private void showStatisticsContent(object sender, EventArgs e)
    {
    }

    private void showProbabilityContent(object sender, EventArgs e)
    {
    }

    private void showWorkInProgressContent(object sender, EventArgs e)
    {
    }
}