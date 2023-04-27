using UnityEngine;


namespace Vobling.FireSimulator
{
    public class ExtinguisherIdentifier : MonoBehaviour
    {
        [SerializeField]  ExtinguisherType extinguisherType;
        [HideInInspector]
        public string Identifier;

        private void Awake()
        {
           Identifier = extinguisherType.ToString();
        }    
    }
}
