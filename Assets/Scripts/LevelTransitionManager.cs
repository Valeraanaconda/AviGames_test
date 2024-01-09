using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;

public class LevelTransitionManager : MonoBehaviour
{
    private const string TRANSITION_COUNT_KEY = "GoToLevelCount";
    
    [SerializeField] private TextMeshProUGUI _goToLevelText;
    [SerializeField] private SceneLoader _sceneLoader;

    private int _levelGoCount;
    
    void Start()
    {
        LoadValuesFromPrefs();
        _sceneLoader.OnGoToLevel += AddCount;
    }

    private void AddCount()
    {
        _levelGoCount++;
        _goToLevelText.text = $"Go To Level Count: {_levelGoCount}";
        
        Analytics.CustomEvent("GoToLevelCount", new Dictionary<string, object>
        {
            {"Count",_levelGoCount}
        });
    }
    
    private void LoadValuesFromPrefs()
    {
        _levelGoCount = PlayerPrefs.GetInt(TRANSITION_COUNT_KEY, 0);
        _goToLevelText.text = $"Go To Level Count: {_levelGoCount}";
    }
    
    private void OnDestroy()
    {
        PlayerPrefs.SetInt(TRANSITION_COUNT_KEY,_levelGoCount);
        
        _sceneLoader.OnGoToLevel -= AddCount;
    }
}
