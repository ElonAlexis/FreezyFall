using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;


public class AdsMAnager : MonoBehaviour, IUnityAdsListener
{
    Action onRewardedAdSuccess; 
    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize("4299213");
        Advertisement.AddListener(this);
    }


    public void PlayAd()
    {
        if(Advertisement.IsReady("Interstitial_Android"))
        {
            Advertisement.Show("Interstitial_Android"); 
        }

    }

    public void PlayRewardedAd(Action onSuccess)
    {
        onRewardedAdSuccess = onSuccess;
        if(Advertisement.IsReady("Rewarded_Android"))
        {
            Advertisement.Show("Rewarded_Android"); 
        }
        else 
        {
            Debug.Log("Rewarded ad is not ready");
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        //throw new System.NotImplementedException();
        Debug.Log("");
    }

    public void OnUnityAdsDidError(string message)
    {
        //throw new System.NotImplementedException();
        Debug.Log("Error" + message);

    }

    public void OnUnityAdsDidStart(string placementId)
    {
        //throw new System.NotImplementedException();
        Debug.Log("");

    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        //throw new System.NotImplementedException();

        if(placementId == "Rewarded_Android" && showResult == ShowResult.Finished)
        {
            onRewardedAdSuccess.Invoke();
            //Debug.Log("Reward Player please!"); 
        }
    }
}
