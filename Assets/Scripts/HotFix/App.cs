using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityGameFramework.Runtime;
using System.Runtime.InteropServices;
using System.Text;
public class App
{
    public static int Main()
    {
        try
        {
            AssetBundle dllAB;
            string prefabPath = Path.Combine(Application.persistentDataPath, "prefab");
            if (File.Exists(prefabPath))
            {
                Debug.LogError("load prefab from persistentDataPath");
                dllAB = AssetBundle.LoadFromFile(prefabPath);
            }
            else
            {
                Debug.LogError("load prefab from StreamingAssets");
                dllAB = BetterStreamingAssets.LoadAssetBundle("prefab");
            }
            GameObject testPrefab = GameObject.Instantiate(dllAB.LoadAsset<UnityEngine.GameObject>("GameFramework_start.prefab"));
        }
        catch (Exception exception)
        {
            Debug.LogError("Exception£º" + exception.ToString());
        }
        return 0;
    }

}
