using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private PrefabExample _prefab;
    [SerializeField] private Transform _parent;
    
    [Header("Pooled")]
    
    [SerializeField] private bool IsPooled;
    [SerializeField] private int _spawnCount;

    [Header("Speed")] 
    
    [SerializeField] private float _spawnCooldown;
    private float _cooldownTimer;
    
    private Pool<PrefabExample> _prefabPool;
    private void Start()
    {
        if (IsPooled) _prefabPool = new Pool<PrefabExample>(_prefab, _spawnCount, _parent);
    }

    private void Update()
    {
        if (_cooldownTimer > Time.time) return;
        
        _cooldownTimer = Time.time + _spawnCooldown;

        if (IsPooled)
            _prefabPool.TryInstantiate(out var prefab, Vector3.zero, Quaternion.identity);
        else
            Instantiate(_prefab, _parent);
    }
}
