using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public struct Table
    {
        public string collection_Diarytype;
        public string collection_List;
        public string collection_Text;
        public string collection_Image;

    }

public class DataRead : MonoBehaviour
{
    private static DataRead instance = null;
    public Dictionary<string, string> stringTable = new Dictionary<string, string>();
    public Dictionary<int, Table> diaryTable = new Dictionary<int, Table>();


    
    private void Awake()
    {
        if(null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        stringTable = CSVReader.Read("StringTable");
       


    }


    public static DataRead Instance
    {
        get
        {
            if(null == instance)
            {
                return null;
            }
            return instance;
        }
    }


    
}
