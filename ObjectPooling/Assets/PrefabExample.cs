
using UnityEngine;

public class PrefabExample : PooledItem
{
    [SerializeField] private float _destroyTime;
    private float _destroyTimer;

    [SerializeField] private bool IsPooled;
    
    private void Start()
    {
        _destroyTimer = Time.time + _destroyTime;
    }

    private void Update()
    {
        if (_destroyTimer < Time.time)
            if (IsPooled) Pooled();
            else Regular();
    }

    private void Regular()
    {
        Destroy(gameObject);
    }

    private void Pooled()
    {
        ReturnToPool();
    }
}

