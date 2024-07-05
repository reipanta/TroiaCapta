using System;
using System.Collections.Generic;
using Data;
using EventSystem;
using Interactables.IngredientSpawners;
using Unity.VisualScripting;
using UnityEngine;

namespace Interactables
{
    public class Pot : MonoBehaviour
    {
        private List<IngredientsData> _listOfIngredients;
        private List<IngredientsData> _ingredientsInThePot;

        private void Start()
        {
            _listOfIngredients = ObjectController.Instance.spawnedIngredients;
            _ingredientsInThePot = ObjectController.Instance.ingredientsInThePot;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            GameEvent.Ingredients.OnThrownToPot.Invoke(other.gameObject.GetComponent<IngredientsData>());
            Destroy(other.gameObject);
        }
    }
}