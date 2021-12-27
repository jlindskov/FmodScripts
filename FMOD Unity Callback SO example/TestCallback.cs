
using FMODUnity;
using UnityEngine;

public class TestCallback : MonoBehaviour
{
    [EventRef]
    public string path;
    public AudioCallback Callback; 
    
    void Start()
    {
        FmodEvent.PlayEvent(path, Callback); 
    }


}
