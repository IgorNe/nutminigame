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

    private int redValue;
    private int greenValue;
    private int blueValue;
    private int yellowValue;
    private bool updateJewels;

    private int maxValue;

    // Start is called before the first frame update
    void Start()
    {
        redValue = greenValue = blueValue = yellowValue = 0;
        updateJewels = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddJewels(string boltColor, int numOfJewels)
    {
        if(boltColor == "Red")
        {
            redValue += numOfJewels;
            redJewelsText.text = redValue.ToString();
            return;
        }
        if (boltColor == "Green")
        {
            greenValue += numOfJewels;
            greenJewelsText.text = greenValue.ToString();
            return;
        }
        if (boltColor == "Blue")
        {
            blueValue += numOfJewels;
            blueJewelsText.text = blueValue.ToString();
            return;
        }
        if (boltColor == "Yellow")
        {
            yellowValue += numOfJewels;
            yellowJewelsText.text = yellowValue.ToString();
            return;
        }
        else
        {
            return;
        }
        //updateJewels = true;
    }
}
