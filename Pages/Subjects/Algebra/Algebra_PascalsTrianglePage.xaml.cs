using AlohaKit.Animations;
using ProjectMHYST.Resources.Values;

namespace ProjectMHYST.Pages.Subjects.Algebra;

public partial class Algebra_PascalsTrianglePage : ContentPage
{
    public Algebra_PascalsTrianglePage()
    {
        InitializeComponent();

        ApplyThemeColors();

        PlayFadeInAnimation();
    }

    int ex = 0;
    bool showing_result = false;
    string n1 = string.Empty, n2 = string.Empty;

    private void ApplyThemeColors()
    {
        string colortheme = Preferences.Default.Get("color_theme", "default-theme");
        AppThemeColors appThemeColors = new();
        Color[] selectedThemeColors = appThemeColors.GetColorArray(colortheme);

        stackMain.BackgroundColor = selectedThemeColors[1];
        borderTitleContainer.Stroke = selectedThemeColors[2];
        borderTitleContainer.BackgroundColor = selectedThemeColors[0];

        borderSolutionStep1.BackgroundColor = selectedThemeColors[0];

        borderSolutionStep2.BackgroundColor = selectedThemeColors[0];

        borderSolutionStep3.BackgroundColor = selectedThemeColors[0];

        borderSolutionStep4.BackgroundColor = selectedThemeColors[0];

        borderSolutionStep5.BackgroundColor = selectedThemeColors[0];

        borderSolutionStep6.BackgroundColor = selectedThemeColors[0];
    }

    private void PlayFadeInAnimation()
    {
        stackMain.Animate(new FadeInAnimation() { Delay=200 });
    }

    private void StartAnswer(object sender, EventArgs e)
    {
        if (!showing_result)
        {
            if (SetCurrentEquationValues())
            {
                //PREPARACIÓN
                AppMath appMath = new();
                showing_result = true;
                lbScreenOrientationTip.IsVisible = true;
                btnCalculate.Text = "Calcular Otro";

                //PASO 1
                string triangle_row = string.Empty;

                borderSolutionStep1.IsVisible = true;


                for (int i = 0; i <= ex; i++)
                {
                    triangle_row += appMath.calculateCombination(ex, i);
                    if (i != ex) triangle_row += ", ";
                }

                stackSolutionStep1.Children.Add(new Label
                {
                    TextType=TextType.Html,
                    Text=triangle_row,
                    //Text="x<sup><small>" + triangle_row + "</small></sup> + y",
                    FontFamily="LatinModernMathRegular",
                    FontSize=20,
                    HorizontalTextAlignment=TextAlignment.Center,
                    Margin=-20
                });


                //PASO 2
                borderSolutionStep2.IsVisible = true;

                for (int i = 0; i <= ex; i++)
                {
                    stackSolutionStep2.Children.Add(new Label
                    {
                        TextType=TextType.Html,
                        Text=appMath.calculateCombination(ex, i).ToString(),
                        FontFamily="LatinModernMathRegular",
                        FontSize=20,
                        HorizontalTextAlignment=TextAlignment.Start,
                        Margin = new Thickness(10, -45, 0, -45)
                    });
                }

                //PASO 3
                string n1_formatted = string.Empty;
                int ex_i = 0;
                borderSolutionStep3.IsVisible = true;

                for (int i = 0; i <= ex; i++)
                {
                    ex_i = ex - i;
                    n1_formatted = n1 + "<sup><small>" + ex_i + "</small></sup>";

                    stackSolutionStep3.Children.Add(new Label
                    {
                        TextType=TextType.Html,
                        Text=appMath.calculateCombination(ex, i).ToString() + n1_formatted,
                        FontFamily="LatinModernMathRegular",
                        FontSize=20,
                        HorizontalTextAlignment=TextAlignment.Start,
                        Margin = new Thickness(10, -45, 0, -45)
                    });
                }

                //PASO 4
                string n2_formatted = string.Empty, final_result = string.Empty;
                borderSolutionStep4.IsVisible = true;

                for (int i = 0; i <= ex; i++)
                {
                    ex_i = ex - i;
                    n1_formatted = n1 + "<sup><small>" + ex_i + "</small></sup>";
                    n2_formatted = n2 + "<sup><small>" + i + "</small></sup>";

                    stackSolutionStep4.Children.Add(new Label
                    {
                        TextType=TextType.Html,
                        Text=appMath.calculateCombination(ex, i).ToString() + n1_formatted + n2_formatted,
                        FontFamily="LatinModernMathRegular",
                        FontSize=20,
                        HorizontalTextAlignment=TextAlignment.Start,
                        Margin = new Thickness(10, -45, 0, -45)
                    });

                    final_result += appMath.calculateCombination(ex, i).ToString() + n1_formatted + n2_formatted;
                    if (i != ex) final_result += " + ";
                }

                //PASO 5
                borderSolutionStep5.IsVisible = true;

                stackSolutionStep5.Children.Add(new Label
                {
                    TextType=TextType.Html,
                    Text=final_result,
                    FontFamily="LatinModernMathRegular",
                    FontSize=20,
                    HorizontalTextAlignment=TextAlignment.Center,
                    LineBreakMode=LineBreakMode.WordWrap,
                    WidthRequest = 200,
                    Margin = new Thickness(0, -45, 0, -45)
                });
            }
        }
        else
        {
            //En teoría, este bloque de código debería recargar la página, pues la duplica
            //y borra la anterior.
            var page = Navigation.NavigationStack.LastOrDefault();
            Navigation.PushAsync(new Algebra_PascalsTrianglePage());
            Navigation.RemovePage(page);
        }
    }

