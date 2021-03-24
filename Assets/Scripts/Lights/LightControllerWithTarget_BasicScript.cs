using System;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace Lights
{
    public abstract class LightControllerWithTarget_BasicScript : LightController_BasicScript
    {
        private float lightingTime = 0f;
        protected float lightingDuration;
        public int level = 0;
        public int maxLevel;

        protected override void Start()
        {
            base.Start();
            maxLevel = childrenScript.Count();
        }

        protected override void Update()
        {
            if (mainSystem.gameState != MainSystemScript.GameState.OnStandby && level > 0)
            {
                lightingTime += Time.deltaTime;
            }

            if (lightingTime > lightingDuration)
            {
                SetLevel(level - 1);
                lightingTime = 0f;
            }
        }

        public void SetLevel(int newLevel)
        {
            bool levelUp = newLevel > level;
            newLevel = Math.Min(Math.Max(newLevel, 0), maxLevel);
            for (int i = 0; i < maxLevel; i++)
            {
                childrenScript[i].SetLight(i < newLevel);
            }

            lightingTime = 0f;
            level = newLevel;
            FunctionByLevel(levelUp);
        }

        private IEnumerator LevelDownCoroutine()
        {
            int wait = (int) Math.Floor(lightingDuration);
            yield return new WaitForSeconds(lightingDuration - wait);
            for (int i = 0; i < wait; i++)
            {
                if (mainSystem.gameState == MainSystemScript.GameState.OnStandby)
                {
                    yield break;
                }

                yield return new WaitForSeconds(1);
            }

            SetLevel(level - 1);
        }

        public override void ResetMethod()
        {
            SetLevel(0);
            lightingTime = 0f;
        }

        protected abstract void FunctionByLevel(bool levelUp);
    }
}
