using NLog;



namespace testDLLrecordsNatacion
{
    internal static class Log
    {
        public static Logger Instance { get; private set; }

        //Logger constructor
        static Log()
        {
            //LogManager.ReconfigExistingLoggers();
            Instance = LogManager.GetCurrentClassLogger();


            LogManager.Setup().LoadConfiguration(builder => {
                builder.ForLogger().FilterMinLevel(LogLevel.Info).WriteToFile(fileName: "Log_debugInfo.txt");
                builder.ForLogger().FilterMinLevel(LogLevel.Debug).WriteToFile(fileName: "Log_debugInfo.txt");
                builder.ForLogger().FilterMinLevel(LogLevel.Warn).WriteToFile(fileName: "Log_warnErrorFatal.txt");
                builder.ForLogger().FilterMinLevel(LogLevel.Error).WriteToFile(fileName: "Log_warnErrorFatal.txt");
                builder.ForLogger().FilterMinLevel(LogLevel.Fatal).WriteToFile(fileName: "Log_warnErrorFatal.txt");
            });

        }

    }
}
