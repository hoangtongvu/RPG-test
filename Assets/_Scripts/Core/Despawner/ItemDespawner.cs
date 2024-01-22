using Core.Spawner;


public class ItemDespawner : DespawnerByDepth
{


    public override void DespawnObject()
    {
        SpawnersCtrl.Instance.ItemDropSpawner.Despawn(transform.parent);
    }

}
