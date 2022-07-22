using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace F4B1
{
    public class SelectionManager : MonoBehaviour
    {
        [SerializeField] private EventSystem eventSystem;
        [SerializeField] private GameObject firstSelected;
        private GameObject _lastSelectedGameObject;

        private void Start()
        {
            _lastSelectedGameObject = firstSelected;
        }

        public void OnNavigate()
        {
            if (eventSystem.currentSelectedGameObject != null) return;
            eventSystem.SetSelectedGameObject(_lastSelectedGameObject);
        }
        
        private void OnMouseMove()
        {
            if (eventSystem.currentSelectedGameObject == null) return;
            _lastSelectedGameObject = eventSystem.currentSelectedGameObject;
        }
    }
}
