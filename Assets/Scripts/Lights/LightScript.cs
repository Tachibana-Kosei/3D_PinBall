using UnityEngine;

namespace Lights
{
	public class LightScript : MonoBehaviour {
		public Material lightingMaterial;
		public Material unlightingMaterial;
		public bool isLight = false;
		private MeshRenderer thisMeshRenderer;

		private void Start() {
			thisMeshRenderer = GetComponent<MeshRenderer>();
			SetLight(isLight);
		}

		private void Update() {
		}

		//引数のbool型で点灯状態を変える。trueで点灯。
		public void SetLight(bool isLight) {
			this.isLight = isLight;
			if (isLight) {
				thisMeshRenderer.material = lightingMaterial;
			} else {
				thisMeshRenderer.material = unlightingMaterial;
			}
		}

		//呼び出されると、自分の点灯or消灯を切り替える。
		public void ToggleLight() {
			isLight = !isLight;
			if (isLight) {
				thisMeshRenderer.material = lightingMaterial;
			} else {
				thisMeshRenderer.material = unlightingMaterial;
			}
		}

		//デバッグ用メソッド
		public void RandomToggle() {
			if (Random.Range(0, 600) == 0) {
				SetLight(!isLight);
			}
		}
	}
}