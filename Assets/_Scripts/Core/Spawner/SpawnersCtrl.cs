using UnityEngine;

namespace Core.Spawner
{
    public class SpawnersCtrl : SaiMonoBehaviour
    {
        private static SpawnersCtrl instance;

        public static SpawnersCtrl Instance
        {
            get
            {
                if (instance != null) return instance;

                instance = FindObjectOfType<SpawnersCtrl>();
                if (instance == null)
                {
                    Debug.LogError("There is no instance");
                }

                return instance;
            }
        }

        [SerializeField] private DialogSpawner dialogSpawner;
        [SerializeField] private PSSpawner psSpawner;
        [SerializeField] private HPTextSpawner hpTextSpawner;
        [SerializeField] private ItemDropSpawner itemDropSpawner;
        public DialogSpawner DialogSpawner => dialogSpawner;
        public PSSpawner PSSpawner => psSpawner;
        public HPTextSpawner HPTextSpawner => hpTextSpawner;
        public ItemDropSpawner ItemDropSpawner => itemDropSpawner;


        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadInstance();
            this.LoadComponentInChildren(ref this.dialogSpawner);
            this.LoadComponentInChildren(ref this.psSpawner);
            this.LoadComponentInChildren(ref this.hpTextSpawner);
            this.LoadComponentInChildren(ref this.itemDropSpawner);
        }

        private void LoadInstance()
        {
            if (instance != null) Destroy(gameObject);
            instance = this;
        }

    }
}