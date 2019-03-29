using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{

    public Animator transitionAnim;
    public string sceneName;


    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag== "Player")
        {
            StartCoroutine(LoadScene());
        }

    }



    IEnumerator LoadScene()
    {
        
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        int nextBuildIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextBuildIndex);
        //SceneManager.LoadScene(sceneName);
    }



}
