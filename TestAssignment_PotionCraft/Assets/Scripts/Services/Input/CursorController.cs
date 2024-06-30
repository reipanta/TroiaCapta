using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Services.Input
{
    public class CursorController : MonoBehaviour
    {
        [SerializeField] private Texture2D cursoreTexture; // Changing cursor texture
        private readonly Vector2 _hotspot = Vector2.zero; // Make sure the hotspot is in the left upper corner of the new texture

        private void Start()
        {
            Cursor.SetCursor(cursoreTexture, _hotspot, CursorMode.Auto);
        }
    }
}