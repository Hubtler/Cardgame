using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : NetworkBehaviour
{
    public GameObject cardPrefab;
    //public GameObject Spawnbereich;
    public string filepathBackside;
    public string dirpathFronts;
    private const int a = 550, b = 230;
    public Material material;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Startmethod from the Playerprefab");
    }

    void Update()
    {
        if (!isLocalPlayer)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ServerClicksButton();
        }

    }

    void HandleMovement()
    {
        if (isLocalPlayer) // Variable aus NetworkBehaviour (Unterklasse von MonoBehaviour), sie prüft, ob die Methode von lokalem Spieler aufgerufen wurde
        {
            /*Color c = material.GetColor("_Color");
            c.r = ((255*c.r+1) % 255 )/255f;
            c.g  = ((255*c.r+2) % 255 )/255f;
            c.b = ((255*c.r+3) % 255 )/255f;
            material.SetColor("_Color", c);*/

        }
    }

    //Karten verteilen am Beispiel

    public void gib10Karten()
    {
        
    }

    //Karte von Spielerhand zur Mitte bewegen am Beispiel von "Karte etwas nach oben bewegen auf Click"
    [Command]
    public void moveCard(GameObject card)
    {
        Vector3 v = card.transform.position;
        v.x += 10;
        card.transform.position = v;
        Debug.Log("ok, karte ist bewegt");
    }


    [Command]
       public void ServerClicksButton()
    {
        System.Random rnd = new System.Random();
        System.IO.DirectoryInfo ParentDirectory = new System.IO.DirectoryInfo("Assets\\Resources\\" + dirpathFronts); // "C:\\Users\\Sascha\\Desktop\\Applapp-Kartenspielprojekt\\cards"
        
        //Debug.Log("Assets\\Resources\\" + dirpathFronts);
        foreach (System.IO.FileInfo f in ParentDirectory.GetFiles())
        {
            Debug.Log(f.Name);
            int i = f.Name.LastIndexOf(".");
            string s = f.Name.Substring(0, i);
            string ft = f.Name.Substring(i+1);
            if (ft == "png")
            {
                GameObject ncard = Instantiate(cardPrefab, new Vector3(rnd.Next(2*a) + 600-a, rnd.Next(2*b) + 300-b, 0), Quaternion.identity);
                //GameObject ncard = Instantiate(cardPrefab, new Vector3(rnd.Next(2*a) + 600-a, rnd.Next(2*b) + 300-b, 0), Quaternion.identity, Spawnbereich.transform);
                cardScript script = ncard.GetComponent<cardScript>();
                script.frontTextureResourceLink = dirpathFronts + "\\" + s;
                script.backTextureResourceLink = filepathBackside;
                script.player = this;                
                NetworkServer.Spawn(ncard);
                script.thisCard = ncard;
            }
            /* Nächste Programmierung: Ein Skript, dass mir aus einem Ordner alle Fronts in eine Stringarray schreibt, und dieses Stringarray kann ich dann anstatt meiner foreach-
             * schleife verwenden, in einer for-schleife
             * Bei einem neuen Kartendeck (z.B. Uno-Karten) muss ich dann nur einen Ordner mit diesen Karten (mit der Struktur: Backside.png und Order mit Fronts) erstellen,
             * das Skript einmal laufen lassen, und den String anpassen.
             * (oder ein Skript schreiben, dass diesen String beim Compilieren erstellt, und bei diesem Script einfügt (z.B. als public variable.)
             * oder stattdessen mit assetbundles arbeiten?
             */
            //ncard.transform.SetParent(Spawnbereich.transform, false);
        }

    }
}
