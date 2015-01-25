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

    List<Corpse> currentRoomCorpses = new List<Corpse>();
    Avatar currentAvatar;
    int currentRoomId;

    float delay = 0f;

	void Awake () {
        Instance = this;
	}

    void Start() {
        WispManager.Instance.InitializeWisps(AvatarsLeft);
        LoadRoom(0);
        AudioManager.Instance.Play("Anthem", this.transform.position);
    }
    public void AvatarGotKilled() {
        SpawnFootprints.Instance.ClearBlood();
        SpawnCorpse(currentAvatar.transform.position);

      //  foreach (Hitpoint hitpoint in FindObjectsOfType<Hitpoint>()) {
      //      hitpoint.FadeOutIfAllowed();
      //  }

        StartCoroutine(RestartRoomAfterTtime(1.0f));
        
    }

    IEnumerator RestartRoomAfterTtime(float delayInSeconds) {
        yield return new WaitForSeconds(delayInSeconds);
        if ((AvatarsLeft - 1) < 0) {
            StartCoroutine(ShowRoom(true));
            yield break;
        }

        FOWRenderTextureCamera.Instance.ResetFogOfWar();

         foreach (Hitpoint hitpoint in FindObjectsOfType<Hitpoint>()) {
             hitpoint.SpawnAgainIfAllowed();
         }

        SpawnAvatar(CurrentRoom.SpawnLocation);

       

        delay = 0.1f;
    }
    /*
    void Update() {
        if (delay != 0 && (delay += Time.deltaTime) >= 0.1f) {
            delay = 0;
            foreach (Corpse corpse in currentRoomCorpses) {
                HitpointManager.Instance.SpawnHitPoint((Vector2)corpse.transform.position, 0.40f);
            }
        }
    }*/

    public void RoomGotCompleted() {
        
        foreach (Hitpoint hitpoint in FindObjectsOfType<Hitpoint>()) {
            Destroy(hitpoint.gameObject);
        }
        StartCoroutine(ShowRoom());
    }

    IEnumerator ShowRoom(bool failed = false) {
        float time = 0;
        while (time < 1) {
            time += Time.deltaTime * 0.7f;
            FogOfWarPlane.Instance.GetComponent<Renderer>().material.SetFloat("_AlphaOveride", Mathf.Lerp(0, -0.3f, time));
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(1.5f);
        time = 0;
        while (time < 1) {
            time += Time.deltaTime * 0.7f;
            FogOfWarPlane.Instance.GetComponent<Renderer>().material.SetFloat("_AlphaOveride", Mathf.Lerp(-0.3f, 1, time));
            yield return new WaitForEndOfFrame();
        }
        FogOfWarPlane.Instance.GetComponent<Renderer>().material.SetFloat("_AlphaOveride", 0);

        if (failed) {
            Application.LoadLevel("GameOver");
        } else {
            CurrentRoom.gameObject.SetActive(false);
            FOWRenderTextureCamera.Instance.ResetFogOfWar();
            SpawnFootprints.Instance.ClearBlood();
            LoadRoom(++currentRoomId);
        }
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
            Vector3 newPos = currentAvatar.transform.position;
            newPos.z = -3;
            currentAvatar.transform.position = newPos;

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
        WispManager.Instance.RemoveWisp();
        AvatarsLeft--;
        Avatar tempAvatar = Instantiate(AvatarPrefab) as Avatar;
        Vector3 newPos = pos;
        newPos.z = -3;
        tempAvatar.transform.position = newPos;
        currentAvatar = tempAvatar;
    }


}
