using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using GoogleMobileAds.Api;
using UnityEngine.Purchasing;

public class GameOver : MonoBehaviour
{
    public Text scoreText;
    public Text bestScoreText;

    private int score;
    private int bestScore;



    void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore");
        score = MainScript.score;

        showAd();
    }

    void showAd()
    {
           
        if (Welcome.interstitialAd.IsLoaded())
        {
            Debug.Log("Showing ad...");
            Welcome.interstitialAd.Show();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (score > bestScore)
        {
            bestScore = score;
        }
        scoreText.text = score.ToString();
        bestScoreText.text = bestScore.ToString();

    }
    public void OnClickPlay()
    {
        PlayerPrefs.SetInt("BestScore", bestScore);
        MainScript.score = 0;
        Welcome.interstitialAd.Destroy();
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void OnClickShare()
    {
        StartCoroutine(TakeScreenShotAndShare());
    }

    private IEnumerator TakeScreenShotAndShare()
    {
        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();
        //string screenShotPath = Application.persistentDataPath + "/" + "share_img.png";
        //ScreenCapture.CaptureScreenshot(screenShotPath, 1);

        string filePath = Path.Combine(Application.temporaryCachePath, "share img.png");
        File.WriteAllBytes(filePath, ss.EncodeToPNG());

        Destroy(ss);
        Debug.Log("filePath");
        Debug.Log(filePath);
        new NativeShare().AddFile(filePath).SetSubject("Dragon Dance").SetText("Check out my record!!!!").Share();
    }
}
