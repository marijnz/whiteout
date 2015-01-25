using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    [SerializeField]
    Avatar AvatarPrefab;
    [SerializeField]
    Corpse CorpsePrefab;

    [SerializeField]
    List<Room> Rooms;

    [SerializeField] 
    int AvatarsLeft;

    public Room CurrentRoom;

    Avatar currentAvatar;
    int currentRoomId;

	void Awake () {
        Instance = this;
        LoadRoom(0);
	}

    public void AvatarGotKilled() {
        AvatarsLeft--;
        if (AvatarsLeft <= 0) {
            Application.LoadLevel("GameOver");
        }
        SpawnCorpse(currentAvatar.transform.position);
        FOWRenderTextureCamera.Instance.ResetFogOfWar();
        SpawnAvatar(CurrentRoom.SpawnLocation);
        
    }

    public void RoomGotCompleted() {
        CurrentRoom.gameObject.SetActive(false);
        FOWRenderTextureCamera.Instance.ResetFogOfWar();
        LoadRoom(++currentRoomId);
    }

    void LoadRoom(int id) {
        if (id >= Rooms.Count) {
            Application.LoadLevel("Finish");
            return;
        }
        Debug.Log("Loading room: " + id);
        CurrentRoom = Rooms[id];
        currentRoomId = id;

        CurrentRoom.gameObject.SetActive(true);
        if (currentAvatar != null) {
            currentAvatar.transform.position = CurrentRoom.SpawnLocation;
        } else {
            SpawnAvatar(CurrentRoom.SpawnLocation);
        }
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
