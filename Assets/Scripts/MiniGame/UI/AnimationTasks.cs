using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTasks : MonoBehaviour
{
    [SerializeField] private Animator tasksAnimator;

    private void Awake()
    {
        EventManager.OnJewelDelivered.AddListener(PlayAnimation);
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    void PlayAnimation(string color)
    {
        tasksAnimator.SetBool($"{color}", true);
        StartCoroutine(EndAnimation(color));
    }

    private IEnumerator EndAnimation(string color)
    {
        yield return new WaitForSeconds(0.2f);
        tasksAnimator.SetBool($"{color}", false);
    }

}
