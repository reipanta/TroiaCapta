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
    // This class operates the UI above the pot showing in-the-pot ingredients
    public class AboveThePotUI : MonoBehaviour
    {
        [SerializeField] private GameObject questionMarkImage;
        [SerializeField] private GameObject[] prefabIngredientImage;

        private GameObject[] _imagesRow = new GameObject[5]; // 
        private Transform _parentPosition;
        private Ingredient _lastIngredient;

        private float _spacing = 50;
        private int _counter = 0;

        private void Start()
        {
            _parentPosition = GetComponent<Transform>();
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

            var currentIngredient = FindPrefabByName(ingredient.Name);

            GameObject newImage = Instantiate(currentIngredient, _parentPosition);
            _imagesRow[_counter] = currentIngredient;

            float xPos = _counter * (newImage.GetComponent<RectTransform>().rect.width + _spacing);

            newImage.GetComponent<RectTransform>().anchoredPosition = new Vector2(xPos, 0);

            transform.GetChild(_counter).gameObject.GetComponent<Image>().enabled = false;

            _counter++;
        }

        private GameObject FindPrefabByName(string name)
        {
            foreach (GameObject prefab in prefabIngredientImage)
            {
                if (prefab.name == name)
                {
                    return prefab; 
                }
            }
            return null;
        }

        private void ClearPotUI()
        {
            _counter = 0;

            foreach (Transform child in transform)
            {
                Debug.Log("Child: " + child.gameObject.name);
                Destroy(child.gameObject);
            }

            FillDefaultUI();
        }

        // Fill with default question marks at the start
        private void FillDefaultUI()
        {
            for (int i = 0; i < _imagesRow.Length; i++)
            {
                GameObject newImage = Instantiate(questionMarkImage, _parentPosition);
                _imagesRow[i] = questionMarkImage;

                float xPos = i * (newImage.GetComponent<RectTransform>().rect.width + _spacing);

                newImage.GetComponent<RectTransform>().anchoredPosition = new Vector2(xPos, 0);
            }
        }
    }
}