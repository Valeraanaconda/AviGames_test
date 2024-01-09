using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;
using static UnityEngine.PlayerPrefs;

public class ValuesManager : MonoBehaviour
{
    private const string CONSUMABLE_KEY = "ConsumableValue";
    private const string NO_CONSUMABLE_KEY = "NoConsumableValue";
    
    [SerializeField] private TextMeshProUGUI _consumableText;
    [SerializeField] private TextMeshProUGUI _noConsumableText;

    private int _consumableValue;
    private int _noConsumableValue;

    private void Start()
    {
        LoadValuesFromPrefs();
        
        Purchaser.OnByConsumable += AddValue;
        Purchaser.OnByNoConsumable += AddValue;
    }

    private void AddValue(ValueType type)
    {
        switch (type)
        {
            case ValueType.counsumable:
                _consumableValue++;
                _consumableText.text = $"Consumable {_consumableValue}";
                
                Analytics.CustomEvent("Consumable purchase", new Dictionary<string, object>
                {
                    {"Value", _consumableValue}
                });
                break;
            case ValueType.noConsumable:
                _noConsumableValue++;
                _noConsumableText.text = $"No Consumable {_noConsumableValue}";
                
                Analytics.CustomEvent("No Consumable purchase", new Dictionary<string, object>
                {
                    {"Value", _noConsumableValue}
                });
                break;
        }
    }
    
    private void LoadValuesFromPrefs()
    {
        _consumableValue = GetInt(CONSUMABLE_KEY, 0);
        _consumableText.text = $"Consumable {_consumableValue}";
        
        _noConsumableValue = GetInt(NO_CONSUMABLE_KEY, 0);
        _noConsumableText.text = $"No Consumable {_noConsumableValue}";
    }
    
    private void OnDestroy()
    {
        SetInt(CONSUMABLE_KEY,_consumableValue);
        SetInt(NO_CONSUMABLE_KEY,_noConsumableValue);
        
        Purchaser.OnByConsumable -= AddValue;
        Purchaser.OnByNoConsumable -= AddValue;
    }
}

public enum ValueType
{
    counsumable,
    noConsumable
}