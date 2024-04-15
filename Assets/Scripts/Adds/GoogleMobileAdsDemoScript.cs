
using GoogleMobileAds.Api;
using GoogleMobileAds;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoogleMobileAdsDemoScript : MonoBehaviour
{
    // These ad units are configured to always serve test ads.
    #if UNITY_ANDROID
        private string _adUnitIdInterstitial = "ca-app-pub-4233766094089575/5829011482";
    #elif UNITY_IPHONE
          private string _adUnitIdInterstitial = "ca-app-pub-3940256099942544/4411468910";
    #else
          private string _adUnitIdInterstitial = "unused";
    #endif

    // These ad units are configured to always serve test ads.
    #if UNITY_ANDROID
        private string _adUnitIdRewarded = "ca-app-pub-4233766094089575/4265676046";
#elif UNITY_IPHONE
          private string _adUnitIdRewarded = "ca-app-pub-3940256099942544/1712485313";
#else
          private string _adUnitIdRewarded = "unused";
#endif

    public GameObject coinsGO;
    private InterstitialAd _interstitialAd;
    private RewardedAd _rewardedAd;

    private bool canShowInterstitial = true;

    public void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => {
            LoadInterstitialAd();
            LoadRewardedAd();
        });
    }


    //---------------------------------- Interstitial Ad --------------------------------------------

    public void LoadInterstitialAd()
    {
        // Clean up the old ad before loading a new one.
        if (_interstitialAd != null)
        {
            _interstitialAd.Destroy();
        }

        Debug.Log("Loading the interstitial ad.");

        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
        InterstitialAd.Load(_adUnitIdInterstitial, adRequest,
            (InterstitialAd ad, LoadAdError error) =>
            {
              // if error is not null, the load request failed.
              if (error != null || ad == null)
                {
                    Debug.LogError("interstitial ad failed to load an ad " +
                                   "with error : " + error);
                    return;
                }

                Debug.Log("Interstitial ad loaded with response : "
                          + ad.GetResponseInfo());

                _interstitialAd = ad;
            });
    }

    public void ShowInterstitialAd()
    {
        if(canShowInterstitial)
        {
            if (_interstitialAd != null && _interstitialAd.CanShowAd())
            {
                Debug.Log("Showing interstitial ad.");
                _interstitialAd.Show();
                StartCoroutine(InterstitialDelay(60));
            }
            else
            {
                Debug.LogError("Interstitial ad is not ready yet.");
            }
        }
    }

    private void RegisterEventHandlers(InterstitialAd interstitialAd)
    {
        // Raised when the ad is estimated to have earned money.
        interstitialAd.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(string.Format("Interstitial ad paid {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };
        // Raised when an impression is recorded for an ad.
        interstitialAd.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Interstitial ad recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        interstitialAd.OnAdClicked += () =>
        {
            Debug.Log("Interstitial ad was clicked.");
        };
        // Raised when an ad opened full screen content.
        interstitialAd.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Interstitial ad full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        interstitialAd.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Interstitial ad full screen content closed.");
            _interstitialAd.Destroy();
            LoadInterstitialAd();
        };
        // Raised when the ad failed to open full screen content.
        interstitialAd.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Interstitial ad failed to open full screen content " +
                           "with error : " + error);

            _interstitialAd.Destroy();
            LoadInterstitialAd();
        };
    }


    //---------------------------------- Rewarded Ad --------------------------------------------

    public void LoadRewardedAd()
    {
        // Clean up the old ad before loading a new one.
        if (_rewardedAd != null)
        {
            _rewardedAd.Destroy();
        }

        Debug.Log("Loading the rewarded ad.");

        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
        RewardedAd.Load(_adUnitIdRewarded, adRequest,
            (RewardedAd ad, LoadAdError error) =>
            {
              // if error is not null, the load request failed.
              if (error != null || ad == null)
                {
                    Debug.LogError("Rewarded ad failed to load an ad " +
                                   "with error : " + error);
                    return;
                }

                Debug.Log("Rewarded ad loaded with response : "
                          + ad.GetResponseInfo());

                _rewardedAd = ad;
            });
    }

    public void ShowRewardedAd()
    {
        const string rewardMsg =
            "Rewarded ad rewarded the user. Type: {0}, amount: {1}.";

        if (_rewardedAd != null && _rewardedAd.CanShowAd())
        {
            _rewardedAd.Show((Reward reward) =>
            {
                // TODO: Reward the user.
                Debug.Log(string.Format(rewardMsg, reward.Type, reward.Amount));
                Debug.Log("Recompenzar");
                //coins.GetCoin(30);
                coinsGO.SetActive(true);
            });
        }
    }

    private void RegisterEventHandlers(RewardedAd ad)
    {
        // Raised when the ad is estimated to have earned money.
        ad.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(string.Format("Rewarded ad paid {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };
        // Raised when an impression is recorded for an ad.
        ad.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Rewarded ad recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        ad.OnAdClicked += () =>
        {
            Debug.Log("Rewarded ad was clicked.");
        };
        // Raised when an ad opened full screen content.
        ad.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Rewarded ad full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Rewarded ad full screen content closed.");

            _rewardedAd.Destroy();
            LoadRewardedAd();
        };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Rewarded ad failed to open full screen content " +
                           "with error : " + error);

            _rewardedAd.Destroy();
            LoadRewardedAd();
        };
    }

    public IEnumerator InterstitialDelay(float interDelay)
    {
        canShowInterstitial = false;
        yield return new WaitForSecondsRealtime(interDelay);
        canShowInterstitial = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            ShowInterstitialAd();
        else if (Input.GetKeyDown(KeyCode.R))
            ShowRewardedAd();
    }

}
