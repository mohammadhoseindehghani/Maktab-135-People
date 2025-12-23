namespace Food.Core.Domain.Model.Emtities
{
	public class Restaurant
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		//public int? OwnerId { get; set; }
		//public int CreatedBy { get; set; }
		//public int LastModifiedBy { get; set; }
	}
	public class Profile
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int OwnerId { get; set; }
	}
}
