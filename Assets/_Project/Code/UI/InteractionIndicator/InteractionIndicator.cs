using System;
using Logic.Events;
using UnityEngine;

public class InteractionIndicator : MonoBehaviour
{
    [SerializeField] private GameObject _image = null;
    [SerializeField] private GameObjectEvent _interactionObjectSelected = null;

    private Camera _camera = null;
    private GameObject _selectedObject = null;
    
    private void Awake()
    {
        enabled = false;
        _image.SetActive(false);
        _camera = Camera.main;
        _interactionObjectSelected.Subscribe(Show);
    }

    private void OnDestroy()
    {
        _interactionObjectSelected.Unsubscribe(Show);
    }

    private void Show(GameObject interaction)
    {
        if (interaction == null)
        {
            _selectedObject = null;
            enabled = false;
            _image.SetActive(false);
        }
        else
        {
            _selectedObject = interaction;
            enabled = true;
            _image.SetActive(true);
        }
    }

    private void Update()
    {
        if (_selectedObject == null)
        {
            Show(_selectedObject);    
            return;
        }
        _image.transform.position = _camera.WorldToScreenPoint(_selectedObject.transform.position + Vector3.up * .15f);
    }
}
