using UnityEngine;
using UnityEngine.Advertisements;

public class ADSInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    private const string ANDROID_GAME_ID = "5521323";
    private const string IOS_GAME_ID = "5521322";

    [SerializeField] bool testMode = true;

    private string _gameID;

    private void Awake()
    {
        InitializeAds();
    }

    private void InitializeAds()
    {
        _gameID = (Application.platform == RuntimePlatform.IPhonePlayer) ? IOS_GAME_ID : ANDROID_GAME_ID;
        Advertisement.Initialize(_gameID, testMode, this);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
}