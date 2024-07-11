using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ControlSpaw : MonoBehaviour
{
    public GameObject gameObjectSpaw;
    public GameObject gameObjectSpaw1;
    public GameObject gameObjectSpaw2;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 250)
        { 
          gameObjectSpaw.SetActive(false);
          gameObjectSpaw1.SetActive(true);
        }
        if(time >400)
        {
            gameObjectSpaw1.SetActive(false);
            gameObjectSpaw2.SetActive(true);
        }
    }
}
