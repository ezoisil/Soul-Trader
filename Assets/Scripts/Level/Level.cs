using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jamination5.Level
{
   
    public class Level : MonoBehaviour
    {
        private Emitter[] emitters =null;
        private int numberOfEmitters;
        private int numberOfEntities;
        [SerializeField] float healthPoints = 20;
        
        public delegate void OnHealthDrop();
        public event OnHealthDrop onHealthDrop;
        

        // Start is called before the first frame update
        void Awake()
        {
            emitters = GetComponentsInChildren<Emitter>();
        }

        private void Start()
        {
            numberOfEmitters = emitters.Length;
        }

        void Update()
        {
            if (healthPoints <= 0)
            {
                print("U lost");
                return;
            }
            numberOfEntities = GameObject.FindGameObjectsWithTag("Entity").Length;
            if (numberOfEmitters == 0 && numberOfEntities == 0)
            {
                print("Level Complete");
            }           
            

            if (Input.GetMouseButton(0)){
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePosition2D = new Vector2(mousePosition.x, mousePosition.y);

                RaycastHit2D[] hits = Physics2D.RaycastAll(mousePosition2D, Vector2.zero);

                foreach (RaycastHit2D hit in hits)
                {
                    if (hit.collider != null && hit.collider.gameObject.tag == "Entity")
                    {
                        Destroy(hit.collider.gameObject);
                    }
                    
                }
            }
                
            
        }

        public void UpdateEmitters()
        {
            numberOfEmitters--;
        }
        
        public void DropHealthPoints()
        {
            onHealthDrop();
            healthPoints--;
        }
    }
}
