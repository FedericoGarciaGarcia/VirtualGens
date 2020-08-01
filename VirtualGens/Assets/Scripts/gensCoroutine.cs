using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System.Threading;

public class gensCoroutine : MonoBehaviour {

	[DllImport("gens", EntryPoint="Hello")]
	public static extern int Hello();
	
	[DllImport("gens", EntryPoint="Init")]
	public static extern void Init();
	
	[DllImport("gens", EntryPoint="RunFrame")]
	public static extern void RunFrame();
	
	[DllImport("gens", EntryPoint="End")]
	public static extern void End();
	
	bool runGens;
	bool runFrame;
	
	IEnumerator GensInit()
    {
        Init();
		
        yield return null;
    }
	
	IEnumerator GensRunFrame()
    {
        RunFrame();

        yield return null;
    }
	
	IEnumerator GensEnd()
    {
        End();

        yield return null;
    }
	
	void Start() {
		IEnumerator coroutineStart = GensInit();
        StartCoroutine(coroutineStart);
	}
	
	void Update() {
		if(Input.GetButton("Run")) {
			IEnumerator coroutineStart = GensRunFrame();
			StartCoroutine(coroutineStart);
			transform.Rotate(new Vector3(0, 180*Time.deltaTime, 0));
		}
		
		if(Input.GetButton("Exit")) {
			IEnumerator coroutineStart = GensEnd();
			StartCoroutine(coroutineStart);
			Application.Quit();
		}
	}
}
