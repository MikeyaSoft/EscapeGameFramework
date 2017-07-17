using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : SingletonMonoBehaviour<SceneManager> {
	public void GoToTitle(){
		//TODO 定数化
		Application.LoadLevel ("B_title");
	}
	public void GoToMainGame(){
		//TODO 定数化
		Application.LoadLevel ("C_MainGame");
	}
}
