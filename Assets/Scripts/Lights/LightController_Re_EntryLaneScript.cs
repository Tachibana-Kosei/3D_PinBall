namespace Lights
{
	public class LightController_Re_EntryLaneScript : LightController_BasicScript {

		public void LightMove_toR() {
			var tempBool = childrenScript[2].isLight;
			childrenScript[2].SetLight(childrenScript[1].isLight);
			childrenScript[1].SetLight(childrenScript[0].isLight);
			childrenScript[0].SetLight(tempBool);
		}

		public void LightMove_toL() {
			var tempBool = childrenScript[0].isLight;
			childrenScript[0].SetLight(childrenScript[1].isLight);
			childrenScript[1].SetLight(childrenScript[2].isLight);
			childrenScript[2].SetLight(tempBool);
		}
	}
}
