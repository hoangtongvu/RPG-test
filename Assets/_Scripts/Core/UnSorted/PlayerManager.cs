using UnityEngine;

namespace Core
{
    public class PlayerManager : SaiMonoBehaviour
    {
        [SerializeField] private static PlayerManager instance;

        public static PlayerManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<PlayerManager>();
                    if (instance == null)
                    {
                        Debug.LogError("There is no instance");
                    }
                }

                return instance;
            }
        }


        [SerializeField] private Player.Ctrl playerCtrl;

        public Player.Ctrl PlayerCtrl => playerCtrl;

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadPlayerCtrl();
        }

        private void LoadPlayerCtrl()
        {
            this.playerCtrl = FindObjectOfType<Player.Ctrl>();
        }
    }
}