using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GoogleMobileAds.Api;
using GoogleMobileAds;

public class ADmob : MonoBehaviour
{
    [NonSerialized] public bool ads = true;
    public LogManager oLogManager;
    public Game_UIManager oGame_UIManager;
    private BannerView bannerAD;
    private InterstitialAd videoAD;
    private RewardedAd videoRewardedAD;

    private AdRequest bannerInfo;
    private AdRequest videoInfo;

    private string appID = "";
    private string bannerID = "";
    private string videoID = "";
    private string rewardedVideoID = "";
    public bool rewardedOK = false;

    private InterstitialAd interstitialAd;

    public void Start()
    {
        if (ads)
        {
            Init();
        }
    }

    public void Init()
    {
        if (ads)
        {
            if (GlobalVars.Instance.device == "Android")
            {
                appID = "ca-app-pub-5685648525148086~1011401326";
                bannerID = "ca-app-pub-5685648525148086/4759074643";
                videoID = "ca-app-pub-5685648525148086/7736591779";
                rewardedVideoID = "ca-app-pub-5685648525148086/8137581794";
            }
            else
            { // pendiente iOS
                appID = "ca-app-pub-5685648525148086~8666530063";
                bannerID = "ca-app-pub-5685648525148086/6963742137"; // new
                videoID = "ca-app-pub-5685648525148086/9788040048";
                rewardedVideoID = "ca-app-pub-5685648525148086/9771886229";
            }
            try
            {
                MobileAds.RaiseAdEventsOnUnityMainThread = true;
                MobileAds.Initialize(initStatus => { oLogManager.Log("ADS:: MobileAds Initialized"); });

                var adRequest = new AdRequest();
                InterstitialAd.Load(videoID, adRequest, (InterstitialAd ad, LoadAdError error) =>
                {
                    // if error is not null, the load request failed.
                    if (error != null || ad == null)
                    {
                        oLogManager.Log("ADS:: interstitial ad failed to load an ad " + "with error : " + error);
                        return;
                    }
                    oLogManager.Log("ADS:: Interstitial ad loaded with response : " + ad.GetResponseInfo());
                    interstitialAd = ad;
                    ShowBanner();
                });
            }
            catch (Exception e) { oLogManager.Log(e.Message); }
        }
    }

    private void ShowBanner()
    {
        if (ads)
        {
            try
            {
                //oLogManager.Log("ADS::  Creating banner view");
                oLogManager.Log("ADS::  Creating banner view");
                // If we already have a banner, destroy the old one.
                if (bannerAD != null) { DestroyAd(); }
                var adRequest = new AdRequest();
                bannerAD = new BannerView(bannerID, AdSize.Banner, AdPosition.Bottom);
                bannerAD.LoadAd(adRequest);
                oLogManager.Log("ADS::  banner created successfull");
            }
            catch (Exception e)
            {
                oLogManager.Log("ADS:: Banner fail : " + e.Message);
            }
        }
    }

    public void ShowVideo()
    {
        oLogManager.Log("ADS::  Show Video");
        if (ads)
        {
            try
            {
                //oLogManager.Log("ADS::  Show Video - interstitialAd:" + interstitialAd + " - interstitialAd.CanShowAd(): " + interstitialAd.CanShowAd());
                oLogManager.Log("ADS::  Show Video - interstitialAd:" + interstitialAd + " - interstitialAd.CanShowAd(): " + interstitialAd.CanShowAd());
                if (interstitialAd != null && interstitialAd.CanShowAd())
                {
                    oLogManager.Log("ADS:: Showing interstitial ad.");
                    interstitialAd.Show();
                }
                else
                {
                    oLogManager.Log("ADS:: Interstitial ad is not ready yet.");
                }
            }
            catch (Exception e)
            {
                oLogManager.Log("ADS:: Interstitial fail : " + e.Message);
            }
        }
    }

    public void SetRewardedVideo()
    {
        if (ads)
        {
            try
            {
                if (videoRewardedAD != null)
                {
                    videoRewardedAD.Destroy();
                    videoRewardedAD = null;
                }

                oLogManager.Log("ADS:: SetRewardedVideo");
                var adRequest = new AdRequest();
                adRequest.Keywords.Add("ranavirtual");

                // send the request to load the ad.
                RewardedAd.Load(rewardedVideoID, adRequest, (RewardedAd ad, LoadAdError error) =>
                {
                    // if error is not null, the load request failed.
                    if (error != null || ad == null)
                    {
                        oLogManager.Log("ADS:: Rewarded ad failed to load an ad " + "with error : " + error);
                        return;
                    }
                    else
                    {
                        rewardedOK = true;
                    }
                    oLogManager.Log("ADS::  Rewarded ad loaded with response : " + ad.GetResponseInfo());
                    videoRewardedAD = ad;
                });
            }
            catch (Exception e)
            {
                oLogManager.Log("ADS:: Set Rewarded Video fail : " + e.Message);
            }
        }
    }

    public void ShowRewardedVideo()
    {
        if (ads)
        {
            try
            {
                oLogManager.Log("ADS::  Show ShowRewardedVideo");
                const string rewardMsg = "JUEGO ALARGADO!";

                if (videoRewardedAD != null && videoRewardedAD.CanShowAd())
                {
                    videoRewardedAD.Show((Reward reward) =>
                    {
                        oLogManager.Log("ADS::  " + rewardMsg);
                        oGame_UIManager.AlargarChico();
                    });
                }
            }
            catch (Exception e)
            {
                oLogManager.Log("ADS:: Show Rewarded Video fail : " + e.Message);
            }
        }
    }

    public void DestroyAd()
    {
        if (ads)
        {
            try
            {
                if (bannerAD != null)
                {

                    oLogManager.Log("ADS:: Destroying banner ad.");
                    bannerAD.Destroy();
                    bannerAD = null;

                }
            }
            catch (Exception e)
            {
                oLogManager.Log("ADS:: DestroyAd fail : " + e.Message);
            }
        }
    }

}
