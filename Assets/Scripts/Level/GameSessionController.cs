using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jamination5.Level
{
    public class GameSessionController : MonoBehaviour
    {
        Level currentLevel;
        [SerializeField] GameObject levels;

        private void Awake()
        {
            
        }

        void Start()
        {
            foreach (Transform child in levels.transform)
            {
                child.transform.gameObject.SetActive(false);
            }

            StartLevel();
        }

        private void Update()
        {
            
        }
        public Level GetCurrentLevel()
        {
            return currentLevel;
        }
        
        public void StartLevel()
        {
            if (levels != null & levels.transform.childCount > 0)
            {
                print("Levels found");
                currentLevel = levels.transform.GetChild(0).GetComponent<Level>();
                print(currentLevel.gameObject.name);
                currentLevel.gameObject.SetActive(true);
            }
        }

        public void EndLevel()
        {
            Destroy(currentLevel.gameObject);
        }
        
        
    }
}
