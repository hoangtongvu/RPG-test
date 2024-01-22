using Core;


public abstract class BaseDespawner : SaiMonoBehaviour
{

    public virtual void DespawnObject()
    {
        transform.parent.gameObject.SetActive(false);
    }

    protected abstract bool CanDespawn();

}
