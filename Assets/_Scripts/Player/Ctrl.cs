using Core.Animator;
using Core.Interaction;
using UnityEngine;

namespace Player
{
    public class Ctrl : Core.Entity.Ctrl
    {
        [SerializeField] private Movement movement;
        [SerializeField] private PlayerJumping playerJumping;
        [SerializeField] private InteractSender interactSender;
        [SerializeField] private BaseAnimator baseAnimator;
        [SerializeField] private WeaponHolder weaponHolder;
        [SerializeField] private AttackHandler attackHandler;

        public Movement Movement => movement;
        public PlayerJumping PlayerJumping => playerJumping;
        public InteractSender InteractSender => interactSender;
        public BaseAnimator BaseAnimator => baseAnimator;
        public WeaponHolder WeaponHolder => weaponHolder;
        public AttackHandler AttackHandler => attackHandler;


        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadComponentInChildren(ref this.movement);
            this.LoadComponentInChildren(ref this.playerJumping);
            this.LoadComponentInChildren(ref this.interactSender);
            this.LoadComponentInChildren(ref this.baseAnimator);
            this.LoadComponentInChildren(ref this.weaponHolder);
            this.LoadComponentInChildren(ref this.attackHandler);
        }
    }
}
