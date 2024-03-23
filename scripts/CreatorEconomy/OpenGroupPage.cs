
using System.Security.Cryptography.X509Certificates;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Economy;

public class OpenGroupPage : UdonSharpBehaviour
{
    public string GroupIdentifier;
    public void OpenGroupPages()
    {
        Store.OpenGroupPage(GroupIdentifier);
    }
}
