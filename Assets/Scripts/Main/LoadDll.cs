using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class LoadDll : MonoBehaviour
{
    void Start()
    {
        BetterStreamingAssets.Initialize();
        LoadGameDll();
        RunMain();
    }

    private System.Reflection.Assembly gameAss;

    private void LoadGameDll()
    {
#if !UNITY_EDITOR
        AssetBundle dllAB;
        string scriptPath = Path.Combine(Application.persistentDataPath, "script");
        if (File.Exists(scriptPath))
        {
            Debug.LogError("load script from persistentDataPath");
            dllAB = AssetBundle.LoadFromFile(scriptPath);
        }
        else
        {
            Debug.LogError("load script from StreamingAssets");
            dllAB = BetterStreamingAssets.LoadAssetBundle("script");
        }
        TextAsset dllBytes = dllAB.LoadAsset<TextAsset>("HotFix.dll.bytes");
        TextAsset pdbBytes = dllAB.LoadAsset<TextAsset>("HotFix.pdb.bytes");
        gameAss = System.Reflection.Assembly.Load(dllBytes.bytes, pdbBytes.bytes);
#else
        gameAss = AppDomain.CurrentDomain.GetAssemblies().First(assembly => assembly.GetName().Name == "HotFix");
#endif
    }

    public void RunMain()
    {
        if (gameAss == null)
        {
            UnityEngine.Debug.LogError("dll未加载");
            return;
        }
        var appType = gameAss.GetType("App");
        var mainMethod = appType.GetMethod("Main");
        mainMethod.Invoke(null, null);
    }
}
