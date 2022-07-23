using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using UnityEngine;

public class Launcher : MonoBehaviourPunCallbacks
{

    private string gameVersion = "1";

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    void Start()
    {
        Connect();
        Disconnect();

        StartCoroutine(DisconnectCoroutine());
    }

    IEnumerator DisconnectCoroutine()
    {
        const float seconds = 60f; 
        yield return new WaitForSeconds(seconds);

        Disconnect();
    }

    private void Connect()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else 
        {
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = gameVersion;
        }
    }

    private void Disconnect()
    {
        if (!PhotonNetwork.IsConnected)
            return;

        PhotonNetwork.Disconnect();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster was called by PUN");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();

        Debug.Log($"joined lobby: {PhotonNetwork.InLobby}");
        PhotonNetwork.JoinOrCreateRoom("theRoom", new RoomOptions 
        { 
            MaxPlayers  = 4, 
            IsVisible = true
        }, TypedLobby.Default);
    }


    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log($"OnJoinedRoom: {PhotonNetwork.InRoom}");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause);

        Debug.Log(
            $"Photon server is disconnected. Cause is: {cause.ToString()}");
    }



}
