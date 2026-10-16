using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;
using NUnit.Framework;
using UnityEditor.PackageManager;
using UnityEngine;

public class SpawningScript : MonoBehaviour
{
    [SerializeField] private float interval = 0.1f;
    private int level = 0;
    private Coroutine repeatCoroutine;
    private TextAsset CurrentLevelFile;
    private string LevelString;
    private bool PickNextLevel()
    {
        level++;
        CurrentLevelFile = Resources.Load<TextAsset>($"Levels/{level}");
        if (CurrentLevelFile != null)
        {
            LevelString = CurrentLevelFile.ToString();
            return true;
        }
        else
        {
            Debug.LogError("Failed to load level file from Resources!");
            StopCoroutine(repeatCoroutine);
            return false;
        }
    }

    void Start()
    {
        repeatCoroutine = StartCoroutine(RepeatFunctionRoutine());
    }

    private IEnumerator RepeatFunctionRoutine()
    {
        while (true) // Infinite loop safely controlled by the yield statement
        {
            yield return new WaitForSeconds(interval);
            SpawningFunc();
        }
    }
    bool fileLoaded = false;
    int spawnIdx = 0;
    int waitTime = 0;
    private void SpawningFunc()
    {
        if (waitTime > 0)
        {
            Debug.Log("Waiting");
            waitTime--;
            return;
        }
        if (!fileLoaded || spawnIdx >= CurrentLevelFile.ToString().Length)
        {
            bool temp = PickNextLevel();
            spawnIdx = 0;
            fileLoaded = true;
            if (!temp)
            {
                Debug.Log("OH NO");
            }
            return;
        }

        char SpawnInstruction = LevelString[spawnIdx++];


        if (SpawnInstruction == '0')
        {
            Debug.Log(
                "Waiting"
            );
            waitTime = int.Parse(LevelString[spawnIdx++].ToString(), System.Globalization.NumberStyles.HexNumber) - 1; //Subtract 1 since it already waited this go.
            return;
        }

        switch (SpawnInstruction)
        {
            case '1':
                Debug.Log("1");
                break;
            case '2':
                Debug.Log("2");
                break;
            case '3':
                Debug.Log('3');
                break;
            default:
                Debug.Log("Who put in a number that represents nothing");
                break;
        }
    }

}
