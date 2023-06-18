using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

namespace OASIS_API.Example
{
    public class APIUIManager : MonoBehaviour
    {
        public TextMeshProUGUI _baseURL;
        public TMP_InputField _route;
        public TMP_InputField _inputJSON;
        public TMP_InputField _outputJSON;

        private int _currentVersion = 0;
        private int _currentRequest = 0;
        private string finalURL;

        private const string BASE_LIVE_URL = "https://api.oasisplatform.world/";
        private const string BASE_STAGING_URL = "https://www.staging.api.oasisplatform.world/";

        public void OnVersionChange(int version)
        {
            _currentVersion = version;
            if (version == 0)
                _baseURL.text = BASE_LIVE_URL;
            else if (version == 1)
                _baseURL.text = BASE_STAGING_URL;
        }

        public void OnRequestChange(int version)
        {
            _currentRequest = version;
            if (version == 0)
                _inputJSON.interactable = true;
            else if (version == 1)
                _inputJSON.interactable = false;
            else if (version == 2)
                _inputJSON.interactable = false;
        }

        public void OnSubmitButtonClicked()
        {
            finalURL = "";
            if (_currentVersion == 0)
                finalURL = BASE_LIVE_URL;
            else if (_currentVersion == 1)
                finalURL = BASE_STAGING_URL;
            finalURL += _route.text;

            if (_currentRequest == 0)
                StartCoroutine(OnPostRequest());
            else if (_currentRequest == 1)
                StartCoroutine(OnGetRequest());
            else if (_currentRequest == 2)
                StartCoroutine(OnDeleteRequest());
        }

        private IEnumerator OnGetRequest()
        {
            using var request = new UnityWebRequest(finalURL);
            request.method = UnityWebRequest.kHttpVerbGET;
            request.downloadHandler = new DownloadHandlerBuffer();
            yield return request.SendWebRequest();
            _outputJSON.text = request.downloadHandler.text;
            _outputJSON.interactable = true;
        }

        private IEnumerator OnPostRequest()
        {
            byte[] requestData = System.Text.Encoding.UTF8.GetBytes(_inputJSON.text);
            using var request = new UnityWebRequest(finalURL);
            request.method = UnityWebRequest.kHttpVerbPOST;
            request.uploadHandler = new UploadHandlerRaw(requestData);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            yield return request.SendWebRequest();
            _outputJSON.text = request.downloadHandler.text;
            _outputJSON.interactable = true;
        }

        private IEnumerator OnDeleteRequest()
        {
            yield return new WaitForEndOfFrame();
        }
    }

}