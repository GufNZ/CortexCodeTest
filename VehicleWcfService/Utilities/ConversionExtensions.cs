using VehicleWcfService.Contracts;
using VehicleWcfService.Data;

namespace VehicleWcfService.Utilities
{
	public static class ConversionExtensions
	{
		public static VehicleContract ToContract(this Vehicle vehicle)
		{
			return (vehicle == null)
				? null
				: new VehicleContract
				{
					ID = vehicle.ID,
					Model = vehicle.Model,
					Year = (ushort)vehicle.Year,
					Description = vehicle.Description
				};
		}

		public static Vehicle ToModel(this VehicleContract vehicleContract)
		{
			return (vehicleContract == null)
				? null
				: new Vehicle
				{
					ID = vehicleContract.ID,
					Model = vehicleContract.Model,
					Year = (short)vehicleContract.Year,
					Description = vehicleContract.Description
				};
		}
	}
}
