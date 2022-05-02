using GameFramework;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace GameFrameworkExample
{
    public class ProcedureLaunch : ProcedureBase
    {
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            string welcomeMessage = Utility.Text.Format("Hello! This is an empty project based on Game Framework {0}.", Version.GameFrameworkVersion);
            Log.Info(welcomeMessage);
            Log.Warning(welcomeMessage);
            Log.Error(welcomeMessage);

            SettingComponent m_SettingComponent = GameEntry.GetComponent<SettingComponent>();
            if (m_SettingComponent == null)
            {
                Log.Fatal("Setting component is invalid.");
                return;
            }

            float m_LastIconX = m_SettingComponent.GetFloat("Debugger.Icon.X", 0.1f);

        }
    }
}
