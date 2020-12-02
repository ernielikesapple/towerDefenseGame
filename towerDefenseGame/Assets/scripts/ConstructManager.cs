using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructManager : MonoBehaviour
{
	public static ConstructManager instance;

	void Awake()
	{
		if (instance != null)
		{
			return;
		}
		instance = this;
	}

	public GameObject buildEffect;
	public GameObject sellEffect;

	private TurretToBuild turretToBuild;
	private Tile selectedNode;

	//public NodeUI nodeUI;

	public bool CanBuild { get { return turretToBuild != null; } } // only allow to build when it this var gets value
    public bool HasMoney { get { return playerInfo.Money >= turretToBuild.cost; } } // todo: update play stats

    public void SelectNode(Tile tile)
	{
		if (selectedNode == tile)
		{
			DeselectNode();
			return;
		}

		selectedNode = tile;
		turretToBuild = null;

		//nodeUI.SetTarget(tile); //todo: update nodeUI
	}

	public void DeselectNode()
	{
		selectedNode = null;
		//nodeUI.Hide(); //todo: update nodeUI
	}

	public void SelectTurretToBuild(TurretToBuild turret)
	{
		turretToBuild = turret;
		DeselectNode();
	}

	public TurretToBuild GetTurretToBuild()
	{
		return turretToBuild;
	}
}
