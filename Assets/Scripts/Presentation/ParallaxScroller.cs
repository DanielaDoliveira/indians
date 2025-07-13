using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScroller : MonoBehaviour
{
    public float scrollSpeed = 0.1f;
    private Renderer rend;
    private Vector2 offset;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        offset.x += scrollSpeed * Time.deltaTime;
        rend.material.mainTextureOffset = offset;
    }
}
