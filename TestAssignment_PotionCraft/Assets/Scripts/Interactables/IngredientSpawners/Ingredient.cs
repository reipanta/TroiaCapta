using UnityEngine;


namespace Interactables.IngredientSpawners
{
    public class Ingredient : MonoBehaviour
    {
        // These fields are containers for data that will be assigned from ScriptableObject
        public string Name { get; set; }
        public int Points { get; set; }
        public GameObject IngredientPrefab { get; set; }
    }
}