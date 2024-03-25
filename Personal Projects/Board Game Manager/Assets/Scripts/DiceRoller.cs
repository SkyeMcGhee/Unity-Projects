using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiceRoller : MonoBehaviour
{
    int rollResult;
    int dicePoolNumn;
    int regDicePool;
    public TMP_Text regNum;
  
    // Start is called before the first frame update
    void Start()
    {
      

    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void onRegularEndEdit()
    {
        /* rollResult = Random.Range(1, 10);
         print(rollResult);*/

        if (int.TryParse(regNum.text, out int result))
        {
            regDicePool = result;
            print(regDicePool);
        }


    }
}
