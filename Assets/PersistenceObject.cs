using UnityEngine;

public class PersistentObject : MonoBehaviour
{
    public static PersistentObject instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    public void DestroyThisWhenQuit()
    {
        Destroy(gameObject);
    }
}
