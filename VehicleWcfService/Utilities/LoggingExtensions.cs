using System;
using System.Runtime.CompilerServices;

using NLog;

namespace VehicleWcfService.Utilities
{
	public static class LoggingExtensions
	{
		public static T Log<T>(this T result, Logger logger, Func<T, (LogLevel level, string message)> getLog, [CallerMemberName] string member = null, [CallerLineNumber] int line = default)
		{
			var (level, message) = getLog(result);
			logger.Log(level, $"{Prefix(member, line)}: {message}");
			return result;
		}


		public static void LogTrace(this Logger logger, string message, [CallerMemberName] string member = null, [CallerLineNumber] int line = default)
		{
			logger.Trace($"{Prefix(member, line)}: {message}");
		}

		public static void LogDebug(this Logger logger, string message, [CallerMemberName] string member = null, [CallerLineNumber] int line = default)
		{
			logger.Debug($"{Prefix(member, line)}: {message}");
		}

		public static void LogInfo(this Logger logger, string message, [CallerMemberName] string member = null, [CallerLineNumber] int line = default)
		{
			logger.Info($"{Prefix(member, line)}: {message}");
		}

		public static void LogWarn(this Logger logger, string message, [CallerMemberName] string member = null, [CallerLineNumber] int line = default)
		{
			logger.Warn($"{Prefix(member, line)}: {message}");
		}
		public static void LogWarn(this Logger logger, Exception exception, [CallerMemberName] string member = null, [CallerLineNumber] int line = default)
		{
			logger.Warn(
				exception,
#if DEBUG
				$"{Prefix(member, line)}: {exception}"
#else
				$"{Prefix(member, line)}: {exception.Message}"
#endif
			);
		}

		public static void LogError(this Logger logger, string message, [CallerMemberName] string member = null, [CallerLineNumber] int line = default)
		{
			logger.Error($"{Prefix(member, line)}: {message}");
		}
		public static void LogError(this Logger logger, Exception exception, [CallerMemberName] string member = null, [CallerLineNumber] int line = default)
		{
			logger.Error(
				exception,
#if DEBUG
				$"{Prefix(member, line)}: {exception}"
#else
				$"{Prefix(member, line)}: {exception.Message}"
#endif
			);
		}

		public static void LogFatal(this Logger logger, string message, [CallerMemberName] string member = null, [CallerLineNumber] int line = default)
		{
			logger.Fatal($"{Prefix(member, line)}: {message}");
		}
		public static void LogFatal(this Logger logger, Exception exception, [CallerMemberName] string member = null, [CallerLineNumber] int line = default)
		{
			logger.Fatal(
				exception,
#if DEBUG
				$"{Prefix(member, line)}: {exception}"
#else
				$"{Prefix(member, line)}: {exception.Message}"
#endif
			);
		}


		private static string Prefix(string member, int line)
		{
			return $"{member}{"[".RCoalesce(line.NullIfDefault().ToString().NullIfEmpty(), "]")}";
		}
	}
}
