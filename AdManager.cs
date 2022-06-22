using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;
using TMPro;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
    private string playStoreID = "---";
    private string appStoreID = "---";

    private string bannerAd = "---";
    private string interstitialAd = "---";
    private string rewardedVideoAd = "---";

    public bool isTargetPlayStore;
    public bool isTestAd;

    private LightUp LightUpManager;

    public GameObject freeHintsPopUp;

    private void Start()
    {
        LightUpManager = GameObject.Find("GameManager").GetComponent<LightUp>();
        if (!(LightUpManager.packsUnlocked[6] || LightUpManager.packsUnlocked[7] || LightUpManager.packsUnlocked[8] || LightUpManager.packsUnlocked[9] ||
            LightUpManager.packsUnlocked[10] || LightUpManager.packsUnlocked[11] || LightUpManager.packsUnlocked[13] || LightUpManager.packsUnlocked[14] ||
            LightUpManager.packsUnlocked[20] || LightUpManager.packsUnlocked[21] || LightUpManager.packsUnlocked[22] || LightUpManager.packsUnlocked[23] ||
            LightUpManager.packsUnlocked[24] || LightUpManager.boughtHints || LightUpManager.themeUnlocked0 == 1 || LightUpManager.themeUnlocked1 == 1 ||
            LightUpManager.themeUnlocked2 == 1 || LightUpManager.themeUnlocked3 == 1 || LightUpManager.themeUnlocked4 == 1))
        {
            Advertisement.AddListener(this);
            InitializeAdvertisment();
            //StartCoroutine(ShowBannerWhenInitialized());
        }            
    }

    private void InitializeAdvertisment()
    {
        if (isTargetPlayStore)
        {
            Advertisement.Initialize(playStoreID, isTestAd);
            return;
        }
        Advertisement.Initialize(appStoreID, isTestAd);
    }

    public void PlayInterstitialAd()
    {
        if (!Advertisement.IsReady(interstitialAd))
            return;
        Advertisement.Show(interstitialAd);
    }

    public void PlayRewardedVideoAd()
    {
        if (!Advertisement.IsReady(rewardedVideoAd))
            return;
        Advertisement.Show(rewardedVideoAd);
    }

    public void OnUnityAdsReady(string placementId)
    {
        if (placementId == rewardedVideoAd)
        {
            //enable the rewarded ads button
        }
    }

    IEnumerator ShowBannerWhenInitialized()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show(bannerAd);          
    }

    public bool isRewardedAdReady()
    {
        if (Advertisement.IsReady(rewardedVideoAd))
            return true;
        return false;
    }

    public void OnUnityAdsDidError(string message)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        if (placementId == interstitialAd || placementId == rewardedVideoAd)
        {
            //mute all sound
        }
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Failed:
                if (placementId == interstitialAd || placementId == rewardedVideoAd)
                {
                    //unmute all sound
                }
                break;
            case ShowResult.Skipped:
                if (placementId == interstitialAd || placementId == rewardedVideoAd)
                {
                    //unmute all sound
                }
                break;
            case ShowResult.Finished:
                if (placementId == rewardedVideoAd)
                {
                    Debug.Log("Reward the player");
                    FindObjectOfType<AudioManager>().Play("confirmation_002");
                    LightUpManager.hints++;
                    LightUpManager.SavePlayer();
                    GameObject.Find("/CanvasStatic/playMode/hintsText").GetComponent<TextMeshProUGUI>().text = LightUpManager.hints + " x";
                    LightUpManager.CanvasGroupChangerActive(false, freeHintsPopUp);
                    //unmute all sound
                }
                if (placementId == interstitialAd)
                {
                    Debug.Log("Finished interstitial");
                    //unmute all sound
                }
                if (placementId == bannerAd)
                {
                    //PlayBannerAd();
                }
                break;
        }
    }
}
