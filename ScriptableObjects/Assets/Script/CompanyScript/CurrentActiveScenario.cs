using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.scripts.CompanyScript
{
    public class CurrentActiveScenario : MonoBehaviour
    {
        static FireType m_scenarioFireType;
        static ExtinguisherType m_scenarioExtringuisherType;
        static ScenarioScenes m_scenarioScene;
        private static string scenarioDescriptionKey;
        public static void SetFireOriginType(FireType p_fireOriginType)
        {
            m_scenarioFireType = p_fireOriginType;
            Debug.Log("[SetFireType0] " + p_fireOriginType);
        }

        public static void SetScenarioScene(ScenarioScenes scenarioScene)
        {
            m_scenarioScene = scenarioScene;
        }

        public static void SetScenarioDescriptionKey(string descriptionKey)
        {

            scenarioDescriptionKey = descriptionKey;
        }

    }



}
