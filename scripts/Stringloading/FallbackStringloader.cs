
using UdonSharp;
using UnityEngine;
using VRC.SDK3.StringLoading;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;

namespace VesOS
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class FallbackStringloader : UdonSharpBehaviour
    {
        public CoreStringloader CoreStringloader;
        public StringHandler StringHandler;
        public void TryGithubURL(VRCUrl GithubStringloaderURL)
        {
            if (CoreStringloader.EnableDebugLogging)
            {
                Debug.LogWarning("[VesOS - Fallback Stringloader] - Trying Fallback URL");
            }
            VRCStringDownloader.LoadUrl(GithubStringloaderURL, (IUdonEventReceiver)this);
        }
        public override void OnStringLoadError(IVRCStringDownload result)
        {
            if (CoreStringloader.EnableDebugLogging)
            {
                Debug.LogWarning("[VesOS - Core Stringloader] - Fallback loading failed");
            }
        }

        public override void OnStringLoadSuccess(IVRCStringDownload result)
        {
            string UdonSyncLoaderString = result.Result;
            StringHandler.LoadString(UdonSyncLoaderString);
        }
    }
}
