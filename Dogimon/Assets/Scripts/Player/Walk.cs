using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetAxisRaw("Horizontal") < 0)
			transform.Translate(Vector3.left * Time.deltaTime * 10);
		if (Input.GetAxisRaw("Horizontal") > 0)
			transform.Translate(Vector3.right * Time.deltaTime * 10);
		if (Input.GetAxisRaw("Vertical") < 0)	
			transform.Translate(Vector3.down * Time.deltaTime * 10);
		if (Input.GetAxisRaw("Vertical") > 0)
			transform.Translate(Vector3.up * Time.deltaTime * 10);
	}
}
