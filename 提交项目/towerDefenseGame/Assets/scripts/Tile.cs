using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour
{
    public Color hoverIndicateColor;

    public Vector3 positionAboveTile;

    [HideInInspector]
    public GameObject turretOnTile;
    [HideInInspector]
    public TurretToBuild turretToBuild;

    private Renderer nodeRender;
    private Color orginalColor;

    ConstructManager constructManager;

    void Start()
    {
        nodeRender = GetComponent<Renderer>();
        orginalColor = nodeRender.material.color;
        constructManager = ConstructManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionAboveTile;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (turretOnTile != null)
        {
            //buildManager.SelectNode(this);
            Debug.Log("already have a turret, but we can upgrate the turrent");
            return;
        }

        if (!constructManager.CanBuild)
            return;

        BuildTurret(constructManager.GetTurretToBuild());  // when click the tile, then try to place node on it

    }

    void BuildTurret(TurretToBuild turretToBuildLocal)
    {
        //if (PlayerStats.Money < turretToBuild.cost)
        //{
        //    Debug.Log("Not enough money to build that!");
        //    return;
        //}

        //PlayerStats.Money -= turretToBuild.cost;

        GameObject _turret = (GameObject)Instantiate(turretToBuildLocal.prefab, GetBuildPosition(), Quaternion.identity);
        turretOnTile = _turret;

        turretToBuild = turretToBuildLocal;

        //GameObject effect = (GameObject)Instantiate(constructManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        //Destroy(effect, 5f);

        Debug.Log("Turret build!");
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!constructManager.CanBuild)
            return;

        nodeRender.material.color = hoverIndicateColor;
    }

    void OnMouseExit()
    {
        nodeRender.material.color = orginalColor;
    }

}