using UnityEngine;

/// <summary>
/// Represents a container for object pooling.
/// </summary>
[System.Serializable]
public class ObjectPoolContainer
{
    /// <summary>
    /// Gets the name of the pool.
    /// </summary>
    public string PoolName;

    /// <summary>
    /// Gets the object to be pooled.
    /// </summary>
    public GameObject PoolObject;

    /// <summary>
    /// Initializes a new instance of the <see cref="ObjectPoolContainer"/> class.
    /// </summary>
    /// <param name="poolName">The name of the pool.</param>
    /// <param name="poolObject">The object to be pooled.</param>
    public ObjectPoolContainer(string poolName, GameObject poolObject)
    {
        PoolName = poolName;
        PoolObject = poolObject;
    }
}
