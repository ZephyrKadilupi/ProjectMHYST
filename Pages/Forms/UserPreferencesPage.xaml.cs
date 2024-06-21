namespace ProjectMHYST.Pages.Forms;

public partial class UserPreferencesPage : ContentPage
{
    public UserPreferencesPage()
    {
        InitializeComponent();

        ShowCurrentProfilePic();
    }

    int profilepic = Preferences.Default.Get("profile_pic", 1);

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
}