namespace Models;
public class Employee
{
    public Employee(Guid employeeId, string firstName, string lastName, string email, string password, bool isManager)
    {
        this.employeeId = employeeId;
        this.firstName = firstName;
        this.lastName = lastName;
        this.email = email;
        this.password = password;
        this.isManager = isManager;
    }

    public Guid employeeId { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public bool isManager { get; set; }
}

/*
CREATE TABLE Employees(
employeeId UNIQUEIDENTIFIER PRIMARY KEY,
firstName NVARCHAR(25) NOT NULL,
lastName NVARCHAR(25) NOT NULL,
email NVARCHAR(50) NOT NULL UNIQUE,
password NVARCHAR(25) NOT NULL,
isManager BIT NOT NULL,
);
*/