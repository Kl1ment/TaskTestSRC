namespace TestTaskSRC.Contracts.Response
{
    public record DoctorResponse(
        Guid Id,
        string FullName,
        int? Cabinet,
        string? Specification,
        int? District);
}
