using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    public bool isSlowMoMode;
    public float slowMoScale;

    public bool isPlay() {
        return false;
    }
    public bool isEnd() {
        return false;
    }
}
