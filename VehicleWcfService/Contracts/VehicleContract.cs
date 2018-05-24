using System.Runtime.Serialization;

using VehicleWcfService.Utilities;

namespace VehicleWcfService.Contracts
{
	[DataContract]
	public class VehicleContract
	{
		[DataMember(IsRequired = true)]
		public int ID { get; set; }

		[DataMember(IsRequired = true)]
		public string Model { get; set; }

		[DataMember(IsRequired = true)]
		public ushort Year { get; set; }

		[DataMember(IsRequired = false, EmitDefaultValue = false)]
		public string Description { get; set; }


		public override string ToString()
		{
			return $"{{{GetType().Name}: {nameof(ID)}: {ID}, {nameof(Model)}: {Model}, {nameof(Year)}: {Year}".RCoalesce($", {nameof(Description)}: ", Description) + "}";
		}
	}
}
