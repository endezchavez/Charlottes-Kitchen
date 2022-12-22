using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITimedTask
{
    public bool IsTaskInProgress();
    public bool HasTaskCompleted();
    public void ResetTask();
    public void TaskCompleted();
}
