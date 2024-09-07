namespace TestTaskSRC.Contracts.Response
{
    public record DoctorResponse(
        Guid Id,
        string FullName,
        Guid? CabinetId,
        Guid? SpecificationId,
        Guid? DistrictId);
}
