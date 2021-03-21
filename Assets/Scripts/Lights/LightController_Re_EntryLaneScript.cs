namespace Lights
{
	public class LightController_Re_EntryLaneScript : LightController_BasicScript {

		public void LightMove_toR() {
			var tempBool = childrenScript[2].isLight;
			childrenScript[2].isLight = childrenScript[1].isLight;
			childrenScript[1].isLight = childrenScript[0].isLight;
			childrenScript[0].isLight = tempBool;
		}

		public void LightMove_toL() {
			var tempBool = childrenScript[0].isLight;
			childrenScript[0].isLight = childrenScript[1].isLight;
			childrenScript[1].isLight = childrenScript[2].isLight;
			childrenScript[2].isLight = tempBool;
		}
	}
}