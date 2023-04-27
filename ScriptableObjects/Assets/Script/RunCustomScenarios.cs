using System;
using UnityEngine;
namespace Vobling.FireSimulator.Scenarios
{
    public class RunCustomScenarios : MonoBehaviour
    {
        [SerializeField] public TrainingCourseData trainingCourseData;
        private int index;
        private void Start()
        {
            index = -1;
            foreach (var t_data in trainingCourseData.trainingScenarioData)
            {
                for (int i = 0; i < t_data.m_extinguisherTypes.Length; i++)
                {
                    
                    t_data.m_extinguisherTypes[i] = ExtinguisherType.Null;
                }
            }
        }
        public void SetFireType(string fireType)
        {
            trainingCourseData.trainingScenarioData[0].fireTypes[0] = (FireType)Enum.Parse(typeof(FireType), fireType);
        }
        public void SetScenario(string key)
        {
            switch (key)
            {
                case "Bus":
                    trainingCourseData.trainingScenarioData[0].m_scenarioDescriptionsKey[0] = DescriptionKey.Bus;
                    SetSceneName("Bus");
                    break;
                case "Car_Park":
                    trainingCourseData.trainingScenarioData[0].m_scenarioDescriptionsKey[0] = DescriptionKey.Car_park;
                    SetSceneName("Car_Park");
                    break;
                case "Electrical_Room":
                    trainingCourseData.trainingScenarioData[0].m_scenarioDescriptionsKey[0] = DescriptionKey.Electrical_Room;
                    SetSceneName("Electrical_Room");
                    break;
                case "Garage":
                    trainingCourseData.trainingScenarioData[0].m_scenarioDescriptionsKey[0] = DescriptionKey.Garage;
                    SetSceneName("Garage");
                    break;
                case "Hospital":
                    trainingCourseData.trainingScenarioData[0].m_scenarioDescriptionsKey[0] = DescriptionKey.Hospital;
                    SetSceneName("Hospital");
                    break;
                case "Hotel":
                    trainingCourseData.trainingScenarioData[0].m_scenarioDescriptionsKey[0] = DescriptionKey.Hotel;
                    SetSceneName("Hotel");
                    break;
                case "Kitchen":
                    trainingCourseData.trainingScenarioData[0].m_scenarioDescriptionsKey[0] = DescriptionKey.Kitchen;
                    SetSceneName("Kitchen");
                    break;
                case "Livingroom":
                    trainingCourseData.trainingScenarioData[0].m_scenarioDescriptionsKey[0] = DescriptionKey.LivingRoom;
                    SetSceneName("Livingroom");
                    break;
                case "Office_Space":
                    trainingCourseData.trainingScenarioData[0].m_scenarioDescriptionsKey[0] = DescriptionKey.Office_Space;
                    SetSceneName("Office_Modern");
                    break;
                case "Office_Desk":
                    trainingCourseData.trainingScenarioData[0].m_scenarioDescriptionsKey[0] = DescriptionKey.Office_Desk;
                    SetSceneName("Office_Modern");
                    break;               
                case "Train":
                    trainingCourseData.trainingScenarioData[0].m_scenarioDescriptionsKey[0] = DescriptionKey.Train;
                    SetSceneName("Train");
                    break;
                case "Warehouse":
                    trainingCourseData.trainingScenarioData[0].m_scenarioDescriptionsKey[0] = DescriptionKey.Warehouse;
                    SetSceneName("Warehouse");
                    break;
                default:
                    break;
            }
        }
        private void SetSceneName(string prefix)
        {
            string sceneName = $"{prefix}_{trainingCourseData.trainingScenarioData[0].fireTypes[0]}";
            trainingCourseData.trainingScenarioData[0].m_sceneName[0] = (ScenarioScenes)Enum.Parse(typeof(ScenarioScenes), sceneName);
        }
        public void SetExtinguishers(string extinguisher)
        {
            index++;
            switch (extinguisher)
            {
                case "CO2":
                    trainingCourseData.trainingScenarioData[0].m_extinguisherTypes[index] = ExtinguisherType.CO2;
                    break;
                case "Foam":
                    trainingCourseData.trainingScenarioData[0].m_extinguisherTypes[index] = ExtinguisherType.Foam;
                    break;
                case "Powder":
                    trainingCourseData.trainingScenarioData[0].m_extinguisherTypes[index] = ExtinguisherType.Powder;
                    break;
                case "Water":
                    trainingCourseData.trainingScenarioData[0].m_extinguisherTypes[index] = ExtinguisherType.Water;
                    break;
                case "WetChemical":
                    trainingCourseData.trainingScenarioData[0].m_extinguisherTypes[index] = ExtinguisherType.WetChemical;
                    break;
                default:
                    break;
            }
        }
    }
}