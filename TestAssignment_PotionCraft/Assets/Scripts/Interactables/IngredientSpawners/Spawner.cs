using Data;
using UnityEngine;

namespace Interactables.IngredientSpawners
{
    // Spawner, Ingredient and ObjectController classes
    // represent a Factory pattern that spawns appropriate Products
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private IngredientsData ingredientsData;
        [SerializeField] private LayerMask mask;
        private Ingredient _ingredient;

        public Ingredient CreateIngredient(Vector3 position)
        {
            InitializeIngredient();
            _ingredient.transform.position = position;
            return _ingredient;
        }

        public void InitializeIngredient()
        {
            _ingredient = new GameObject("IngredientHolder").AddComponent<Ingredient>();
            _ingredient.Name = ingredientsData.name;
            _ingredient.Points = ingredientsData.points;
            _ingredient.IngredientPrefab = ingredientsData.ingredientPrefab;
        }

        private void OnMouseDown()
        {
            // Temporary switch off the collider of the spawner
            // to get rid of newly spawned ingredients' physics bugs and flickering
            //GetComponent<Collider2D>().enabled = false;

            ObjectController.Instance.InstantiateIngredient(this);
        }

        private void OnMouseUp()
        {
            // Switch the collider back again after spawning the ingredient
            GetComponent<Collider2D>().enabled = true;
        }
    }
}