using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool altView;
   public CharacterHandler characterSpriteScript;
    CharacterHandler csScript;
    // Start is called before the first frame update
    void Start()
    {
      characterSpriteScript = FindObjectOfType<CharacterHandler>();
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
            characterSpriteScript.SetSprite(1);
            altView = true;
        }
        else
        {
            characterSpriteScript.SetSprite(0);
            altView = false;
        }
    }
}
