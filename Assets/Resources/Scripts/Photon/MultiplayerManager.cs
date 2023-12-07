using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class MultiplayerManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField roomName, password;

    void Start()
    {
        // Connect to Photon servers using settings
        PhotonNetwork.ConnectUsingSettings();
    }

    // Callback when connected to Photon servers
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Photon servers!");
    }

    public void JoinOrCreateRoom()
    {
        RoomOptions roomOptions = new() { MaxPlayers = 4 }; // Set your max player count here
        PhotonNetwork.JoinOrCreateRoom(roomName.text, roomOptions, TypedLobby.Default);
    }

    // Callback when joined a room
    public override void OnJoinedRoom()
    {
        Debug.Log("Joined room: " + PhotonNetwork.CurrentRoom.Name);

        // Instantiate player prefab
        Vector3 spawnPosition = new(); // Set your spawn position here
        PhotonNetwork.Instantiate("Prefabs/PlayerPrefab", spawnPosition, Quaternion.identity, 0);
    }

    // Callback when failed to join a room
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join room: " + message);
        CreateRoom();
    }

    void CreateRoom()
    {
        RoomOptions roomOptions = new() { MaxPlayers = 4 }; // Set your max player count here
        PhotonNetwork.CreateRoom(roomName.text, roomOptions, TypedLobby.Default);
    }

    // Callback when created a room
    public override void OnCreatedRoom()
    {
        Debug.Log("Created room: " + PhotonNetwork.CurrentRoom.Name);
    }

    // Callback when disconnected from Photon servers
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconnected from Photon servers: " + cause.ToString());
    }

    public void JoindRandom()
    {
        PhotonNetwork.JoinRandomOrCreateRoom();
    }

    public void Disconnect()
    {
        if (PhotonNetwork.IsConnected) PhotonNetwork.Disconnect();
    }

    // Other callbacks can be implemented as needed (e.g., OnPlayerEnteredRoom, OnPlayerLeftRoom, etc.)
}