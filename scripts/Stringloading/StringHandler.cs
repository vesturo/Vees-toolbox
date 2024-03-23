
using System.Collections.Generic;
using System.Data;
using UdonSharp;
using UnityEngine;
using VRC.SDK3.Data;
using VRC.SDKBase;
using VRC.Udon;

namespace VesOS
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class StringHandler : UdonSharpBehaviour
    {
        public CoreStringloader CoreStringloader;

        public void LoadString(string result)
        {
            if (CoreStringloader.EnableDebugLogging)
            {
                Debug.LogWarning("[VesOS - String Handler] - " + result);
            }
            if (VRCJson.TryDeserializeFromJson(result, out DataToken DataToken))
            {
                DataToken.DataDictionary.TryGetValue("WorldPermissionLevels", out DataToken WorldPermissionLevelsRaw);
                if (VRCJson.TrySerializeToJson(WorldPermissionLevelsRaw, JsonExportType.Beautify, out DataToken WorldPermissionLevels))
                {
                    // Use WorldPermissionLevels.ToString() to get usable data :)
                }
                else
                {
                    // Failed to serialize for some reason, running ToString on the result should tell us why.
                    Debug.Log(WorldPermissionLevels.ToString());
                }
                
            }
        }
    }
}
