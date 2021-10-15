using OASIS.AVATAR;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    private OASISAvatar oasisAvatar;

    private void Start()
    {
        oasisAvatar = FindObjectOfType<OASISAvatar>();
        oasisAvatar.GetTerms((result) => Debug.Log(result));
    }
}
