using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace OASIS.BASE_REST
{
    public static class OASISBaseREST
    {
        public static IEnumerator OnGetRequest(string finalURL, System.Action<string> callback)
        {
            using var request = new UnityWebRequest(finalURL);
            request.method = UnityWebRequest.kHttpVerbGET;
            request.downloadHandler = new DownloadHandlerBuffer();
            yield return request.SendWebRequest();
            callback(request.downloadHandler.text);
        }
        /*
                public static async Task<string> OnPostRequest(string finalURL, string inputJSON)
                {
                    using var request = new UnityWebRequest(finalURL);
                    request.method = UnityWebRequest.kHttpVerbPOST;
                    request.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(inputJSON));
                    request.downloadHandler = new DownloadHandlerBuffer();
                    request.SetRequestHeader("Content-Type", "application/json");
                    yield return request.SendWebRequest();
                    callback(request.downloadHandler.text);
                }*/

        public static IEnumerator OnDeleteRequest(System.Action<string> callback)
        {
            yield return new WaitForEndOfFrame();
        }
    }
}