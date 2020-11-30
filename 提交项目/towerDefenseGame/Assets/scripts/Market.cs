using UnityEngine;

public class Market : MonoBehaviour
{
	public TurretToBuild singleMissleTurret;
	public TurretToBuild doubleMissleTurret;
	public TurretToBuild cruiseMissleTurret;

	ConstructManager constructManager;

	void Start()
	{
		constructManager = ConstructManager.instance;
	}

	public void SelectSingleMissleTurret()
	{
		constructManager.SelectTurretToBuild(singleMissleTurret);
	}

	public void SelectDoubleMissileLauncher()
	{
		constructManager.SelectTurretToBuild(doubleMissleTurret);
	}

	public void SelectCruiseMissleBeamer()
	{
		constructManager.SelectTurretToBuild(cruiseMissleTurret);
	}
}
