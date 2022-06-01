using Jamination5.Visual;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Jamination5.Core
{
    public class SceneManagement : MonoBehaviour
    {
        private bool isChangable;
        private void OnEnable()
        {
            PlayText.onEndText += MakeSceneChangable;
        }


        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && isChangable)
            {
                ChangeToNextScene();
            }

        }
        
        private void ChangeToNextScene() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        private void MakeSceneChangable()
        {
            isChangable = true;
        }

        private void OnDestroy()
        {
            PlayText.onEndText -= MakeSceneChangable;
        }
    }
}
