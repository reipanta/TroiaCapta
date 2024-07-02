using UnityEditor.U2D.Aseprite;
using UnityEngine;
using static UnityEngine.Tilemaps.Tile;

namespace Data
{
    [CreateAssetMenu(fileName = "New Ingredient", menuName = "Ingredient")]
    public class IngredientsData : ScriptableObject
    {
        public new string name;
        public int points;
        public GameObject ingredientPrefab;

    }
}