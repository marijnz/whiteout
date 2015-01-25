using UnityEngine;
using System.Collections;

public class BloodSpatterSpawner : MonoBehaviour {

    public GameObject[] BloodSpatters;

    public void Spawn (Vector2 position, float angle)
    {
        GameObject blood = (GameObject)Instantiate(BloodSpatters[Mathf.FloorToInt(Random.value * BloodSpatters.Length)]);
        blood.transform.position = new Vector3(position.x, position.y, -0.2f);
        blood.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        blood.transform.position += transform.up * -0.1f;
    }
}
