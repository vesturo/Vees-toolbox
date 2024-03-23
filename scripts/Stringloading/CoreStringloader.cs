
using UdonSharp;
using UnityEngine;
using VRC.SDK3.StringLoading;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;

namespace VesOS
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class CoreStringloader : UdonSharpBehaviour
    {
        public bool EnableGithubFallback;
        public bool EnableDebugLogging;
        public float RefreshRate;
        [Header("Stringloader")]
        public VRCUrl UntrustedStringloaderURL;
        public VRCUrl GithubStringloaderURL;

        [Space(32)]
        public FallbackStringloader FallbackStringloader;
        public StringHandler StringHandler;
        void Start()
        {
            if (EnableDebugLogging) { 
                Debug.LogWarning("[VesOS - Core Stringloader] - Starting Loader"); 
            }
            TryUntrustedURL();
        }
        public void TryUntrustedURL()
        {
            if (EnableDebugLogging)
            {
                Debug.LogWarning("[VesOS - Core Stringloader] - Trying Untrusted URL");
            }
            VRCStringDownloader.LoadUrl(UntrustedStringloaderURL, (IUdonEventReceiver)this);
            SendCustomEventDelayedSeconds("TryUntrustedURL", RefreshRate);
        }
        public override void OnStringLoadError(IVRCStringDownload result)
        {
            if (EnableDebugLogging)
            {
                Debug.LogWarning("[VesOS - Core Stringloader] - Switching To Fallback Stringloader");
            }
            FallbackStringloader.TryGithubURL(GithubStringloaderURL);
        }

        public override void OnStringLoadSuccess(IVRCStringDownload result)
        {
            string UdonSyncLoaderString = result.Result;
            StringHandler.LoadString(UdonSyncLoaderString);
        }
    }
}
