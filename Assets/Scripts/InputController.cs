using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;
using UnityEngine.Networking;
using System.Net;

public class InputController : MonoBehaviour 
{

	public GameObject obj;

	public void Button_Click(InputField url)
	{
		string link = url.text;
		WWW www = new WWW (link);
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
			GameObject clone;

			if (gameObjects.Length == 0)
			{
				clone = Instantiate (obj, new Vector3 (0, 5, -350), obj.transform.rotation);
			} 
			else 
			{
				DestroyAllLinks ();
				GameObject last = findLast (gameObjects);
				clone = Instantiate (obj, new Vector3 (0, 5, last.transform.position.z+100), obj.transform.rotation);
			}

			string w = www.url;
			w = w.Replace ("https", "");
			w = w.Replace ("http", "");
			w = w.Replace ("www.","");
			w = w.Replace ("://","");
			clone.GetComponent<LinkHandler> ().setText (www.url.Replace("http://",""));
			clone.GetComponent<LinkHandler> ().setUrl (www.url);
			clone.GetComponent<LinkHandler> ().enabled = true;
			clone.tag = "History";

		}
		else
		{
			Debug.Log("WWW Error: "+ www.error);
		}  
	}

	public static void DestroyAllLinks()
	{
		GameObject[] gameObjects = GameObject.FindGameObjectsWithTag ("LinkTag");
		for(var i = 0 ; i < gameObjects.Length ; i ++)
		{
			Destroy(gameObjects[i]);
		}
	}

	public static GameObject findLast(GameObject[] objects)
	{
		GameObject lst = objects [0];
		for(var i = 0 ; i < objects.Length ; i ++)
		{
			if (objects [i].transform.position.z>lst.transform.position.z)
			{
				lst = objects [i];
			}
		}
		return lst;
	}
}