using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace OASIS.BASE_REST
{
    public static class OASISBaseREST
    {
        public static IEnumerator OnGetRequest(string finalURL, System.Action<string> callback, string authenticationToken = null)
        {
            using var request = UnityWebRequest.Get(finalURL);
            request.method = UnityWebRequest.kHttpVerbGET;
            request.SetRequestHeader("Content-Type", "application/json");
            if (authenticationToken != null)
                request.SetRequestHeader("Authorization", authenticationToken);
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
                callback?.Invoke(request.downloadHandler.text);
            else
                callback?.Invoke(request.error);
        }

        public static IEnumerator OnPostRequest(string finalURL, string inputJSON, System.Action<string> callback)
        {
            using var request = new UnityWebRequest(finalURL);
            request.method = UnityWebRequest.kHttpVerbPOST;
            request.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(inputJSON));
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
                callback?.Invoke(request.downloadHandler.text);
            else
                callback?.Invoke(request.error);
        }

        public static IEnumerator OnPostRequestWithoutInput(string finalURL, System.Action<string> callback)
        {
            using var request = new UnityWebRequest(finalURL);
            request.method = UnityWebRequest.kHttpVerbPOST;
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
                callback?.Invoke(request.downloadHandler.text);
            else
                callback?.Invoke(request.error);
        }

        public static IEnumerator OnDeleteRequest(string finalURL, System.Action<string> callback)
        {
            Debug.Log(finalURL);
            using var request = UnityWebRequest.Get(finalURL);
            request.method = UnityWebRequest.kHttpVerbDELETE;
            request.SetRequestHeader("Content-Type", "application/json");
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
                callback?.Invoke(request.downloadHandler.text);
            else
                callback?.Invoke(request.error);
        }
    }
}