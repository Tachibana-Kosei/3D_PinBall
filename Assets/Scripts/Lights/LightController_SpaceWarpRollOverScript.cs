using UnityEngine;

namespace Lights
{
	public class LightController_SpaceWarpRollOverScript : LightController_BasicScript{
		public Material lightingMaterial;
		public Material unlightingMaterial;
		private MeshRenderer meshRenderer;
	
		protected override void Start(){
			base.Start();
			meshRenderer = GetComponent<MeshRenderer>();
			meshRenderer.material = unlightingMaterial;
		}

		private void OnTriggerEnter(Collider other) {
			if (other.CompareTag("Ball")) {
				childrenScript.ForEach(x => x.SetLight(true));
				meshRenderer.material = lightingMaterial;
			}
		}
		private void OnTriggerExit(Collider other) {
			if (other.CompareTag("Ball")) {
				meshRenderer.material = unlightingMaterial;
			}
		}
	}
}
