using Data;
using UnityEngine;

namespace Interactables.IngredientSpawners
{
    public class Ingredient : MonoBehaviour
    {
        // These fields are containers for data that will be assigned from ScriptableObject
        private string _name;
        private int _points;
        private GameObject _ingredientPrefab;

        // 3 properties for accessing private fields
        public GameObject IngredientPrefab
        {
            get { return _ingredientPrefab; }
        }

        public int Points
        {
            get { return _points; }
        }

        public string Name
        {
            get { return _name; }
        }

        // This method assigns data from appropriate ScriptableObject to this object's fields
        public void Initialize(IngredientsData ingredientsData)
        {
            _name = ingredientsData.name;
            _points = ingredientsData.points;
            _ingredientPrefab = ingredientsData.ingredientPrefab;
        }
    }
}