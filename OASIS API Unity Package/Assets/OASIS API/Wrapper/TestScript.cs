using OASIS.AVATAR;
using OASIS.AVATAR.JSON;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    private OASISAvatar oasisAvatar;

    private void Start()
    {
        oasisAvatar = FindObjectOfType<OASISAvatar>();
        var authenticationJson = new OASISAvatarJSONInputStructs.Authenticate();
        authenticationJson.email = "prasanta.contact@gmail.com";
        authenticationJson.password = "ThisTestPass";

        oasisAvatar.DeleteAvatarByIdAndProviderType("TestID", oasisAvatar.GetCurrentProviderType(), true, (result) =>
        {
            Debug.Log(result);
        });
    }
}
