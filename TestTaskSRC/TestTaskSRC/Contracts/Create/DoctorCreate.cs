namespace TestTaskSRC.Contracts.Create
{
    public record DoctorCreate(
        string FullName,
        Guid CabinetId,
        Guid SpecificationId,
        Guid DistrictId);
}
