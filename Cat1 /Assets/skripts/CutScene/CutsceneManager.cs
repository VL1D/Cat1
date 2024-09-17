using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    public static CutsceneManager Instance;

    [SerializeField] private List<CutsceneStruct> cutscenes = new List<CutsceneStruct>();

    public static Dictionary<string, GameObject> cutsceneDataBase = new Dictionary<string, GameObject>();

    public static GameObject activeCutscene;

    private void Awake()
    {
        Instance = this;

        InitializeCutsceneDataBase();

        foreach (var cutscene in cutsceneDataBase)
        {
            cutscene.Value.SetActive(false);
        }
    }

    private void InitializeCutsceneDataBase()
    {
        cutsceneDataBase.Clear();

        for (int i = 0; i < cutscenes.Count; i++)
        {
            cutsceneDataBase.Add(cutscenes[i].cutsceneKey, cutscenes[i].cutsceneObject);
        }
    }

    public void StartCutscene(string cutsceneKey)
    {
        if (!cutsceneDataBase.ContainsKey(cutsceneKey))
        {
            Debug.LogError($"Катсцены c ключом \"{cutsceneKey}\" нету в cutsceneDataBase");
            return;
        }

        if (activeCutscene != null)
        {
            if (activeCutscene == cutsceneDataBase[cutsceneKey])
            {
                return;
            }
        }

        activeCutscene = cutsceneDataBase[cutsceneKey];

        foreach (var cutscene in cutsceneDataBase)
        {
            cutscene.Value.SetActive(false);
        }

        cutsceneDataBase[cutsceneKey].SetActive(true);
    }

    public void EndCutscene()
    {
        if (activeCutscene != null)
        {
            activeCutscene.SetActive(false);
            activeCutscene = null;
        }
    }
}

[System.Serializable]
public struct CutsceneStruct
{
    public string cutsceneKey;
    public GameObject cutsceneObject;
}

