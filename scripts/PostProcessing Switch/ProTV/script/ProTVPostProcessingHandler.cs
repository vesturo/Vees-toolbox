
using ArchiTech.ProTV;
using Texel;
using UdonSharp;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Video;
using VRC.SDKBase;
using VRC.Udon;

namespace ArchiTech.ProTV
{
    public enum CustomPlayerState { STOPPED, PAUSED, ERROR, PLAYING }
    public class ProTVPostProcessingHandler : TVPlugin
    {
        [HideInInspector] public CustomPlayerState playerState;
        public Animator PostProcessing;
        public override void Start()
        {
            if (init) return; // prevent start from being called accidentally more than once.
            base.Start(); // sets up all the TV stuff.
        }

        public override void _TvStop()
        {
            playerState = CustomPlayerState.STOPPED;
            SetState(playerState);
        }
        public override void _TvPlay()
        {
            playerState = CustomPlayerState.PLAYING;
            SetState(playerState);
        }
        public override void _TvPause()
        {
            playerState = CustomPlayerState.PAUSED;
            SetState(playerState);
        }
        public override void _TvVideoPlayerError()
        {
            playerState = CustomPlayerState.ERROR;
            SetState(playerState);
        }
        public void SetState(CustomPlayerState playerState)
        {
            switch (playerState)
            {
                case CustomPlayerState.STOPPED:
                    if (IsDebugEnabled) Debug($"Current Playerstate is {playerState}");
                    PostProcessing.SetBool("VideoPlaying", false);
                    break;
                case CustomPlayerState.PAUSED:
                    if (IsDebugEnabled) Debug($"Current Playerstate is {playerState}");
                    PostProcessing.SetBool("VideoPlaying", false);
                    break;
                case CustomPlayerState.ERROR:
                    if (IsDebugEnabled) Debug($"Current Playerstate is {playerState}");
                    PostProcessing.SetBool("VideoPlaying", false);
                    break;
                case CustomPlayerState.PLAYING:
                    if (IsDebugEnabled) Debug($"Current Playerstate is {playerState}");
                    PostProcessing.SetBool("VideoPlaying", true);
                    break;
            }
        }
    }
}