using ProjectMHYST.Pages.Start;
using ProjectMHYST.Resources.Values;

namespace ProjectMHYST.Pages.Forms;

public partial class UserPreferencesPage : ContentPage
{
    public UserPreferencesPage()
    {
        InitializeComponent();

        ApplyThemeColors();

        ShowThemeColors();

        ShowCurrentProfilePic();

        ShowCurrentColorTheme();
    }

    int profilepic = Preferences.Default.Get("profile_pic", 1);
    string colortheme = Preferences.Default.Get("color_theme", "default-theme");

    private void ApplyThemeColors()
    {
        string colortheme = Preferences.Default.Get("color_theme", "default-theme");
        AppThemeColors appThemeColors = new();
        Color[] selectedThemeColors = appThemeColors.GetColorArray(colortheme);

        gridMain.BackgroundColor = selectedThemeColors[1];
        lbExtraInfo.TextColor = selectedThemeColors[2];
        btnLogOut.TextColor = selectedThemeColors[2];
        lbProfilePicTip.TextColor = selectedThemeColors[2];
        lbColorThemeTip.TextColor = selectedThemeColors[2];
    }

    private void ShowCurrentProfilePic()
    {
        switch (profilepic)
        {
            case 0:
                //Has no profile pic
                break;
            case 1:
                imgUserProfilePic.Source = "profile_1.svg";
                imgbuttonProfile1.Opacity = 1;
                break;
            case 2:
                imgUserProfilePic.Source = "profile_2.svg";
                imgbuttonProfile2.Opacity = 1;
                break;
            case 3:
                imgUserProfilePic.Source = "profile_3.svg";
                imgbuttonProfile3.Opacity = 1;
                break;
            case 4:
                imgUserProfilePic.Source = "profile_4.svg";
                imgbuttonProfile4.Opacity = 1;
                break;
            case 5:
                imgUserProfilePic.Source = "profile_5.svg";
                imgbuttonProfile5.Opacity = 1;
                break;
            case 6:
                imgUserProfilePic.Source = "profile_6.svg";
                imgbuttonProfile6.Opacity = 1;
                break;
        }
    }

	private void SetProfilePic1(object sender, EventArgs e)
	{
        ShowChangedProfilePic(1);
        Preferences.Default.Set("profile_pic", 1);
        imgUserProfilePic.Source = "profile_1.svg";
    }

    private void SetProfilePic2(object sender, EventArgs e)
    {
        ShowChangedProfilePic(2);
        Preferences.Default.Set("profile_pic", 2);
        imgUserProfilePic.Source = "profile_2.svg";
    }

    private void SetProfilePic3(object sender, EventArgs e)
    {
        ShowChangedProfilePic(3);
        Preferences.Default.Set("profile_pic", 3);
        imgUserProfilePic.Source = "profile_3.svg";
    }

    private void SetProfilePic4(object sender, EventArgs e)
    {
        ShowChangedProfilePic(4);
        Preferences.Default.Set("profile_pic", 4);
        imgUserProfilePic.Source = "profile_4.svg";
    }

    private void SetProfilePic5(object sender, EventArgs e)
    {
        ShowChangedProfilePic(5);
        Preferences.Default.Set("profile_pic", 5);
        imgUserProfilePic.Source = "profile_5.svg";
    }

    private void SetProfilePic6(object sender, EventArgs e)
    {
        ShowChangedProfilePic(6);
        Preferences.Default.Set("profile_pic", 6);
        imgUserProfilePic.Source = "profile_6.svg";
    }

    private void ShowChangedProfilePic(int changedpic = 0)
    {
        profilepic = Preferences.Default.Get("profile_pic", 1);

        if (profilepic != changedpic)
        {
            switch (profilepic)
            {
                case 1:
                    imgbuttonProfile1.Opacity = 0.3;
                    break;
                case 2:
                    imgbuttonProfile2.Opacity = 0.3;
                    break;
                case 3:
                    imgbuttonProfile3.Opacity = 0.3;
                    break;
                case 4:
                    imgbuttonProfile4.Opacity = 0.3;
                    break;
                case 5:
                    imgbuttonProfile5.Opacity = 0.3;
                    break;
                case 6:
                    imgbuttonProfile6.Opacity = 0.3;
                    break;
            }


            switch (changedpic)
            {
                case 1:
                    imgbuttonProfile1.Opacity = 1;
                    break;
                case 2:
                    imgbuttonProfile2.Opacity = 1;
                    break;
                case 3:
                    imgbuttonProfile3.Opacity = 1;
                    break;
                case 4:
                    imgbuttonProfile4.Opacity = 1;
                    break;
                case 5:
                    imgbuttonProfile5.Opacity = 1;
                    break;
                case 6:
                    imgbuttonProfile6.Opacity = 1;
                    break;
            }

            ShowProfilePicTip();
        }

        
    }

    private void ShowProfilePicTip()
    {
        lbProfilePicTip.IsVisible = true;
    }

