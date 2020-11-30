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
		Debug.Log("1");
		constructManager.SelectTurretToBuild(singleMissleTurret);
	}

	public void SelectDoubleMissileLauncher()
	{
		Debug.Log("2");
		constructManager.SelectTurretToBuild(doubleMissleTurret);
	}

	public void SelectCruiseMissleBeamer()
	{
		Debug.Log("3");
		constructManager.SelectTurretToBuild(cruiseMissleTurret);
	}
}
