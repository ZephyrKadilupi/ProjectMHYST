using ProjectMHYST.Pages.Subjects.ContentViews;
using ProjectMHYST.Resources.Values;

namespace ProjectMHYST.Pages.Subjects;

public partial class PrincipalSubjectListPage : ContentPage
{
	public PrincipalSubjectListPage()
	{
		InitializeComponent();

		LoadSubjectContentPage();

        ApplyThemeColors();

        ShowCurrentProfilePic();
	}

    int profilepic = Preferences.Default.Get("profile_pic", 1);

    string ImageButtonCurrentFocus = "welcome",
        message = "Este contenido aún no está disponible. Llevo varios días sin dormir más de 3 horas, (mi equipo" +
        " le hace honor a su nombre), y eso sumado con el pobre rendimiento de MAUI, y su increiblemente deficiente documentación" +
        " creo que estoy empezando a cuestionar mi propia sanidad mental. Mi GitHub no me dejará mentir. (:";


    //Métodos Miscelanea

    private void ApplyThemeColors()
    {
        string colortheme = Preferences.Default.Get("color_theme", "default-theme"); 
        AppThemeColors appThemeColors = new();
        Color[] selectedThemeColors = appThemeColors.GetColorArray(colortheme);

        /*
         * 0 - Darkest
         * 1 - Dark
         * 2 - Highlight
         * 3 - Lightest
         * 
         * (Inverse for Light Theme)
         */

        UI_UserSection.BackgroundColor = selectedThemeColors[0];
        lbUsername.TextColor = selectedThemeColors[3];
        UI_UserSection_UpperLine.BackgroundColor = selectedThemeColors[3];
        UI_SideBar.BackgroundColor = selectedThemeColors[0];
        UI_SideBar_ButtonsContainer.BackgroundColor = selectedThemeColors[1];
        UI_EndOfSideBar.BackgroundColor = selectedThemeColors[0];
        UI_EndOfSideBar_BottomLine.BackgroundColor = selectedThemeColors[3];
        UI_SubjectSection.BackgroundColor = selectedThemeColors[1];
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

    private void ShowCurrentProfilePic()
    {
        switch (profilepic)
        {
            case 1:
                imgUserProfilePic.Source = "profile_1.svg";
                break;

            case 2:
                imgUserProfilePic.Source = "profile_2.svg";
                break;

            case 3:
                imgUserProfilePic.Source = "profile_3.svg";
                break;

            case 4:
                imgUserProfilePic.Source = "profile_4.svg";
                break;

            case 5:
                imgUserProfilePic.Source = "profile_5.svg";
                break;

            case 6:
                imgUserProfilePic.Source = "profile_6.svg";
                break;
        }
    }




	//Métodos de los ImageButtons

    private void showWelcomeContent(object sender, EventArgs e)
    {
        ContentView contentView = new Misc_WelcomeView();
        containerSubjectContentView.Content = contentView;

        setImageButtonOpacity("welcome");
    }

	private void showAlgebraContent(object sender, EventArgs e)
	{
        ContentView contentView = new TopicList_AlgebraView();
        containerSubjectContentView.Content = contentView;

        setImageButtonOpacity("algebra");
    }

    private void showTrigonometryContent(object sender, EventArgs e)
    {
        DisplayAlert("WIP", message, "OKKKK");

        //setImageButtonOpacity("trigonometry");
    }

    private void showAnalyticGeometryContent(object sender, EventArgs e)
    {
        DisplayAlert("WIP", message, "OKKKK");

        //setImageButtonOpacity("analyticgeometry");
    }

    private void showCalculusContent(object sender, EventArgs e)
    {
        DisplayAlert("WIP", message, "OKKKK");

        //setImageButtonOpacity("calculus");
    }

    private void showStatisticsContent(object sender, EventArgs e)
    {
        DisplayAlert("WIP", message, "OKKKK");

        //setImageButtonOpacity("statistics");
    }

    private void showProbabilityContent(object sender, EventArgs e)
    {
        DisplayAlert("WIP", message, "OKKKK");

        //setImageButtonOpacity("probability");
    }

    private void showWorkInProgressContent(object sender, EventArgs e)
    {
        DisplayAlert("WIP", message, "OKKKK");
    }





    //Otros métodos auxiliares

    private void setImageButtonOpacity(string subject)
    {
        bool invalidsubject = false;

        switch (subject)
        {
            case "welcome":
                imgbuttonWelcome.Opacity = 1;
                break;

            case "algebra":
                imgbuttonAlgebra.Opacity = 1;
                break;

            case "trigonometry":
                imgbuttonTrigonometry.Opacity = 1;
                break;

            case "analyticgeometry":
                imgbuttonAnalyticGeometry.Opacity = 1;
                break;

            case "calculus":
                imgbuttonCalculus.Opacity = 1;
                break;

            case "statistics":
                imgbuttonStatistics.Opacity = 1;
                break;

            case "probability":
                imgbuttonProbability.Opacity = 1;
                break;

            default:
                invalidsubject = true;
                break;
        }

        if (!invalidsubject)
        {
            if (ImageButtonCurrentFocus != subject) switch (ImageButtonCurrentFocus)
            {
                case "welcome":
                    imgbuttonWelcome.Opacity = 0.2;
                    break;

                case "algebra":
                    imgbuttonAlgebra.Opacity = 0.2;
                    break;

                case "trigonometry":
                    imgbuttonTrigonometry.Opacity = 0.2;
                    break;

                case "analyticgeometry":
                    imgbuttonAnalyticGeometry.Opacity = 0.2;
                    break;

                case "calculus":
                    imgbuttonCalculus.Opacity = 0.2;
                    break;

                case "statistics":
                    imgbuttonStatistics.Opacity = 0.2;
                    break;

                case "probability":
                    imgbuttonProbability.Opacity = 0.2;
                    break;
            }

            ImageButtonCurrentFocus = subject;
        }
    }
}