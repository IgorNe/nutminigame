using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningController : MonoBehaviour
{
    [SerializeField] private ParticleSystem lightning;
    [SerializeField] private Transform lightningStartPosition;
    private ParticleSystem currentParticle;


    void PlayLightning(int numStoneBolt, float stoneboltCount)
    {
        currentParticle = Instantiate(lightning, lightningStartPosition.position, Quaternion.Euler(0, 0, SetLightningDirection(numStoneBolt)));
        var size = currentParticle.transform.localScale.y;
        size = stoneboltCount;
    }

    float SetLightningDirection(int stoneBolt)
    {
        if(stoneBolt == 1)
        {
            return 90f;
        }
        if (stoneBolt == 2)
        {
            return -180f;
        }
        else
        {
            return -90f;
        }

    }


}
