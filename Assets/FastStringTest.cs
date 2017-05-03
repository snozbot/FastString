using UnityEngine;
using UnityEngine.Profiling;

public class FastStringTest : MonoBehaviour
{
    private FastString m_strCustom = new FastString(64);

    private System.Text.StringBuilder m_strBuilder = new System.Text.StringBuilder(64);

    private delegate string Test();

    private string String_Added()
    {
        string str = "PI=" + Mathf.PI + "_373=" + 373;
        return str.Replace("373", "5428");
    }

    private string String_Concat()
    {
        return string.Concat("PI=", Mathf.PI, "_373=", 373).Replace("373", "5428");
    }

    private string StringBuilder()
    {
        m_strBuilder.Length = 0;
        m_strBuilder.Append("PI=").Append(Mathf.PI).Append("_373=").Append(373).Replace("373", "5428");
        return m_strBuilder.ToString();
    }

    private string FastString()
    {
        m_strCustom.Clear();
        m_strCustom.Append("PI=").Append(Mathf.PI).Append("_373=").Append(373).Replace("373", "5428");
        return m_strCustom.ToString();
    }

    private void RunTest(string testName, Test test)
    {
        Profiler.BeginSample(testName);
        string lastResult = null;
        for (int i = 0; i < 1000; i++)
            lastResult = test();
        Profiler.EndSample();
        Debug.Log( "Check test result: test=" + testName + " result='" + lastResult + "' (" + lastResult.Length + ")" );
    }

    private void Start()
    {
        Debug.Log("=================");
        RunTest("Test #1: string (+)       ", String_Added);
        RunTest("Test #2: string (.concat) ", String_Concat);
        RunTest("Test #3: StringBuilder    ", StringBuilder);
        RunTest("Test #4: FastString", FastString);
    }
}
