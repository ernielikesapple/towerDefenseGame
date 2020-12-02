using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public AudioSource shoppingSuccessAudio;
    public Color hoverIndicateColor;
    public Color notEnoughMoneyColor;

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
        if (playerInfo.Money < turretToBuildLocal.cost)
        {
            playerInfo.notificationTextToDisplay = "Not enough money to build that!";
            playerInfo.notificationTextToDisplayNotified = true;
            return;
        }

        

        GameObject _turret = (GameObject)Instantiate(turretToBuildLocal.prefab, GetBuildPosition(), Quaternion.identity);
        turretOnTile = _turret;

        turretToBuild = turretToBuildLocal;

        playerInfo.Money -= turretToBuildLocal.cost;
        shoppingSuccessAudio.Play();
        
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!constructManager.CanBuild)
            return;

        nodeRender.material.color = hoverIndicateColor;

        if (constructManager.HasMoney)
        {
            nodeRender.material.color = hoverIndicateColor;
        }
        else
        {
            nodeRender.material.color = notEnoughMoneyColor;
        }
    }

    void OnMouseExit()
    {
        nodeRender.material.color = orginalColor;
    }

}