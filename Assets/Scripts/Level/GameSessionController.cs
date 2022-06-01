using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jamination5.Level
{
    public class GameSessionController : MonoBehaviour
    {       
        [SerializeField] GameObject levels;
        
        private int currentLevelIndex = -1;
        private Level currentLevel;

        private void Awake()
        {
            
        }

        void Start()
        {
            foreach (Transform child in levels.transform)
            {
                child.transform.gameObject.SetActive(false);
            }

            StartNextLevel();
        }

        private void Update()
        {
            
        }
        public Level GetCurrentLevel()
        {
            return currentLevel;
        }
        
        public void StartNextLevel()
        {
            if (levels != null & levels.transform.childCount > 0)
            {
                currentLevel = levels.transform.GetChild(currentLevelIndex +1).GetComponent<Level>();
                currentLevel.gameObject.SetActive(true);
                currentLevelIndex++;
            }
        }
        public void RestartLevel()
        {
            if (levels != null & levels.transform.childCount > 0)
            {
                currentLevel = levels.transform.GetChild(currentLevelIndex).GetComponent<Level>();
                currentLevel.gameObject.SetActive(true);
            }
        }

        public void EndLevel()
        {
            Destroy(currentLevel.gameObject);
        }
        
        
    }
}
