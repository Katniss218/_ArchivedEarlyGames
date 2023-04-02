using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelTank : MonoBehaviour
{
	public float maxFuel;
	public float currentFuel { get; private set; }

	private void Awake()
	{
		currentFuel = maxFuel;
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public bool ConsumeFuel(float amt )
	{
		this.currentFuel -= amt;
		if( this.currentFuel <= 0 )
		{
			this.currentFuel = 0;
			return false;
		}
		return true;
	}
}
