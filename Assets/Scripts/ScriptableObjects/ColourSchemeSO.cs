using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CarVisit
{
    [CreateAssetMenu(menuName = "CarVisit/ColourSchemeSO")]
    public class ColourSchemeSO : ScriptableObject
    {
        public Material baseMaterial;
        public Material secondaryMaterial;
    }
}