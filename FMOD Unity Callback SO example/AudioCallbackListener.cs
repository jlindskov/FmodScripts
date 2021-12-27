
using UnityEngine;
using UnityEngine.Events;

public class AudioCallbackListener : MonoBehaviour
{
    public AudioCallback Callback;
    public UnityEvent Response; 
    
    public void OnExecute()
    {
       Response.Invoke();
    }

    private void OnEnable()
    {
        Callback.RegisterListener(this);
    }

    private void OnDisable()
    {
        Callback.UnRegisterListener(this);
    }
}
