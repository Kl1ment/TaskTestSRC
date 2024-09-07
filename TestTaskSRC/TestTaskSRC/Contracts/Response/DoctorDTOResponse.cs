namespace TestTaskSRC.Contracts.Response
{
    public record DoctorDTOResponse(
        Guid Id,
        string FullName,
        int? Cabinet,
        string? Specification,
        int? District);
}
