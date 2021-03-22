using UnityEngine;

namespace Lights
{
	public class LightControllerWithTarget_BoosterScript : LightControllerWithTarget_BasicScript {

		protected override void Start() {
			base.Start();
			lightingDuration = 60f;
		}

		protected override void FunctionByLevel(bool levelUp) {
			switch (level) {
				case 0:
					mainSystem.awardMultiplyRate = 1;
					break;

				case 1:
					if (levelUp) {
						mainSystem.awardMultiplyRate = 5;
						Debug.Log("Flags Upgraded");
					}
					break;

				case 2:
					if (levelUp) {
						mainSystem.jackpotEnable = true;
						Debug.Log("Jackpot Activated");
					}
					break;

				case 3:
					if (levelUp) {
						mainSystem.bonusEnable = true;
						Debug.Log("Bonus Activated");
					}
					break;

				case 4:
					if (levelUp) {
						mainSystem.bonusHold = true;
						Debug.Log("Bonus Hold");
					}
					break;
			}
		}
	}
}