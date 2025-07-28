using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnNPC : MonoBehaviour
{

    int areaMaxy = -4;
    int areaMiny = -54;
    int area1Maxx = -15;
    int area1Minx = -65;
    int area2Maxx = 65;
    int area2Minx = 15;

    public void Spawn(GameObject nPC, GameObject checkObj)
    {
        
        int areaNum = Random.Range(0, 2);
        int posY = Random.Range(areaMiny, areaMaxy);
        if(areaNum == 0)
        {
            int posX = Random.Range(area1Minx, area1Maxx);
            Vector3 nPCPos = new Vector3(posX, posY, 0);
            Instantiate(nPC, nPCPos, Quaternion.identity, checkObj.transform);

        }
        else
        {
            int posX = Random.Range(area2Minx, area2Maxx);
            Vector3 nPCPos = new Vector3(posX, posY, 0);
            Instantiate(nPC, nPCPos, Quaternion.identity, checkObj.transform);
        }
    }
}
