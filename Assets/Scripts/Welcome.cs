using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;

public class Welcome : MonoBehaviour
{
    static bool isAdInit = false;
    public static InterstitialAd interstitialAd;

    // Start is called before the first frame update
    void Start()
    {
        if (!isAdInit)
        {
            MobileAds.Initialize(initStatus => { });
            isAdInit = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void onClickPlay()
    {
        loadAdd();
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    private void loadAdd()
    {
        #if UNITY_ANDROID
        string adUnitId = "ca-app-pub-9470310520604423/8207533595";
        //string adUnitId = "ca-app-pub-3940256099942544/1033173712";//test ad

        #elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-9470310520604423/8330605293";
        //string adUnitId = "ca-app-pub-3940256099942544/4411468910";//test ad
        #else
        string adUnitId = "unexpected_platform";
        #endif
        // Initialize an InterstitialAd.
        interstitialAd = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        Debug.Log("Loading ad...");
        interstitialAd.LoadAd(request);
    }
}
