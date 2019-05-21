using UnityEngine;
using System.Collections;

public class CreateLink: MonoBehaviour 
{
	
	public static void Create(GameObject obj, float x, float y, float z, string result)
	{
		if(z<500)
		{
			foreach (LinkItem i in LinkFinder.Find(result)) 
			{
				GameObject clone =  Instantiate (obj, new Vector3 (x, y, z), obj.transform.rotation);
				clone.GetComponent<LinkHandler> ().setText (i.Text);
				clone.GetComponent<LinkHandler> ().setUrl (i.Href);
				clone.GetComponent<LinkHandler> ().enabled=true;
				clone.tag="LinkTag";
				x += 100;

				if (x >= 250)
				{
					z += 100;
					x = -200;
					if(z>500)
					{
						break;
					}
				}
			}
		}
	}
}
