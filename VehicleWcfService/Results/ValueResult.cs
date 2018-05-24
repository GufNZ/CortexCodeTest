using System.Runtime.Serialization;

namespace VehicleWcfService
{
	[DataContract]
	public class ValueResult<TContract, TValue> : Result<TContract>
		where TContract : ValueResult<TContract, TValue>, new()
	{
		[DataMember(IsRequired = true)]
		public TValue Value { get; private set; }


		public static TContract Succeeded(TValue value)
		{
			var result = Succeeded();
			result.Value = value;
			return result;
		}
	}
}
