using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Es.InkPainter;

public class PainterTest : MonoBehaviour{
[SerializeField]
	private Brush brush;

	void Update(){
		if(Input.GetMouseButton(0)){
			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitInfo;
			if(Physics.Raycast(ray, out hitInfo)){
				var paintObject = hitInfo.transform.GetComponent<InkCanvas>();
				if(paintObject != null)
					paintObject.Paint(brush, hitInfo);
			}
		}
	}
}
