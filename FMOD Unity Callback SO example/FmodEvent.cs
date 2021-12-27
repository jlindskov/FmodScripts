
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class FmodEvent : MonoBehaviour
{
   
   //Small example of how to play a sound with a audio callback attached
   public static EventInstance PlayEvent(string eventName, AudioCallback callback)
   {
      var instance = RuntimeManager.CreateInstance(eventName);
      callback.beatCallback = new FMOD.Studio.EVENT_CALLBACK(callback.FMODAudioCallback);
      instance.setCallback(callback.beatCallback, callback.callbackType);
      instance.start();
      return instance;
   }
}
