using Infrastructure;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "New Ingredient", menuName = "Ingredient")]
    public class IngredientsData : ScriptableObject // This ScriptableObject holds all data for the Ingredient class
    {
        public new string name;
        public int points;
        public GameObject ingredientPrefab;
    }
}