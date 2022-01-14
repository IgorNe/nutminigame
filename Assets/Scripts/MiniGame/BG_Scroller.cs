using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Scroller: MonoBehaviour
{
    
    public float scrollSpeedHorizontal;
    public float scrollSpeedVertical;
    
    private Renderer renderer;

    void Start()
    {
        
        renderer = GetComponent<Renderer>();
        
    }

    private void Update()
    {
        
        
    }

    private void FixedUpdate()
    {
        float x = Mathf.Repeat(Time.time * scrollSpeedHorizontal, 1);
        float y = Mathf.Repeat(Time.time * scrollSpeedVertical, 1);
        Vector2 offset = new Vector2(x, y);
        renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }

}
