using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadProgressBar : MonoBehaviour
{
    [SerializeField] private Slider progressBar;
    [SerializeField] private float loadingTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        StartCoroutine(LoadAnimation());
    }
    private IEnumerator LoadAnimation()
    {
        float time = 0f;
        while(time < loadingTime)
        {
            time += Time.deltaTime;
            progressBar.value = time / loadingTime;
            yield return null;
        }
        gameObject.SetActive(false);
    }
}
