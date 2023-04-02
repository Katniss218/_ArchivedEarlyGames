using UnityEngine;
using UnityEngine.Experimental.VFX;

public class Engine : MonoBehaviour
{
	public float maxThrust = 50;
	public bool isIgnited { get; private set; }
	private Vector3 localThrustTransform = new Vector3( 0, 1, 0 );

	public FuelTank fuelTank;

	public Vector3 localThrustVector { get
		{
			return isIgnited ? maxThrust * localThrustTransform : Vector3.zero;
		} }

    // Start is called before the first frame update
    void Start()
    {
		Shutdown();
    }

	public VisualEffect visualEffect;
	
	// Update is called once per frame
	void Update()
	{
		

		if( !isIgnited )
			return;
		if( !fuelTank.ConsumeFuel( fuelConsumptionPerSec * Time.deltaTime ) )
		{
			Shutdown();
		}
    }

	public void Ignite()
	{
		this.isIgnited = true;
		visualEffect.Reinit();
	}

	public void Shutdown()
	{
		this.isIgnited = false;
		visualEffect.Stop();

	}

	public float fuelConsumptionPerSec { get
		{
			return this.maxThrust * 0.75f;
		} }
}
