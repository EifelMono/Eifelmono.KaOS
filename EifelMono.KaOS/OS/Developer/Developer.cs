﻿using System;
using System.Runtime.CompilerServices;

namespace EifelMono.KaOS
{
    public class Developer
    {
        public event Action<PlatformKind, string, string, string, int, string> OnAll;

        public event Action<PlatformKind, string, string, int, string> OnLogInfo;

        public void LogInfo(string message = "",
                                  [CallerMemberName] string callerMemberName = "",
                                  [CallerLineNumber] int callerLineNumber = -1,
                                  [CallerFilePath] string callerFilePath = "")
        {
            OnAll?.Invoke(OS.Device.PlatformKind, nameof(LogInfo), message, callerMemberName, callerLineNumber, callerFilePath);
            OnLogInfo?.Invoke(OS.Device.PlatformKind, message, callerMemberName, callerLineNumber, callerFilePath);
        }

        public event Action<PlatformKind, string, string, int, string> OnLogError;

        public void LogError(string message = "",
                                  [CallerMemberName] string callerMemberName = "",
                                  [CallerLineNumber] int callerLineNumber = -1,
                                  [CallerFilePath] string callerFilePath = "")
        {
            OnAll?.Invoke(OS.Device.PlatformKind, nameof(LogError), message, callerMemberName, callerLineNumber, callerFilePath);
            OnLogError?.Invoke(OS.Device.PlatformKind, message, callerMemberName, callerLineNumber, callerFilePath);
        }

        public event Action<PlatformKind, string, string, int, string> OnNotImplemented;

        public void NotImplemented(string message = "",
                                  [CallerMemberName] string callerMemberName = "",
                                  [CallerLineNumber] int callerLineNumber = -1,
                                  [CallerFilePath] string callerFilePath = "")
        {
            OnAll?.Invoke(OS.Device.PlatformKind, nameof(NotImplemented), message, callerMemberName, callerLineNumber, callerFilePath);
            OnNotImplemented?.Invoke(OS.Device.PlatformKind, message, callerMemberName, callerLineNumber, callerFilePath);
        }

        public event Action<PlatformKind, string, string, int, string> OnNoEquivalentFunctionAvailable;

        public void NoEquivalentFunctionAvailable(string message= "",
                                  [CallerMemberName] string callerMemberName = "",
                                  [CallerLineNumber] int callerLineNumber = -1,
                                  [CallerFilePath] string callerFilePath = "")
        {
            OnAll?.Invoke(OS.Device.PlatformKind, nameof(NoEquivalentFunctionAvailable), message, callerMemberName, callerLineNumber, callerFilePath);
            OnNoEquivalentFunctionAvailable?.Invoke(OS.Device.PlatformKind, message, callerMemberName, callerLineNumber, callerFilePath);
        }

        public event Action<PlatformKind, string, string, int, string> OnNoOSxNeededUseImplemented;

        public void NoOSxNeededUseImplemented(string message= "",
                                  [CallerMemberName] string callerMemberName = "",
                                  [CallerLineNumber] int callerLineNumber = -1,
                                  [CallerFilePath] string callerFilePath = "")
        {
            OnAll?.Invoke(OS.Device.PlatformKind, nameof(NoOSxNeededUseImplemented), message, callerMemberName, callerLineNumber, callerFilePath);
            OnNoOSxNeededUseImplemented?.Invoke(OS.Device.PlatformKind, message, callerMemberName, callerLineNumber, callerFilePath);
        }
    }
}
