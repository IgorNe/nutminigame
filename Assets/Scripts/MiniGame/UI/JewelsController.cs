using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JewelsController : MonoBehaviour
{
    [SerializeField] private Text redJewelsText;
    [SerializeField] private Text greenJewelsText;
    [SerializeField] private Text blueJewelsText;
    [SerializeField] private Text yellowJewelsText;

    [SerializeField]private float delayTime;

    private int redValue;
    private int greenValue;
    private int blueValue;
    private int yellowValue;



    private int maxValue;

    void Start()
    {
        redValue = greenValue = blueValue = yellowValue = 0;
    }

    private void Awake()
    {
        EventManager.OnJewelsAdd.AddListener(AddJewels);
    }

    void AddJewels(string boltColor, int numOfJewels)
    {
        StartCoroutine(DelayAddJewel(boltColor, numOfJewels));
    }

    IEnumerator DelayAddJewel (string boltColor, int numOfJewels)
    {
        yield return new WaitForSeconds(delayTime + 0.15f);
        if (boltColor == "Red")
        {
            redValue += numOfJewels;
            redJewelsText.text = redValue.ToString();
        }
        if (boltColor == "Green")
        {
            greenValue += numOfJewels;
            greenJewelsText.text = greenValue.ToString();
        }
        if (boltColor == "Blue")
        {
            blueValue += numOfJewels;
            blueJewelsText.text = blueValue.ToString();
        }
        if (boltColor == "Yellow")
        {
            yellowValue += numOfJewels;
            yellowJewelsText.text = yellowValue.ToString();
        }
        else
        {
            yield return null;
        }
    }
}
