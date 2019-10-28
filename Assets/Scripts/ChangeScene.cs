using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string scene;
    public OVRScreenFade[] screenFades;
    public float waitTime;
    private IEnumerator coroutine;
    public bool controllerEnabled;

    // Start is called before the first frame update
    void Start()
    {
        if (controllerEnabled) 
            InputSystem.onAButtonPressed += UpdateScene;
    }

    private void UpdateScene()  {
        Debug.Log("starting transition...");
        List<GameObject> gol = new  List<GameObject>();
        Scene Curscene = SceneManager.GetActiveScene();
        Curscene.GetRootGameObjects(gol);
        Debug.Log("all  objecst in  scene:");
        foreach(GameObject gameObject in gol){
            Debug.Log(gameObject.name);
        }
        Debug.Log("all objects printed...");
        StartCoroutine(startUpdatingScene(waitTime));
        //SceneManager.LoadScene(scene);
    }

    IEnumerator startUpdatingScene(float waitTime) {
        Debug.Log("courutine started...");
        if(screenFades[0] == null) {
            Debug.Log("missing the objects!!!");
            screenFades = FindObjectsOfType<OVRScreenFade>();
            Debug.Log(screenFades[0]);
            Debug.Log(screenFades[1]);
        }
        foreach (OVRScreenFade sf in screenFades)
        {
            sf.FadeOut();
        }
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(scene);
    }

    void OnDisable()
    {
        Debug.Log("PrintOnDisable: "+ this.name +" was disabled");
        InputSystem.onAButtonPressed -= UpdateScene;
    }

}
