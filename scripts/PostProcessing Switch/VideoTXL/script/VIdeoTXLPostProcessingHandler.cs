
using Texel;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

[UdonBehaviourSyncMode(BehaviourSyncMode.None)]
public class VIdeoTXLPostProcessingHandler : UdonSharpBehaviour
{
    public TXLVideoPlayer videoPlayer;
    public Animator PostProcessing;

    void Start()
    {
        videoPlayer._Register(TXLVideoPlayer.EVENT_VIDEO_STATE_UPDATE, this, nameof(_OnVideoStateUpdate));
    }

    public void _OnVideoStateUpdate()
    {
        switch (videoPlayer.playerState)
        {
            case TXLVideoPlayer.VIDEO_STATE_STOPPED:
                PostProcessing.SetBool("VideoPlaying", false);
                break;
            case TXLVideoPlayer.VIDEO_STATE_ERROR:
                PostProcessing.SetBool("VideoPlaying", false);
                break;
            case TXLVideoPlayer.VIDEO_STATE_LOADING:
                PostProcessing.SetBool("VideoPlaying", false);
                break;
            case TXLVideoPlayer.VIDEO_STATE_PLAYING:
                PostProcessing.SetBool("VideoPlaying", true);
                break;
        }
    }
}
