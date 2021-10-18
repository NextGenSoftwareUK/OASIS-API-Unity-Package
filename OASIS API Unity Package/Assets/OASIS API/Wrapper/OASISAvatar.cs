using OASIS.AVATAR.JSON;
using OASIS.BASE_REST;
using System;
using UnityEditor;
using UnityEngine;

namespace OASIS.AVATAR
{
    public class OASISAvatar : MonoBehaviour
    {
        public int currentAPIVersion;
        private const string BASE_LIVE_URL = "https://api.oasisplatform.world/";
        private const string BASE_STAGING_URL = "https://www.staging.api.oasisplatform.world/";
        private string[] OASIS_Provider_Options = new string[] { "Default", "HoloOASIS", "EOSIOOASIS", "EthereumOASIS", "SolanaOASIS", "MongoDBOASIS", "SQLiteOASIS", "Neo4jOASIS", "ActivityPubOASIS", "ThreefoldOASIS" };

        private string GetBaseURL()
        {
            if (EditorPrefs.GetInt("OASISVersion") == 0)
                return BASE_LIVE_URL;
            else if (EditorPrefs.GetInt("OASISVersion") == 1)
                return BASE_STAGING_URL;
            else
                return "DLL";
        }
        public string GetCurrentProviderType()
        {
            return OASIS_Provider_Options[EditorPrefs.GetInt("OASISProviderType")];
        }

        //Get without Authorization
        public void GetTerms(Action<string> callback) => StartCoroutine(OASISBaseREST.OnGetRequest(GetBaseURL() + "api/avatar/GetTerms", callback));
        public void GetAvatarImageById(string id, Action<string> callback) => StartCoroutine(OASISBaseREST.OnGetRequest(GetBaseURL() + "api/avatar/GetAvatarImage/" + id, callback));
        public void GetAvatarImageByUsername(string username, Action<string> callback) => StartCoroutine(OASISBaseREST.OnGetRequest(GetBaseURL() + "api/avatar/GetAvatarImageByUsername/" + username, callback));
        public void GetAvatarImageByEmail(string email, Action<string> callback) => StartCoroutine(OASISBaseREST.OnGetRequest(GetBaseURL() + "api/avatar/GetAvatarImageByEmail/" + email, callback));
        public void GetAvatarDetailById(string id, Action<string> callback) => StartCoroutine(OASISBaseREST.OnGetRequest(GetBaseURL() + "api/avatar/GetAvatarDetail/" + id, callback));
        public void GetAvatarDetailByUsername(string username, Action<string> callback) => StartCoroutine(OASISBaseREST.OnGetRequest(GetBaseURL() + "api/avatar/GetAvatarDetailByUsername/" + username, callback));
        public void GetAvatarDetailByEmail(string email, Action<string> callback) => StartCoroutine(OASISBaseREST.OnGetRequest(GetBaseURL() + "api/avatar/GetAvatarDetailByEmail/" + email, callback));
        public void GetAllAvatarDetails(Action<string> callback) => StartCoroutine(OASISBaseREST.OnGetRequest(GetBaseURL() + "api/avatar/GetAllAvatarDetails", callback));
        public void GetAll(Action<string> callback) => StartCoroutine(OASISBaseREST.OnGetRequest(GetBaseURL() + "api/avatar/GetAll", callback));
        public void GetAllByProdiverType(string providerType, Action<string> callback) => StartCoroutine(OASISBaseREST.OnGetRequest(GetBaseURL() + "api/avatar/GetAll/" + providerType, callback));
        public void GetById(string id, Action<string> callback) => StartCoroutine(OASISBaseREST.OnGetRequest(GetBaseURL() + "api/avatar/GetById/" + id, callback));
        public void GetByUsername(string username, Action<string> callback) => StartCoroutine(OASISBaseREST.OnGetRequest(GetBaseURL() + "api/avatar/GetByUsername/" + username, callback));
        public void GetByEmail(string email, Action<string> callback) => StartCoroutine(OASISBaseREST.OnGetRequest(GetBaseURL() + "api/avatar/GetByEmail/" + email, callback));
        public void GetByIdAndProviderType(string id, string providerType, bool setGlobally, Action<string> callback) => StartCoroutine(OASISBaseREST.OnGetRequest(GetBaseURL() + "api/avatar/GetById/" + id + "/" + providerType + "/" + setGlobally, callback));
        public void Search(string searchParams, Action<string> callback) => StartCoroutine(OASISBaseREST.OnGetRequest(GetBaseURL() + "api/avatar/Search/" + searchParams, callback));
        public void SearchByProviderType(string searchParams, string providerType, bool setGlobally, Action<string> callback) => StartCoroutine(OASISBaseREST.OnGetRequest(GetBaseURL() + "api/avatar/Search/" + searchParams + "/" + providerType + "/" + setGlobally, callback));
        public void GetUMAJsonById(string id, Action<string> callback) => StartCoroutine(OASISBaseREST.OnGetRequest(GetBaseURL() + "api/avatar/GetUMAJsonById/" + id, callback));
        public void GetUMAJsonByUsername(string username, Action<string> callback) => StartCoroutine(OASISBaseREST.OnGetRequest(GetBaseURL() + "api/avatar/GetUMAJsonByUsername/" + username, callback));
        public void GetUMAJsonByEmail(string email, Action<string> callback) => StartCoroutine(OASISBaseREST.OnGetRequest(GetBaseURL() + "api/avatar/GetUMAJsonByMail/" + email, callback));

