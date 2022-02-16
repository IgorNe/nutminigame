using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ManaController : MonoBehaviour
{
	[SerializeField] private float minValue = 0;
	[SerializeField] private float maxValue = 100;
	[SerializeField] private GameObject manaBar;
	[SerializeField] private float maxYPos;
	[SerializeField] private float minYPos;
	[SerializeField] private GameObject firstButton;
	[SerializeField] private GameObject secondButton;
	[SerializeField] private int activateFist;
	[SerializeField] private int activateSecond;

	private float currentYPos;
	private RectTransform manaRTransform;
	private static float current;


    private void Awake()
    {
		EventManager.OnTrueBoltColor.AddListener(AddMana);
    }
    void Start()
	{
		manaRTransform = manaBar.GetComponent<RectTransform>();
		UpdateUI();
		currentYPos = minYPos;
	}

	public static float currentValue
	{
		get { return current; }
	}

	void Update()
	{
        if (current < minValue) current = minValue;
        if (current > maxValue) current = maxValue;
	}

	void UpdateUI()
	{
		Calc();
		ActivateButton();
		manaBar.transform.localPosition = new Vector3(manaBar.transform.localPosition.x, currentYPos, 0);
	}


	private void AddMana(int adjust)
	{
		current += adjust;
		UpdateUI();
	}

	void Calc()
    {
		currentYPos =minYPos + Mathf.Abs((maxYPos - minYPos) / (maxValue / current + 0.1f));
    }

	private void ActivateButton()
    {
		if(current > activateFist)
        {
			firstButton.SetActive(true);
        }
		if(current > activateSecond)
        {
			secondButton.SetActive(true);
        }
		if(current < activateFist)
        {
			firstButton.SetActive(false);
		}
		if (current < activateSecond)
		{
			secondButton.SetActive(false);
		}
	}

	public void OnFirstButtonClicked()
    {
		EventManager.SendClearBolt();
		AddMana(-activateFist);
    }

	public void OnSecondButtonClicked()
	{
		EventManager.SendClearSpinner();
		AddMana(-activateSecond);
	}
}
