using System.Collections;
using UnityEngine;


public class DespawnerByTime : BaseDespawner
{
    [SerializeField] protected float maxTimeSecond = 5f;


    private void OnEnable() => StartCoroutine(this.Despawning());

    protected override bool CanDespawn() => true;

    private IEnumerator Despawning()
    {
        yield return new WaitForSeconds(this.maxTimeSecond);
        this.DespawnObject();
    }

}
