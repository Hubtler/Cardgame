using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class OwnNetworkManager : NetworkManager
{
    private int nr;
    public override void OnStartServer()
    {
        //base.OnStartServer();
        Debug.Log("Server started!");
        nr = 0;
    }

    public override void OnStopServer()
    {
        //base.OnStopServer();
        Debug.Log("Server stopped!");
    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        //base.OnClientConnect(conn);
        Debug.Log($"Spieler {nr} joined");
        nr = (nr+1)%4; // die Nummer für den nächsten Spieler vorbereiten        
    }

    public override void OnClientDisconnect(NetworkConnection conn)
    {
        //base.OnClientDisconnect(conn);
        Debug.Log("Spieler disconnected");
    }
}

