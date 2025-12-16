/*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at https://mozilla.org/MPL/2.0/.
*
* Copyright (c) 2025 Florian K.
*
*/

#pragma warning disable CA1416 // Platform compatibility warning

using Microsoft.Win32.TaskScheduler;
using System.Diagnostics;

namespace LibreDiagnostics.Tasks.Platform.Windows
{
    public class WindowsStartup
    {
        #region Fields

        static readonly string ProcessPath = Environment.ProcessPath;

        #endregion

        #region Public

        public static bool StartupTaskExists()
        {
            using (var taskService = new TaskService())
            {
                var task = taskService.FindTask(Constants.TASKNAME_WINDOWSSTARTUP);

                if (task == null)
                {
                    return false;
                }

                var action = task.Definition.Actions.OfType<ExecAction>().FirstOrDefault();

                if (action == null || action.Path != ProcessPath)
                {
                    return false;
                }

                return true;
            }
        }

        public static void EnableStartupTask(string exePath = null)
        {
            try
            {
                using (var taskService = new TaskService())
                {
                    TaskDefinition def = taskService.NewTask();
                    def.Triggers.Add(new LogonTrigger() { Enabled = true });
                    def.Actions.Add(new ExecAction(exePath ?? ProcessPath));
                    def.Principal.RunLevel = TaskRunLevel.Highest;

                    def.Settings.DisallowStartIfOnBatteries = false;
                    def.Settings.StopIfGoingOnBatteries = false;
                    def.Settings.ExecutionTimeLimit = TimeSpan.Zero;

                    taskService.RootFolder.RegisterTaskDefinition(Constants.TASKNAME_WINDOWSSTARTUP, def);
                }
            }
            catch (Exception e)
            {
                using (var log = new EventLog("Application"))
                {
                    log.Source = ProcessPath;
                    log.WriteEntry(e.ToString(), EventLogEntryType.Error, 100, 1);
                }
            }
        }

        public static void DisableStartupTask()
        {
            using (var taskService = new TaskService())
            {
                taskService.RootFolder.DeleteTask(Constants.TASKNAME_WINDOWSSTARTUP, false);
            }
        }

        #endregion
    }
}

#pragma warning restore CA1416 // Platform compatibility warning
