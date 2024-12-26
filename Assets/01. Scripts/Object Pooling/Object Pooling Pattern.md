# Unity Object Pooling System Documentation

## Overview
Object Pooling is a design pattern used to improve performance by reusing objects instead of creating and destroying them repeatedly. This implementation provides a robust object pooling system for Unity using the built-in ObjectPool class.

## Components

### 1. ObjectPoolContainer
A serializable class that holds the configuration for each pool:

```csharp
[System.Serializable]
public class ObjectPoolContainer
{
    public string PoolName;
    public GameObject PoolObject;

    public ObjectPoolContainer(string poolName, GameObject poolObject)
    {
        PoolName = poolName;
        PoolObject = poolObject;
    }
}
```

### 2. ObjectPoolManager
The main manager class that handles the creation and management of object pools:

```csharp
public class ObjectPoolManager : MonoBehaviour
{
    [SerializeField]
    private ObjectPoolContainer[] objectPools;
    private Dictionary<string, IObjectPool<GameObject>> poolsDictionary;
    
    // Implementation details below...
}
```

## How It Works

1. **Pool Initialization**:
   - Each pool is defined by an ObjectPoolContainer with a unique name and prefab
   - Pools are automatically initialized in Awake
   - Default capacity is 10 objects with a maximum of 100 objects per pool

2. **Pool Operations**:
   - Objects are retrieved using `GetObjectFromPool(string poolName)`
   - Objects are returned using `ReleaseObjectToPool(string poolName, GameObject obj)`
   - Active/inactive state is automatically managed

## Usage Example

1. **Setup in Inspector**:
```csharp
// Attach ObjectPoolManager to a GameObject
public class GameManager : MonoBehaviour
{
    [SerializeField] private ObjectPoolManager poolManager;
    [SerializeField] private GameObject bulletPrefab;

    void Start()
    {
        // Configure your pools in the inspector
        // Add ObjectPoolContainer with name "Bullets" and bulletPrefab
    }
}
```

2. **Spawning Objects**:
```csharp
// Get an object from the pool
GameObject bullet = poolManager.GetObjectFromPool("Bullets");
bullet.transform.position = spawnPoint.position;

// Return object to pool when done
poolManager.ReleaseObjectToPool("Bullets", bullet);
```

## Features

1. **Automatic Management**:
   - Automatic object activation/deactivation
   - Built-in capacity management
   - Error checking for non-existent pools

2. **Performance Benefits**:
   - Reduces garbage collection calls
   - Minimizes memory fragmentation
   - Improves frame rate stability

3. **Unity Integration**:
   - Uses Unity's built-in ObjectPool class
   - Serializable in Inspector
   - Compatible with Prefab system

## Best Practices

1. **Pool Sizing**:
   - Set appropriate initial capacity based on maximum expected simultaneous objects
   - Consider memory vs. performance trade-offs when setting maxSize

2. **Object Management**:
   - Always release objects back to the pool when done
   - Don't destroy pooled objects manually
   - Use pool names consistently throughout your code

3. **Performance Optimization**:
   - Cache pool references when accessing frequently
   - Initialize pools during loading screens or quiet moments
   - Consider using multiple smaller pools instead of one large pool

## Common Pitfalls to Avoid

1. **Memory Leaks**:
   - Not releasing objects back to the pool
   - Keeping references to pooled objects after release

2. **Performance Issues**:
   - Setting pool capacity too low
   - Creating new pools during gameplay
   - Excessive pool resizing

3. **Logic Errors**:
   - Using destroyed pooled objects
   - Modifying pooled objects permanently
   - Not resetting object state on reuse

## Implementation Details

The system uses Unity's built-in `ObjectPool<T>` class with the following configuration:

```csharp
new ObjectPool<GameObject>(
    createFunc: () => Instantiate(poolContainer.PoolObject),
    actionOnGet: obj => obj.SetActive(true),
    actionOnRelease: obj => obj.SetActive(false),
    actionOnDestroy: obj => Destroy(obj),
    collectionCheck: false,
    defaultCapacity: 10,
    maxSize: 100
);
```

- `createFunc`: Creates new instances when needed
- `actionOnGet`: Activates objects when retrieved
- `actionOnRelease`: Deactivates objects when released
- `actionOnDestroy`: Properly destroys objects when pool is cleared
- `collectionCheck`: Disabled for performance
- `defaultCapacity`: Initial pool size
- `maxSize`: Maximum number of objects per pool

## Notes
- Consider implementing pool expansion monitoring for optimization
- Add state reset logic for complex pooled objects
- Test pool performance under various load conditions