    private void ShowThemeColors()
    {
        AppThemeColors appThemeColors = new AppThemeColors();
        Color[] colorsTheme0 = appThemeColors.GetColorArray("default-theme");
        Color[] colorsTheme1 = appThemeColors.GetColorArray("dark-theme-1");
        Color[] colorsTheme2 = appThemeColors.GetColorArray("dark-theme-2");
        Color[] colorsTheme3 = appThemeColors.GetColorArray("dark-theme-3");
        Color[] colorsTheme4 = appThemeColors.GetColorArray("dark-theme-4");

        bwTheme0Color1.BackgroundColor = colorsTheme0[0];
        bwTheme0Color2.BackgroundColor = colorsTheme0[1];
        bwTheme0Color3.BackgroundColor = colorsTheme0[2];
        bwTheme0Color4.BackgroundColor = colorsTheme0[3];

        bwTheme1Color1.BackgroundColor = colorsTheme1[0];
        bwTheme1Color2.BackgroundColor = colorsTheme1[1];
        bwTheme1Color3.BackgroundColor = colorsTheme1[2];
        bwTheme1Color4.BackgroundColor = colorsTheme1[3];

        bwTheme2Color1.BackgroundColor = colorsTheme2[0];
        bwTheme2Color2.BackgroundColor = colorsTheme2[1];
        bwTheme2Color3.BackgroundColor = colorsTheme2[2];
        bwTheme2Color4.BackgroundColor = colorsTheme2[3];

        bwTheme3Color1.BackgroundColor = colorsTheme3[0];
        bwTheme3Color2.BackgroundColor = colorsTheme3[1];
        bwTheme3Color3.BackgroundColor = colorsTheme3[2];
        bwTheme3Color4.BackgroundColor = colorsTheme3[3];

        bwTheme4Color1.BackgroundColor = colorsTheme4[0];
        bwTheme4Color2.BackgroundColor = colorsTheme4[1];
        bwTheme4Color3.BackgroundColor = colorsTheme4[2];
        bwTheme4Color4.BackgroundColor = colorsTheme4[3];
    }

    private void ShowCurrentColorTheme()
    {
        switch (colortheme)
        {
            case "default-theme":
                gridTheme0.BackgroundColor = Color.FromArgb("#50ffffff");
                break;
            case "dark-theme-1":
                gridTheme1.BackgroundColor = Color.FromArgb("#50ffffff");
                break;
            case "dark-theme-2":
                gridTheme2.BackgroundColor = Color.FromArgb("#50ffffff");
                break;
            case "dark-theme-3":
                gridTheme3.BackgroundColor = Color.FromArgb("#50ffffff");
                break;
            case "dark-theme-4":
                gridTheme4.BackgroundColor = Color.FromArgb("#50ffffff");
                break;
        }
    }

    private void SetTheme0(object sender, EventArgs e)
    {
        ShowChangedColorTheme("default-theme");
        Preferences.Default.Set("color_theme", "default-theme");
    }

    private void SetTheme1(object sender, EventArgs e)
    {
        ShowChangedColorTheme("dark-theme-1");
        Preferences.Default.Set("color_theme", "dark-theme-1");
    }

    private void SetTheme2(object sender, EventArgs e)
    {
        ShowChangedColorTheme("dark-theme-2");
        Preferences.Default.Set("color_theme", "dark-theme-2");
    }

    private void SetTheme3(object sender, EventArgs e)
    {
        ShowChangedColorTheme("dark-theme-3");
        Preferences.Default.Set("color_theme", "dark-theme-3");
    }

    private void SetTheme4(object sender, EventArgs e)
    {
        ShowChangedColorTheme("dark-theme-4");
        Preferences.Default.Set("color_theme", "dark-theme-4");
    }

    private void ShowChangedColorTheme(string changedtheme = "dark-theme-1")
    {
        colortheme = Preferences.Default.Get("color_theme", "dark-theme-1");

        if (colortheme != changedtheme)
        {
            switch (colortheme)
            {
                case "default-theme":
                    gridTheme0.BackgroundColor = Color.FromArgb("#00000000");
                    break;
                case "dark-theme-1":
                    gridTheme1.BackgroundColor = Color.FromArgb("#00000000");
                    break;
                case "dark-theme-2":
                    gridTheme2.BackgroundColor = Color.FromArgb("#00000000");
                    break;
                case "dark-theme-3":
                    gridTheme3.BackgroundColor = Color.FromArgb("#00000000");
                    break;
                case "dark-theme-4":
                    gridTheme4.BackgroundColor = Color.FromArgb("#00000000");
                    break;
            }


            switch (changedtheme)
            {
                case "default-theme":
                    gridTheme0.BackgroundColor = Color.FromArgb("#50ffffff");
                    break;
                case "dark-theme-1":
                    gridTheme1.BackgroundColor = Color.FromArgb("#50ffffff");
                    break;
                case "dark-theme-2":
                    gridTheme2.BackgroundColor = Color.FromArgb("#50ffffff");
                    break;
                case "dark-theme-3":
                    gridTheme3.BackgroundColor = Color.FromArgb("#50ffffff");
                    break;
                case "dark-theme-4":
                    gridTheme4.BackgroundColor = Color.FromArgb("#50ffffff");
                    break;
            }

            ShowColorThemeTip();
        }
    }

    private void ShowColorThemeTip()
    {
        lbColorThemeTip.IsVisible = true;
    }

    private async void LogOut(object sender, EventArgs e)
    {
        SecureStorage.Default.Remove("oauth_token");
        await Navigation.PopToRootAsync();
    }
}