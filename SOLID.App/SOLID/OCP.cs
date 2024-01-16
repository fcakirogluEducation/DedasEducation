namespace SOLID.App.SOLID;

public enum SalaryType
{
    Normal,
    Manager,
    Editor,
    Super
}

#region interfaces

public interface ISalaryCalculate
{
    decimal Calculate(decimal baseSalary);
}

public class NormalSalaryCalculate : ISalaryCalculate
{
    public decimal Calculate(decimal baseSalary)
    {
        return baseSalary * 10;
    }
}

public class ManagerSalaryCalculate : ISalaryCalculate
{
    public decimal Calculate(decimal baseSalary)
    {
        return baseSalary * 15;
    }
}

public class EditorSalaryCalculate : ISalaryCalculate
{
    public decimal Calculate(decimal baseSalary)
    {
        return baseSalary * 5;
    }
}

public class SuperSalaryCalculate : ISalaryCalculate
{
    public decimal Calculate(decimal baseSalary)
    {
        return baseSalary * 20;
    }
}

#endregion

public class NormalSalaryCalculateWithDelegate
{
    public decimal Calculate(decimal baseSalary)
    {
        return baseSalary * 10;
    }
}

public class ManagerSalaryCalculateWithDelegate
{
    public decimal Calculate(decimal baseSalary)
    {
        return baseSalary * 15;
    }
}

public delegate decimal SalaryCalculateDelegate(decimal baseSalary);

public class SalaryCalculate
{
    public decimal CalculateWithDelegate(SalaryCalculateDelegate salaryCalculateDelegate, decimal baseSalary)
    {
        return salaryCalculateDelegate(baseSalary);
    }


    public decimal CalculateWithInterface(ISalaryCalculate salaryCalculate, decimal baseSalary)
    {
        return salaryCalculate.Calculate(baseSalary);
    }


    public decimal Calculate(decimal baseSalary, SalaryType salaryType)
    {
        return salaryType switch
        {
            SalaryType.Normal => baseSalary * 10,
            SalaryType.Manager => baseSalary * 15,
            SalaryType.Editor => baseSalary * 5,
            _ => throw new ArgumentException("Invalid salary type")
        };
    }
}