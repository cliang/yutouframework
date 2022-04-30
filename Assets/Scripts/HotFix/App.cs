using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityGameFramework.Runtime;
using GameFramework;
using System.Runtime.InteropServices;

public class App
{
    public static int Main()
    {

        AssetBundle dllAB = BetterStreamingAssets.LoadAssetBundle("prefab");
        GameObject testPrefab = GameObject.Instantiate(dllAB.LoadAsset<UnityEngine.GameObject>("GameFramework_start.prefab"));

        return 0;
    }
}
