using System;

namespace LoanBuddyApp
{
    public interface IApprovable
    {
        bool ApproveLoan();
        double CalculateEMI();
        string GetLoanStatus();
    }

    public class Applicant
    {
        public string Name { get; set; }
        private int creditScore;
        public double Income { get; set; }
        public double LoanAmount { get; set; }

        public Applicant(string name, int creditScore, double income, double loanAmount)
        {
            Name = name;
            this.creditScore = creditScore;
            Income = income;
            LoanAmount = loanAmount;
        }

        public int CreditScore
        {
            get { return creditScore; }
            set
            {
                if (value >= 300 && value <= 900)
                    creditScore = value;
                else
                    throw new ArgumentException("Credit score must be between 300 and 900");
            }
        }

        public bool IsEligible()
        {
            return creditScore >= 550 && Income > 0 && LoanAmount > 0;
        }

        public override string ToString()
        {
            return $"Applicant: {Name}, Credit Score: {creditScore}, Income: ${Income:F2}, Loan Amount: ${LoanAmount:F2}";
        }
    }

    public abstract class LoanApplication : IApprovable
    {
        public string LoanType { get; protected set; }
        public int TermMonths { get; protected set; }
        public double InterestRate { get; protected set; }
        public Applicant Applicant { get; protected set; }
        private bool isApproved;
        private string loanStatus;

        public LoanApplication(Applicant applicant, int termMonths, double interestRate, string loanType)
        {
            Applicant = applicant;
            TermMonths = termMonths;
            InterestRate = interestRate;
            LoanType = loanType;
            isApproved = false;
            loanStatus = "Pending";
        }

        public bool ApproveLoan()
        {
            if (!Applicant.IsEligible())
            {
                loanStatus = "Rejected - Applicant not eligible";
                return isApproved = false;
            }

            double monthlyIncome = Applicant.Income / 12;
            double emi = CalculateEMI();
            double debtToIncomeRatio = (emi / monthlyIncome) * 100;

            if (debtToIncomeRatio > 50)
            {
                loanStatus = "Rejected - High debt-to-income ratio";
                return isApproved = false;
            }

            if (Applicant.CreditScore < 600)
            {
                loanStatus = "Rejected - Credit score too low";
                return isApproved = false;
            }

            if (!PerformRiskAssessment())
            {
                loanStatus = "Rejected - Risk assessment failed";
                return isApproved = false;
            }

            isApproved = true;
            loanStatus = "Approved";
            return true;
        }

        public abstract double CalculateEMI();

        protected virtual bool PerformRiskAssessment()
        {
            return true;
        }

        public string GetLoanStatus()
        {
            return loanStatus;
        }

        public void GenerateRepaymentPlan()
        {
            if (!isApproved)
            {
                Console.WriteLine("Cannot generate repayment plan for rejected loan");
                return;
            }

            double emi = CalculateEMI();
            double totalAmount = emi * TermMonths;
            double totalInterest = totalAmount - Applicant.LoanAmount;

            Console.WriteLine("\n========== REPAYMENT PLAN ==========");
            Console.WriteLine($"Loan Type: {LoanType}");
            Console.WriteLine($"Principal Amount: ${Applicant.LoanAmount:F2}");
            Console.WriteLine($"Interest Rate: {InterestRate:F2}% per annum");
            Console.WriteLine($"Loan Term: {TermMonths} months");
            Console.WriteLine($"Monthly EMI: ${emi:F2}");
            Console.WriteLine($"Total Amount to be Paid: ${totalAmount:F2}");
            Console.WriteLine($"Total Interest: ${totalInterest:F2}");
            Console.WriteLine($"Status: {loanStatus}");
            Console.WriteLine("====================================\n");
        }
    }

    public class PersonalLoan : LoanApplication
    {
        public PersonalLoan(Applicant applicant, int termMonths = 60) 
            : base(applicant, termMonths, 10.5, "Personal Loan")
        {
        }

        public override double CalculateEMI()
        {
            double monthlyRate = InterestRate / 100 / 12;
            double numerator = Applicant.LoanAmount * monthlyRate * Math.Pow(1 + monthlyRate, TermMonths);
            double denominator = Math.Pow(1 + monthlyRate, TermMonths) - 1;
            return numerator / denominator;
        }

        protected override bool PerformRiskAssessment()
        {
            return Applicant.CreditScore >= 600;
        }
    }

    public class HomeLoan : LoanApplication
    {
        public HomeLoan(Applicant applicant, int termMonths = 240) 
            : base(applicant, termMonths, 6.5, "Home Loan")
        {
        }

