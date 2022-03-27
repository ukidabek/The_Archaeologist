using Logic.Events;
using UnityEngine;

public class Viewfinder : MonoBehaviour
{
    [SerializeField] private BoolEvent _boolEvent = null;

    private void Awake()
    {
        gameObject.SetActive(false);
        _boolEvent.Subscribe(gameObject.SetActive);
    }

    private void OnDestroy()
    {
        _boolEvent.Unsubscribe(gameObject.SetActive);
    }
}
