using UnityEngine;
//using I2.Loc;

namespace Vobling.FireSimulator.Scenarios
{

    [System.Serializable]
    public class TrainingData
    {
        [SerializeField]public ScenarioScenes[] m_sceneName;  
        [SerializeField] public FireType[] fireTypes;
        [SerializeField] public ExtinguisherType[] m_extinguisherTypes;
        [SerializeField] public DescriptionKey[] m_scenarioDescriptionsKey;
        [SerializeField] string m_localizationTitleKey;

        public string welcomeMessage;

        public string GetLocalizedtrainingName()
        {

            string translation = "";
          //  translation = LocalizationManager.GetTranslation(m_localizationTitleKey);

            if (string.IsNullOrEmpty(translation))
                return m_localizationTitleKey;

            else
                return translation;
        }

        public FireType[] GetFireTypes { get { return fireTypes; } set { fireTypes = value; } }
        public ExtinguisherType[] GetExtinguisherTypes { get { return m_extinguisherTypes; } set { m_extinguisherTypes = value; } }
        public ScenarioScenes[] sceneToLoad { get { return m_sceneName; }  set { m_sceneName = value; } }
        public DescriptionKey[] GetDescriptionKeys { get { return m_scenarioDescriptionsKey; } set { m_scenarioDescriptionsKey = value; } }
    }
}
