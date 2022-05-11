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
            GameObject testPrefab = GameObject.Instantiate(dllAB.LoadAsset<UnityEngine.GameObject>("GameFramework.prefab"));
        }
        catch (Exception exception)
        {
            Debug.LogError("Exception£º" + exception.ToString());
        }

        //var stacktrace = new StackTrace();
        //string info = "trace back:\n";
        //for (var i = 0; i < stacktrace.FrameCount; i++)
        //{
        //    var method = stacktrace.GetFrame(i).GetMethod();
        //    info += "\t" + method.ReflectedType.FullName + "." + method.Name + "\n";
        //}

        return 0;
    }

}
