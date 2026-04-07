using UnityEngine;
using System.IO;
using System.Xml.Serialization;
using UnityEngine.UI;
using System.Text;
using TMPro;

#if UNITY_ANDROID
using UnityEngine.Android;
#endif

public class DataSaver : MonoBehaviour
{

    public TextMeshProUGUI positionSavedShow; // optional: show current path
    private GameData gameDataCurrent;

    void Start()
    {
        // Get game data from your recording script
        gameDataCurrent = transform.GetComponent<RecordDataExample>().gameData;

#if UNITY_ANDROID
        // Request write permission if needed (older Android)
        if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite))
        {
            Permission.RequestUserPermission(Permission.ExternalStorageWrite);
        }
#endif
    }


    public void SaveData()
    {
        SaveCsv(gameDataCurrent);
        Debug.Log("All data saved!");
    }


    public void MoveToDownloads()
    {
        string savedFolder = Path.Combine(GetSavePath(), "SavedData");
        if (!Directory.Exists(savedFolder))
        {
            Debug.LogWarning("SavedData folder does not exist!");
            return;
        }

        string downloadsPath;

        if (Application.platform == RuntimePlatform.Android)
        {
            downloadsPath = "/storage/emulated/0/Download/SavedData"; // Android Downloads
        }
        else
        {
            downloadsPath = "C:/Users/leodr/Downloads/Programmering-af-mobile-applikationer/Assets";
        }

        if (!Directory.Exists(downloadsPath))
            Directory.CreateDirectory(downloadsPath);

        foreach (string file in Directory.GetFiles(savedFolder))
        {
            string destFile = Path.Combine(downloadsPath, Path.GetFileName(file));
            File.Copy(file, destFile, true);
            Debug.Log("Copied to Downloads: " + destFile);
        }

        Debug.Log("All files moved to Downloads folder!");
    }

    

    void SaveCsv(GameData gameData)
    {
        string folder = Path.Combine(GetSavePath(), "SavedData");
        if (!Directory.Exists(folder))
            Directory.CreateDirectory(folder);

        string pathFull = Path.Combine(folder, "gameData.csv");
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("time,posX,health,score");

        foreach (var entry in gameData.entries)
            sb.AppendLine($"{entry.time},{entry.posX},{entry.health},{entry.score}");

        File.WriteAllText(pathFull, sb.ToString());
        Debug.Log("Saved CSV: " + pathFull);
    }


    private string GetSavePath()
    {
        if (Application.isEditor)
            return Application.dataPath; // Editor folder
        else
            return Application.persistentDataPath; // Android, iOS, Standalone builds
    }
}
