using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    private int _score = 0;

    public int GetScore()
    {
        return this._score;
    }

    public void PlusScore(int score)
    {
        this._score += score;
    }
}
