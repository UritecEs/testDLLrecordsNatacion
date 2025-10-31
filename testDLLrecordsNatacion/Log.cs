using NLog;
using NLog.Config;
using NLog.Targets;
using NLog.Targets.Wrappers;
using System;
using System.IO;


namespace testDLLrecordsNatacion
{
    internal static class Log
    {
        public static Logger Instance { get; private set; }

        //Logger constructor
        static Log()
        {
            var layout = "${date:format=yyyy-MM-dd HH\\:mm\\:ss.ff} [${level}] ${processid} ${logger} ${message} ${argument} \n${exception} ${stacktrace}";
            Instance = LogManager.GetCurrentClassLogger();
            //LogManager.ReconfigExistingLoggers();
            
            LogManager.Setup().LoadConfiguration(builder => {
                var fileTargetLowerLevels = builder.ForTarget("traceDebugInfo").WriteTo(new FileTarget
                {
                    FileName = Path.Combine($"Logs/{DateTime.Now.ToString("yyyyMMdd")}_log_debugInfo.txt"),
                    Layout = layout,
                    KeepFileOpen = false,
                    ArchiveAboveSize = 5_000_000,  // 5 MB
                    MaxArchiveFiles = 5,
                }).WithAsync(AsyncTargetWrapperOverflowAction.Block);
                builder.ForLogger().FilterMaxLevel(LogLevel.Info).WriteTo(fileTargetLowerLevels);

                var fileTargetHigherLevels = builder.ForTarget("warnErrorFatal").WriteTo(new FileTarget
                {
                    FileName = Path.Combine($"Logs/{DateTime.Now.ToString("yyyyMMdd")}_log_debugInfo.txt"),
                    Layout = layout,
                    KeepFileOpen = false,
                    ArchiveAboveSize = 5_000_000,  // 5 MB
                    MaxArchiveFiles = 5,
                }).WithAsync(AsyncTargetWrapperOverflowAction.Block);
                builder.ForLogger().FilterMinLevel(LogLevel.Warn).WriteTo(fileTargetHigherLevels);
            });

            //LogManager.Setup(new Action<ISetupBuilder>(NLog.config));
        }

    }
}
