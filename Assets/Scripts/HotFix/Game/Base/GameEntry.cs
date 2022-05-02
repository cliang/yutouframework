using UnityEngine;

namespace Tutorial
{
    /// <summary>
    /// 游戏入口。
    /// </summary>
    public partial class GameEntry : MonoBehaviour
    {
        private void Start()
        {
            // 初始化内置组件
            InitBuiltinComponents();

            // 初始化自定义组件
            InitCustomComponents();

            // 初始化自定义调试器
            InitCustomDebuggers();
        }
        //GUIStyle sss;
        //private void Awake()
        //{
        //    sss = new GUIStyle();
        //    sss.fontSize = 15;
        //}

        //public static string _logStr = "";

        //void OnGUI()
        //{
        //    GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity,
        //       new Vector3(Screen.width / 1200.0f, Screen.height / 800.0f, 1.0f));
        //    GUI.Label(new Rect(10, 10, 800, 370), _logStr, sss);
        //}
    }
}