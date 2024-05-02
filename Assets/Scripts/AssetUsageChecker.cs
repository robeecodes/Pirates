using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.IO;

public class AssetUsageChecker : EditorWindow
{
    [MenuItem("Tools/Asset Usage Checker")]
    static void Init()
    {
        AssetUsageChecker window = (AssetUsageChecker)EditorWindow.GetWindow(typeof(AssetUsageChecker));
        window.Show();
    }

    void OnGUI()
    {
        if (GUILayout.Button("Check Asset Usage"))
        {
            CheckAssetUsage();
        }
    }

    void CheckAssetUsage()
    {
        List<AssetInfo> usedAssets = new List<AssetInfo>();

        // Get all GameObjects in the scene
        GameObject[] sceneObjects = GameObject.FindObjectsOfType<GameObject>();

        foreach (GameObject obj in sceneObjects)
        {
            // Get components of the GameObject
            Component[] components = obj.GetComponents<Component>();

            foreach (Component comp in components)
            {
                // Check if the component references an asset
                SerializedObject so = new SerializedObject(comp);
                SerializedProperty sp = so.GetIterator();

                while (sp.NextVisible(true))
                {
                    if (sp.propertyType == SerializedPropertyType.ObjectReference && sp.objectReferenceValue != null)
                    {
                        // Check if the referenced object is an asset
                        string assetPath = AssetDatabase.GetAssetPath(sp.objectReferenceValue);
                        if (!string.IsNullOrEmpty(assetPath))
                        {
                            string assetName = Path.GetFileNameWithoutExtension(assetPath);
                            string packageName = GetPackageName(assetPath);

                            AssetInfo assetInfo = new AssetInfo(assetName, assetPath, packageName);

                            // Add link to the Unity Asset Store if applicable
                            string assetStoreLink = GetAssetStoreLink(assetPath);
                            if (!string.IsNullOrEmpty(assetStoreLink))
                            {
                                assetInfo.AssetStoreLink = assetStoreLink;
                            }

                            // Add to list
                            usedAssets.Add(assetInfo);
                        }
                    }
                }
            }
        }

        // Write to CSV file
        WriteToCSV(usedAssets);
    }

    string GetPackageName(string assetPath)
    {
        // Extract package name from the asset path
        // This assumes a typical package structure where the package name is part of the path
        string[] parts = assetPath.Split('/');
        if (parts.Length >= 3)
        {
            return parts[1]; // Assuming the package name is the second part of the path
        }
        return "Unknown";
    }

    string GetAssetStoreLink(string assetPath)
    {
        // Check if the asset is from the Unity Asset Store
        AssetImporter importer = AssetImporter.GetAtPath(assetPath);
        if (importer != null && !string.IsNullOrEmpty(importer.assetBundleName))
        {
            string packageName = importer.assetBundleName;
            // Construct a generic Asset Store search URL with the package name as the search query
            return "https://assetstore.unity.com/search?q=" + WWW.EscapeURL(packageName);
        }
        return null;
    }

    void WriteToCSV(List<AssetInfo> usedAssets)
    {
        string filePath = EditorUtility.SaveFilePanel("Save Asset Usage Report", "", "AssetUsageReport", "csv");

        if (string.IsNullOrEmpty(filePath))
        {
            return;
        }

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("Asset Name,Asset Path,Package Name,Asset Store Link");

            foreach (AssetInfo assetInfo in usedAssets)
            {
                writer.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\"", assetInfo.AssetDisplayName, assetInfo.AssetPath, assetInfo.PackageName, assetInfo.AssetStoreLink));
            }
        }

        Debug.Log("Asset usage report saved to: " + filePath);
    }

    class AssetInfo
    {
        public string AssetDisplayName { get; }
        public string AssetPath { get; }
        public string PackageName { get; }
        public string AssetStoreLink { get; set; }

        public AssetInfo(string assetDisplayName, string assetPath, string packageName)
        {
            AssetDisplayName = assetDisplayName;
            AssetPath = assetPath;
            PackageName = packageName;
            AssetStoreLink = string.Empty;
        }
    }
}
