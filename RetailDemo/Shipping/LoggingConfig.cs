using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;

namespace Shipping
{
    class LoggingConfig
    {
        public static void ConfigureLog4Net()
        {
            var layout = new PatternLayout
            {
                ConversionPattern = "%d [%t] %-5p %c [%x] - %m%n"
            };
            layout.ActivateOptions();
            var consoleAppender = new ColoredConsoleAppender
            {
                Threshold = Level.Info,
                Layout = layout
            };
            consoleAppender.ActivateOptions();
            var appenderInfo = new RollingFileAppender
            {
                DatePattern = "yyyy-MM-dd'.txt'",
                RollingStyle = RollingFileAppender.RollingMode.Composite,
                MaxFileSize = 10 * 1024 * 1024,
                MaxSizeRollBackups = 10,
                LockingModel = new FileAppender.MinimalLock(),
                StaticLogFileName = false,
                File = @"C:\Logs\Nservicebus\nsb_info_log_ship_",
                Layout = layout,
                AppendToFile = true,
                Threshold = Level.Info,
            };

            var appenderError = new RollingFileAppender
            {
                DatePattern = "yyyy-MM-dd'.txt'",
                RollingStyle = RollingFileAppender.RollingMode.Composite,
                MaxFileSize = 10 * 1024 * 1024,
                MaxSizeRollBackups = 10,
                LockingModel = new FileAppender.MinimalLock(),
                StaticLogFileName = false,
                File = @"C:\Logs\Nservicebus\nsb_error_log_ship_",
                Layout = layout,
                AppendToFile = true,
                Threshold = Level.Error,
            };
            appenderInfo.ActivateOptions();

            BasicConfigurator.Configure(appenderInfo, consoleAppender, appenderError);
        }
    }
}
