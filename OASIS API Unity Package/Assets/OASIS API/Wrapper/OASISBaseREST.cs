using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace OASIS.BASE_REST
{
    public static class OASISBaseREST
    {
        public static IEnumerator OnGetRequest(string finalURL, System.Action<string> callback)
        {
            using var request = UnityWebRequest.Get(finalURL);
            request.SetRequestHeader("Content-Type", "application/json");
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("success");
                callback?.Invoke(request.downloadHandler.text);
            }
            else
            {
                Debug.Log("error");
                callback?.Invoke(request.error);
            }
        }

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