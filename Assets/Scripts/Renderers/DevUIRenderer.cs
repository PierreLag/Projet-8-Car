using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace CarVisit
{
    public class DevUIRenderer : MonoBehaviour
    {
        int avgFPS;
        int triangleCount;
        [SerializeField]
        private TextMeshProUGUI fpsDisplay;
        [SerializeField]
        private TextMeshProUGUI triangleDisplay;

        // Start is called before the first frame update
        void Start()
        {
            // On répète l'exécution de ces méthodes chaque seconde.
            InvokeRepeating("DisplayFrameRate", 1, 1);
            InvokeRepeating("DisplayTriangleCount", 1, 1);
        }

        /// <summary>
        /// Cette méthode change le texte du champs de FPS pour afficher le nombre de Frames Par Seconde.
        /// </summary>
        private void DisplayFrameRate()
        {
            float current = 0;
            current = (int)(1f / Time.unscaledDeltaTime);
            avgFPS = (int)current;
            fpsDisplay.text = "FPS : " + avgFPS;
        }

        /// <summary>
        /// Cette méthode change le texte du champs de triangles pour afficher le nombre de triangles dans la scène.
        /// </summary>
        private void DisplayTriangleCount()
        {
            triangleCount = 0;
            MeshFilter[] allMeshes = FindObjectsByType<MeshFilter>(FindObjectsSortMode.None);

            foreach (MeshFilter mesh in allMeshes)
            {
                triangleCount += mesh.mesh.triangles.Length;
            }
            triangleDisplay.text = "Triangles : " + triangleCount;
        }
    }
}