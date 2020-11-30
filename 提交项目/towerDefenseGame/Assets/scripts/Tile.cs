using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Color hoverIndicateColor;

    public Vector3 positionAboveTile;

    [HideInInspector]
    public GameObject turretOnTile;

    private Renderer nodeRender;
    private Color orginalColor;

    ConstructManager constructManager;

    void Start()
    {
        nodeRender = GetComponent<Renderer>();
        orginalColor = nodeRender.material.color;

    }

    void OnMouseDown()
    {
        if (turretOnTile != null)
        {
            //buildManager.SelectNode(this);
            Debug.Log("already have a turret, but we can upgrate the turrent");
            return;
        }

        //if (!constructManager.CanBuild)
        //    return;
        GameObject testT = ConstructManager.instance.testprefab;
        turretOnTile = (GameObject)Instantiate(testT, transform.position + positionAboveTile, transform.rotation);
        //BuildTurret(constructManager.GetTurretToBuild());

    }

    void OnMouseEnter()
    {
        nodeRender.material.color = hoverIndicateColor;
    }

    void OnMouseExit()
    {
        nodeRender.material.color = orginalColor;
    }

}