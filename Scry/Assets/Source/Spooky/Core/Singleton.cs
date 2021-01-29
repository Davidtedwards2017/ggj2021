using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance { get; set; }
    public bool IsPresistant = true;
    
    //Returns the instance of this singleton.
    public static T Instance
    {
        get
        {
            //if (instance == null)
            //{
            //    instance = (T)FindObjectOfType(typeof(T));
            //
            //    if (instance == null)
            //    {
            //        Debug.LogError("An instance of " + typeof(T) +
            //           " is needed in the scene, but there is none.");
            //    }
            //}

            return instance;
        }
    }

    protected virtual void Awake()
    {
        if (!instance)
        {
            instance = this as T;
        }
        else
        {
            Destroy(gameObject);
        }

        if (IsPresistant)
        {
            DontDestroyOnLoad(transform.root.gameObject);
        }
    }

}
