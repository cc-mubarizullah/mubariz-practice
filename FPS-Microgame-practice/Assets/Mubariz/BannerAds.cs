using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
public class BannerAds : MonoBehaviour
{

    string adUnitId = "ca-app-pub-3940256099942544/6300978111";
    BannerView bannerView;

    private void Start()
    {
        MobileAds.Initialize((InitializationStatus inintStatus) => { });
        LoadBannerAd();
    }

    void CreateBannerAd()
    {
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
    }

    void LoadBannerAd()
    {
        if (bannerView == null)
        {
            CreateBannerAd();
        }
        AdRequest adRequest = new AdRequest();
        bannerView.LoadAd(adRequest);
    }


}
