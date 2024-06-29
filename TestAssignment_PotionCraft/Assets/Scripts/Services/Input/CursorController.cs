using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Services.Input
{
    public class CursorController : MonoBehaviour
    {
        [SerializeField] private Texture2D cursoreTexture;
        private readonly Vector2 _hotspot = Vector2.zero;

        private void Start()
        {
            Cursor.SetCursor(cursoreTexture, _hotspot, CursorMode.Auto);
        }
    }
}