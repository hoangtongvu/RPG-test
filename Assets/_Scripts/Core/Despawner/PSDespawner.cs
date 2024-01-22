using Core.Spawner;


public class PSDespawner : DespawnerByTime
{

    protected override void ResetValue()
    {
        base.ResetValue();
        this.maxTimeSecond = 0.6f;
    }

    public override void DespawnObject()
    {
        SpawnersCtrl.Instance.PSSpawner.Despawn(transform.parent);
    }

}