using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;


public class PlayFabLogin : MonoBehaviour
{
    [Header("LOGIN")]
    private string userEmailLogin;
    private string userPassWordLogin;
    public void Start()
    {
        
        if(string.IsNullOrEmpty(PlayFabSettings.TitleId))
        {
            
            PlayFabSettings.TitleId = "1C0DB";
        }
        // API-kutsu (GET)
        var request = new LoginWithEmailAddressRequest { Email = userEmailLogin, Password = userPassWordLogin };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);

        
        
    }

    //Tämä metodi suoritetaan jos Loggaus onnistuu
    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Congratulations, you made first successful API call!");
    }

    //tämä metodi suoritetaan jos loggaus epäonnistuu
    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your first API call. :(");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }

    // Tallentaa Login-lomakkeella tulleen salasanan
    public void GetUserPasswordLogin(string passwordIn)
    {
        userPassWordLogin = passwordIn;
    }

    // Tallentaa Login-lomakkeelta tulleen sähköpostiosoitteen
    public void GetUserEmailLogin(string emailIn)
    {
        userEmailLogin = emailIn;
    }

    // Tarkistaa API-kutsulla onko pelaaja olemassa
    public void LogIn()
    {
        var request = new LoginWithEmailAddressRequest { Email = userEmailLogin, Password = userPassWordLogin};
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);

    }
}