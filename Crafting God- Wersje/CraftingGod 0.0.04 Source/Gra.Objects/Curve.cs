namespace Gra.Objects;

public class Curve
{
	public float MinValue;

	public float MaxValue;

	public static float GetValue(float MaxValue, float Value)
	{
		return MaxValue / Value;
	}

	public Curve(float MinValue, float MaxValue)
	{
		this.MinValue = MinValue;
		this.MaxValue = MaxValue;
	}
}
