using System.ServiceModel;
using System.Threading.Tasks;

using VehicleWcfService.Contracts;

namespace VehicleWcfService
{
	[ServiceContract]
	public interface IVehicleService
	{
		[OperationContract]
		VehicleListResult ListVehicles();

		[OperationContract]
		Task<VehicleResult> GetVehicleByIDAsync(ushort id);

		[OperationContract]
		Task<VehicleResult> AddVehicleAsync(VehicleContract vehicleContract);

		[OperationContract]
		Task<Result> UpdateVehicleAsync(VehicleContract vehicleContract);

		[OperationContract]
		Task<Result> DeleteVehicleByIDAsync(ushort id);
	}
}
