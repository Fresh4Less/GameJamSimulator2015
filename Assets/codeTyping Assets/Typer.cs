using UnityEngine;
using System.Collections;

public class Typer : MonoBehaviour {

	CodeReader codereader;

	// Use this for initialization
	void Start () {
		codereader = new CodeReader();
		if(codereader.Load("Assets/codeTyping Assets/CodeReader.cs"))
		{
			print ("Loaded");
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown)
		{
			string str = "";
			Color color = Color.white;
			if(codereader.TryReadWord(out str,out color))
			{
				print(str + " : " + color.ToString());
			}
		}
		
	}
}
