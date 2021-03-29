using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DecorationScript : DecorationBasicScript
{
    [SerializeField,TooltipAttribute("光っているマテリアル")] private Material lightingMaterial;
    [SerializeField,TooltipAttribute("光っていないマテリアル")] private Material unLightingMaterial;
    [SerializeField,TooltipAttribute("ボール射出前の点灯状態。\nOnで点灯、Offで消灯、BlinkFastで早く点滅、BlinkSlowで遅く点滅")] private LightingType onBeforeLaunch=LightingType.Off;
    [SerializeField,TooltipAttribute("ボール射出後の点灯状態。(以下OnBeforeLaunchに同文)")] private LightingType onAfterLaunch=LightingType.On;
    [SerializeField,TooltipAttribute("BlinkFast時の、点滅の待機フレーム数。数字が小さいほど早く点滅。")] private int blinkWaitFrame_Fast=7;
    [SerializeField,TooltipAttribute("BlinkSlow時の(以下BlinkWaitFrame_Fastに同文)")] private int blinkWaitFrame_Slow=15;
    private bool isLight = false;
    private MeshRenderer meshRenderer;
    private Coroutine myCoroutine;
    private LightingType beforeLightingType;

    protected override void Start()
    {
        base.Start();
        meshRenderer = GetComponent<MeshRenderer>();
        if (lightingMaterial == null) lightingMaterial = meshRenderer.material;
        if (unLightingMaterial == null) unLightingMaterial = meshRenderer.material;
        SetLight(isLight);
        if (isLight)
        {
            meshRenderer.material = lightingMaterial;
        }
        else
        {
            meshRenderer.material = unLightingMaterial;
        }
    }

    public override void ResetMethod()
    {
        SetLight(false);
    }


    private enum LightingType
    {
        On,
        Off,
        BlinkFast,
        BlinkSlow
    }

    //引数のbool型で点灯状態を変える。trueで点灯。
    public void SetLight(bool isLight)
    {
        if(this.isLight==isLight) return;
        this.isLight = isLight;
        if (isLight)
        {
            meshRenderer.material = lightingMaterial;
        }
        else
        {
            meshRenderer.material = unLightingMaterial;
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
        if (UnityEngine.Random.Range(0, 600) == 0)
        {
            ToggleLight();
        }
    }

    private IEnumerator BlinkCoroutine(int blinkWaitFrame)
    {
        while (true)
        {
            ToggleLight();
            for (int i = 0; i < blinkWaitFrame; i++)
            {
                yield return null;
            }
        }
    }

    private void SetLighting(LightingType lightingType)
    {
        switch (lightingType)
        {
            case LightingType.On:
                if (myCoroutine != null)
                {
                    StopCoroutine(myCoroutine);
                    myCoroutine = null;
                }
                SetLight(true);
                beforeLightingType = LightingType.On;
                break;
            case LightingType.Off:
                if (myCoroutine != null)
                {
                    StopCoroutine(myCoroutine);
                    myCoroutine = null;
                }
                SetLight(false);
                beforeLightingType = LightingType.Off;
                break;
            case LightingType.BlinkFast:
                if(beforeLightingType==LightingType.BlinkFast) break;
                if (myCoroutine != null)
                {
                    StopCoroutine(myCoroutine);
                    myCoroutine = null;
                }
                myCoroutine = StartCoroutine(BlinkCoroutine(blinkWaitFrame_Fast));
                beforeLightingType = LightingType.BlinkFast;
                break;
            case LightingType.BlinkSlow:
                if(beforeLightingType==LightingType.BlinkSlow) break;
                if (myCoroutine != null)
                {
                    StopCoroutine(myCoroutine);
                    myCoroutine = null;
                }
                myCoroutine = StartCoroutine(BlinkCoroutine(blinkWaitFrame_Slow));
                beforeLightingType = LightingType.BlinkSlow;
                break;
        }
    }


    protected override void BeforeLaunch()
    {
        SetLighting(onBeforeLaunch);
    }

    protected override void AfterLaunch()
    {
        SetLighting(onAfterLaunch);
    }
}
