using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevConsole
{
    public class SpawnedObjectsList : MonoBehaviour
    {
        public static SpawnedObjectsList SOL;

        public List<GameObject> spawnedObjects = new List<GameObject>();

        private void OnEnable()
        {
            SOL = this;
        }

        private void Awake()
        {
            SOL = this;
        }
    }
}