        //Get with Authorization
        public void GetAvatarByJwt(string jwt, Action<string> callback) => StartCoroutine(OASISBaseREST.OnGetRequest(GetBaseURL() + "api/avatar/GetAvatarByJwt", callback, jwt));

        //Post with JSON Inputs
        public void Upload2DAvatarImage(OASISAvatarJSONInputStructs.Upload2DAvatarImage upload, Action<string> callback) => StartCoroutine(OASISBaseREST.OnPostRequest(GetBaseURL() + "api/avatar/verify-email", JsonUtility.ToJson(upload), callback));
        public void Authenticate(OASISAvatarJSONInputStructs.Authenticate upload, Action<string> callback) => StartCoroutine(OASISBaseREST.OnPostRequest(GetBaseURL() + "api/avatar/authenticate", JsonUtility.ToJson(upload), callback));
        public void AuthenticateByProvideType(OASISAvatarJSONInputStructs.Authenticate upload, string providerType, bool setGlobally, Action<string> callback) => StartCoroutine(OASISBaseREST.OnPostRequest(GetBaseURL() + "api/avatar/authenticate/" + providerType + "/" + setGlobally, JsonUtility.ToJson(upload), callback));
        public void Register(OASISAvatarJSONInputStructs.Register upload, Action<string> callback) => StartCoroutine(OASISBaseREST.OnPostRequest(GetBaseURL() + "api/avatar/register", JsonUtility.ToJson(upload), callback));
        public void RegisterByProviderType(OASISAvatarJSONInputStructs.Register upload, string providerType, bool setGlobally, Action<string> callback) => StartCoroutine(OASISBaseREST.OnPostRequest(GetBaseURL() + "api/avatar/register/" + providerType + "/" + setGlobally, JsonUtility.ToJson(upload), callback));
        public void VerifyEmail(OASISAvatarJSONInputStructs.VerifyEmail upload, Action<string> callback) => StartCoroutine(OASISBaseREST.OnPostRequest(GetBaseURL() + "api/avatar/verify-email", JsonUtility.ToJson(upload), callback));
        public void VerifyEmailByProviderType(OASISAvatarJSONInputStructs.VerifyEmail upload, string providerType, bool setGlobally, Action<string> callback) => StartCoroutine(OASISBaseREST.OnPostRequest(GetBaseURL() + "api/avatar/verify-email/" + providerType + "/" + setGlobally, JsonUtility.ToJson(upload), callback));
        public void ForgetPassword(OASISAvatarJSONInputStructs.ForgetPassword upload, Action<string> callback) => StartCoroutine(OASISBaseREST.OnPostRequest(GetBaseURL() + "api/avatar/forgot-password", JsonUtility.ToJson(upload), callback));
        public void ForgetPasswordByProviderType(OASISAvatarJSONInputStructs.ForgetPassword upload, string providerType, bool setGlobally, Action<string> callback) => StartCoroutine(OASISBaseREST.OnPostRequest(GetBaseURL() + "api/avatar/forgot-password/" + providerType + "/" + setGlobally, JsonUtility.ToJson(upload), callback));
        public void ValidateResetToken(OASISAvatarJSONInputStructs.ValidateResetToken upload, Action<string> callback) => StartCoroutine(OASISBaseREST.OnPostRequest(GetBaseURL() + "api/avatar/validate-reset-token", JsonUtility.ToJson(upload), callback));
        public void ResetPassword(OASISAvatarJSONInputStructs.ResetPassword upload, Action<string> callback) => StartCoroutine(OASISBaseREST.OnPostRequest(GetBaseURL() + "api/avatar/reset-password", JsonUtility.ToJson(upload), callback));
        public void ResetPasswordByProviderType(OASISAvatarJSONInputStructs.ResetPassword upload, string providerType, bool setGlobally, Action<string> callback) => StartCoroutine(OASISBaseREST.OnPostRequest(GetBaseURL() + "api/avatar/reset-password/" + providerType + "/" + setGlobally, JsonUtility.ToJson(upload), callback));
        public void CreateModel(OASISAvatarJSONInputStructs.CreateModel upload, string model, Action<string> callback) => StartCoroutine(OASISBaseREST.OnPostRequest(GetBaseURL() + "api/avatar/Create/" + model, JsonUtility.ToJson(upload), callback));
        public void CreateModelByProviderType(OASISAvatarJSONInputStructs.CreateModel upload, string model, string providerType, bool setGlobally, Action<string> callback) => StartCoroutine(OASISBaseREST.OnPostRequest(GetBaseURL() + "api/avatar/Create/" + model + "/" + providerType + "/" + setGlobally, JsonUtility.ToJson(upload), callback));
        public void AddKarmaToAvatar(OASISAvatarJSONInputStructs.AddKarmaToAvatar upload, string avatarId, Action<string> callback) => StartCoroutine(OASISBaseREST.OnPostRequest(GetBaseURL() + "api/avatar/AddKarmaToAvatar/" + avatarId, JsonUtility.ToJson(upload), callback));
        public void AddKarmaToAvatarByProviderType(OASISAvatarJSONInputStructs.AddKarmaToAvatar upload, string avatarId, string providerType, bool setGlobally, Action<string> callback) => StartCoroutine(OASISBaseREST.OnPostRequest(GetBaseURL() + "api/avatar/AddKarmaToAvatar/" + avatarId + "/" + providerType + "/" + setGlobally, JsonUtility.ToJson(upload), callback));
        public void RemoveKarmaFromAvatar(OASISAvatarJSONInputStructs.RemoveKarmaFromAvatar upload, string avatarId, Action<string> callback) => StartCoroutine(OASISBaseREST.OnPostRequest(GetBaseURL() + "api/avatar/RemoveKarmaFromAvatar/" + avatarId, JsonUtility.ToJson(upload), callback));
        public void RemoveKarmaFromAvatarByProviderType(OASISAvatarJSONInputStructs.RemoveKarmaFromAvatar upload, string avatarId, string providerType, bool setGlobally, Action<string> callback) => StartCoroutine(OASISBaseREST.OnPostRequest(GetBaseURL() + "api/avatar/RemoveKarmaFromAvatar/" + avatarId + "/" + providerType + "/" + setGlobally, JsonUtility.ToJson(upload), callback));
        public void UpdateAvatarById(OASISAvatarJSONInputStructs.UpdateAvatar upload, string id, Action<string> callback) => StartCoroutine(OASISBaseREST.OnPostRequest(GetBaseURL() + "api/avatar/Update/" + id, JsonUtility.ToJson(upload), callback));
        public void UpdateAvatarByEmail(OASISAvatarJSONInputStructs.UpdateAvatar upload, string email, Action<string> callback) => StartCoroutine(OASISBaseREST.OnPostRequest(GetBaseURL() + "api/avatar/Update/" + email, JsonUtility.ToJson(upload), callback));
        public void UpdateAvatarByUsername(OASISAvatarJSONInputStructs.UpdateAvatar upload, string username, Action<string> callback) => StartCoroutine(OASISBaseREST.OnPostRequest(GetBaseURL() + "api/avatar/Update/" + username, JsonUtility.ToJson(upload), callback));
        public void UpdateAvatarByIdAndProviderType(OASISAvatarJSONInputStructs.UpdateAvatar upload, string id, string providerType, bool setGlobally, Action<string> callback) => StartCoroutine(OASISBaseREST.OnPostRequest(GetBaseURL() + "api/avatar/Update/" + id + "/" + providerType + "/" + setGlobally, JsonUtility.ToJson(upload), callback));

