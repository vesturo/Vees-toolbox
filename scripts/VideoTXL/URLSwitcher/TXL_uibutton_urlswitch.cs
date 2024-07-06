
using Texel;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class TXL_uibutton_urlswitch : UdonSharpBehaviour
{
    [Header("Call '_SwitchURL' on this component to switch the URL set below!")]
    public SyncPlayer TXLVideoPlayer;
    public VRCUrl NewUrlPC;
    public bool QuestCompatibleWorld;
    public VRCUrl NewUrlQuest;
    public void _SwitchURL()
    {
        if (QuestCompatibleWorld)
        {
            TXLVideoPlayer._ChangeUrl(NewUrlPC, NewUrlQuest);
        }
        else
        {
            TXLVideoPlayer._ChangeUrl(NewUrlPC);
        }
    }
}
