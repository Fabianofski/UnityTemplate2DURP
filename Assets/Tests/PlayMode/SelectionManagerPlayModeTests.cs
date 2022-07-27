using System.Collections;
using F4B1.UI;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace F4B1.Tests.PlayMode
{
    public class SelectionManagerPlayModeTests
    {
        [UnityTest]
        public IEnumerator Start()
        {
            new GameObject().AddComponent<EventSystem>();
            GameObject firstSelected = new GameObject();
            SelectionManager selectionManager = new GameObject().AddComponent<SelectionManager>();
            selectionManager.FirstSelected = firstSelected;
            yield return null;
            
            Assert.AreEqual(firstSelected,  selectionManager.LastSelectedGameObject);
        }
        
        [UnityTest]
        public IEnumerator OnNavigate_NothingSelected_SelectControl()
        {
            EventSystem eventSystem = new GameObject().AddComponent<EventSystem>();
            GameObject firstSelected = new GameObject();
            SelectionManager selectionManager = new GameObject().AddComponent<SelectionManager>();
            selectionManager.FirstSelected = firstSelected;
            yield return null;

            eventSystem.SetSelectedGameObject(null);
            selectionManager.OnNavigate();
            
            Assert.AreEqual(firstSelected, eventSystem.currentSelectedGameObject);
            Assert.AreEqual(firstSelected, selectionManager.LastSelectedGameObject);
        }
        
        [UnityTest]
        public IEnumerator OnNavigate_ControlSelected_DoNothing()
        {
            EventSystem eventSystem = new GameObject().AddComponent<EventSystem>();
            GameObject firstSelected = new GameObject();
            SelectionManager selectionManager = new GameObject().AddComponent<SelectionManager>();
            selectionManager.FirstSelected = firstSelected;
            yield return null;

            GameObject selected = new GameObject();
            selected.AddComponent<Button>();
            eventSystem.SetSelectedGameObject(selected);
            selectionManager.OnNavigate();
            
            Assert.AreEqual(firstSelected,  selectionManager.LastSelectedGameObject);
            Assert.AreEqual(selected, eventSystem.currentSelectedGameObject);
        }
        
        [UnityTest]
        public IEnumerator OnMouseMove_ControlSelected_SaveSelectedControl()
        {
            EventSystem eventSystem = new GameObject().AddComponent<EventSystem>();
            GameObject firstSelected = new GameObject();
            SelectionManager selectionManager = new GameObject().AddComponent<SelectionManager>();
            selectionManager.FirstSelected = firstSelected;
            yield return null;

            GameObject selected = new GameObject();
            selected.AddComponent<Button>();
            eventSystem.SetSelectedGameObject(selected);
            selectionManager.OnMouseMove();
            
            Assert.AreEqual(selected,  selectionManager.LastSelectedGameObject);
            Assert.AreEqual(selected, eventSystem.currentSelectedGameObject);
        }
        
        [UnityTest]
        public IEnumerator OnMouseMove_NothingSelected_DoNothing()
        {
            EventSystem eventSystem = new GameObject().AddComponent<EventSystem>();
            GameObject firstSelected = new GameObject();
            SelectionManager selectionManager = new GameObject().AddComponent<SelectionManager>();
            selectionManager.FirstSelected = firstSelected;
            yield return null;

            eventSystem.SetSelectedGameObject(null);
            selectionManager.OnMouseMove();
            
            Assert.AreEqual(firstSelected,  selectionManager.LastSelectedGameObject);
            Assert.AreEqual(null, eventSystem.currentSelectedGameObject);
        }
    }
}