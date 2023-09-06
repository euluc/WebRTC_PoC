using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public static class Console
{
    #region Methods

    #region Public Methods

    public static void Log(string message, LogType logType, ScrollRect console)
    {
        var log = Object.Instantiate(Resources.Load("Prefabs/pf_LogObject") as GameObject, console.transform.GetChild(0).GetChild(0).transform).GetComponent<LogObject>();

        switch (logType)
        {
            case LogType.Error:
                log.SetupAsError(message);
                break;
            case LogType.Warning:
                log.SetupAsWarning(message);
                break;
            case LogType.Message:
                log.SetupAsMessage(message);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(logType), logType, null);
        }
        
        console.ScrollToBottom();
    }

    #endregion

    #endregion
}