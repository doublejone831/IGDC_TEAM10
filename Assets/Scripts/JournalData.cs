using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class JournalData {

    public int journal_ID;
    public bool JournalSwitch;
    public string JournalContant;
   
    public JournalData( int _journal_ID, string _JournalContant){
    journal_ID = _journal_ID;
    JournalSwitch = false;
    JournalContant =_JournalContant;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
 
}