        public override double CalculateEMI()
        {
            double monthlyRate = InterestRate / 100 / 12;
            double numerator = Applicant.LoanAmount * monthlyRate * Math.Pow(1 + monthlyRate, TermMonths);
            double denominator = Math.Pow(1 + monthlyRate, TermMonths) - 1;
            return numerator / denominator;
        }

        protected override bool PerformRiskAssessment()
        {
            return Applicant.CreditScore >= 550;
        }
    }

    public class AutoLoan : LoanApplication
    {
        public AutoLoan(Applicant applicant, int termMonths = 84) 
            : base(applicant, termMonths, 8.0, "Auto Loan")
        {
        }

        public override double CalculateEMI()
        {
            double monthlyRate = InterestRate / 100 / 12;
            double numerator = Applicant.LoanAmount * monthlyRate * Math.Pow(1 + monthlyRate, TermMonths);
            double denominator = Math.Pow(1 + monthlyRate, TermMonths) - 1;
            return numerator / denominator;
        }

        protected override bool PerformRiskAssessment()
        {
            return Applicant.CreditScore >= 575;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========== LOANBUDDY - LOAN APPROVAL AUTOMATION ==========\n");

            Console.WriteLine("--- TEST CASE 1: Personal Loan Application ---");
            Applicant applicant1 = new Applicant("John Doe", 720, 60000, 250000);
            Console.WriteLine(applicant1);
            
            PersonalLoan personalLoan = new PersonalLoan(applicant1, 60);
            Console.WriteLine($"Loan Type: {personalLoan.LoanType}");
            Console.WriteLine($"Monthly EMI: ${personalLoan.CalculateEMI():F2}");
            
            bool isApproved = personalLoan.ApproveLoan();
            Console.WriteLine($"Approval Status: {personalLoan.GetLoanStatus()}");
            
            if (isApproved)
                personalLoan.GenerateRepaymentPlan();
            Console.WriteLine();

            Console.WriteLine("--- TEST CASE 2: Home Loan Application ---");
            Applicant applicant2 = new Applicant("Sarah Smith", 680, 120000, 3000000);
            Console.WriteLine(applicant2);
            
            HomeLoan homeLoan = new HomeLoan(applicant2, 240);
            Console.WriteLine($"Loan Type: {homeLoan.LoanType}");
            Console.WriteLine($"Monthly EMI: ${homeLoan.CalculateEMI():F2}");
            
            isApproved = homeLoan.ApproveLoan();
            Console.WriteLine($"Approval Status: {homeLoan.GetLoanStatus()}");
            
            if (isApproved)
                homeLoan.GenerateRepaymentPlan();
            Console.WriteLine();

            Console.WriteLine("--- TEST CASE 3: Auto Loan Application ---");
            Applicant applicant3 = new Applicant("Michael Johnson", 650, 75000, 800000);
            Console.WriteLine(applicant3);
            
            AutoLoan autoLoan = new AutoLoan(applicant3, 84);
            Console.WriteLine($"Loan Type: {autoLoan.LoanType}");
            Console.WriteLine($"Monthly EMI: ${autoLoan.CalculateEMI():F2}");
            
            isApproved = autoLoan.ApproveLoan();
            Console.WriteLine($"Approval Status: {autoLoan.GetLoanStatus()}");
            
            if (isApproved)
                autoLoan.GenerateRepaymentPlan();
            Console.WriteLine();

            Console.WriteLine("--- TEST CASE 4: Rejected Application (Low Credit Score) ---");
            Applicant applicant4 = new Applicant("Emily Davis", 480, 45000, 500000);
            Console.WriteLine(applicant4);
            
            PersonalLoan personalLoan2 = new PersonalLoan(applicant4, 60);
            Console.WriteLine($"Loan Type: {personalLoan2.LoanType}");
            Console.WriteLine($"Monthly EMI: ${personalLoan2.CalculateEMI():F2}");
            
            isApproved = personalLoan2.ApproveLoan();
            Console.WriteLine($"Approval Status: {personalLoan2.GetLoanStatus()}");
            Console.WriteLine();

            Console.WriteLine("--- TEST CASE 5: Rejected Application (High Debt-to-Income Ratio) ---");
            Applicant applicant5 = new Applicant("Robert Wilson", 700, 30000, 2000000);
            Console.WriteLine(applicant5);
            
            HomeLoan homeLoan2 = new HomeLoan(applicant5, 240);
            Console.WriteLine($"Loan Type: {homeLoan2.LoanType}");
            Console.WriteLine($"Monthly EMI: ${homeLoan2.CalculateEMI():F2}");
            
            isApproved = homeLoan2.ApproveLoan();
            Console.WriteLine($"Approval Status: {homeLoan2.GetLoanStatus()}");
            Console.WriteLine();

            Console.WriteLine("========== END OF LOANBUDDY DEMONSTRATION ==========");
        }
    }
}