        //Post without JSON Inputs
        public void AuthenticateToken(string token, Action<string> callback) => StartCoroutine(OASISBaseREST.OnPostRequestWithoutInput(GetBaseURL() + "api/avatar/AuthenticateToken/" + token, callback));
        public void RefreshToken(Action<string> callback) => StartCoroutine(OASISBaseREST.OnPostRequestWithoutInput(GetBaseURL() + "api/avatar/refresh-token", callback));
        public void RefreshTokenByProviderType(string providerType, bool setGlobally, Action<string> callback) => StartCoroutine(OASISBaseREST.OnPostRequestWithoutInput(GetBaseURL() + "api/avatar/refresh-token/" + providerType + "/" + setGlobally, callback));
        public void RevokeToken(Action<string> callback) => StartCoroutine(OASISBaseREST.OnPostRequestWithoutInput(GetBaseURL() + "api/avatar/revoke-token", callback));
        public void RevokeTokenByProviderType(string providerType, bool setGlobally, Action<string> callback) => StartCoroutine(OASISBaseREST.OnPostRequestWithoutInput(GetBaseURL() + "api/avatar/revoke-token/" + providerType + "/" + setGlobally, callback));

        //Delete
        public void DeleteAvatarById(string id, Action<string> callback) => StartCoroutine(OASISBaseREST.OnDeleteRequest(GetBaseURL() + "api/avatar/" + id, callback));
        public void DeleteAvatarByEmail(string email, Action<string> callback) => StartCoroutine(OASISBaseREST.OnDeleteRequest(GetBaseURL() + "api/avatar/DeleteByEmail/" + email, callback));
        public void DeleteAvatarByUsername(string username, Action<string> callback) => StartCoroutine(OASISBaseREST.OnDeleteRequest(GetBaseURL() + "api/avatar/DeleteByUsername/" + username, callback));
        public void DeleteAvatarByIdAndProviderType(string id, string providerType, bool setGlobally, Action<string> callback) => StartCoroutine(OASISBaseREST.OnDeleteRequest(GetBaseURL() + "api/avatar/" + id + "/" + providerType + "/" + setGlobally, callback));
    }
}