using GoogleMobileAds.Api;
using UnityEngine;

public class InterstitialAdsTest : MonoBehaviour
{

    InterstitialAd interstitialAd;
    string adUnityId = "ca-app-pub-3940256099942544/6300978111";   // Id for test ads
    private void Start()
    {
        InitializeAdSDK();       // first we have to initialize the GoogleMobileAdSDK at the start of our game only once
        LoadInterstitialAd();       // loading the interstitial ad
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowInterstitialAds();        // when ever we'll press space the interstitial ad will popup
        }
    }
    void InitializeAdSDK()     // initializing the SDK
    {
        MobileAds.Initialize((InitializationStatus initializeStatus) =>
            {

            });
    }
    void LoadInterstitialAd()
    {
        if (interstitialAd != null)          //if ad is not null, it is present already
        {
            Debug.Log("Theres already an instance of interstitial ad, destroying previous ad");
            interstitialAd.Destroy();  // then destroy interstitial ad
            interstitialAd = null;     // and set the variable to null
        }
                 // IF NOT
        AdRequest adRequest = new AdRequest();  //  request ad

        InterstitialAd.Load(adUnityId, adRequest, (InterstitialAd ad, LoadAdError error) =>
            {

                if (error != null && ad == null)
                {
                    Debug.LogError("interstitial ad failed to load with an error " + error);
                }

                Debug.Log("interstitial ad loaded eith reponses :" + ad.GetResponseInfo());
                interstitialAd = ad;   //we assign our variable to the Method Load interstitial variable on line40
                EventListner(interstitialAd);       // calling ad listners because ad is loaded
                RegisterPreloaderHandler(interstitialAd);     // preload the next ad
            });

    }

    void ShowInterstitialAds()
    {
        if (interstitialAd != null && interstitialAd.CanShowAd())
        {
            interstitialAd.Show();
        }
        else
        {
            Debug.LogError("Interstitial ad is not ready to show");
        }
    }
                                    
                                    ////////////////////////
                                    ////                  //
                                    ////     EVENTS       //
                                    ////                  //
                                    ////////////////////////
    
    
    void EventListner(InterstitialAd interstitialAd)
    {
        interstitialAd.OnAdClicked += InterstitialAd_OnAdClicked;
    }

    private void InterstitialAd_OnAdClicked()
    {
        Debug.Log("Ad is clicked");
    }
                                 
                                     ////////////////////////
                                     ////                  //
                                     //// PRE-LOADING AD   //
                                     ////                  //
                                     ////////////////////////
                                 

    void RegisterPreloaderHandler(InterstitialAd interstitialAd)
    {
        interstitialAd.OnAdFullScreenContentClosed += InterstitialAd_OnAdFullScreenContentClosed;
    }

    private void InterstitialAd_OnAdFullScreenContentClosed()
    {
        Debug.Log("Interstiial ad full screen closed");
        LoadInterstitialAd();
    }
}
