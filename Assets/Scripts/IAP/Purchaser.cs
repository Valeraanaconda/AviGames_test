using System;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class Purchaser : MonoBehaviour
{
    private const string CONSUMABLE_ADS = "com.DefaultCompany.AviGames_test.Consumable";
    private const string NO_CONSUMABLE_ADS = "com.DefaultCompany.AviGames_test.NoConsumable";

    public static Action<ValueType> OnByConsumable; 
    public static Action<ValueType> OnByNoConsumable;
    
    [SerializeField] private Button _noConsumableButton;

    private void Awake()
    {
        IapDuplicateClearing();
    }

    public void OnPurchaseCompleted(Product product)
    {
        switch(product.definition.id)
        {
            case CONSUMABLE_ADS:
                ConsumableAds();
                break;
            case NO_CONSUMABLE_ADS:
                NoConsumableAds();
                break;
        }
    }

    private void ConsumableAds()
    {
        OnByConsumable?.Invoke(ValueType.counsumable);
    }

    private void NoConsumableAds()
    {
        OnByNoConsumable?.Invoke(ValueType.noConsumable);
        _noConsumableButton.interactable = false;
    }
    
    private void IapDuplicateClearing()
    {
        Purchaser[] purchasers = FindObjectsOfType<Purchaser>();
        if (purchasers.Length > 1)
        {
            Destroy(purchasers[0].gameObject);
        }
    }
}
