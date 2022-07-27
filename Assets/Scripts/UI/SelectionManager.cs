using UnityEngine;
using UnityEngine.EventSystems;

namespace F4B1.UI
{
    public class SelectionManager : MonoBehaviour
    {
        private EventSystem _eventSystem;
        [SerializeField] private GameObject firstSelected;
        private GameObject _lastSelectedGameObject;

        private void Start()
        {
            _eventSystem = FindObjectOfType<EventSystem>();
            _lastSelectedGameObject = firstSelected;
        }

        public void OnNavigate()
        {
            if (_eventSystem.currentSelectedGameObject != null) return;
            _eventSystem.SetSelectedGameObject(_lastSelectedGameObject);
        }
        
        private void OnMouseMove()
        {
            if (_eventSystem.currentSelectedGameObject == null) return;
            _lastSelectedGameObject = _eventSystem.currentSelectedGameObject;
        }
    }
}
