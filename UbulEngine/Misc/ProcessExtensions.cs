using System.Diagnostics;

public static class ProcessExtensions
{
    private static string FindIndexedProcessName(int pid)
    {
        var processName = "";
        try
        {
            if (Process.GetProcessById(pid).ProcessName != null)
            {
                processName = Process.GetProcessById(pid).ProcessName;
            }
            else
            {
                return null;
            }
        } catch { }
        var processesByName = Process.GetProcessesByName(processName);
        string processIndexdName = null;

        for (var index = 0; index < processesByName.Length; index++)
        {
            processIndexdName = index == 0 ? processName : processName + "#" + index;
            var processId = new PerformanceCounter("Process", "ID Process", processIndexdName);
            if ((int)processId.NextValue() == pid)
            {
                return processIndexdName;
            }
        }

        return processIndexdName;
    }

    private static Process FindPidFromIndexedProcessName(string indexedProcessName)
    {
        var parentId = new PerformanceCounter("Process", "Creating Process ID", indexedProcessName);
        try
        {
            return Process.GetProcessById((int)parentId.NextValue());
        } catch { }
        return null;
    }

    public static Process Parent(this Process process)
    {
        return FindPidFromIndexedProcessName(FindIndexedProcessName(process.Id));
    }
}