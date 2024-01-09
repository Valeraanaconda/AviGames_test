using UnityEngine;
using UnityEngine.Events;

public class ClickableObject : MonoBehaviour
{
    [SerializeField] private UnityEvent OnClickEvent;
    
    private void OnMouseDown()
    {
        OnClickEvent?.Invoke();
    }
}