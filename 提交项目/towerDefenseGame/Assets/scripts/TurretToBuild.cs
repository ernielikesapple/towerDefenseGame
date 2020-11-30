using System.Collections;
using UnityEngine;

[System.Serializable]
public class TurretToBuild : MonoBehaviour
{
	public GameObject prefab;
	public int cost;

	public GameObject upgradedPrefab;
	public int upgradeCost;

	public int GetSellAmount()
	{
		return cost / 2;
	}
}
