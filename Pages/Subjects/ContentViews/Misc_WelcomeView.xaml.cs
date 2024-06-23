using AlohaKit.Animations;
using ProjectMHYST.Resources.Values;

namespace ProjectMHYST.Pages.Subjects.ContentViews;

public partial class Misc_WelcomeView : ContentView
{
    int dialog_index = 1, dialog_index_2 = 0;
    AppDialogues appDialogues = new();

    public Misc_WelcomeView()
	{
		InitializeComponent();

        PlayFadeInAnimation();
    }

    private void PlayFadeInAnimation()
    {
        stackMain.Animate(new FadeInAnimation() { Delay=200 });
    }

    private void ApplyPastEvents(object sender, EventArgs e)
    {
        if (Preferences.Default.Get("cat_fled_away", false))
        {
            imgCat.IsVisible = false;
            btnContinueDialogue.IsVisible = false;
            lbDialogue.Text = "El gato se fue. (Felicidades)";
        }
    }

	private void NextDialogue(object sender, EventArgs e)
    {
        string[] dialog = appDialogues.GetDialogues("welcome");

        if (dialog_index < dialog.Length)
        {
            lbDialogue.Text = dialog[dialog_index];
            dialog_index++;

            if (dialog_index == dialog.Length)
            {
                btnContinueDialogue.IsVisible = false;
            }
        }
    }

    private void SpecialTouchedDialogue(object sender, EventArgs e)
    {
        string[] dialog = appDialogues.GetDialogues("event-petted");

        if (dialog_index_2 != dialog.Length || btnContinueDialogue.IsVisible) 
            imgCat.Animate(new ShakeAnimation()
            {
                Duration = "200",
                Delay = 0
            });

        if (dialog_index_2 < dialog.Length)
        {
            lbDialogue.Text = dialog[dialog_index_2];
            dialog_index_2++;
        } 

        if (dialog_index_2 == dialog.Length && !btnContinueDialogue.IsVisible)
        {
            imgCat.Animate(new TranslateToAnimation()
            {
                Duration = "500",
                TranslateX = 1000
            });

            lbDialogue.IsVisible = false;

            Preferences.Default.Set("cat_fled_away", true);
        }
    }
}