using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartLevelTwo : MonoBehaviour {

    public Button btn;
    // Use this for initialization
    void Start () {
		
        btn.onClick.AddListener(LoadLevel);
    }
	
    // Update is called once per frame
	
    private void LoadLevel()
    {
        SceneManager.LoadScene("LevelTwo");
	
    }
}
