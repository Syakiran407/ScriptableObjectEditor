using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Snorlax.BlackboardTest
{
    [CreateAssetMenu(menuName = "Snorlax's Tools/Blackboard")]
    public class Blackboard : ScriptableObject
    {
        public Parameter[] parameters = new Parameter[0];

        #region Editor Methods
#if UNITY_EDITOR

        public void AddParameter(string name, ParameterType type)
        {
            Parameter newParameter = new Parameter();
            newParameter.Name = MakeUniqueParameterName(name);
            newParameter.Type = type;

            AddParameter(newParameter);
        }

        public void AddParameter(Parameter paramater)
        {
            Undo.RecordObject(this, "Parameter added");
            Parameter[] parameterVector = parameters;
            ArrayUtility.Add(ref parameterVector, paramater);
            parameters = parameterVector;
        }

        public void RemoveParameter(int index)
        {
            Undo.RecordObject(this, "Parameter removed");
            Parameter[] parameterVector = parameters;
            ArrayUtility.Remove(ref parameterVector, parameterVector[index]);
            parameters = parameterVector;
        }

        public void RemoveParameter(Parameter parameter)
        {
            Undo.RecordObject(this, "Parameter removed");
            Parameter[] parameterVector = parameters;
            ArrayUtility.Remove(ref parameterVector, parameter);
            parameters = parameterVector;
        }

        public Parameter GetIndex(int index)
        {
            return parameters[index];
        }

        public int GetIndex(Parameter parameter)
        {
            return ArrayUtility.IndexOf(parameters, parameter);
        }

        private bool ContainsName(string name)
        {
            for (int i = 0; i < parameters.Length; i++) // Parameters parameters in parameters)
            {
                if (parameters[i].Name == name)
                {
                    return true;
                }
            }

            return false;
        }

        public string MakeUniqueParameterName(string name)
        {
            if (ContainsName(name))
            {
                return NameWithNumber(name);
            }
            else return name;
        }

        private string NameWithNumber(string name, int i = 1)
        {
            int number = i;
            string fullName = name + $" {number}";
            if (ContainsName(fullName))
            {
                number++;
                return NameWithNumber(name, number);
            }
            else
            {
                return fullName;
            }
        }

        public string[] ReturnNames()
        {
            List<string> Names = new List<string>();
            for (int i = 0; i < parameters.Length; i++)
            {
                Names.Add(parameters[i].Name);
            }

            return Names.ToArray();
        }
#endif
        #endregion
    }
}