using UnityEngine;

public class guidePoints : MonoBehaviour
{
    public static Transform[] guidePointsArray;

    private void Awake()
    {
        guidePointsArray = new Transform[transform.childCount];
        for (int i = 0; i < guidePointsArray.Length; i++)
        {
            guidePointsArray[i] = transform.GetChild(i);
        }
    }

}
