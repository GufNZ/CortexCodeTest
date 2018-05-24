using System.Runtime.Serialization;

namespace VehicleWcfService
{
	// Use a data contract as illustrated in the sample below to add composite types to service operations.
	[DataContract]
	public class CompositeType
	{
		[DataMember]
		public bool BoolValue { get; set; } = true;

		[DataMember]
		public string StringValue { get; set; } = "Hello ";
	}
}
