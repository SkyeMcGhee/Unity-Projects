using UnityEngine;
using TMPro;
using System.Collections;

public class NodeCollider : MonoBehaviour
{
    public int nodeID;
    string nodeText;
    public DialogueHandler DialogueHandler;
    public GameObject textCanv;
    public TMP_Text text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textCanv.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (textCanv.active)
        {
            StartCoroutine(RemoveAfterSeconds(2));
        }
    }

    IEnumerator RemoveAfterSeconds(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        textCanv.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        nodeText = DialogueHandler.GetText(nodeID);
        Debug.Log(nodeText);

        text.text = nodeText;

        textCanv.SetActive(true);
    }
}
