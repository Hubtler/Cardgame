using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class cardScript : NetworkBehaviour
{
    [SyncVar]
    public string frontTextureResourceLink, backTextureResourceLink;
    [SyncVar]
    public PlayerScript player;
    [SyncVar]
    public GameObject thisCard;

    void Start()
    {
        LoadTextureAndSet();
    }

    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            onDragBeginning();
        }
 }

    public void onDragBeginning()
    {
        Debug.Log("bewege bitte die Karte");
        player.moveCard(thisCard);
    }

    public void LoadTextureAndSet()
    {
        Texture frontTexture = Resources.Load<Texture>(frontTextureResourceLink); 
        Texture backTexture = Resources.Load<Texture>(backTextureResourceLink);
        setTexture(frontTexture, backTexture);
    }

    private void setTexture(Texture frontTexture, Texture backTexture)
    {
        Renderer backRenderer = transform.Find("Back").GetComponent<Renderer>();
        Renderer frontRenderer = transform.Find("Front").GetComponent<Renderer>();

        backRenderer.material.SetTexture("_MainTex", backTexture);
        frontRenderer.material.SetTexture("_MainTex", frontTexture);
    }
}
