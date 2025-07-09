using UnityEngine;

public class PersistentObjects : MonoBehaviour
{
<<<<<<< Updated upstream:Assets/Scripts/Data Persistence/PersistentObjects.cs
    private static PersistentObjects instance;
=======
    public static PersistentObject instance;
>>>>>>> Stashed changes:Assets/PersistenceObject.cs

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
