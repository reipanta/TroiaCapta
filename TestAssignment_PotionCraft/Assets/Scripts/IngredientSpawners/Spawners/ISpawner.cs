using Data;
using IngredientSpawners.Ingredients;
using UnityEngine;

namespace IngredientSpawners.Spawners
{
    public interface ISpawner
    {
        public IIngredient Spawn();
    }
}