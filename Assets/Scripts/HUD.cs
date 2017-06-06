using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

	public Text distanceLabel, velocityLabel;

	public void SetValues (float distanceTraveled, float velocity) {
		distanceLabel.text = ((int)(distanceTraveled * 10f)).ToString() + "Gigameters";
		velocityLabel.text = ((int)(velocity * 10f)).ToString() + "Mm/s";
	}
}