using UnityEngine;
using System.Collections;

public class Typer : MonoBehaviour {

	private CodeReader codereader;
	public TextMesh text;
	private bool flipFlop = false;

	// Use this for initialization
	void Start () {
		codereader = new CodeReader();
		text = this.GetComponent<TextMesh> ();
		if(codereader.Load("Assets/codeTyping Assets/CodeReader.cs"))
		{
			print ("Loaded.");
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
				text.text = text.text + " " + str;
			}
		}
		if(Input.GetKeyDown(KeyCode.PageDown))
		{
			this.transform.Translate(new Vector3(0,1.0f,0));
		}
		
	}
}
