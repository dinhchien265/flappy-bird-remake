using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        float hight = spriteRenderer.bounds.size.y;
        float width = spriteRenderer.bounds.size.x;

        float worldHeight = Camera.main.orthographicSize * 2;
        float worldWidth = worldHeight * Screen.width / Screen.height;

        transform.localScale = new Vector3(worldWidth / width, worldHeight / hight, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
