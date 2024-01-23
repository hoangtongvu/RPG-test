using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : SaiMonoBehaviour
{
    [SerializeField] private Transform hitbox;
    [SerializeField] private ParticleSystem onAttackPS;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTransformInChildrenByName(out this.hitbox, "Hitbox");
        this.LoadComponentInChildren(ref this.onAttackPS);
    }


    public void DisableWeaponCollider()
    {
        this.hitbox.gameObject.SetActive(false);
        this.onAttackPS.Stop();
    }

    public void EnableWeaponCollider()
    {
        this.hitbox.gameObject.SetActive(true);
        this.onAttackPS.Play();
    }

}
