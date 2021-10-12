using UnityEditor;
using UnityEngine;

namespace OASISAPI.Editor
{
    public class OASISAPIBaseManager : EditorWindow
    {
        public Texture OASIS_LOGO;
        private string[] OASIS_Version_Options = new string[] { "Live", "Staging", "DLL" };
        private int OASIS_Version_Number = 0;

        [MenuItem("OASIS/Settings")]
        private static void OASISSettings()
        {
            EditorWindow window = GetWindow<OASISAPIBaseManager>("OASIS API Settings");
            window.maxSize = new Vector2(465, 350);
            window.minSize = new Vector2(465, 350);
        }

        private void OnGUI()
        {
            GUI.DrawTexture(new Rect(0, 0, 465, 110), OASIS_LOGO);

            EditorGUILayout.Space(115);

            EditorGUILayout.BeginVertical();
            EditorStyles.label.fontStyle = FontStyle.Bold;
            EditorGUILayout.LabelField("About OASIS", GUILayout.Width(120));
            EditorStyles.label.fontStyle = FontStyle.Normal;
            EditorStyles.label.wordWrap = true;
            EditorGUILayout.LabelField("The core OASIS (Open Advanced Sensory Immersion System) API that powers Our World and manages the central profile/avatar/karma system that " +
                "other satellite apps/games plug into it and share.");
            EditorGUILayout.EndVertical();

            EditorGUILayout.Space();

            EditorGUILayout.BeginVertical();
            EditorStyles.label.fontStyle = FontStyle.Bold;
            EditorGUILayout.LabelField("OASIS API Version : ", GUILayout.Width(120));
            EditorStyles.label.fontStyle = FontStyle.Normal;
            OASIS_Version_Number = EditorGUILayout.Popup(OASIS_Version_Number, OASIS_Version_Options);
            EditorGUILayout.HelpBox(" LIVE : Stable Release \n Staging : Beta Testing \n DLL : Native DLL", MessageType.Info);
            EditorGUILayout.EndVertical();

            EditorGUILayout.Space();

            EditorGUILayout.BeginVertical();
            EditorStyles.label.fontStyle = FontStyle.Bold;
            EditorGUILayout.LabelField("Visit Us On : ");
            EditorStyles.label.fontStyle = FontStyle.Normal;
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Website", GUILayout.Width(150)))
                Application.OpenURL("https://oasisplatform.world");
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
            EditorGUILayout.EndVertical();
        }
    }
}
