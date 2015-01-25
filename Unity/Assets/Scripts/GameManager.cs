﻿using UnityEngine;
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

    List<Corpse> currentRoomCorpses = new List<Corpse>();
    Avatar currentAvatar;
    int currentRoomId;

	void Awake () {
        Instance = this;
        LoadRoom(0);
	}

    public void AvatarGotKilled() {
        SpawnFootprints.Instance.DecreaseAlpha();

        if ((AvatarsLeft - 1) < 0) {
            Application.LoadLevel("GameOver");
        }
        SpawnCorpse(currentAvatar.transform.position);
        FOWRenderTextureCamera.Instance.ResetFogOfWar();
        SpawnAvatar(CurrentRoom.SpawnLocation);

        StartCoroutine(SpawnCorpseHelpersAfterTime(0.2f));

    }

    IEnumerator SpawnCorpseHelpersAfterTime(float delayInSeconds) {
        yield return new WaitForSeconds(delayInSeconds);
        foreach (Corpse corpse in currentRoomCorpses) {
            HitpointManager.Instance.SpawnHitPoint((Vector2) corpse.transform.position, 300);
        }
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
            currentAvatar.ResetImpendingDoom();
        } else {
            SpawnAvatar(CurrentRoom.SpawnLocation);
        }
       
        currentRoomCorpses = new List<Corpse>();
    }

    void SpawnCorpse(Vector2 pos) {
        Corpse tempCorpse = Instantiate(CorpsePrefab) as Corpse;
        Vector3 newPos = pos;
        newPos.z = -3;
        tempCorpse.transform.position = newPos;
        currentRoomCorpses.Add(tempCorpse);
    }

    void SpawnAvatar(Vector2 pos) {
        AvatarsLeft--;
        Avatar tempAvatar = Instantiate(AvatarPrefab) as Avatar;
        Vector3 newPos = pos;
        newPos.z = -3;
        tempAvatar.transform.position = newPos;
        currentAvatar = tempAvatar;
    }


}
