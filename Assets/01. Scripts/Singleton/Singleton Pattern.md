# Unity Singleton Pattern Documentation

## Overview
The Singleton pattern is a design pattern that ensures a class has only one instance and provides a global point of access to that instance. This implementation is specifically designed for Unity MonoBehaviour classes and includes additional features like scene persistence.

## Features
- Generic implementation that works with any MonoBehaviour
- Automatic instance creation if none exists
- Scene persistence with DontDestroyOnLoad
- Automatic cleanup of duplicate instances
- Thread-safe instance access

## Implementation
```csharp
using UnityEngine;
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindFirstObjectByType<T>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    instance = obj.AddComponent<T>();
                }
            }
            return instance;
        }
    }

    public virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
```

## Usage Example
To create a singleton class, simply inherit from the Singleton class:

```csharp
public class GameManager : Singleton<GameManager>
{
    // Your GameManager implementation
    public void StartGame()
    {
        Debug.Log("Game Started!");
    }
}
```

To access the singleton instance from anywhere in your code:

```csharp
void SomeMethod()
{
    GameManager.Instance.StartGame();
}
```

## How It Works

1. **Instance Creation**:
   - The first time you access the Instance property, it checks if an instance exists
   - If no instance exists, it searches the scene for an existing component
   - If still no instance is found, it creates a new GameObject with the component

2. **Scene Persistence**:
   - When an instance is created, `DontDestroyOnLoad` is called to make it persist between scenes
   - This ensures the singleton remains available throughout the entire game session

3. **Duplicate Prevention**:
   - If a new instance is created while one already exists, the new instance is automatically destroyed
   - This prevents multiple instances from existing simultaneously

## Best Practices

1. **Initialization**:
   - Override the `Awake` method in your derived class using the `override` keyword
   - Always call `base.Awake()` first in your override

2. **Usage**:
   - Access the singleton through the Instance property: `YourClass.Instance`
   - Avoid creating references to the Instance in Update methods
   - Consider caching the reference if you need frequent access

3. **Memory Management**:
   - Remember that singleton instances persist between scenes
   - Clean up any resources when the application quits

## Common Pitfalls

1. **Circular Dependencies**:
   - Avoid creating circular dependencies between singletons
   - Initialize dependencies in a specific order if needed

2. **Scene Loading**:
   - Be aware that the singleton persists between scenes
   - Consider resetting state when new scenes load if necessary

## Notes
- This implementation is not thread-safe for initialization
- Consider adding thread safety if needed for multi-threaded scenarios
- The singleton pattern should be used sparingly, as it can make testing and maintenance more difficult