﻿using UnityEngine;
using UnityEditor;
using System.IO;

public class CreateAssetBundles {
    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles() {
        // string assetBundleDirectory = Application.streamingAssetsPath;
        if(!Directory.Exists(Application.streamingAssetsPath)) {
            Directory.CreateDirectory(Application.streamingAssetsPath);
        }
        BuildPipeline.BuildAssetBundles(Application.streamingAssetsPath, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
    }
}
