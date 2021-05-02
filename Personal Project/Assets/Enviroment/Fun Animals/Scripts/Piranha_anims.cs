using UnityEngine;
using System.Collections;

public class Piranha_anims : MonoBehaviour {

	public ParticleSystem bubblesParticle_swim ;
	public ParticleSystem bubblesParticle_bite ;
	public ParticleSystem waveParticle ;
	
	Animator animator ;
	
	private ParticleSystem inst_waveParticle ;

	// Use this for initialization
	void Start () {

		animator = GetComponent<Animator>() ;

	}

	// Functions for enable/disable the bubbles particle system associated to swim animation
	void EnableParticle_bubblesSwim () {
		bubblesParticle_swim.Play() ;
	}
	void DisableParticle_bubblesSwim () {
		bubblesParticle_swim.Stop() ;
	}

	// Functions for enable/disable the bubbles particle system associated to bite and jumpBite animations
	void EnableParticle_bubblesBite () {
		bubblesParticle_bite.Play() ;
	}
	void DisableParticle_bubblesBite () {
		bubblesParticle_bite.Stop() ;
	}

	// Function for disable all particle system associated to swim, bite and jumpBite animation
	void DisableParticle_all () {
		bubblesParticle_swim.Stop() ;
		bubblesParticle_bite.Stop() ;
	}

	// Function for instantiate and enable the wave particle system to jumpBite animation
	void EnableParticle_wave () {
		var temp_root = transform.Find ("root");
		inst_waveParticle = Instantiate (waveParticle, temp_root.transform.position, temp_root.transform.rotation) as ParticleSystem;
		inst_waveParticle.Play() ;
		Destroy(inst_waveParticle.gameObject, 1.5f) ;
	}

}
