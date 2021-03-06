using UnityEngine;
using static MainStaticScript;

namespace Lights
{
	public class LightControllerWithTarget_MultiplierScript : LightControllerWithTarget_BasicScript {

		protected override void Start() {
			base.Start();
			lightingDuration = 60f;
		}

		protected override void FunctionByLevel(bool levelUp) {
			switch (level) {
				case 0:
					mainSystem.fieldMultiplyRate = 1;
					break;

				case 1:
					mainSystem.fieldMultiplyRate = 2;
					if (levelUp) SetMessage("Point Multiply x2");
					break;

				case 2:
					mainSystem.fieldMultiplyRate = 3;
					if (levelUp) SetMessage("Point Multiply x3");
					break;

				case 3:
					mainSystem.fieldMultiplyRate = 5;
					if (levelUp) SetMessage("Point Multiply x5");
					break;

				case 4:
					mainSystem.fieldMultiplyRate = 10;
					if (levelUp) SetMessage("Point Multiply x10");
					break;
			}
		}
	}
}
