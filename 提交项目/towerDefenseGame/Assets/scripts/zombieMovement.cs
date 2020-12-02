using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(zombie))]
public class zombieMovement : MonoBehaviour
{
	private Transform target;
	private int wavepointIndex = 0;

	private zombie zombieSingle;
    //public AudioSource playerDead;

    void Start()
	{
		zombieSingle = GetComponent<zombie>(); // get reference to the zombie instance

		target = guidePoints.guidePointsArray[0];
	}

	void Update()
	{
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * zombieSingle.speed * Time.deltaTime, Space.World);

		if (Vector3.Distance(transform.position, target.position) <= 0.4f)
		{
			GetNextWaypoint();
		}

		zombieSingle.speed = zombieSingle.startMoveSpeed;
	}

	void GetNextWaypoint()
	{
		if (wavepointIndex >= guidePoints.guidePointsArray.Length - 1)
		{
			EndPath();
			return;
		}

		wavepointIndex++;
		if (wavepointIndex == 1)
		{
			transform.Rotate(0f, -90.0f, 0.0f, Space.World);
		}
		else if(wavepointIndex == 2) {
			transform.Rotate(0f, 90.0f, 0.0f, Space.World);
		}

		target = guidePoints.guidePointsArray[wavepointIndex];
	}

	void EndPath()
	{
		playerInfo.Lives--;
        //playerDead.Play();
        zombieSpawner.EnemiesAlive--;
		Destroy(gameObject);
	}
}
