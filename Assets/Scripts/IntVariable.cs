using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "Variable", menuName = "Variable/Int", order = 0)]
    public class IntVariable : ScriptableObject
    {
        public int Value;
    }
}