using System;
using System.Collections.Generic;
using EventSystem;
using Interactables;
using Interactables.IngredientSpawners;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI
{
    public class AboveThePotUI : MonoBehaviour
    {
        [SerializeField] private GameObject image;
        private Vector2 _parentPosition;
        private Vector2 _spacing = new Vector2(-40, 0);
        private GameObject[] _imagesRow = new GameObject[5];
        private Ingredient _lastIngredient;

        private void Start()
        {
            _parentPosition = GetComponent<Transform>().position;
            FillDefaultUI();
        }

        private void OnEnable()
        {
            GameEvent.Ingredients.OnThrownToPot?.AddListener(SpawnIngredientImages);
            GameEvent.Ingredients.OnMealComplete?.AddListener(ClearPotUI);
        }

        private void OnDisable()
        {
            GameEvent.Ingredients.OnThrownToPot?.RemoveListener(SpawnIngredientImages);
            GameEvent.Ingredients.OnMealComplete?.RemoveListener(ClearPotUI);
        }

        private void SpawnIngredientImages(Ingredient ingredient)
        {
            ingredient = Pot.IngredientToPassToIcon;

            switch (ingredient.Name)
            {
                case "Мясо":
                    break;
                case "Болгарский перец":
                    break;
                case "Лук":
                    break;
                case "Морковь":
                    break;
                case "Картофель":
                    break;
            }
        }

        private void ClearPotUI()
        {
        }

        // Fill with default question marks at the start
        private void FillDefaultUI()
        {
            for (int i = 0; i < _imagesRow.Length; i++)
            {
                //Instantiate(image, _parentPosition);
            }
        }
    }
}