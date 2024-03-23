Hi, repo for things i figure out :)

i will make this properly tomorrow but for now:

## How 2 Group button:
- ### MAKE A BACKUP
- ## MAKE SURE YOUR BACKUP IS OKAY
- Update your SDK to 3.5.1 or later
- copy script
- assign script to button
- find you group ID (ex grp_0c89d633-b4e6-4359-8496-cb14ca80889b for myriad)
- put group ID in group id field :D

Code:
```csharp
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Economy;

public class GroupButton : UdonSharpBehaviour
{
    public string GroupIdentifier;
    public void OpenGroupPageButton()
    {
        Store.OpenGroupPage(GroupIdentifier);
    }
}
```

No clue how to use U#? download my Repo, copy the folder "GroupButton into your assets follow above!
* will do this tomorrow lmao


Yes itr is that easy, fuck twitter's max letter limit without blue
