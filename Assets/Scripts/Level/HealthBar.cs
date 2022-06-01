using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Jamination5.Level
{
    public class HealthBar : MonoBehaviour
    {
        private Image[] healthImages = null;
        private GameSessionController gameSessionController = null;
        private Level currentLevel = null;

        private void Awake()
        {
            healthImages = gameObject.transform.GetComponentsInChildren<Image>();
            gameSessionController = FindObjectOfType<GameSessionController>();
            
        }
        private void Start()
        {
            currentLevel = gameSessionController.GetCurrentLevel();
            if (currentLevel != null)
            {
                currentLevel.onHealthDrop += DropHealth;
            }

        }
  
        
        private void DropHealth()
        {
            if(healthImages != null)
            {
                healthImages = gameObject.transform.GetComponentsInChildren<Image>();
                int length = healthImages.Length;
                if (length > 0)
                {
                    Destroy(healthImages[length - 1].gameObject);
                }
                else if (length == 0)
                {
                    currentLevel.onHealthDrop -= DropHealth;
                }

            }
                
        }

    }
}
