using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class CSVReader
{
    static string SPLIT_RE = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
    static string LINE_SPLIT_RE = @"\r\n|\r";
    static char[] TRIM_CHARS = { '\"' };

    public static Dictionary<string, string>Read(string file)
    {
        var dictionaryData = new  Dictionary <string, string>();
        TextAsset data = Resources.Load("StringTable/"+file) as TextAsset;

        var lines = Regex.Split(data.text, LINE_SPLIT_RE);

        if (lines.Length <= 1) return dictionaryData;

        var header = Regex.Split(lines[0], SPLIT_RE);

        var entry = new Dictionary<string, string>();

        for (var i = 0; i < lines.Length; i++)
        {
            var values = Regex.Split(lines[i], SPLIT_RE);
            if (values.Length == 0 || values[0] == "") continue;

            dictionaryData.Add(values[0], values[1]);
        }

        return dictionaryData;
    }

    public static Dictionary<string, Table> ReadCollection(string file)
    {
        var dictionaryData = new Dictionary<string, Table>();
        TextAsset data = Resources.Load("StringTable/" + file) as TextAsset;

        var lines = Regex.Split(data.text, LINE_SPLIT_RE);

        if (lines.Length <= 1) return dictionaryData;

        var header = Regex.Split(lines[0], SPLIT_RE);

        var entry = new Dictionary<string, Table>();

        Table table = new Table();
        for (var i = 0; i < lines.Length; i++)
        {
            var values = Regex.Split(lines[i], SPLIT_RE);
            if (values.Length == 0 || values[0] == "") continue;
           // table.collection_Image = "asda";
            dictionaryData.Add(values[0], table);
        }

        return dictionaryData;
    }
}

