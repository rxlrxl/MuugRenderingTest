using UnityEngine;
using UnityEngine.UI;

namespace RenderTest
{
    public class RenderTest : MonoBehaviour
    {
        [SerializeField] private Transform _testsParent = null;
        [SerializeField] private GameObject _buttonPrefab = null;
        
        [SerializeField] private Transform _buttonsGroup = null;
        [SerializeField] private Text _headerText = null;
        
        private void Start()
        {
            Application.targetFrameRate = int.MaxValue;

            SpawnButtons();
            SetTest(0);
        }

        private void SpawnButtons()
        {
            for (int i = 0; i < _testsParent.childCount; i++)
            {
                var button = Instantiate(_buttonPrefab, _buttonsGroup);
                button.GetComponentInChildren<Text>().text = _testsParent.GetChild(i).gameObject.name;
                
                int index = i;
                button.GetComponentInChildren<Button>().onClick.AddListener(() => SetTest(index)); 
            }
        }

        private void SetTest(int index)
        {
            for (int i = 0; i < _testsParent.childCount; i++)
            {
                _testsParent.GetChild(i).gameObject.SetActive(i == index);
            }

            _headerText.text = _testsParent.GetChild(index).gameObject.name;
        }

#if UNITY_EDITOR
        [UnityEditor.MenuItem("RenderTest/PlaceTransparentQuads")]
        private static void PlaceTransparentQuads()
        {
            var selectedTransform = UnityEditor.Selection.transforms[0];
            
            int currentPositionModifier = 0;
            foreach (Transform child in selectedTransform)
            {
                child.position = Vector3.forward * 8 + Vector3.forward * 0.2f * currentPositionModifier;
                currentPositionModifier++;
            }
        }
#endif
    }
}
