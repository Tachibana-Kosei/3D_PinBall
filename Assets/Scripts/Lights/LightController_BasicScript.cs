using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Lights
{
	public abstract class LightController_BasicScript : ControllerBasicScript {
		public List<GameObject> childrenLight;
		public List<LightScript> childrenScript;

		protected override void Start() {
			base.Start();
			childrenLight = GetComponentsInChildren<Transform>().Where(x=>x.GetComponent<LightScript>()).Select(x => x.gameObject).ToList();
			float disX = childrenLight.Max(x => x.transform.position.x) - childrenLight.Min(x => x.transform.position.x);
			float disZ = childrenLight.Max(x => x.transform.position.z) - childrenLight.Min(x => x.transform.position.z);
			if (disX > disZ) {
				childrenLight= childrenLight.OrderBy(x => x.transform.position.x).ToList();
			} else {
				childrenLight= childrenLight.OrderBy(x => x.transform.position.z).ToList();
			}
			childrenScript = childrenLight.Select(x => x.GetComponent<LightScript>()).ToList();
		}

		protected virtual void Update()
		{
			if(IsEveryLighting()){childrenScript.ForEach(x=>x.StartCoroutine(x.BlinkAndSetLightCoroutine(false)));}
		}

		public virtual void SetAllLight(bool isLight) {
			childrenScript.ForEach(value => value.SetLight(isLight));
		}

		public bool IsEveryLighting() {
			return childrenScript.All(value => value.isLight);
		}

		public override void ResetMethod() {
			SetAllLight(false);
		}
	}
}
