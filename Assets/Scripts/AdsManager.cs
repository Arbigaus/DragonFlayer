using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    #if UNITY_IOS
        private string _gameId = "4221930";
        private string _rewardedId = "Rewarded_iOS";
        private string _bannerAdId = "Banner_iOS";
    #else 
        private string _gameId = "4221930";
        private string _rewardedId = "Rewarded_Android";
        private string _bannerAdId = "Banner_Android";
    #endif
    
    private bool _testMode = true;
    void Start()
    {
        Advertisement.Initialize(_gameId, _testMode);
    }

    public void PlayRewardedAd()
    {
        if (Advertisement.IsReady(_rewardedId))
        {
            Debug.Log("Show Rewarded Ad");
            Advertisement.Show(_rewardedId);
        }
        else
        {
            Debug.Log("Rewarded ad is not ready " + Advertisement.IsReady(_rewardedId));
        }
    }

    public void PlayBannerAd()
    {
        if (Advertisement.IsReady(_bannerAdId))
        {
            Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
            Advertisement.Banner.Show(_bannerAdId);
        }
        else
        {
            Debug.Log("Banner ad is not ready " + Advertisement.IsReady(_bannerAdId));
        }
    }

    public void CloseBannerAd()
    {
        Advertisement.Banner.Hide();
    }

    public void OnUnityAdsReady(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        Debug.Log("Finished Rewarded AD" + placementId);
        if (showResult.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Finished Rewarded AD");
        }
    }
}
