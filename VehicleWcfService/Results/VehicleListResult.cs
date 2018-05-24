using System.Collections.Generic;
using System.Runtime.Serialization;

using VehicleWcfService.Contracts;

namespace VehicleWcfService
{
// ReSharper disable once ClassNeverInstantiated.Global
	[DataContract]
	public class VehicleListResult : ValueResult<VehicleListResult, List<VehicleContract>> { }
}
