using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

using NLog;

using VehicleWcfService.Contracts;
using VehicleWcfService.Utilities;

namespace VehicleWcfService
{
	public class VehicleService : DatabaseServiceBase, IVehicleService
	{
		private static readonly Logger Log = LogManager.GetCurrentClassLogger();


		public VehicleListResult ListVehicles()
		{
			return ExecDB(
				db => VehicleListResult.Succeeded(
					db.Vehicles
						.Select(vehicle => vehicle.ToContract())
						.ToList()
						.Log(Log, result => (LogLevel.Info, $"Returning {result.Count} Vehicles."))
				)
			);
		}

		public async Task<VehicleResult> GetVehicleByIDAsync(ushort id)
		{
			return await ExecDBAsync(
				async db => VehicleResult.Succeeded(
					(await db.Vehicles.FirstOrDefaultAsync(vehicle => vehicle.ID == id))
					.ToContract()
					.Log(Log, result => (LogLevel.Info, $"For ID {id}, return {result}."))
				)
			);
		}


		public async Task<VehicleResult> AddVehicleAsync(VehicleContract vehicleContract)
		{
			return await ExecDBAsync(
				async db =>
				{
					var vehicle = vehicleContract.ToModel();
					var (valid, error) = vehicle.Validate();
					if (valid)
					{
						vehicleContract = db.Vehicles.Add(vehicle)
							.ToContract()
							.Log(Log, result => (LogLevel.Info, $"Adding with new ID {result.ID}: {result}."));

						(await db.SaveChangesAsync()).Log(Log, rows => (LogLevel.Debug, $"Rows affected: {rows}"));

						return VehicleResult.Succeeded(vehicleContract);
					}


					Log.LogError($"Failed validation: {error}.");
					return VehicleResult.Failed(error);
				}
			);
		}

		public async Task<Result> UpdateVehicleAsync(VehicleContract vehicleContract)
		{
			return await ExecDBAsync(
				async db =>
				{
					var vehicle = vehicleContract.ToModel();
					var (valid, error) = vehicle.Validate();
					if (valid)
					{
						db.Vehicles.Attach(vehicle)
							.Log(Log, result => (LogLevel.Info, $"Saving {result.ToContract()}."));

						(await db.SaveChangesAsync()).Log(Log, rows => (LogLevel.Debug, $"Rows affected: {rows}"));

						return Result.Succeeded();
					}


					Log.LogError($"Failed validation: {error}.");
					return Result.Failed(error);
				}
			);
		}

		public async Task<Result> DeleteVehicleByIDAsync(ushort id)
		{
			return await ExecDBAsync(
				async db =>
				{
					var vehicle = await db.Vehicles.FirstOrDefaultAsync(v => v.ID == id);
					if (vehicle == null)
					{
						Log.LogWarn($"Can't find Vehicle with ID {id}.");
						return Result.Failed($"Vehicle with ID {id} does not exist!");
					}


					Log.LogInfo($"Removing {vehicle.ToContract()}...");
					db.Vehicles.Remove(vehicle);

					(await db.SaveChangesAsync()).Log(Log, rows => (LogLevel.Debug, $"Rows affected: {rows}"));

					return Result.Succeeded();
				}
			);
		}
	}
}
