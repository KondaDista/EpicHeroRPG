using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private GameObject ObsctacleGO;

    private void Start()
    {
        if (MethodFromStringExecuter.Instance.IsStateQuest(2, 3))
            ObsctacleGO.SetActive(false);
    }

    private void Update()
    {
        if (ObsctacleGO.activeSelf)
            if (MethodFromStringExecuter.Instance.IsStateQuest(2, 3))
                ObsctacleGO.SetActive(false);
    }
}
