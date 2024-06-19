﻿namespace ProjectMHYST.Pages.Subjects.ContentViews;

public partial class Misc_WelcomeView : ContentView
{
    int dialog_index = 0;
    string[] dialog = [
    "—¡Has llegado! Me temo que tienes mucho por aprender, ¿o no?",
    "*Suspiro*",
    "—¿Qué quieres repasar hoy?",
    "",
    "—No me toques... Eso es de mala educación...",
    "—¿Q-Quieres parar de una vez?"];

    public Misc_WelcomeView()
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
}