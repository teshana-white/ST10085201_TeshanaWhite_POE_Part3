using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace POE_Part_3
{
    public class Accomodation : Expenses //child class of the expenses class
    {

        #region get and set
        //getters and setters for the housing and rental expenses
        public int rent { get; set; }
        public int house { get; set; }
        public int deposit { get; set; }
        public int interest { get; set; }
        public int numOfMonths { get; set; }
        public double homeLoan { get; set; }
        public double leftover { get; set; }



        #endregion

        #region setting getters and setters
        public Accomodation(int income, int groceries, int utilities, int travelCost, int cellPhone,
                              int otherExpenses, int Rent, int House, int Deposit, int Interest, int NumOfMonths,
                                string carType, int carPrice, int carDeposit,
                             int carInterest, int carInsurance, int saving, int years, int saveInterest)
            : base(income, groceries, utilities, travelCost, cellPhone, otherExpenses, carType, carPrice,
                  carDeposit, carInterest, carInsurance, saving, years, saveInterest)
        {
            this.rent = Rent;
            this.house = House;
            this.deposit = Deposit;
            this.interest = Interest;
            this.numOfMonths = NumOfMonths;
            this.homeLoan = CalculateHomeLoan(House, Interest, NumOfMonths);
            this.leftover = CalcLeftOver(income, total, rent, house, deductions, carPrice);


        }


        private double CalcLeftOver(int income, double total, int rent, int house, double deductions, int carPrice)  //Formula to calculate money left over after all deductions
        {
            //calculates money left after all expenses
            return (this.income - (this.total + this.rent + this.house +
                        this.deductions + this.carPrice));
        }
        #endregion

        public double CalculateHomeLoan(int House, int Interest, int NumOfMonths)
        //calculates the cost of the home loan per month
        {
            return ((this.house - this.deposit) * (1 + (this.interest / 100) * (this.numOfMonths) / 12))
                    / this.numOfMonths;
        }

        #region Income, expenses and vehcile expenses
        public override string ToString() //displays the output message at end of the application after it has been run
        {
            return "INCOME AND EXPENSES" + "\n" + //outputting income and expenses

              "Income: R" + this.income + "\nAmount deducted: R" + this.deductions +
              "\nGroceries: R" + this.groceries + "\nUtilities: R" + this.utilities +
              "\nTavel Cost: R" + this.travelCost + "\nCellPhone: R" + this.cellPhone +
              "\nOther Expenses: R" + this.otherExpenses + "\nTotal expenses: R" + this.total +


              "\n" + "\nRENT" +

              "\nMonthly rent: R" + this.rent +  //outputting rent

              "\n" + "\nHousing" +  //outputting housing

               "\nPurchase price: R" + this.house + "\nTotal deposit: R" + this.deposit +
               "\nInterest rate: " + this.interest + "%" +
               "\nNumber of months for repayment: " + this.numOfMonths +
               "\nMonthly repayment: R" + this.homeLoan +

              "\n" + "\nVEHCILE EXPENSES" +  //outputting vehcile 

                 "\nCar type: " + this.carType + "\nCar price: R" + this.CarPrice +
                 "\nTotal deposit: R" + this.CarDeposit + "\nInterest rate : " + this.carInterest + "%" +
                 "\nEstimated insurance premium: R" + this.carInsurance + "\nMonthly cost: R" + this.carTotal +

                 "\n" + "\nLEFTOVER MONEY" + //outputting leftover money

                 "\nAvailable money after deductions: R" + this.leftover + 

                 "\n" + "\nSAVINGS" + //outputting savings

                 "\n" +"\nTarget amount: R" + this.saving + "\nDuration: " + this.years + 
                 "\nInterest: " + this.saveInterest + "%" + "\nMonthly deposit needed: R" + this.SavingTotal;

        }
        #endregion
    }

}
