using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ChekImageForAnswer : MonoBehaviour
{
    [SerializeField] private GameObject IamgeGO;
    [SerializeField] private int answerCheck;

    private void Start()
    {
        if (MethodFromStringExecuter.Instance.IsAnswered(answerCheck) || MethodFromStringExecuter.Instance.IsStatLess(2, 7))
            IamgeGO.SetActive(false);
    }

    private void Update()
    {
        if (IamgeGO.activeSelf)
            if (MethodFromStringExecuter.Instance.IsAnswered(answerCheck) || MethodFromStringExecuter.Instance.IsStatLess(2, 7))
                IamgeGO.SetActive(false);
    }
}
