using JetBrains.Annotations;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class DialogueHandler : MonoBehaviour
{
    public TextAsset csvFile;
    public List<Node> nodes = new List<Node>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var lines = Regex.Split(csvFile.text, "\n|\r|\r\n");
        foreach (var line in lines)
        {
            if (line.Length > 0)
            {
                var columns = line.Split(',');
                var ID = int.Parse(columns[0]);
                var text = columns[1];

                nodes.Add(new Node(text, ID));
            }
        }

        for (int i = 0; i < nodes.Count; i++)
        {
            Debug.Log(nodes[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetText(int id)
    {
       
            foreach (var node in nodes)
            {
                if (node.ID == id)
                { return node.text; }

            }
        
     return null;

    }

}

public class Node
{
    
    public string text;
    public int ID;

    public Node(string text, int ID)
    {
       
        this.text = text;
        this.ID = ID;
        
    }
}
