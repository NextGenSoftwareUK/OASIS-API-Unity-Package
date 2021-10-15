using OASIS.AVATAR;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    private OASISAvatar oasisAvatar = new OASISAvatar();

    private void Start()
    {
        oasisAvatar.GetTerms((result) => Debug.Log(result));

    }
}
