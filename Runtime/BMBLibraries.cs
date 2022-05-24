using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;

namespace BMBLibraries
{
#if UNITY_EDITOR
    [InitializeOnLoad]
    public class BMBLibraries : Editor
    {
        // Symbols to add.
        public static readonly string[] Symbols = new string[] {
             "BMB_LIBRARIES",
         };

        // Adds the symbols to compilation.
        static BMBLibraries()
        {
            // Get list of symbols.
            string symbolsStr = PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup);
            List<string> symbols = symbolsStr.Split(';').ToList();

            // Add our symbols.
            symbols.AddRange(Symbols.Except(symbols));

            // Reassign symbols list to the player.
            PlayerSettings.SetScriptingDefineSymbolsForGroup(
                EditorUserBuildSettings.selectedBuildTargetGroup,
                string.Join(";", symbols.ToArray()));
        }
    }
#endif
}