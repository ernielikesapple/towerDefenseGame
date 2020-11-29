using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Color hoverIndicateColor;

    private Renderer nodeRender;
    private Color orginalColor;

    void Start()
    {
        nodeRender = GetComponent<Renderer>();
        orginalColor = nodeRender.material.color;

    }

    void OnMouseEnter()
    {
        nodeRender.material.color = hoverIndicateColor;
    }

    private void OnMouseExit()
    {
        nodeRender.material.color = orginalColor;
    }

}