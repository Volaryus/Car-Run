using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class AdsManager : MonoBehaviour, IUnityAdsListener
{

    public Transform playerTransform;
    public GameObject player;
    public GameObject deathPanel;
    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize("5079109");
        Advertisement.AddListener(this);
    }

    public void PlayRewardedAd()
    {
        if (Advertisement.IsReady("Rewarded_Android"))
        {
            Debug.Log("A");
            Advertisement.Show("Rewarded_Android");
        }
    }

    public void PlayAd()
    {
        if(Advertisement.IsReady("Interstitial_Android"))
        {
            Advertisement.Show("Interstitial_Android");
        }
    }

    void IUnityAdsListener.OnUnityAdsReady(string placementId)
    {
        Debug.Log("Ads are ready");
    }

    void IUnityAdsListener.OnUnityAdsDidError(string message)
    {
        Debug.Log("Error: " + message);
    }

    void IUnityAdsListener.OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Ad started");
    }

    void IUnityAdsListener.OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == "Rewarded_Android" && showResult == ShowResult.Finished)
        {
            //Reward the player
            Debug.Log("Done");
        }
    }
}
