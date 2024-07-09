using UnityEngine;

namespace GameServices.Input
{
    // This is present in the game at runtime
    public class CursorController : MonoBehaviour
    {
        [SerializeField] private Texture2D cursorTexture; // Changing cursor texture
        private readonly Vector2 _hotspot = Vector2.zero; // Make sure the hotspot is in the left upper corner of the new texture

        private void Start()
        {
            Cursor.SetCursor(cursorTexture, _hotspot, CursorMode.Auto);
        }
    }
}