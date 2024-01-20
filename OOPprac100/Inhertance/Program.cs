using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Inhertance
{
    internal class Program
    {
        static void Main(string[] args)
        {

        } 
    }

    public  abstract class Employee
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal HourlyRate { get; set; }

        public int ExpectedHours { get; set; }
        public int LoggedHours { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        protected  decimal CalculateBasicSalary() => (LoggedHours - Math.Max(LoggedHours - ExpectedHours, 0)) * HourlyRate;
        protected  decimal CalculateOverTime() => Math.Max(LoggedHours - ExpectedHours, 0) * HourlyRate * 1.5m;
        protected virtual  decimal CalculateGrossBySalary() => CalculateBasicSalary() + CalculateOverTime();
        protected decimal CalculateTaxAmount() => CalculateGrossBySalary() * HRConstants.TaxAmount;
        protected  decimal CalculatNetSalary() => CalculateGrossBySalary() - CalculateTaxAmount();

        public abstract string ShowSalarySlip();

    }
  sealed  public class Manager: Employee
    {
        public decimal Allowance { get; set; }
        public override string ShowSalarySlip()
        {
            decimal basicSalary = CalculateBasicSalary();
            decimal grossSalary = CalculateGrossBySalary();
            decimal taxAmount = CalculateTaxAmount();
            decimal netSalary = CalculatNetSalary();
            decimal overtime = CalculateOverTime();

            return $"Employee: #{Id} ({FullName}).\n" +
            $"Hours Logged: {LoggedHours} hrs.\n" +
            $"Hourly rate: {HourlyRate.ToString("C")} /hr.\n" +
            $"Basic Salary: {basicSalary.ToString("C")}\n" +
            $"Overtime({HRConstants.OverTime}x): {overtime.ToString("C")}\n" +
            $"Allowance: {Allowance.ToString("C")}\n" +
            $"Gross Pay: {grossSalary.ToString("C")}\n" +
            $"Tax Amount ({(HRConstants.TaxAmount).ToString("%0")}): {taxAmount.ToString("C")}\n" +
            $"-------------------------------------\n" +
            $"Net Salary: {netSalary.ToString("C")}";
        }
        protected override decimal CalculateGrossBySalary()
        {
            return base.CalculateGrossBySalary()+Allowance;
        }

    }
 sealed   public class SaleAgent: Employee
    {
        public decimal TotalSale { get; set; }
        public override string ShowSalarySlip()
        {
            decimal basicSalary = CalculateBasicSalary();
            decimal grossSalary = CalculateGrossBySalary();
            decimal taxAmount = CalculateTaxAmount();
            decimal netSalary = CalculatNetSalary();
            decimal overtime = CalculateOverTime();
            decimal commission = CalculateCommission();

            return $"Employee: #{Id} ({FullName}).\n" +
            $"Hours Logged: {LoggedHours} hrs.\n" +
            $"Hourly rate: {HourlyRate.ToString("C")} /hr.\n" +
            $"Basic Salary: {basicSalary.ToString("C")}\n" +
            $"Overtime({HRConstants.OverTime}x): {overtime.ToString("C")}\n" +
            $"Total Sales: {TotalSale.ToString("C")}\n" +
            $"Commission({(HRConstants.CommissionRate).ToString("%0")}): {commission.ToString("C")}\n" +
            $"Gross Pay: {grossSalary.ToString("C")}\n" +
            $"Tax Amount ({(HRConstants.TaxAmount).ToString("%0")}): {taxAmount.ToString("C")}\n" +
            $"-------------------------------------\n" +
            $"Net Salary: {netSalary.ToString("C")}";
        }

        private decimal CalculateCommission() => TotalSale * HRConstants.CommissionRate;
        protected override decimal CalculateGrossBySalary()
        {
            return base.CalculateGrossBySalary()+ CalculateCommission();
        }
    }
  sealed  public class HandMan: Employee
    {

        public decimal HardShip { get; set; }
        public override string ShowSalarySlip()
        {
            decimal basicSalary = CalculateBasicSalary();
            decimal grossSalary = CalculateGrossBySalary();
            decimal taxAmount = CalculateTaxAmount();
            decimal netSalary = CalculatNetSalary();
            decimal overtime = CalculateOverTime();

            return $"Employee: #{Id} ({FullName}).\n" +
            $"Hours Logged: {LoggedHours} hrs.\n" +
            $"Hourly rate: {HourlyRate.ToString("C")} /hr.\n" +
            $"Basic Salary: {basicSalary.ToString("C")}\n" +
            $"Overtime({HRConstants.OverTime}x): {overtime.ToString("C")}\n" +
            $"Hardship: {HardShip.ToString("C")}\n" +
            $"Gross Pay: {grossSalary.ToString("C")}\n" +
            $"Tax Amount ({(HRConstants.TaxAmount).ToString("%0")}): {taxAmount.ToString("C")}\n" +
            $"-------------------------------------\n" +
            $"Net Salary: {netSalary.ToString("C")}";
        }

        protected override decimal CalculateGrossBySalary()
        {
            return base.CalculateGrossBySalary()+ HardShip;
        }
    }
 sealed   public class SoftwereEnginer:Employee
    {

        public decimal TrainingAllownce { get; set; }

        public int StoryPointCompleted { get; set; }

        public override string ShowSalarySlip()
        {
            decimal basicSalary = CalculateBasicSalary();
            decimal grossSalary = CalculateGrossBySalary();
            decimal taxAmount = CalculateTaxAmount();
            decimal netSalary = CalculatNetSalary();
            decimal overtime = CalculateOverTime();
            decimal bonus = CalculateBouns();

            return $"Employee: #{Id} ({FullName}).\n" +
                $"Hours Logged: {LoggedHours} hrs.\n" +
                $"Hourly rate: {HourlyRate.ToString("C")} /hr.\n" +
                $"Basic Salary: {basicSalary.ToString("C")}\n" +
                $"Overtime({HRConstants.OverTime}x): {overtime.ToString("C")}\n" +
                $"Training Allowance: {TrainingAllownce.ToString("C")}\n" +
                $"Bonus(>={HRConstants.SoftwareEngineerPointThreshols}): {bonus.ToString("C")}\n" +
                $"Gross Pay: {grossSalary.ToString("C")}\n" +
                $"Tax Amount ({(HRConstants.TaxAmount).ToString("%0")}): {taxAmount.ToString("C")}\n" +
                $"-------------------------------------\n" +
                $"Net Salary: {netSalary.ToString("C")}";
        }

        private decimal CalculateBouns()
      => StoryPointCompleted >= HRConstants.SoftwareEngineerPointThreshols ? HRConstants.SoftwareEngineerBounsAmount : 0;

        protected override decimal CalculateGrossBySalary()
        {
            return base.CalculateGrossBySalary()+ CalculateBouns()+TrainingAllownce;
        }

    }
    public static class HRConstants
    {

        public static decimal OverTime = 1.5m;
        public static decimal TaxAmount = 0.10m;
        public static decimal CommissionRate = 0.0005m;
        public static decimal SoftwareEngineerBounsAmount = 40m;
        public static int SoftwareEngineerPointThreshols = 8;


    } 
  
}
