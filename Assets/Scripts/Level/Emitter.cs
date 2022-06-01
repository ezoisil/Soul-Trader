using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jamination5.Level
{
 
    public class Emitter : MonoBehaviour
    {
        [SerializeField] GameObject[] entityPrefabs = null;
        [SerializeField] float frequency = 3.0f;
        public float range = 5.0f;
        public float startTime;
        public float lifeTime;

        private float timer;
        private Level rootLevel = null;

        private void Awake()
        {
            rootLevel = GetComponentInParent<Level>();
        }
        private void Start()
        {
            timer = frequency;
        }
        private void Update()
        {
            if (lifeTime <= 0)
            {
                DestroyEmitter();
                return;
            }
            lifeTime -= Time.deltaTime;
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                Emit();
                timer = frequency;
            }
        }
        

        private void Emit()
        {
            if (entityPrefabs == null)
                return;

            GameObject entity = Instantiate(entityPrefabs[Random.Range(0,entityPrefabs.Length-1)], GetLocation(), transform.rotation);
            entity.GetComponent<Entity>().SetEmitter(this);
        }

        private void DestroyEmitter()
        {
            rootLevel.UpdateEmitters();
            Destroy(gameObject);
        }

        private Vector2 GetLocation()
        {
            return new Vector2(Random.Range(-range, range), Random.Range(-range, range));
        }

        public Level GetRootLevel()
        {
            return rootLevel;
        }



}
}
