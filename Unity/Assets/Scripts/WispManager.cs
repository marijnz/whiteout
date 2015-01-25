using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WispManager : MonoBehaviour {

    public static WispManager Instance;

    public Wisp WispPrefab;

    public Transform UpperLeft;
    public Transform LowerLeft;
    public Transform UpperRight;
    public Transform LowerRight;

    List<Wisp> wisps = new List<Wisp>();

    void Awake() {
        Instance = this;
    }

    public void AskForNewDirection(Wisp wisp) {
        
    }

    public void InitializeWisps(int amount) {
        for (int i = 0; i < amount; i++) {
            Wisp tempWisp = Instantiate(WispPrefab) as Wisp;
            wisps.Add(tempWisp);
            Vector3 zero = new Vector3(UpperLeft.transform.position.x, Random.Range(UpperLeft.transform.position.y, LowerLeft.transform.position.y), -10);
            Vector3 one = new Vector3(UpperRight.transform.position.x, Random.Range(LowerRight.transform.position.y, UpperRight.transform.position.y), -10);
            Vector3 two = new Vector3(Random.Range(UpperLeft.transform.position.x, UpperRight.transform.position.x), UpperLeft.transform.position.y, -10);
            Vector3 three = new Vector3(Random.Range(LowerLeft.transform.position.x, LowerRight.transform.position.x), LowerLeft.transform.position.y, -10);

            int rand = Random.Range(0, 3);
            switch (rand) {
                case 0:
                    tempWisp.transform.position = zero;
                    tempWisp.MoveTo(UpperLeft.transform.position);
                    break;
                case 1:
                    tempWisp.transform.position = one;
                    tempWisp.MoveTo(LowerRight.transform.position);
                    break;
                case 2:
                    tempWisp.transform.position = two;
                    tempWisp.MoveTo(UpperRight.transform.position);
                    break;
                case 3:
                    tempWisp.transform.position = three;
                    tempWisp.MoveTo(LowerLeft.transform.position);
                    break;
            }
        }
    }

    public void RemoveWisp() {
        int wispIndex = Random.Range(0, wisps.Count-1);
        wisps[wispIndex].Kill();
        wisps.RemoveAt(wispIndex);
    }
}
