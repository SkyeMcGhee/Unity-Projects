using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool altView;
   public GameObject characterSpriteScript;
    CharacterHandler csScript;
    // Start is called before the first frame update
    void Start()
    {
      CharacterHandler csScript = characterSpriteScript.GetComponent<CharacterHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            onTabPress(altView);
        }
    }

    public void onTabPress(bool altView)
    {
        if (altView == false)
        {
            csScript.SetSprite(1);
            altView == true;
        }
        else
        {
            csScript.SetSprite(0);
            altView == false;
        }
    }
}
