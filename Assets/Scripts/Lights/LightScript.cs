using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Lights
{
    public class LightScript : MonoBehaviour
    {
        public Material lightingMaterial;
        public Material unlightingMaterial;
        public bool isLight = false;
        private MeshRenderer thisMeshRenderer;
        private MainSystemScript mainSystemScript;

        private void Awake()
        {
            
            thisMeshRenderer = GetComponent<MeshRenderer>();
        }

        private void Start()
        {
            mainSystemScript = GameObject.FindWithTag("MainSystem").GetComponent<MainSystemScript>();
            SetLight(isLight);
        }

        //引数のbool型で点灯状態を変える。trueで点灯。
        public void SetLight(bool isLight)
        {
            this.isLight = isLight;
            if (isLight)
            {
                thisMeshRenderer.material = lightingMaterial;
            }
            else
            {
                thisMeshRenderer.material = unlightingMaterial;
            }
        }

        //呼び出されると、自分の点灯or消灯を切り替える。
        public void ToggleLight()
        {
            SetLight(!isLight);
        }

        //デバッグ用メソッド
        public void RandomToggle()
        {
            if (Random.Range(0, 600) == 0)
            {
                SetLight(!isLight);
            }
        }

        public IEnumerator BlinkAndSetLightCoroutine(bool isLight)
        {
            SetLight(isLight);
            int blinkWaitFrame = 10;
            if (this.isLight)
            {
                thisMeshRenderer.material = unlightingMaterial;
                for (int j = 0; j < blinkWaitFrame; j++)
                {
                    yield return null;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (mainSystemScript.gameState == MainSystemScript.GameState.OnStandby)
                {
                    SetLight(false);
                    yield break;
                }
                thisMeshRenderer.material = lightingMaterial;
                for (int j = 0; j < blinkWaitFrame; j++)
                {
                    yield return null;
                }

                thisMeshRenderer.material = unlightingMaterial;
                for (int j = 0; j < blinkWaitFrame; j++)
                {
                    yield return null;
                }
            }

            SetLight(isLight);
        }
    }
}
