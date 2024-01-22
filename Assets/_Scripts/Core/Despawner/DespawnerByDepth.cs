using UnityEngine;


public class DespawnerByDepth : BaseDespawner
{
    [SerializeField] float maxDepth = -17f;

    private void FixedUpdate()
    {
        if (!this.CanDespawn()) return;
        this.DespawnObject();
    }

    protected override bool CanDespawn()
    {
        float currentDepth = this.transform.parent.position.y;
        return currentDepth <= this.maxDepth;
    }


}
