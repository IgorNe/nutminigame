using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskAnimationController : MonoBehaviour
{
    [SerializeField] private Animator maskAnimator;

    private void Awake()
    {
        EventManager.OnNutColorFalse.AddListener(SetAngryMask);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            SetAngryMask();
        }
    }
    private void SetAngryMask()
    {
        maskAnimator.SetBool("falseColor", true);
        StartCoroutine(SetHappyMask());
    }
    private IEnumerator SetHappyMask()
    {
        yield return new WaitForSeconds(0.6f);
        maskAnimator.SetBool("falseColor", false);
    }
}
