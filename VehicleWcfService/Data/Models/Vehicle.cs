using System;
using System.Collections.Generic;
using System.Linq;

using VehicleWcfService.Utilities;

namespace VehicleWcfService.Data
{
	public partial class Vehicle
	{
		public (bool isValid, string errorMessage) Validate()
		{
			var errors = new List<string>();

			if (string.IsNullOrWhiteSpace(Model))
			{
				errors.Add($"{nameof(Model)} is required!");
			}

			if (Year < 1000 || Year > 9999)
			{
				errors.Add($"{nameof(Year)} is out of the accepted range of [1000, 9999]!");
			}

			return (!errors.Any(), string.Join(Environment.NewLine, errors).NullIfEmpty());
		}
	}
}
