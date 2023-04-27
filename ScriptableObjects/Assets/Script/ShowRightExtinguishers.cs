using System.Collections.Generic;
using Vobling.FireSimulator.Scenarios;
using UnityEngine;
using UnityEngine.UI;

namespace Vobling.FireSimulator
{
    public class ShowRightExtinguishers : MonoBehaviour
    {

        [SerializeField] private SafetyPinController safetyPinController;
        [SerializeField] private GameObject[] fireExtinguisherOriginal;
        private TrainingData m_trainingData;
        private RunRandomScenes m_random;

        ExtinguisherIdentifier[] extinguisherIdentifiers;

        public static ExtinguisherType SelectedExtinguisher;

        void Start()
        {
            extinguisherIdentifiers = new ExtinguisherIdentifier[fireExtinguisherOriginal.Length];

            if (TrainingSelectorManager.trainingDataObject != null)
            {                                           
                    m_trainingData = TrainingSelectorManager.trainingDataObject.trainingScenarioData[TrainingSelectorManager.currentSceneIndex];                             
            }
            else
            {
                return;
            }

            for (int i = 0; i < fireExtinguisherOriginal.Length; i++)
            {
               
                extinguisherIdentifiers[i] = fireExtinguisherOriginal[i].GetComponent<ExtinguisherIdentifier>();
                fireExtinguisherOriginal[i].SetActive(false);
            }
        }
        private void OnEnable()
        {
            if (m_trainingData != null)
            {
                ShowCorrectEtinguishers(m_trainingData);
            }
            else return;
        }

        public void ShowCorrectEtinguishers(TrainingData t_data)
        {
            List<ExtinguisherType> selectedExtinguisherTypes = new List<ExtinguisherType>();

            foreach (ExtinguisherType extinguisherType in t_data.GetExtinguisherTypes)
            {
                selectedExtinguisherTypes.Add(extinguisherType);

                for (int i = 0; i < fireExtinguisherOriginal.Length; i++)
                {
                    if (extinguisherIdentifiers[i].Identifier == extinguisherType.ToString())
                    {
                        if (TrainingSelectorManager.showMessageOneExt)
                        {
                            fireExtinguisherOriginal[i].GetComponentInChildren<Button>().onClick.Invoke();
                        }
                        else
                        {
                            fireExtinguisherOriginal[i].SetActive(true);
                        }
                    }

                }
            }
        }
    }
}
