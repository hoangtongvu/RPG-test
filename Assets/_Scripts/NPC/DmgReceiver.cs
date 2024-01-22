using Core.Spawner;
using Core.UI.Text;
using UnityEngine;


namespace NPC
{

    public class DmgReceiver : Core.Damage.DmgReceiver
    {
        [SerializeField] private HPText hpText;


        private void OnEnable()
        {
            this.SpawnHPText();
            this.SubTextToEvent();
        }

        private void OnDisable()
        {
            //DesSpawn HP text.
        }

        private void SpawnHPText()
        {
            const string prefabName = "text";
            Vector3 spawnPos = transform.parent.position;
            Quaternion quaternion = Quaternion.identity;
            quaternion.eulerAngles = new Vector3(70f, 0f, 0f);

            Transform prefab = SpawnersCtrl.Instance.HPTextSpawner.Spawn(prefabName, spawnPos, quaternion);
            prefab.gameObject.SetActive(true);

            this.hpText = prefab.GetComponent<HPText>();

            if (hpText == null)
            {
                Debug.LogError("NULL hp text NPC");
                return;
            }

            this.hpText.SetTarget(transform.parent);

            this.hpText.SetHP((this.currentHp, this.maxHp));

        }

        private void SubTextToEvent() => this.onHpChangeEvent.AddListener(this.hpText.SetHP);


    }


}
