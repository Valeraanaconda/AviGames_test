using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class SceneLoader : MonoBehaviour
{
    public Action OnGoToLevel;
        
    [SerializeField] private AssetReference _sceneReference;
    
    public void LoadScene()
    {
        OnGoToLevel?.Invoke();
        _sceneReference.LoadSceneAsync();
    }
}
