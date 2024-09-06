namespace TestTaskSRC.Contracts.Create
{
    public record PatientCreate(
        string Surname,
        string Name,
        string Patronymic,
        string Address,
        DateTime Birthdate,
        string Sex,
        int District);
}
