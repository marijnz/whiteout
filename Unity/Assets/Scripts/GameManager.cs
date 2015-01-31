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

    [SerializeField]
    GameObject FailedCanvas;

    [SerializeField]
    GameObject FinishCanvas;

    public Room CurrentRoom;

    List<Corpse> currentRoomCorpses = new List<Corpse>();
    Avatar currentAvatar;
    int currentRoomId;


    public bool IsSwitchingLevel = false;

	void Awake () {
        Instance = this;
	}

    void Start() {
        StartGame();
        AudioManager.Instance.Play("Anthem", this.transform.position);
        AudioManager.Instance.Play("Breath", this.transform.position);
    }

    public void StartGame() {
        currentRoomId = 0;
        WispManager.Instance.InitializeWisps(AvatarsLeft);
        LoadRoom(0);
    }
    public void AvatarGotKilled()
{
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

         SpawnFootprints.Instance.ClearBlood();

        SpawnAvatar(CurrentRoom.SpawnLocation);
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
        IsSwitchingLevel = true;
        FindObjectOfType<SpawnFootprints>().isSpawning = false;
        foreach (Hitpoint hitpoint in FindObjectsOfType<Hitpoint>()) {
            DestroyImmediate(hitpoint.gameObject);
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
            time += Time.deltaTime * 1f;
            FogOfWarPlane.Instance.GetComponent<Renderer>().material.SetFloat("_AlphaOveride", Mathf.Lerp(-0.3f, 2, time));
            yield return new WaitForEndOfFrame();
        }
        FogOfWarPlane.Instance.GetComponent<Renderer>().material.SetFloat("_AlphaOveride", 0);

        SpawnFootprints.Instance.ClearBlood();
        CurrentRoom.gameObject.SetActive(false);
        FOWRenderTextureCamera.Instance.ResetFogOfWar();

        Debug.Log("FAILED " + failed);

        if (failed) {
            //Application.LoadLevel("GameOver");
            FailedCanvas.SetActive(true);
        } else {
            LoadRoom(++currentRoomId);
        }
    }

    void LoadRoom(int id) {

        if (id >= Rooms.Count) {
           // Application.LoadLevel("Finish");
            FinishCanvas.SetActive(true);
            return;
        }
        Debug.Log(FinishCanvas.GetComponent<TryAgain>());
        FinishCanvas.SetActive(false);
        FailedCanvas.SetActive(false);


        Debug.Log("Loading room: " + id);
        CurrentRoom = Rooms[id];
        currentRoomId = id;
        StartCoroutine(LittleDelayInShowingLevel(id));
        CurrentRoom.gameObject.SetActive(true);
        if (currentAvatar != null)
        {
            currentAvatar.transform.position = CurrentRoom.SpawnLocation;
            Vector3 newPos = currentAvatar.transform.position;
            newPos.z = -3;
            currentAvatar.transform.position = newPos;

            currentAvatar.ResetImpendingDoom();

            AudioManager.Instance.Play("Door Opens", currentAvatar.transform.position);
        }
        else
        {
            SpawnAvatar(CurrentRoom.SpawnLocation);
        }
       
        foreach (Corpse c in currentRoomCorpses)
        {
            Destroy(c.gameObject);
        }
        currentRoomCorpses = new List<Corpse>();
        FOWRenderTextureCamera.Instance.ResetFogOfWar();

        IsSwitchingLevel = false;
    }

    IEnumerator LittleDelayInShowingLevel(int levelId) {
        yield return new WaitForSeconds(0.5f);
        LevelShower.Instance.ShowLevel(levelId);
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

        AudioManager.Instance.Play("Door Opens", currentAvatar.transform.position);
    }


}
