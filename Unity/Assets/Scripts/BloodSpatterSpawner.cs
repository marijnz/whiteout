using UnityEngine;
using System.Collections;

public class BloodSpatterSpawner : MonoBehaviour {

    public GameObject[] BloodSpatters;
    public GameObject holder;

    public void Start ()
    {
        holder = GameObject.Find("BloodHolder");
    }

    public void Spawn (Vector3 position, float angle)
    {
        GameObject blood = (GameObject)Instantiate(BloodSpatters[Mathf.FloorToInt(Random.value * BloodSpatters.Length)]);
        blood.transform.position = position;
        blood.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        blood.transform.position += transform.up * -0.15f;
        blood.transform.parent = holder.transform;
    }
}
