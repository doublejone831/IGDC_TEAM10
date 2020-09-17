using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBaseManager : MonoBehaviour{

    static public DataBaseManager instance;

    public List<ItemData> ItemList = new List<ItemData> ();

    public List<JournalData> JournalList = new List<JournalData>();
    

    void Start()
    {
        
    }

    // Update is called once per frame
 
}
