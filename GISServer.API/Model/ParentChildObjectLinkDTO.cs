namespace GISServer.API.Model
{
    public class ParentChildObjectLinkDTO
    {
        public Guid? Id { get; set; }
        public String? ParentGeographicalObjectName { get; set; }
        public String? ChildGeographicalObjectName { get; set; }
        public bool? CompletelyIncludedFlag { get; set; }
        public double? IncludedPercent { get; set; }
        public DateTime? CreationDateTime { get; set; }
        public DateTime? LastUpdatedDateTime { get; set; }
    }
}