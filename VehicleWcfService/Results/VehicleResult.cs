using System.Runtime.Serialization;

using VehicleWcfService.Contracts;

namespace VehicleWcfService
{
// ReSharper disable once ClassNeverInstantiated.Global
	[DataContract]
	public class VehicleResult : ValueResult<VehicleResult, VehicleContract> { }
}
