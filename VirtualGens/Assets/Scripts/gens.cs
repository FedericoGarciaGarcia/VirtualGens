using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System.Threading;

public class gens : MonoBehaviour {

	[DllImport("gens", EntryPoint="Hello")]
	public static extern int Hello();
	
	[DllImport("gens", EntryPoint="Init")]
	public static extern void Init();
	
	[DllImport("gens", EntryPoint="RunFrame")]
	public static extern void RunFrame();
	
	[DllImport("gens", EntryPoint="End")]
	public static extern void End();
	
	[DllImport("gens", EntryPoint="GetMD_ScreenCopyUShort")]
	public static extern void GetMD_ScreenCopyUShort(ushort [] ptr);
	
	[DllImport("gens", EntryPoint="GetMD_ScreenCopyByte")]
	public static extern void GetMD_ScreenCopyByte(byte [] ptr);
	
	[DllImport("gens", EntryPoint="UpdateButtons")]
	public static extern void UpdateButtons(
	int lup_1, int ldown_1, int lleft_1, int lright_1, int la_1, int lb_1, int lc_1, int lx_1, int ly_1, int lz_1, int lstart_1, int lmode_1,
	int lup_2, int ldown_2, int lleft_2, int lright_2, int la_2, int lb_2, int lc_2, int lx_2, int ly_2, int lz_2, int lstart_2, int lmode_2
	);
	
	[DllImport("gens", EntryPoint="SetFrameSkip")]
	public static extern int SetFrameSkip(int n);
	
	bool run;
	bool end;
	bool stop;
	readonly object access_MD_Screen = new object();
	Texture2D texture;
	Renderer renderer;
	Color[] colors;
	ushort[] MD_Screen;
	byte[] MD_ScreenBytes;
	
	int [] controls1;
	
	/*
	IEnumerator StartGens(float Count){
		yield return new WaitForSeconds(Count); //Count is the amount of time in seconds that you want to wait.
		
		Thread thread = new Thread(delegate() {
			Init();
		
			while(run) {
				RunFrame();
				lock(access_MD_Screen) {
					GetMD_ScreenCopyUShort(MD_Screen);
					Buffer.BlockCopy(MD_Screen, 0, MD_ScreenBytes, 0, 336 * 240 * 2);
				}
			}
			
			End();
		});
		thread.IsBackground = true;
		thread.Start();
		
		yield return null;
	}*/
	
	void Start() {
		QualitySettings.vSyncCount = 0;  // VSync must be disabled
		Application.targetFrameRate = 60;
		
		run = true;
		end = false;
		stop = false;
		
		controls1 = new int[12];
		
		for(int i=0; i<12; i++)
			controls1[i] = 1;
		
		renderer = GetComponent<Renderer>();
		
		texture = new Texture2D(336, 240, TextureFormat.RGB565, false);
		texture.filterMode = FilterMode.Trilinear;
		
		colors  = new Color[336 * 240];
		MD_Screen      = new ushort[336 * 240];
		MD_ScreenBytes = new byte[336 * 240 * 2];
				
		// StartCoroutine("StartGens", 2);
		Init();
		SetFrameSkip(-2);
	}
	
	void Update() {
		Cursor.visible = false;
		
		if(run) {
			UpdateController();
			
			RunFrame();
			//GetMD_ScreenCopyUShort(MD_Screen);
			//Buffer.BlockCopy(MD_Screen, 0, MD_ScreenBytes, 0, 336 * 240 * 2);
			GetMD_ScreenCopyByte(MD_ScreenBytes);

			UpdateTexture();
		}
		
		/*if(Input.GetButton("Quit")) {
			End();
			Application.Quit();
		}*/
	}
	
	void UpdateController() {
		controls1[0]  = Input.GetButton("Up") ? 0 : 1;
		controls1[1]  = Input.GetButton("Down") ? 0 : 1;
		controls1[2]  = Input.GetButton("Left") ? 0 : 1;
		controls1[3]  = Input.GetButton("Right") ? 0 : 1;
		controls1[4]  = Input.GetButton("A") ? 0 : 1;
		controls1[5]  = Input.GetButton("B") ? 0 : 1;
		controls1[6]  = Input.GetButton("C") ? 0 : 1;
		controls1[7]  = Input.GetButton("X") ? 0 : 1;
		controls1[8]  = Input.GetButton("Y") ? 0 : 1;
		controls1[9]  = Input.GetButton("Z") ? 0 : 1;
		controls1[10] = Input.GetButton("Start") ? 0 : 1;
		controls1[11] = Input.GetButton("Mode") ? 0 : 1;
		
		UpdateButtons(controls1[0], controls1[1], controls1[2], controls1[3], controls1[4], controls1[5], controls1[6], controls1[7], controls1[8], controls1[9], controls1[10], controls1[11],
		1,1,1,1,1,1,1,1,1,1,1,1
		);
	}
	
	void UpdateTexture() {
		texture.LoadRawTextureData (MD_ScreenBytes);
		texture.Apply();
		
		renderer.material.SetTexture("_MainTex", texture);
		//renderer.material.SetTexture("_EmissionMap", texture);
	}
}
