using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ManaMotionController : MonoBehaviour
{
    [SerializeField] private GameObject manaObject;
    [SerializeField] private float moveTime;

    [SerializeField] private Transform startPosition;
    [SerializeField] private Transform endPosition;
    [SerializeField] private List<Transform> firstMidPoint;
    [SerializeField] private List<Transform> secondMidPoint;
    void Start()
    {
        
    }
    private void Awake()
    {
        EventManager.OnManaAdd.AddListener(InstMana);
    }
    private void InstMana()
    {
        var mana = Instantiate(manaObject, startPosition.position, Quaternion.identity);
        StartCoroutine(MoveMana(mana));
    }

    private IEnumerator MoveMana(GameObject mana)
    {
        var fPoint = firstMidPoint[Random.Range(0, firstMidPoint.Count - 1)];
        var sPoint = secondMidPoint[Random.Range(0, secondMidPoint.Count - 1)];
        var startPosition = mana.transform.position;
        float time = 0;
        yield return new WaitForSeconds(Random.Range(0.05f, 0.3f));
        while (time < moveTime)
        {
            mana.transform.position = Bezier.GetPoint(startPosition,
                fPoint.position,
                sPoint.position,
                endPosition.position, time / moveTime);
            time += Time.deltaTime;
            yield return null;
        }
        Destroy(mana);
    }
}
