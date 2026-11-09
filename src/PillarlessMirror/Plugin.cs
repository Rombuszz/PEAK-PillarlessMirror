using BepInEx;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace PillarlessMirror;

[BepInPlugin(Id, Name, Version)]
public sealed class Plugin : BaseUnityPlugin
{
    public const string Id = "Rombusz.PillarlessMirror";
    public const string Name = "PillarlessMirror";
    public const string Version = "1.1.2";

    // Path to the pillar object in the scene hierarchy.
    private const string PillarPath = "Mirror (1)/Details/Cube (2)";

    private void Awake()
    {
        SceneManager.sceneLoaded += RemovePillar;
        RemovePillar(SceneManager.GetActiveScene(), LoadSceneMode.Single);
        Logger.LogMessage($"Plugin {Name} {Version} is loaded!");
    }

    private void OnDestroy() => SceneManager.sceneLoaded -= RemovePillar;

    private static void RemovePillar(Scene scene, LoadSceneMode _)
    {
        if (scene.name != "Airport")
        {
            return;
        }

        GameObject.Find("Map")?.transform.Find(PillarPath)?.gameObject.SetActive(false);
    }
}
