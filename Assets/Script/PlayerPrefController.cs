﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefController : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string NEW_GAME_KEY = "new game";

    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;

    const float MIN_DIFFICULTY = 1f;
    const float MAX_DIFFICULTY = 5f;

    public static void SetMasterVolume(float volume) { if (volume >= MIN_VOLUME && volume <= MAX_VOLUME) { PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume); } else { Debug.LogError("Range Error w/ MASTER_VOLUME_KEY!"); } }
    public static void SetDifficulty(int difficulty) { if (difficulty >= MIN_DIFFICULTY && difficulty <= MAX_DIFFICULTY) { PlayerPrefs.SetInt(DIFFICULTY_KEY, difficulty);  } else { Debug.LogError("Range Error w/ MASTER_VOLUME_KEY!"); } }

    public static float GetMasterVolume() { return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY); }
    public static int GetDifficulty() { return PlayerPrefs.GetInt(DIFFICULTY_KEY); }

    public static void SetAsLoadedBefore() { PlayerPrefs.SetInt(NEW_GAME_KEY,1);  }
    public static int GetLoadStatus() { return PlayerPrefs.GetInt(NEW_GAME_KEY); }
}
