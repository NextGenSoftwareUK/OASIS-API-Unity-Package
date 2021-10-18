using UnityEditor;
using UnityEngine;

namespace OASISAPI.Editor
{
    [CustomEditor(typeof(OASIS.BASE_REST.OASISBaseREST))]
    public class OASISAPIBaseManager : EditorWindow
    {
        public Texture OASIS_LOGO;

        private string LiveOASISVersion = "vX.X";
        private string StagingOASISVersion = "vX.X";
        private string[] OASIS_Version_Options = new string[] { "Live", "Staging", "DLL" };
        private string[] OASIS_Provider_Options = new string[] { "Default", "HoloOASIS", "EOSIOOASIS", "EthereumOASIS", "SolanaOASIS", "MongoDBOASIS", "SQLiteOASIS", "Neo4jOASIS", "ActivityPubOASIS", "ThreefoldOASIS" };

        [MenuItem("OASIS/Settings")]
        private static void OASISSettings()
        {
            EditorWindow window = GetWindow<OASISAPIBaseManager>("OASIS API Settings");
            window.maxSize = new Vector2(462, 540);
            window.minSize = new Vector2(462, 540);
        }

        public void OnGUI()
        {
            GUI.DrawTexture(new Rect(0, 0, 462, 110), OASIS_LOGO);

            EditorGUILayout.Space(115);

            EditorGUILayout.BeginVertical();
            EditorGUILayout.BeginHorizontal();
            EditorStyles.label.fontStyle = FontStyle.Bold;
            EditorGUILayout.LabelField("About OASIS", GUILayout.Width(120));
            EditorStyles.label.fontStyle = FontStyle.Normal;
            EditorGUILayout.EndHorizontal();
            EditorStyles.label.wordWrap = true;
            EditorGUILayout.LabelField("The core OASIS (Open Advanced Sensory Immersion System) API that powers Our World and manages the central profile/avatar/karma system that " +
                "other satellite apps/games plug into it and share.");
            EditorGUILayout.EndVertical();

            EditorGUILayout.Space();

            EditorGUILayout.BeginVertical();
            EditorStyles.label.fontStyle = FontStyle.Bold;
            EditorGUILayout.LabelField("OASIS API Version : ", GUILayout.Width(120));
            EditorStyles.label.fontStyle = FontStyle.Normal;
            EditorPrefs.SetInt("OASISVersion", EditorGUILayout.Popup(EditorPrefs.GetInt("OASISVersion", 0), OASIS_Version_Options));
            EditorGUILayout.HelpBox($" LIVE : Stable Release ({LiveOASISVersion})\n Staging : Beta Testing ({StagingOASISVersion})\n DLL : Native DLL", MessageType.Info);
            EditorGUILayout.EndVertical();

            EditorGUILayout.Space();

            EditorGUILayout.BeginVertical();
            EditorStyles.label.fontStyle = FontStyle.Bold;
            EditorGUILayout.LabelField("OASIS Provider Type : ", GUILayout.Width(200));
            EditorStyles.label.fontStyle = FontStyle.Normal;
            EditorPrefs.SetInt("OASISProviderType", EditorGUILayout.Popup(EditorPrefs.GetInt("OASISProviderType", 0), OASIS_Provider_Options));
            EditorGUILayout.HelpBox($" Default : The Fastest Provider that can be connected to)\n" +
                                    $" HoloOASIS : The Holochain Provider for OASIS)\n" +
                                    $" EOSIOOASIS : The EOSIO Provider for OASIS)\n" +
                                    $" EthereumOASIS : The Ethereum Provider for OASIS\n" +
                                    $" SolanaOASIS : The Solana Provider for OASIS\n" +
                                    $" MongoDBOASIS : The MongoDB Provider for OASIS\n" +
                                    $" SQLiteOASIS : The SQLite Provider for OASIS\n" +
                                    $" Neo4jOASIS : The Neo4j Provider for OASIS\n" +
                                    $" ActivityPubOASIS : The ActivityPub Provider for OASIS\n" +
                                    $" ThreefoldOASIS : The Threefold Provider for OASIS"
                                    , MessageType.Info);

            EditorGUILayout.EndVertical();

            EditorGUILayout.Space();

            EditorGUILayout.BeginVertical();
            EditorStyles.label.fontStyle = FontStyle.Bold;
            EditorGUILayout.LabelField("Visit Us On : ");
            EditorStyles.label.fontStyle = FontStyle.Normal;
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("OASIS Release History", GUILayout.Width(150)))
                Application.OpenURL("https://github.com/NextGenSoftwareUK/Our-World-OASIS-API-HoloNET-HoloUnity-And-.NET-HDK/blob/master/NextGenSoftware.OASIS.API.ONODE.WebAPI/OASIS%20API%20RELEASE%20HISTORY.txt");
            if (GUILayout.Button("Facebook", GUILayout.Width(150)))
                Application.OpenURL("http://www.facebook.com/ourworldthegame");
            if (GUILayout.Button("Twitter", GUILayout.Width(150)))
                Application.OpenURL("http://www.twitter.com/ourworldthegame");
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Discord", GUILayout.Width(150)))
                Application.OpenURL("https://discord.gg/WQxaNQUTxv");
            if (GUILayout.Button("GitHub", GUILayout.Width(150)))
                Application.OpenURL("https://github.com/NextGenSoftwareUK/Our-World-OASIS-API-HoloNET-HoloUnity-And-.NET-HDK");
            if (GUILayout.Button("Swagger", GUILayout.Width(150)))
                Application.OpenURL("https://api.oasisplatform.world");
            EditorGUILayout.EndHorizontal();
            if (GUILayout.Button("Website", GUILayout.Width(456)))
                Application.OpenURL("https://oasisplatform.world");
            EditorGUILayout.EndVertical();
        }
    }
}
