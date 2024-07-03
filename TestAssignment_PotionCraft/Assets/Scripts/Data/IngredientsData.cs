using UnityEngine;

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