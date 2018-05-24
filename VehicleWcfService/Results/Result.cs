using System.Runtime.Serialization;

namespace VehicleWcfService
{
	[DataContract]
	public class Result<TContract>
		where TContract : Result<TContract>, new()
	{
		[DataMember(IsRequired = true)]
		public bool Success { get; private set; }

		[DataMember(IsRequired = false, EmitDefaultValue = false)]
		public string ErrorMessage { get; private set; }


		public static TContract Succeeded()
		{
			return new TContract
			{
				Success = true
			};
		}


		public static TContract Failed(string errorMessage)
		{
			return new TContract
			{
				Success = false,
				ErrorMessage = errorMessage
			};
		}
	}


	[DataContract]
	public class Result : Result<Result> { }
}
