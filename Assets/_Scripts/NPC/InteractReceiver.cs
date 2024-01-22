using Core.Spawner;
using Core.UI.Text;
using UnityEngine;

namespace NPC
{
    public class InteractReceiver : Core.Interaction.InteractReceiver
    {
        [SerializeField] private string dialog = "I am NPC, id: ";

        public override void OnInteract()
        {
            this.ShowDialog();
        }

        private void ShowDialog()
        {
            DialogSpawner dialogSpawner = SpawnersCtrl.Instance.DialogSpawner;

            string prefabName = "text";
            Vector3 spawnPos = transform.position.Add(y: 2f);
            Quaternion quaternion = Quaternion.identity;    
            quaternion.eulerAngles = new Vector3(70f, 0f, 0f);

            Transform dialog = dialogSpawner.Spawn(prefabName, spawnPos, quaternion);
            dialog.gameObject.SetActive(true);

            if (!dialog.TryGetComponent(out DialogText dialogText)) return;
            dialogText.Text.text = this.dialog;
        }
    }
}