using System.Collections;
using System.Collections.Generic;
using System.IO;
using Packages.Rider.Editor.UnitTesting;
using TMPro;
using UnityEngine;

public class LevelParserStarter : MonoBehaviour
{
    public string filename;

    public GameObject Rock;

    public GameObject Brick;

    public GameObject QuestionBox;

    public GameObject Stone;

    public Transform parentTransform;

    public TextMeshProUGUI timer;
    public float timeDown = 400;


    // Start is called before the first frame update
    void Start()
    {
        RefreshParse();
    }


    private void Update()
    {
        timeDown -= Time.deltaTime;
        timer.text = (timeDown).ToString("0");
        if(timeDown == 0)
        {
            endgame();
        }

    }

    public void endgame()
    {
        Application.Quit();
    }

    private void FileParser()
    {
        //string fileToParse = string.Format("{0}{1}{2}.txt", Application.dataPath, "/Resources/", filename);

        string fileToParse = "Assets/Resources/Test.txt";
        Debug.Log("spawning1");


        using (StreamReader sr = new StreamReader(fileToParse))
        {
            string line = "";
            int row = 0;

            while ((line = sr.ReadLine()) != null)
            {
                int column = 0;
                char[] letters = line.ToCharArray();
                foreach (var letter in letters)
                {
                    
                    Debug.Log(letter);

                    //var in = new Vector3(, row, column);
                    
                    
                    //Call SpawnPrefab
                    
                    //SpawnPrefab(letter, );
                    
                    row++;
                    column++;
                }

            }

            sr.Close();
        }
    }

    private void SpawnPrefab(char spot, Vector3 positionToSpawn)
    {
        GameObject ToSpawn;

        switch (spot)
        {
            case 'b': Debug.Log("Spawn Brick"); break;
            case '?': Debug.Log("Spawn QuestionBox"); break;
            case 'x': Debug.Log("Spawn Rock"); break;
            case 's': Debug.Log("Spawn Rock"); break;
            //default: Debug.Log("Default Entered"); break;
            default: return;
                //ToSpawn = //Brick;       break;
        }

        //ToSpawn = GameObject.Instantiate(ToSpawn, parentTransform);
        //ToSpawn.transform.localPosition = positionToSpawn;
    }

    public void RefreshParse()
    {
        GameObject newParent = new GameObject();
        newParent.name = "Environment";
        newParent.transform.position = parentTransform.position;
        newParent.transform.parent = this.transform;
        
        if (parentTransform) Destroy(parentTransform.gameObject);

        parentTransform = newParent.transform;
        FileParser();
    }
}
