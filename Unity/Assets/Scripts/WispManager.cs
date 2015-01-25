using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WispManager : MonoBehaviour {

    public static WispManager Instance;

    public Wisp WispPrefab;

    public WispWaypoint UpperLeft;
    public WispWaypoint LowerLeft;
    public WispWaypoint UpperRight;
    public WispWaypoint LowerRight;

    List<Wisp> wisps = new List<Wisp>();

    void Awake() {
        Instance = this;
    }

    public void InitializeWisps(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Wisp tempWisp = Instantiate(WispPrefab) as Wisp;
            wisps.Add(tempWisp);

            int rand = Random.Range(0, 3);
            switch (rand)
            {
                case 0:
                    tempWisp.transform.position = UpperLeft.getPosition();
                    tempWisp.MoveTo(UpperLeft.getNextWaypoint());
                    break;
                case 1:
                    tempWisp.transform.position = LowerRight.getPosition();;
                    tempWisp.MoveTo(LowerRight.getNextWaypoint());
                    break;
                case 2:
                    tempWisp.transform.position = UpperRight.getPosition();;
                    tempWisp.MoveTo(UpperRight.getNextWaypoint());
                    break;
                case 3:
                    tempWisp.transform.position = LowerLeft.getPosition();;
                    tempWisp.MoveTo(LowerLeft.getNextWaypoint());
                    break;
            }
            tempWisp.JumpToRandomPositionOnLine();
        }
    }

    public void RemoveWisp()
    {
        int wispIndex = Random.Range(0, wisps.Count-1);
        wisps[wispIndex].Kill();
        wisps.RemoveAt(wispIndex);
    }
}
