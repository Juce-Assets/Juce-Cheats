using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Juce.Cheats.Utils
{
    [ExecuteInEditMode]
    public class CheatsCopyTextSizeToLayoutElement : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TMPro.TextMeshProUGUI text = default;
        [SerializeField] private LayoutElement layoutElement = default;

        [Header("Width")]
        [SerializeField] private bool width = true;
        [SerializeField] private float widthPadding = default;

        [Header("Height")]
        [SerializeField] private bool height = default;
        [SerializeField] private float heightPadding = default;

        private bool needsToUpdate;

        private void Awake()
        {
            TMPro_EventManager.TEXT_CHANGED_EVENT.Add(OnTextChanged);
        }

        private void OnDestroy()
        {
            TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(OnTextChanged);
        }

        private void OnEnable()
        {
            TryRefreshMesh();
            CopySize();
        }

        private void Update()
        {
            TryCopySize();
        }

        private void OnTextChanged(Object obj)
        {
            if (obj.Equals(text) == false)
            {
                return;
            }

            needsToUpdate = true;
        }

        private void TryCopySize()
        {
            if (!Application.isPlaying)
            {
                TryRefreshMesh();
                CopySize();
            }

            if (!needsToUpdate)
            {
                return;
            }

            needsToUpdate = false;

            CopySize();
        }

        private void TryRefreshMesh()
        {
            if (Application.isPlaying)
            {
                return;
            }

            if (text == null)
            {
                return;
            }

            text.ForceMeshUpdate(true);
        }

        public void CopySize()
        {
            if (layoutElement == null)
            {
                return;
            }

            if (text == null)
            {
                return;
            }

            Vector2 newSize = new Vector2(layoutElement.minWidth, layoutElement.minHeight);
            Vector2 textSize = text.GetRenderedValues();

            if (width)
            {
                textSize.x = Mathf.Max(0, textSize.x);
                newSize.x = textSize.x + widthPadding;

                layoutElement.minWidth = newSize.x;
            }

            if (height)
            {
                textSize.y = Mathf.Max(0, textSize.y);
                newSize.y = textSize.y + heightPadding;

                layoutElement.minHeight = newSize.y;
            }
        }
    }
}
