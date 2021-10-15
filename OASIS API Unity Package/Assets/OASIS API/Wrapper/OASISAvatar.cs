using OASIS.BASE_REST;
using System;
using UnityEngine;

namespace OASIS.AVATAR
{
    public class OASISAvatar : MonoBehaviour
    {
        private const string BASE_LIVE_URL = "https://api.oasisplatform.world/";

        public void GetTerms(Action<string> callback)
        {
            StartCoroutine(OASISBaseREST.OnGetRequest(BASE_LIVE_URL + "api/avatar/GetTerms", callback));
        }
    }
}