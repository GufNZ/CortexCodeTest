//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VehicleWcfService.Data
{
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Infrastructure;
	using System.Data.Entity.Core.Objects;
	using System.Linq;
	
	public partial class CodeTestEntities : DbContext
	{
		public CodeTestEntities()
			: base("name=CodeTestEntities")
		{
		}
	
	
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			throw new UnintentionalCodeFirstException();
		}
	
	
		public virtual DbSet<Vehicle> Vehicles { get; set; }
	
		public virtual ObjectResult<AddVehicle_Result> AddVehicle(string model, Nullable<short> year, string description)
		{
			var modelParameter = model != null
				? new ObjectParameter("Model", model)
				: new ObjectParameter("Model", typeof(string));
	
			var yearParameter = year.HasValue
				? new ObjectParameter("Year", year)
				: new ObjectParameter("Year", typeof(short));
	
			var descriptionParameter = description != null
				? new ObjectParameter("Description", description)
				: new ObjectParameter("Description", typeof(string));
	
			return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AddVehicle_Result>("AddVehicle", modelParameter, yearParameter, descriptionParameter);
		}
	
		public virtual ObjectResult<GetVehicle_Result> GetVehicle(Nullable<int> iD)
		{
			var iDParameter = iD.HasValue
				? new ObjectParameter("ID", iD)
				: new ObjectParameter("ID", typeof(int));
	
			return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetVehicle_Result>("GetVehicle", iDParameter);
		}
	
		public virtual ObjectResult<ListVehicles_Result> ListVehicles()
		{
			return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ListVehicles_Result>("ListVehicles");
		}
	
		public virtual int RemoveVehicle(Nullable<int> iD)
		{
			var iDParameter = iD.HasValue
				? new ObjectParameter("ID", iD)
				: new ObjectParameter("ID", typeof(int));
	
			return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RemoveVehicle", iDParameter);
		}
	
		public virtual ObjectResult<UpdateVehicle_Result> UpdateVehicle(Nullable<int> iD, string model, Nullable<short> year, string description)
		{
			var iDParameter = iD.HasValue
				? new ObjectParameter("ID", iD)
				: new ObjectParameter("ID", typeof(int));
	
			var modelParameter = model != null
				? new ObjectParameter("Model", model)
				: new ObjectParameter("Model", typeof(string));
	
			var yearParameter = year.HasValue
				? new ObjectParameter("Year", year)
				: new ObjectParameter("Year", typeof(short));
	
			var descriptionParameter = description != null
				? new ObjectParameter("Description", description)
				: new ObjectParameter("Description", typeof(string));
	
			return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UpdateVehicle_Result>("UpdateVehicle", iDParameter, modelParameter, yearParameter, descriptionParameter);
		}
	}
}
