using UnityEngine;
using UnityEngine.UI;
//using Vobling.FireSimulator.Input.SafetyPin;
//using Vobling.FireSimulator.UI.MessageSnackbar;
//using Vobling.FireSimulator.Utilities;
using Vobling.FireSimulator.Scenarios;
using UnityEngine.SceneManagement;


namespace Assets.scripts.CompanyScript
{
    [RequireComponent(typeof(ReportCard))]
    public class ReportCardButtons : MonoBehaviour
    {
        [SerializeField] private ReturnToMainMenuButton returnToMainMenuButton;
        [SerializeField] private SceneLoader sceneLoader;
        [SerializeField] private SafetyPinController safetyPinController;
        [SerializeField] private SnackbarHandler snackbarHandler;
        [SerializeField] private GameObject courseText;
        [SerializeField] private TrainingSummaryMenu trainingSummaryMenu;
        [SerializeField] private Button retryButton;
        [SerializeField] private Button continueButton;
        [SerializeField] private Button summaryButton;

        private TrainingSelectorManager trainingSelectorManager;
        private ReportCard reportCard;

        private void Awake()
        {
            trainingSelectorManager = FindObjectOfType<TrainingSelectorManager>();
        }
        void OnEnable()
        {
            reportCard = GetComponent<ReportCard>();
        }

        public void SetUpContinue()
        {
            TrainingSelectorManager.RecordScenarioResult(reportCard.reportCardState);
            if (TrainingSelectorManager.IsCourseDone)
            {
                SetUpScenarioFinished();
            }
            else
            {
                retryButton.transform.parent.gameObject.SetActive(false);
                continueButton.transform.parent.gameObject.SetActive(true);
                summaryButton.transform.parent.gameObject.SetActive(false);

                continueButton.onClick.RemoveAllListeners();
                continueButton.onClick.AddListener(() => sceneLoader.LoadScene(trainingSelectorManager.LoadNextScene()));
            }
        }

        public void SetUpRetry(string sceneName)
        {
            if (!TrainingSelectorManager.trainingDataObject.forceContinue)
            {
                retryButton.transform.parent.gameObject.SetActive(true);
                continueButton.transform.parent.gameObject.SetActive(false);
                summaryButton.transform.parent.gameObject.SetActive(false);
            }
            else
            {
                SetUpContinue();
            }
            retryButton.onClick.RemoveAllListeners();
            retryButton.onClick.AddListener(() => sceneLoader.LoadScene(SceneManager.GetActiveScene().name));
        }

        public void SetUpScenarioFinished()
        {
            if (TrainingSelectorManager.showResults)
            {
                retryButton.transform.parent.gameObject.SetActive(false);
                continueButton.transform.parent.gameObject.SetActive(false);
                summaryButton.transform.parent.gameObject.SetActive(true);

                summaryButton.onClick.RemoveAllListeners();
                summaryButton.onClick.AddListener(() =>
               {
                   reportCard.Close();
                   trainingSummaryMenu.Open();

               });
            }
            else if (TrainingSelectorManager.RunInduvidualScenario)
            {
                SetUpRetry(trainingSelectorManager.currentActiveScene);
            }
            else
            {
                retryButton.transform.parent.gameObject.SetActive(false);
                continueButton.transform.parent.gameObject.SetActive(false);
                summaryButton.transform.parent.gameObject.SetActive(false);

                returnToMainMenuButton.Center();
            }
        }
        public void ReturnToMainMenu()
        {
            //  safetyPinController.ResetForceSafetyPinMode();  this is used but depends on script from the company.

            if (TrainingSelectorManager.trainingCourseStarted) TrainingSelectorManager.trainingCourseStarted = false;
            sceneLoader.LoadScene("MainMenu", () => { reportCard.Close(); });
        }
    }
}
