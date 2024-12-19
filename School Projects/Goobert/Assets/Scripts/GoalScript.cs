using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
      
        if (other.gameObject.tag == "Player")
        {
           
            //check current scene and load next
            Scene curScene = SceneManager.GetActiveScene();
            int curSceneIndex = curScene.buildIndex;
            int nextSceneIndex = curSceneIndex + 1;

            SceneManager.LoadScene(nextSceneIndex);
           
            
        }
    }
}
