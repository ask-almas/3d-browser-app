using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.IO;

public class LinkHandler : MonoBehaviour
{

	public string url="";

	public void setText(string t)
	{
		if (t.Length > 10)
		{
			t = t.Substring (0, 10);
		}
		this.GetComponentInChildren<TextMesh>().text = t;
	}

	public void setUrl(string u)
	{
		this.url = u;
	}

	void OnMouseDown()
	{
		Debug.Log (url);
		WWW www = new WWW (url);
		StartCoroutine (WaitForRequest(www));
	}

	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;

		// check for errors
		if (www.error == null)
		{
			string result = www.text;
			GameObject[] gameObjects = GameObject.FindGameObjectsWithTag ("History");
			GameObject last = InputController.findLast (gameObjects);

			if(gameObject.tag=="History")
			{
				InputController.DestroyAllLinks ();
				CreateLink.Create (gameObject, -200, 5, last.transform.position.z+100, result);
			}
			else
			{
				gameObject.tag="History";
				float z = gameObject.transform.position.z+100;
				InputController.DestroyAllLinks ();
				CreateLink.Create (gameObject, -200, 5, z, result);
			}

		}
		else
		{
			Debug.Log("WWW Error: "+ www.error);
		}  
	}

	void Update () 
	{
		transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
	}
}