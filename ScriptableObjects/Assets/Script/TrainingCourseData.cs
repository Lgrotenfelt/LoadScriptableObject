using System.Collections.Generic;
using UnityEngine;
//using NaughtyAttributes;

namespace Vobling.FireSimulator.Scenarios
{
    [CreateAssetMenu(menuName = "Fire Simulator / Scriptable Objects / Training Data Master Object")]
    public class TrainingCourseData : ScriptableObject

    {

        [NonReorderable]
        public List<TrainingData> trainingScenarioData;


        [Header(" no bools = OnFail(Retry Button UI) OnSuccess(Continue Button UI)")]
        [Header("BOOLS TO SET THE DIFFERENT SCENARIOS")]

        [Tooltip("Use this bool only when you want to play individual scenarios")]
        public bool runInduvidualScenario;
        [Tooltip("Use this bool when you only want to show the press continue button UI even if you fail the scenario")]
        public bool forceContinue;
        [Tooltip("Use this bool when you only have one extinguisher and you don't want to show it on the Ext UI, the forceContinue bool also need to be true for this to work")]
       // [ShowIf("forceContinue")]
        public bool showMessageNoExtUI;
        [Tooltip("Use this bool when you need to show the summeryCard at the end of a scenarioCourse, the forceContinue bool also need to be true for this to work")]
       // [ShowIf("forceContinue")]
        public bool showSummaryCard;
        [Tooltip("Use this bool only when you want to play the scenarios in random order ")]
        public bool runRandomScenarios;



    }
}
