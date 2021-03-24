using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SimpleDecorationScript : DecorationBasicScript
{
    [SerializeField, Tooltip("ボール射出前のマテリアル")]
    private Material beforeLaunchMaterial;

    [SerializeField, Tooltip("ボール射出後のマテリアル")]
    private Material afterLaunchMaterial;

    private MeshRenderer meshRenderer;
    private bool nowIsBeforeLaunchMaterial = false;

    protected override void Start()
    {
        base.Start();
        meshRenderer = GetComponent<MeshRenderer>();
        if (beforeLaunchMaterial == null) beforeLaunchMaterial = meshRenderer.material;
        if (afterLaunchMaterial == null) afterLaunchMaterial = meshRenderer.material;
    }

    public override void ResetMethod()
    {
        meshRenderer.material = beforeLaunchMaterial;
        nowIsBeforeLaunchMaterial = true;
    }

    protected override void BeforeLaunch()
    {
        if (!nowIsBeforeLaunchMaterial)
        {
        }
    }

    protected override void AfterLaunch()
    {
        if (nowIsBeforeLaunchMaterial)
        {
            meshRenderer.material = afterLaunchMaterial;
            nowIsBeforeLaunchMaterial = false;
        }
    }
}
