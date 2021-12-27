using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using FMOD.Studio;
using UnityEngine;


[CreateAssetMenu]
public class AudioCallback : ScriptableObject
{
    private List<AudioCallbackListener> Listeners = new List<AudioCallbackListener>();
    
    public FMOD.Studio.EVENT_CALLBACK beatCallback;
    public EVENT_CALLBACK_TYPE callbackType; 
    
    [AOT.MonoPInvokeCallback(typeof(FMOD.Studio.EVENT_CALLBACK))]
   public FMOD.RESULT FMODAudioCallback(FMOD.Studio.EVENT_CALLBACK_TYPE type, IntPtr instancePtr, IntPtr parameterPtr)
   {
      switch (type)
         {
            case FMOD.Studio.EVENT_CALLBACK_TYPE.TIMELINE_BEAT:
            {
               var parameter = (FMOD.Studio.TIMELINE_BEAT_PROPERTIES)Marshal.PtrToStructure(parameterPtr, typeof(FMOD.Studio.TIMELINE_BEAT_PROPERTIES));
               //Here you could split based on certain beats or you could pass the properties onwards to the callback listeners and let them handle it. 
               Execute(); 
            }
               break;
            case FMOD.Studio.EVENT_CALLBACK_TYPE.TIMELINE_MARKER:
            {
               var parameter = (FMOD.Studio.TIMELINE_MARKER_PROPERTIES)Marshal.PtrToStructure(parameterPtr, typeof(FMOD.Studio.TIMELINE_MARKER_PROPERTIES));
               //Here you could split based on certain beats or you could pass the properties onwards to the callback listeners and let them handle it. 
               Execute();
            }
               break;
            
            //TODO: Proper implement the other callbacks
            case EVENT_CALLBACK_TYPE.CREATED:
               Execute(); 
               break;
            case EVENT_CALLBACK_TYPE.DESTROYED:
               Execute(); 
               break;
            case EVENT_CALLBACK_TYPE.STARTING:
               Execute(); 
               break;
            case EVENT_CALLBACK_TYPE.STARTED:
               Execute(); 
               break;
            case EVENT_CALLBACK_TYPE.RESTARTED:
               Execute(); 
               break;
            case EVENT_CALLBACK_TYPE.STOPPED:
               Execute(); 
               break;
            case EVENT_CALLBACK_TYPE.START_FAILED:
               Execute(); 
               break;
            case EVENT_CALLBACK_TYPE.CREATE_PROGRAMMER_SOUND:
               Execute(); 
               break;
            case EVENT_CALLBACK_TYPE.DESTROY_PROGRAMMER_SOUND:
               Execute(); 
               break;
            case EVENT_CALLBACK_TYPE.PLUGIN_CREATED:
               Execute(); 
               break;
            case EVENT_CALLBACK_TYPE.PLUGIN_DESTROYED:
               Execute(); 
               break;
            case EVENT_CALLBACK_TYPE.SOUND_PLAYED:
               Execute(); 
               break;
            case EVENT_CALLBACK_TYPE.SOUND_STOPPED:
               Execute(); 
               break;
            case EVENT_CALLBACK_TYPE.REAL_TO_VIRTUAL:
               Execute(); 
               break;
            case EVENT_CALLBACK_TYPE.VIRTUAL_TO_REAL:
               Execute(); 
               break;
            case EVENT_CALLBACK_TYPE.START_EVENT_COMMAND:
               Execute(); 
               break;
            case EVENT_CALLBACK_TYPE.NESTED_TIMELINE_BEAT:
               Execute(); 
               break;
            case EVENT_CALLBACK_TYPE.ALL:
               Execute(); 
               break;
            default:
               throw new ArgumentOutOfRangeException(nameof(type), type, null);
         }
         return FMOD.RESULT.OK;
   }

   private void Execute()
    {
        for (int i = Listeners.Count -1; i>= 0; i--)
        {
            Listeners[i].OnExecute(); 
        }
    }


    public void RegisterListener(AudioCallbackListener listener)
    {
        if (!Listeners.Contains(listener))
        {
            Listeners.Add(listener);
        }
        
    }
    
    public void UnRegisterListener(AudioCallbackListener listener)
    {
        if (Listeners.Contains(listener))
        {
            Listeners.Remove(listener); 
        }
    }


}
