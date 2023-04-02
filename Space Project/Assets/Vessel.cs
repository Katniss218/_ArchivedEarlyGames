using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vessel : MonoBehaviour
{
	public Engine[] engines;
	public Rigidbody rb;

	private Vector3 localThrustVector;
	private Vector3 localThrustPosition;
	public Text text;

	public float currAtmoDensity = 1;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if( Input.GetKey( KeyCode.Space ) )
		{
			for( int i = 0; i < engines.Length; i++ )
				engines[i].Ignite();
		}
		if( Input.GetKey( KeyCode.Z ) )
		{
			currAtmoDensity -= 0.01f;
			currAtmoDensity = Mathf.Clamp01( currAtmoDensity );
			for( int i = 0; i < engines.Length; i++ )
			{
				engines[i].visualEffect.SetFloat( "CurrentAtmoDensity", currAtmoDensity );
			}
		}
		if( Input.GetKey( KeyCode.X ) )
		{
			currAtmoDensity += 0.01f;
			currAtmoDensity = Mathf.Clamp01( currAtmoDensity );
			for( int i = 0; i < engines.Length; i++ )
			{
				engines[i].visualEffect.SetFloat( "CurrentAtmoDensity", currAtmoDensity );
			}
		}
		text.text = "TWR: " + localThrustVector.magnitude / rb.mass + "Vel: " + rb.velocity.magnitude + " m/s";
	}

	private void FixedUpdate()
	{
		localThrustVector = Vector3.zero;
		localThrustPosition = Vector3.zero;
		for( int i = 0; i < engines.Length; i++ )
		{
			localThrustVector += engines[i].localThrustVector;
			localThrustPosition += engines[i].transform.localPosition;
		}
		localThrustPosition /= engines.Length;

		rb.AddForceAtPosition( this.transform.position + localThrustVector, this.transform.position + localThrustPosition );
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawCube( this.transform.position + localThrustPosition, new Vector3( 1, 1, 1 ) );
		Gizmos.DrawLine( this.transform.position + localThrustVector, this.transform.position + localThrustPosition );
	}
}
