using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class AddCardScript : NetworkBehaviour
{
    public GameObject cardPrefab;
    //public GameObject Spawnbereich;
    public string filepathBackside;
    public string dirpathFronts;
    private const int a = 550, b = 230;

    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
   [Command]
       public void ServerClicks()
    {
        /*System.Random rnd = new System.Random();
        System.IO.DirectoryInfo ParentDirectory = new System.IO.DirectoryInfo("Assets\\Resources\\" + dirpathFronts); // "C:\\Users\\Sascha\\Desktop\\Applapp-Kartenspielprojekt\\cards"
        Texture backTexture = Resources.Load<Texture>(filepathBackside);
        Debug.Log("TEST");
        Debug.Log("Assets\\Resources\\" + dirpathFronts);
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
                script.backTexture = backTexture;
                Texture frontTexture = Resources.Load<Texture>(dirpathFronts + "\\" + s);      //Problem: pfad ist kein Pfad von Resources sondern einer direkt im Filesystem   
                //Debug.Log(dirpathFronts + "\\" + s);
                script.frontTexture = frontTexture;
                NetworkServer.Spawn(ncard);
            }
            /* Nächste Programmierung: Ein Skript, dass mir aus einem Ordner alle Fronts in eine Stringarray schreibt, und dieses Stringarray kann ich dann anstatt meiner foreach-
             * schleife verwenden, in einer for-schleife
             * Bei einem neuen Kartendeck (z.B. Uno-Karten) muss ich dann nur einen Ordner mit diesen Karten (mit der Struktur: Backside.png und Order mit Fronts) erstellen,
             * das Skript einmal laufen lassen, und den String anpassen.
             * (oder ein Skript schreiben, dass diesen String beim Compilieren erstellt, und bei diesem Script einfügt (z.B. als public variable.)
             * oder stattdessen mit assetbundles arbeiten?
             */
            //ncard.transform.SetParent(Spawnbereich.transform, false);
       // }

    }

    public void OnClick2()
    {
        ServerClicks();        
    }
}
