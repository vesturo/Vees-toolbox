
using UdonSharp;
using UnityEngine;

namespace VRSL
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class Gi_updater_handler : UdonSharpBehaviour
    {
        public VRSL_GI_Function VRSL_GI_Function;
        [Range(1.0f, 30.0f)] public float Timeout;

        public void _UpdatePosition()
        {
            VRSL_GI_Function.isRunning = true;
            SendCustomEventDelayedSeconds("_ResetFunction", Timeout);
        }

        public void _ResetFunction()
        {
            VRSL_GI_Function.isRunning = false;
        }
    }
}