    private bool SetCurrentEquationValues()
    {
        bool ex_was_not_a_number = false;

        n1 = entryNumber1.Text;
        n2 = entryNumber2.Text;

        try
        {
            ex = int.Parse(entryExponent.Text);
        }
        catch (Exception e)
        {
            ex_was_not_a_number = true;
            ex = 0;
        }


        if (n1 != string.Empty && n2 != string.Empty && ex != 0 && !ex_was_not_a_number)
        {
            return true;
        }
        else
        {
            string message = "Los valores introducidos son inválidos. Por favor, llene los recuadros con un número o una letra.";
            DisplayAlert("Valores Inválidos", message, "Ok");
            return false;
        }
    }

    //Este método es llamado cada vez que el tamaño de la pantalla cambia
    private void OnOrientationChange(object sender, EventArgs e)
    {
        /* Ajustarse a la pantalla:
         * Si es más alta que ancha entonces está en vertical, sino, en horizontal
         * Esto es importante para reposicionar y modificar el tamaño de los elementos
         * que dependen del tamaño de la pantalla. (En Android Studio lo normal hubiera
         * sido usar Constraints y Match_Parent, pero pos no se puede)...
         */
        if (contentPageMain.Width < contentPageMain.Height)
        { //Pantalla en Vertical
            lbDialogueStep1.WidthRequest = 200;
            dividerStep1.WidthRequest = 260;

            lbDialogueStep2.WidthRequest = 200;
            dividerStep2.WidthRequest = 260;

            lbDialogueStep3.WidthRequest = 200;
            dividerStep3.WidthRequest = 260;

            lbDialogueStep4.WidthRequest = 200;
            dividerStep4.WidthRequest = 260;

            lbDialogueStep5.WidthRequest = 200;
            dividerStep5.WidthRequest = 260;

            lbDialogueStep6.WidthRequest = 200;
        }
        else
        { //Pantalla en Horizontal
            lbDialogueStep1.WidthRequest = 400;
            dividerStep1.WidthRequest = 460;

            lbDialogueStep2.WidthRequest = 400;
            dividerStep2.WidthRequest = 460;

            lbDialogueStep3.WidthRequest = 400;
            dividerStep3.WidthRequest = 460;

            lbDialogueStep4.WidthRequest = 400;
            dividerStep4.WidthRequest = 460;

            lbDialogueStep5.WidthRequest = 400;
            dividerStep5.WidthRequest = 460;

            lbDialogueStep6.WidthRequest = 400;
        }
    }
}