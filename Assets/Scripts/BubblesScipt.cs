using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblesScipt : MonoBehaviour {

	private ParticleSystem ps;
	public int maxXPosition;
	public int minXPosition;
	public int maxYPosition;

	// Use this for initialization
	void Start () {
		ps = GetComponent<ParticleSystem>();
	}

	/**
	 * @usage It remove the particle that are going outside the boundaries
	 */
	void removeTheParticles ()
	{
		ParticleSystem.Particle[] particles = new ParticleSystem.Particle[ps.particleCount];

		int num = ps.GetParticles(particles);
		while (--num >= 0)
		{
			if (particles[num].position.x > maxXPosition || 
				particles[num].position.x < minXPosition || 
				particles[num].position.y > maxYPosition)
			{
				particles[num].remainingLifetime = 0;
			}
		}

		ps.SetParticles(particles, particles.Length);
	}

	void onClickParticle ()
	{
		
		ParticleSystem.Particle[] particles = new ParticleSystem.Particle[ps.particleCount];

		int num = ps.GetParticles(particles);

		while (--num >= 0)
		{
			var p = particles[num];
			if (Physics.Raycast(p.position, -Vector3.up, 0.1f))
			{
				particles [num].remainingLifetime = 0;

			}
		}
		ps.SetParticles(particles, particles.Length);
	}

	void onMouseClick()
	{
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("onMouseClick");

		}

	}
	
	// Update is called once per frame
	void Update () {

		removeTheParticles();
		onMouseClick ();
	}
}
