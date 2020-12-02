using System.Collections;
using UnityEngine;

public class guidePoints : MonoBehaviour
{
    public AudioSource playerDead;
    public static bool getEaten = false;
    public static Transform[] guidePointsArray;

    private void Awake()
    {
        guidePointsArray = new Transform[transform.childCount];
        for (int i = 0; i < guidePointsArray.Length; i++)
        {
            guidePointsArray[i] = transform.GetChild(i);
        }
    }



    void Update()
    {
        if (getEaten) {
            getEaten = false;
            playerDead.Play();
            StartCoroutine(StopAudio(4f));
        }
    }


    IEnumerator StopAudio(float delay)  // stop sound after 2 sec
    {

        yield return new WaitForSeconds(delay);
        playerDead.Stop();

    }

}
