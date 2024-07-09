using UnityEngine;

namespace GameServices.Input
{
    // Class for changing the cursor texture
    public class CursorController : MonoBehaviour
    {
        [SerializeField] private Texture2D cursorTexture;
        private readonly Vector2 _hotspot = Vector2.zero;

        private void Start()
        {
            Cursor.SetCursor(cursorTexture, _hotspot, CursorMode.Auto);
        }
    }
}