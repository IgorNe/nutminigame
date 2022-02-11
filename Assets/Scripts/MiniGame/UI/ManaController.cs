using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ManaController : MonoBehaviour
{

	public float maxValue = 100;
	public Color color = Color.red;
	public int height = 4;
	public Slider slider;
	public bool isRight;

	private static float current;

	void Start()
	{
		slider.fillRect.GetComponent<Image>().color = color;

		slider.maxValue = maxValue;
		slider.minValue = 0;
		current = 0;

		UpdateUI();
	}

	public static float currentValue
	{
		get { return current; }
	}

	void Update()
	{
		if (current < 0) current = 0;
		if (current > maxValue) current = maxValue;
		slider.value = current;
        if (Input.GetKeyDown(KeyCode.M))
        {
			AddMana(50);
        }
	}

	void UpdateUI()
	{
		RectTransform rect = slider.GetComponent<RectTransform>();

		int rectDeltaY = Screen.height / height;
		float rectPosY = 0;


		rectPosY = rect.position.y + (rectDeltaY - rect.sizeDelta.y) / 2;
		slider.direction = Slider.Direction.BottomToTop;


		rect.sizeDelta = new Vector2(rect.sizeDelta.x, rectDeltaY);
		rect.position = new Vector3(rect.position.x, rectPosY, rect.position.z);
	}

	public void AddMana(float adjust)
	{
		current += adjust;
	}
}
