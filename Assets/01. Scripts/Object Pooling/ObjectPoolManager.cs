using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

/// <summary>
/// Manages object pools for efficient reuse of game objects.
/// </summary>
public class ObjectPoolManager : MonoBehaviour
{
    /// <summary>
    /// Array of object pool containers to be managed.
    /// </summary>
    [SerializeField]
    private ObjectPoolContainer[] objectPools;

    /// <summary>
    /// Dictionary to store the object pools with their names as keys.
    /// </summary>
    private Dictionary<string, IObjectPool<GameObject>> poolsDictionary = new Dictionary<string, IObjectPool<GameObject>>();

    /// <summary>
    /// Initializes the object pools.
    /// </summary>
    private void Awake()
    {
        foreach (var poolContainer in objectPools)
        {
            var pool = new ObjectPool<GameObject>(
                createFunc: () => Instantiate(poolContainer.PoolObject),
                actionOnGet: obj => obj.SetActive(true),
                actionOnRelease: obj => obj.SetActive(false),
                actionOnDestroy: obj => Destroy(obj),
                collectionCheck: false,
                defaultCapacity: 10,
                maxSize: 100
            );

            poolsDictionary.Add(poolContainer.PoolName, pool);
        }
    }

    /// <summary>
    /// Gets an object from the specified pool.
    /// </summary>
    /// <param name="poolName">The name of the pool.</param>
    /// <returns>The pooled game object.</returns>
    public GameObject GetObjectFromPool(string poolName)
    {
        if (poolsDictionary.TryGetValue(poolName, out var pool))
        {
            return pool.Get();
        }
        Debug.LogError($"Pool with name {poolName} does not exist.");
        return null;
    }

    /// <summary>
    /// Releases an object back to the specified pool.
    /// </summary>
    /// <param name="poolName">The name of the pool.</param>
    /// <param name="obj">The game object to be released.</param>
    public void ReleaseObjectToPool(string poolName, GameObject obj)
    {
        if (poolsDictionary.TryGetValue(poolName, out var pool))
        {
            pool.Release(obj);
        }
        else
        {
            Debug.LogError($"Pool with name {poolName} does not exist.");
        }
    }
}
