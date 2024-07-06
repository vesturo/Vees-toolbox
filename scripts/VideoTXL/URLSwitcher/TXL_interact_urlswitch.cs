
using Texel;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

[UdonBehaviourSyncMode(BehaviourSyncMode.None)]
public class TXL_interact_urlswitch : UdonSharpBehaviour
{
    public SyncPlayer TXLVideoPlayer;
    public VRCUrl NewUrlPC;
    public bool QuestCompatibleWorld;
    public VRCUrl NewUrlQuest;
    public override void Interact()
    {
        if(QuestCompatibleWorld)
        {
            TXLVideoPlayer._ChangeUrl(NewUrlPC, NewUrlQuest);
        }
        else
        {
            TXLVideoPlayer._ChangeUrl(NewUrlPC);
        }
    }
}
