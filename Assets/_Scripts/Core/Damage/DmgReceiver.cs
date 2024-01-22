using Core.MyEvent;
using Core.Spawner;
using UnityEngine;

namespace Core.Damage
{
    [RequireComponent(typeof(Collider))]

    public class DmgReceiver : SaiMonoBehaviour
    {

        [SerializeField] protected int currentHp;
        [SerializeField] protected int maxHp = 100;
        public readonly CustomEventArg<(int currentHp, int maxHp)> onHpChangeEvent = new();
        //[SerializeField] private int def = 100;


        protected override void ResetValue()
        {
            base.ResetValue();
            this.currentHp = this.maxHp;
        }

        public void SetCurrentHp(int newValue)
        {
            if (newValue <= 0)
            {
                this.Die();
                this.onHpChangeEvent.Invoke((this.currentHp, this.maxHp));
                return;
            }
            if (newValue > this.maxHp) newValue = this.maxHp;

            this.currentHp = newValue;
            this.onHpChangeEvent.Invoke((this.currentHp, this.maxHp));
        }

        public void DeductHp(int deductAmount)
        {
            this.SetCurrentHp(this.currentHp - deductAmount);
            this.PlayOnHitEffect();
        }

        public void AddHp(int addAmount)
        {
            this.SetCurrentHp(this.currentHp + addAmount);
        }

        private void Die()
        {
            this.currentHp = 0;
            Debug.Log("You Died.");

        }

        private void PlayOnHitEffect()
        {
            Vector3 spawnPos = transform.position;
            Quaternion spawnRot = Quaternion.identity;
            Transform onHitEffect = SpawnersCtrl.Instance.PSSpawner.Spawn(PSSpawner.bloodSplashPS, spawnPos, spawnRot);
            onHitEffect.gameObject.SetActive(true);
        }


    }


}
