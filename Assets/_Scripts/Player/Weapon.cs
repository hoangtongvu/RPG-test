using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : SaiMonoBehaviour
{
    [SerializeField] private Transform hitbox;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTransformInChildrenByName(out this.hitbox, "Hitbox");
    }


    public void DisableWeaponCollider()
    {
        this.hitbox.gameObject.SetActive(false);
    }

    public void EnableWeaponCollider()
    {
        this.hitbox.gameObject.SetActive(true);
    }

}
