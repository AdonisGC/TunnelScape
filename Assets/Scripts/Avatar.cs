using UnityEngine;

public class Avatar : MonoBehaviour {

	public ParticleSystem shape, trail, burst;
    public GameObject ship;
	private Player player;

	public float deathCountdown = -1f;

	private void Awake () {
		player = transform.root.GetComponent<Player>();
        ship = GameObject.Find("StarShip");
        MeshRenderer render = ship.GetComponent<MeshRenderer>();
        render.enabled = true;
    }

	private void OnTriggerEnter (Collider collider) {
		if (deathCountdown < 0f) {
			shape.enableEmission = false;
			trail.enableEmission = false;
            ship = GameObject.Find("StarShip");
            MeshRenderer render = ship.GetComponent<MeshRenderer>();
            render.enabled = false;
            burst.Emit(burst.maxParticles);
			deathCountdown = burst.startLifetime;
		}
	}
	
	private void Update () {
		if (deathCountdown >= 0f) {
			deathCountdown -= Time.deltaTime;
			if (deathCountdown <= 0f) {
				deathCountdown = -1f;
				shape.enableEmission = true;
				trail.enableEmission = true;
				player.Die();
			}
		}
	}
}