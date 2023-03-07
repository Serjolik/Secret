using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance;

    public static T Instance
    {
        get => instance;
    }

    public static bool IsInstantiated
    {
        get => instance != null;
    }

    protected virtual void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("[Singleton] Trying to instantiate a second instance of singleton class.");
        }
        else
        {
            instance = (T)this;
        }
    }

    protected void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
}