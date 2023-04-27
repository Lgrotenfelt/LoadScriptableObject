//using Vobling.FireSimulator.Input.SafetyPin;
using UnityEngine;
using System.Collections.Generic;
//using I2.Loc;
using System;
//using Vobling.FireSimulator.Utilities;
//using Vobling.FireSimulator.TrainingCourse;
//using Vobling.FireSimulator.UI;
using Assets.scripts.CompanyScript;
namespace Vobling.FireSimulator.Scenarios
{
    public class TrainingSelectorManager : MonoBehaviour
    {
        public Action OnPressed;

        private static SceneLoader sceneLoader;
        public static TrainingCourseData trainingDataObject;
        public static TrainingData m_trainingData;

        private static SkillsTestScenarioGrading gradingSystem = new SkillsTestScenarioGrading();
        public static List<ScenarioRecord> ScenarioRecords = new List<ScenarioRecord>();
        public static List<string> sceneNames = new List<string>();

        public static ExtinguisherType SelectedExtinguisher;
        public static int currentSceneIndex = 0;
        public static float ElapsedTime = 0.0f;
        public static string ScenarioResultDescription;

        public static bool trainingCourseStarted = false;
        public static bool showResults;
        public static bool IsCourseDone;
        public static bool RunInduvidualScenario;
        public static bool showMessageOneExt;
        public static bool runRandomScenarios;

        [HideInInspector] public string sceneToLoad = null;
        [HideInInspector] public int randomIndex;
        [HideInInspector] public string currentActiveScene;

        // make a property of RunRandomScenes and also check if it's not null
        private RunRandomScenes _myRunRandomScenes;
        public RunRandomScenes OtherClassProperty => _myRunRandomScenes ?? (_myRunRandomScenes = new RunRandomScenes());
       
        // make a property of SaftyPinController and also check if it's not null
        private SafetyPinController _mySafteyPinController;
        public SafetyPinController MySafetyPinController => _mySafteyPinController ?? (_mySafteyPinController = new SafetyPinController());
        void Start()
        {
            DontDestroyOnLoad(this.gameObject);          
            sceneLoader = FindObjectOfType<SceneLoader>();
        }
        public void OnSelected(TrainingCourseData trainingCourseData)
        {
            currentSceneIndex = 0;
            IsCourseDone = false;

            trainingDataObject = trainingCourseData;
            showResults = trainingDataObject.showSummaryCard;
            RunInduvidualScenario = trainingDataObject.runInduvidualScenario;
            showMessageOneExt = trainingDataObject.showMessageNoExtUI;

            runRandomScenarios = trainingCourseData.runRandomScenarios;

            if (runRandomScenarios)
            {
                foreach (var scenarioData in trainingDataObject.trainingScenarioData)
                {
                    foreach (var sceneName in scenarioData.m_sceneName)
                    {
                        sceneNames.Add(sceneName.ToString());
                    }
                }

                OtherClassProperty.RunRandomScenarios();
            }

            ScenarioRecords.Clear();
            LoadScene(currentSceneIndex);
        }
        public void OnSelected()
        {
            currentSceneIndex = 0;
            IsCourseDone = false;

            LoadScene(currentSceneIndex);
        }
        public string LoadNextScene()
        {
            if (runRandomScenarios)
            {
                OtherClassProperty.RunRandomScenarios();
                return sceneNames[randomIndex];
            }
            currentSceneIndex++;
            return LoadScene(currentSceneIndex);
        }
        public string LoadScene(int sceneIndex)
        {
            if (sceneIndex < 0 || sceneIndex >= trainingDataObject.trainingScenarioData.Count)
            {
                return null;
            }

            var t_data = trainingDataObject.trainingScenarioData[sceneIndex];

            if (t_data == null)
            {
                return null;
            }

            m_trainingData = t_data;
            OnTrainingDataSelected(m_trainingData);

            return t_data.sceneToLoad[0].ToString();
        }
        public void OnTrainingDataSelected(TrainingData t_data)
        {
            CurrentActiveScenario.SetScenarioScene((ScenarioScenes)Enum.Parse(typeof(ScenarioScenes), t_data.sceneToLoad[0].ToString()));
            CurrentActiveScenario.SetScenarioDescriptionKey(t_data.m_scenarioDescriptionsKey[0].ToString());
            CurrentActiveScenario.SetFireOriginType((FireType)t_data.GetFireTypes[0]);

            trainingCourseStarted = true;

          //  MySafetyPinController.SaveForceSafetyPinMode(); this is used but is 
            RunActiveScenario();
        }
        public void FinishCurrentScenario()
        {
            currentSceneIndex++;
        }
        public void ResetCourseIndex()
        {
            currentSceneIndex = 0;
        }
        /* public static string GetWelcomeMessage()
         {
             if (trainingDataObject.trainingScenarioData == null || trainingDataObject.trainingScenarioData.Count <= 0)
             {
                 return String.Empty;
             }
             else 
                 return LocalizationManager.GetTranslation(m_trainingData.welcomeMessage);
         }*///this is used but depends on script from the company.
        protected void CheckIfCourseDone()
        {
            if (!runRandomScenarios && currentSceneIndex >= trainingDataObject.trainingScenarioData.Count -1)
            {
                IsCourseDone = true;
                trainingCourseStarted = false;
            }

            else if (runRandomScenarios && 1 >= sceneNames.Count)
            {
                IsCourseDone = true;
                trainingCourseStarted = false;
            }
            
        }
        public void RunActiveScenario()
        {
            if (!runRandomScenarios)
            {
                currentActiveScene = trainingDataObject.trainingScenarioData[currentSceneIndex].sceneToLoad[0].ToString();
                sceneLoader.LoadScene(currentActiveScene);
                //currentSceneIndex++;
            }
            CheckIfCourseDone();
        }
        public static void RecordScenarioResult(ReportCardStates state)
        {
            var newScenarioRecord = new ScenarioRecord();
            newScenarioRecord.SceanrioDescriptionKey = m_trainingData.m_scenarioDescriptionsKey[0].ToString();
            newScenarioRecord.FireType = (FireType)m_trainingData.GetFireTypes[0];
            newScenarioRecord.ExtinguisherType = m_trainingData.GetExtinguisherTypes[0];
            newScenarioRecord.ElapsedTime = Mathf.RoundToInt(ElapsedTime);
            newScenarioRecord.ScenarioResultDescription = ScenarioResultDescription;
           // newScenarioRecord.ScenarioScore = ScoreOfPlayedScenario(state);
            ScenarioRecords.Add(newScenarioRecord);
        }
        /*  private static float ScoreOfPlayedScenario(ReportCardStates state)
          {
              return  gradingSystem.GetScenarioPoint(m_trainingData.m_scenarioDescriptionsKey[0].ToString(), m_trainingData.GetExtinguisherTypes[0], state);
          }*/// this is used but depends on script from the company.
    }
}