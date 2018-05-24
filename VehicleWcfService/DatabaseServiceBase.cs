using System;
using System.Threading.Tasks;

using NLog;

using VehicleWcfService.Data;
using VehicleWcfService.Utilities;

namespace VehicleWcfService
{
	public class DatabaseServiceBase
	{
		private static readonly Logger Log = LogManager.GetCurrentClassLogger();


		protected static TResult ExecDB<TResult>(Func<CodeTestEntities, TResult> func)
			where TResult : Result<TResult>, new()
		{
			try
			{
				using (var db = new CodeTestEntities())
				{
					return func(db);
				}
			}
			catch (Exception exception)
			{
				Log.LogError(exception);

				return Result<TResult>.Failed(
#if DEBUG
					exception.ToString()
#else
					exception.Message
#endif
				);
			}
		}

		protected static Task<TResult> ExecDBAsync<TResult>(Func<CodeTestEntities, Task<TResult>> func)
			where TResult : Result<TResult>, new()
		{
			try
			{
				using (var db = new CodeTestEntities())
				{
					return func(db);
				}
			}
			catch (Exception exception)
			{
				Log.LogError(exception);

				return Task.FromResult(
					Result<TResult>.Failed(
#if DEBUG
						exception.ToString()
#else
						exception.Message
#endif
					)
				);
			}
		}
	}
}
