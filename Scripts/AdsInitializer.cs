using UnityEngine;
using UnityEngine.Advertisements;

///////////////////////////
// Written by: Unity Documentation
// Associate writing: 
// Last Modified: 1/22/2023
////////////////////////////

public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] string _androidGameId;
    [SerializeField] string _iOSGameId;
    [SerializeField] bool _testMode = true;
    private string _gameId;

    void Awake()
    {
        InitializeAds();
    }

    //Ad Intializer
    public void InitializeAds()
    {
        _gameId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOSGameId
            : _androidGameId;
        Advertisement.Initialize(_gameId, _testMode, this);
    }

    //Debug message when Initialization is complete
    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
    }

    //Debug message when Init fails
    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
}