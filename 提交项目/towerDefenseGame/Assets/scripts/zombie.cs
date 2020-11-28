using UnityEngine;

public class zombie : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    private Transform zombieCurrentMoveTo;  // guidePoint the zombie currently is moving to 
    private int currentMoveToIndex; // index for the zombie currently is moving to 

    // Start is called before the first frame update
    void Start()
    {
        zombieCurrentMoveTo = guidePoints.guidePointsArray[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = zombieCurrentMoveTo.position - transform.position;
        transform.Translate(moveDirection.normalized * moveSpeed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, zombieCurrentMoveTo.position) <= 0.2f)
        {
            nextGuidePointInfo();

        }
    }

    void nextGuidePointInfo() { // get the next guide point the zombie should move to 
        if (currentMoveToIndex >= guidePoints.guidePointsArray.Length - 1) {
            Destroy(gameObject);
            return;
        }
        currentMoveToIndex++;
        zombieCurrentMoveTo = guidePoints.guidePointsArray[currentMoveToIndex];
    }
}
