using System.Collections.Generic;
using UnityEngine;

namespace Unity.FPS.Game
{
    public class ObjectiveManager : MonoBehaviour
    {
        List<Objective> m_Objectives = new List<Objective>();
        bool m_ObjectivesCompleted = false;

        public GameObject m_listObjectives;
        public List<GameObject> m_ObjectivesGO = new List<GameObject>();

        void Awake()
        {
            int i = 0;
            foreach (Transform child in m_listObjectives.transform) {
                m_ObjectivesGO.Add(child.gameObject);
                m_ObjectivesGO[i++].SetActive(false);
            }
            Objective.OnObjectiveCreated += RegisterObjective;
            m_ObjectivesGO[0].SetActive(true);
        }

        void RegisterObjective(Objective objective) => m_Objectives.Add(objective);

        void Update()
        {
            if (m_ObjectivesGO[0] == null) {
                Continue();
                return;
            }

            if (m_Objectives.Count == 0 || m_ObjectivesCompleted)
                return;

            for (int i = 0; i < m_Objectives.Count; i++)
            {
                // pass every objectives to check if they have been completed
                if (m_Objectives[i].IsBlocking())
                {
                    // break the loop as soon as we find one uncompleted objective
                    return;
                }
            }

            m_ObjectivesCompleted = true;
            EventManager.Broadcast(Events.AllObjectivesCompletedEvent);
        }

        void OnDestroy()
        {
            Objective.OnObjectiveCreated -= RegisterObjective;
        }

        public void Continue() {
            m_ObjectivesGO.Remove(m_ObjectivesGO[0]);
            m_ObjectivesGO[0].SetActive(true);
        }
    }
}