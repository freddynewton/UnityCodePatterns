using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    // Private static instance of the singleton class
    private static T instance;

    // Public static property to access the singleton instance
    public static T Instance
    {
        get
        {
            // If the instance is null, try to find an existing instance in the scene
            if (instance == null)
            {
                instance = FindFirstObjectByType<T>();

                // If no instance is found, create a new GameObject and add the component
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    instance = obj.AddComponent<T>();
                }
            }

            // Return the singleton instance
            return instance;
        }
    }

    // Awake is called when the script instance is being loaded
    public virtual void Awake()
    {
        // If the instance is null, set it to this instance and make it persist across scenes
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        // If an instance already exists, destroy this new instance
        else
        {
            Destroy(gameObject);
        }
    }
}