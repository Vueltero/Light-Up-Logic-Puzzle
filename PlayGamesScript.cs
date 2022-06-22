using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;
using System;
using System.Collections;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class PlayGamesScript : MonoBehaviour
{
    private LightUp LightUpManager;

    private void Awake()
    {
        InitiatePlayGames();
    }

    private void InitiatePlayGames()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
    }

    public bool SignIn()
    {
        bool result = true;
        Social.localUser.Authenticate((bool success) =>
        {
            if (!success) //Debug.Log("Fail Login");
                result = false;
        });
        return result;
    }

    public void LoadAchisIfFirstTime()
    {
        LightUpManager = GameObject.Find("GameManager").GetComponent<LightUp>();
        if (PlayGamesPlatform.Instance.IsAuthenticated())
            LightUpManager.VerifyAchisIfNotChecked();
        else
            Social.localUser.Authenticate((bool success) => {
                LightUpManager.VerifyAchisIfNotChecked();
            });
    }

    public bool IsSignedIn()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated())
            return true;
        else
            return false;
    }

    public void UnlockAchievement(string id)
    {
        Social.ReportProgress(id, 100.0f, success => { });
    }

    public void IncrementAchievement(string id, int stepsToIncrement)
    {
        PlayGamesPlatform.Instance.IncrementAchievement(id, stepsToIncrement, success => { });
    }

    public void ShowAchievementsUI()
    {
        Social.ShowAchievementsUI();
    }
}