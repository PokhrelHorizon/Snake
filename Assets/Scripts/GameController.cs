using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;
using System;

public class GameController : MonoBehaviour
{
    [NonSerialized] public List<GameObject> snakeBody = new List<GameObject>(); //list that stores snake parts
    [NonSerialized] public List<Vector2> snakeBodyPositions = new List<Vector2>(); //list that stores snake part locations

    public UnityEvent StartofGame;

    void Start()
    {
        StartofGame.Invoke();
    }
}
