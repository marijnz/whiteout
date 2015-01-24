using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    [SerializeField]
    Avatar AvatarPrefab;
    [SerializeField]
    Corpse CorpsePrefab;

    [SerializeField] 
    int AvatarsLeft;

    public Room CurrentRoom;

    Avatar currentAvatar;

	void Awake () {
        Instance = this;
        SpawnAvatar(CurrentRoom.SpawnLocation);
	}

    public void AvatarGotKilled() {
        SpawnCorpse(currentAvatar.transform.position);
        SpawnAvatar(CurrentRoom.SpawnLocation);
    }

    public void LevelGotCompleted() {
        // Load next room
    }

    void SpawnCorpse(Vector2 pos) {
        Corpse tempCorpse = Instantiate(CorpsePrefab) as Corpse;
        tempCorpse.transform.position = pos;
    }

    void SpawnAvatar(Vector2 pos) {
        Avatar tempAvatar = Instantiate(AvatarPrefab) as Avatar;
        tempAvatar.transform.position = pos;


        currentAvatar = tempAvatar;
    }


}
