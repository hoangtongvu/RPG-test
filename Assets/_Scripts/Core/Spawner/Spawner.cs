using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Spawner
{
    public abstract class Spawner : SaiMonoBehaviour
    {

        [SerializeField] protected Transform holder;
        [SerializeField] protected int spawnedCount = 0;
        [SerializeField] protected List<Transform> prefabs;
        [SerializeField] protected List<Transform> poolObjs;


        #region LoadComponents

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadPrefabs();
            this.LoadTransformInChildrenByName(out this.holder, "Holder");
        }

        protected virtual void LoadPrefabs()
        {
            Transform prefabObj = transform.Find("Prefabs");
            foreach (Transform prefab in prefabObj) prefabs.Add(prefab);
            this.HidePrefabs();
        }

        #endregion

        protected virtual void HidePrefabs() => this.prefabs.ForEach(p => p.gameObject.SetActive(false));


        public virtual Transform Spawn(string prefabName, Vector3 spawnPos, Quaternion rotation)
        {
            Transform prefab = this.GetPrefabByName(prefabName);
            if (prefab == null)
            {
                Debug.LogWarning($"Prefab not found: {prefabName}");
                return null;
            }

            return this.Spawn(prefab, spawnPos, rotation);
        }


        public virtual Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation)
        {
            Transform newPrefab = this.GetObjectFromPool(prefab);
            newPrefab.SetPositionAndRotation(spawnPos, rotation);

            //newPrefab.parent = this.holder;
            newPrefab.SetParent(this.holder);
            this.spawnedCount++;
            return newPrefab;

        }

        protected virtual Transform GetPrefabByName(string prefabName) => this.prefabs.Find(p => p.name == prefabName);

        protected virtual Transform GetObjectFromPool(Transform prefab)
        {
            foreach (Transform poolObj in poolObjs)
            {
                if (poolObj.name == prefab.name)
                {
                    poolObjs.Remove(poolObj);
                    return poolObj;
                }
            }

            Transform newPrefab = Instantiate(prefab);
            newPrefab.name = prefab.name;
            return newPrefab;
        }

        public virtual void Despawn(Transform obj)
        {
            if (this.poolObjs.Find(p => p == obj) != null) return;
            poolObjs.Add(obj);
            obj.gameObject.SetActive(false);
            this.spawnedCount--;
        }

        public virtual Transform GetRandomPrefab()
        {
            int rand = Random.Range(0, prefabs.Count);
            return prefabs[rand];
        }


    }
}