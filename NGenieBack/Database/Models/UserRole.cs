namespace NGenieBack.Database.Models;


[Flags]
public enum UserRole
{
    None = 0,
    Student = 1,
    Teacher = 2,
    Admin = 4,
}