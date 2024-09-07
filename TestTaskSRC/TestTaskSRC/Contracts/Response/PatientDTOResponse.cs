namespace TestTaskSRC.Contracts.Response
{
    public record PatientDTOResponse(
        Guid Id,
        string Surname,
        string Name,
        string Patronymic,
        string Address,
        DateTime Birthdate,
        string Sex,
        int? District);
}
