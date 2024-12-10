using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CarVisit
{
    [CreateAssetMenu(menuName = "CarVisit/CatalogueSO")]
    public class CatalogueSO : ScriptableObject
    {
        public CarSO[] cars;
    }
}