using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class Recipe : ScriptableObject
{
    //public RecipeType recipeType;
    public Ingredient[] ingredients;
}

[System.Serializable]
public class Ingredient
{
    public string name;
    public string[] requiredIngredients;
    public float cookingTime;
}
