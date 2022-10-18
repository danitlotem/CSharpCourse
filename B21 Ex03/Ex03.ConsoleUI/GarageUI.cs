using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageUI
    {
        private const short k_MinOptionInMainMenu = 1;
        private const short k_MaxOptionInMainMenu = 8;
        private const short k_MinOptionInVehicleTypeMenu = 1;
        private const short k_MaxOptionInVehicleTypeMenu = 5;
        private const short k_MinOptionInVehicleStatusMenu = 1;
        private const short k_MaxOptionInVehicleStatusMenu = 4;
        private Garage m_Garage;

        public Garage OurGarage
        {
            get
            {
                return m_Garage;
            }

            set
            {
                m_Garage = value;
            }
        }

        public enum eMenuOptions
        {
            InsertVehicle = 1,
            PresentVehiclesLicenseNumberByStatus,
            ChangeVehicleStatus,
            FillAirPressure,
            FillFuel,
            ChargeBattery,
            ShowFullDetails,
            Exit
        }

        private static void showMenu()
        {
            string menu = string.Format(
                @"Welcome to our garage!
------------------------------------------------
Please follow the menu:
1 - Insert new vehicle to the garage
2 - Present garage vehicles license number by status
3 - Change status of a vehicle
4 - Fill air pressure of vehicle wheel to max level
5 - Fill fuel of gasoline vehicle
6 - Charge battery of electric vehicle
7 - Present full details of vehicle
8 - Exit
");
            Console.WriteLine(menu);
        }

        private static short getUserChoice()
        {
            short userChoice = -1;
            string strChoice = null;

            Console.Write("Your Choice: ");

            try
            {
                strChoice = Console.ReadLine();
                Console.WriteLine("");
                userChoice = short.Parse(strChoice);
            }
            catch (FormatException fe)
            {
                Console.WriteLine("{0} is Invalid choice. Please choose again", strChoice);
                throw fe;
            }

            return userChoice;
        }

        private static string getLicenseNumberFromUser()
        {
            string licenseNumber = string.Empty;
            bool isFirst = true;

            while (licenseNumber.Length < 1)
            {
                if (isFirst == true)
                {
                    Console.WriteLine("Please enter the license number:");
                    isFirst = false;
                }
                else
                {
                    Console.WriteLine("Invalid license number. Please enter license number again:");
                }

                Console.Write("Your answer: ");
                licenseNumber = Console.ReadLine();
                Console.WriteLine(string.Empty);
            }

            return licenseNumber;
        }

        private static void printLicenseList(List<string> i_LicenseList)
        {
            if (i_LicenseList.Count == 0)
            {
                Console.WriteLine("There are no vehicles in this status{0}", Environment.NewLine);
            }
            else
            {
                StringBuilder listToPrint = new StringBuilder();

                foreach (string license in i_LicenseList)
                {
                    listToPrint.Append(license);
                    listToPrint.Append(Environment.NewLine);
                }

                Console.WriteLine(listToPrint);
            }
        }

        private static bool isStringContainsOnlyChars(string i_ClientName)
        {
            bool isAllLetter = true;

            foreach (char letter in i_ClientName)
            {
                if (!char.IsLetter(letter))
                {
                    isAllLetter = false;
                }
            }

            return isAllLetter;
        }

        private static void getClientNameFromUser(out string o_ClientName)
        {
            bool isFirst = true;
            o_ClientName = string.Empty;

            while (o_ClientName.Length < 1 || !isStringContainsOnlyChars(o_ClientName))
            {
                if (isFirst == true)
                {
                    Console.WriteLine("Please enter client name:");
                    isFirst = false;
                }
                else
                {
                    Console.WriteLine("invalid name. Please enter client name again:");
                }

                Console.Write("Your answer: ");
                o_ClientName = Console.ReadLine();
                Console.WriteLine(string.Empty);
            }
        }

        private static void getClientPhoneNumberFromUser(out string o_ClientPhoneNumber)
        {
            o_ClientPhoneNumber = string.Empty;
            bool isFirst = true;

            while (!int.TryParse(o_ClientPhoneNumber, out int validPhoneNumber))
            {
                if (isFirst == true)
                {
                    Console.WriteLine("Please enter client phone number:");
                    isFirst = false;
                }
                else
                {
                    Console.WriteLine("Invalid phone number. Please enter phone number again:");
                }

                Console.Write("Your answer: ");
                o_ClientPhoneNumber = Console.ReadLine();
                Console.WriteLine(string.Empty);
            }
        }

        private static void getClientInfoFromUser(out string o_ClientName, out string o_ClientPhoneNumber)
        {
            getClientNameFromUser(out o_ClientName);
            getClientPhoneNumberFromUser(out o_ClientPhoneNumber);
        }

        private static List<string> addAnswersFromUserToList(List<VehicleInfoQuestions> i_Questions)
        {
            List<string> vehicleAnswersFromUser = new List<string>();

            foreach (VehicleInfoQuestions question in i_Questions)
            {
                Console.WriteLine(question.Question);
                Console.Write("Your answer: ");
                string answer = Console.ReadLine();
                Console.WriteLine(string.Empty);
                vehicleAnswersFromUser.Add(answer);
            }

            return vehicleAnswersFromUser;
        }

        private static string splitByUpperCase(string i_StringToSplit)
        {
            char prevChar = char.MinValue;
            StringBuilder strAfterSplit = new StringBuilder();

            foreach (char letter in i_StringToSplit)
            {
                if (char.IsUpper(letter) && strAfterSplit.Length != 0 && prevChar != ' ')
                {
                    strAfterSplit.Append(' ');
                }

                strAfterSplit.Append(letter);
            }

            return strAfterSplit.ToString();
        }

        private void applyChoice(eMenuOptions i_UserChoice)
        {
            switch (i_UserChoice)
            {
                case eMenuOptions.InsertVehicle:
                    {
                        insertVehicleToTheGarage();
                        break;
                    }

                case eMenuOptions.PresentVehiclesLicenseNumberByStatus:
                    {
                        presentVehiclesLicenseNumbers();
                        break;
                    }

                case eMenuOptions.ChangeVehicleStatus:
                    {
                        changeVehicleStatus();
                        break;
                    }

                case eMenuOptions.FillAirPressure:
                    {
                        fillMaxAirPressure();
                        break;
                    }

                case eMenuOptions.FillFuel:
                    {
                        fillFuelInVehicle();
                        break;
                    }

                case eMenuOptions.ChargeBattery:
                    {
                        chargeVehicleBattery();
                        break;
                    }

                case eMenuOptions.ShowFullDetails:
                    {
                        showVehicleFullDetails();
                        break;
                    }

                case eMenuOptions.Exit:
                    {
                        Environment.Exit(-1);
                        break;
                    }

                default:
                    {
                        throw new ValueOutOfRangeException(k_MinOptionInMainMenu, k_MaxOptionInMainMenu, i_UserChoice.ToString());
                    }
            }
        }

        private void menuToSort()
        {
            StringBuilder printVehiclesOptions = new StringBuilder();

            printVehiclesOptions.Append("1 - Print all vehicles");
            printVehiclesOptions.Append(Environment.NewLine);

            for (short i = 2; i <= Enum.GetNames(typeof(Garage.eVehicleStatus)).Length + 1; i++)
            {
                printVehiclesOptions.Append(i.ToString());
                printVehiclesOptions.Append(" - Print ");
                string enumName = Enum.GetName(typeof(Garage.eVehicleStatus), i);
                printVehiclesOptions.Append(splitByUpperCase(enumName));
                printVehiclesOptions.Append(" vehicles");
                printVehiclesOptions.Append(Environment.NewLine);
            }

            Console.WriteLine(printVehiclesOptions);
        }

        private void showVehicleFullDetails()
        {
            string licenseNumber = getLicenseNumberFromUser();
            string vehicleFullDetails = OurGarage.GetVehiclesFullDetails(licenseNumber);
            Console.WriteLine(vehicleFullDetails);
        }

        private void chargeVehicleBattery()
        {
            string licenseNumber = getLicenseNumberFromUser();
            bool isLicenseExist = checkIfLicenseIsExistInClientList(licenseNumber);

            if (isLicenseExist == true)
            {
                Console.WriteLine("Please enter the number of minutes to charge ");
                string energyMsg = string.Format(@"
Current energy: {0}
Max energy: {1}",
                    OurGarage.Clients[licenseNumber].ClientVehicle.VehicleEngine.CurrentEnergyStatus,
                    OurGarage.Clients[licenseNumber].ClientVehicle.VehicleEngine.MaxEnergy);
                Console.WriteLine(energyMsg);
                Console.Write("Your answer: ");
                float minutesToCharge = float.Parse(Console.ReadLine());
                Console.WriteLine("");
                OurGarage.ChargeElectricVehicle(licenseNumber, minutesToCharge / 60);
                Console.WriteLine("The vehicle charged successfully");
            }
            else
            {
                Console.WriteLine("The vehicle is not in the garage");
            }
        }

        private void fillFuelInVehicle()
        {
            string licenseNumber = getLicenseNumberFromUser();
            bool isLicenseExist = checkIfLicenseIsExistInClientList(licenseNumber);

            if (isLicenseExist == true)
            {
                StringBuilder fuelTypeMsgBuilder = new StringBuilder();

                Console.WriteLine("Please enter the fuel type:");
                for (short i = 0; i < Enum.GetNames(typeof(FuelEngine.eFuelType)).Length; i++)
                {
                    fuelTypeMsgBuilder.Append((i + 1).ToString());
                    fuelTypeMsgBuilder.Append(" - ");
                    string enumName = Enum.GetName(typeof(FuelEngine.eFuelType), i);
                    fuelTypeMsgBuilder.Append(splitByUpperCase(enumName));
                    fuelTypeMsgBuilder.Append(Environment.NewLine);
                }

                Console.WriteLine(fuelTypeMsgBuilder);
                Console.Write("Your choice: ");
                short fuelTypeShort = short.Parse(Console.ReadLine());
                Console.WriteLine("");
                FuelEngine.eFuelType fuelType = (FuelEngine.eFuelType)fuelTypeShort;
                string fuelAmountMsg = string.Format(
                    @"
How much Fuel do you want to fill?
Current energy: {0}
Max energy: {1}",
                    OurGarage.Clients[licenseNumber].ClientVehicle.VehicleEngine.CurrentEnergyStatus,
                    OurGarage.Clients[licenseNumber].ClientVehicle.VehicleEngine.MaxEnergy);
                Console.WriteLine(fuelAmountMsg);
                Console.Write("Your answer: ");
                int fuelAmount = int.Parse(Console.ReadLine());
                Console.WriteLine("");
                OurGarage.FuelRegularVehicle(licenseNumber, fuelType, fuelAmount);
                Console.WriteLine("The vehicle was refueled successfully");
            }
            else
            {
                Console.WriteLine("The vehicle is not in the garage");
            }
        }

        private void fillMaxAirPressure()
        {
            string licenseNumber = getLicenseNumberFromUser();
            bool isLicenseExist = checkIfLicenseIsExistInClientList(licenseNumber);

            if (isLicenseExist == true)
            {
                OurGarage.FillVehiclesWheelsToMaxAirPressure(licenseNumber);
                Console.WriteLine("The vehicle wheels were filled successfully");
            }
            else
            {
                Console.WriteLine("The vehicle is not in the garage");
            }
        }

        private void changeVehicleStatus()
        {
            string licenseNumber = getLicenseNumberFromUser();
            StringBuilder vehicleStatusMsg = new StringBuilder();

            vehicleStatusMsg.Append("Please enter the new vehicle status: ");
            vehicleStatusMsg.Append(Environment.NewLine);

            for (short i = 1; i <= Enum.GetNames(typeof(Garage.eVehicleStatus)).Length; i++)
            {
                vehicleStatusMsg.Append(i.ToString());
                vehicleStatusMsg.Append(" - ");
                string enumName = Enum.GetName(typeof(Garage.eVehicleStatus), i + 1);
                vehicleStatusMsg.Append(splitByUpperCase(enumName));
                vehicleStatusMsg.Append(Environment.NewLine);
            }

            Console.WriteLine(vehicleStatusMsg);
            Console.Write("Your choice: ");
            short newStatusChoice = short.Parse(Console.ReadLine());
            Console.WriteLine("");
            if (newStatusChoice < 1 || newStatusChoice > 3)
            {
                throw new ValueOutOfRangeException(1, 3, newStatusChoice.ToString());
            }

            m_Garage.ChangeVehicleStatus(licenseNumber, (Garage.eVehicleStatus)(newStatusChoice + 1));
            Console.WriteLine("Vehicle status changed successfully{0}", Environment.NewLine);
        }

        private void presentVehiclesLicenseNumbers()
        {
            List<string> licenseList;

            menuToSort();
            Console.Write("Your choice: ");
            short choice = short.Parse(Console.ReadLine());
            Console.WriteLine("");

            if (choice == 1)
            {
                licenseList = OurGarage.GetAllVehicles();
            }
            else if (choice >= 2 && choice <= 4)
            {
                licenseList = OurGarage.GetVehiclesByStatus((Garage.eVehicleStatus)choice);
            }
            else
            {
                throw new ValueOutOfRangeException(
                    k_MinOptionInVehicleStatusMenu,
                    k_MaxOptionInVehicleStatusMenu,
                    choice.ToString());
            }

            printLicenseList(licenseList);
        }

        private bool checkIfLicenseIsExistInClientList(string i_LicenseNumber)
        {
            return OurGarage.CheckIfLicenseIsExistInClientList(i_LicenseNumber);
        }

        private short getVehicleTypeFromUser()
        {
            Console.WriteLine("Choose type of vehicle:");
            showVehicleTypesMenu();
            Console.Write("Your choice: ");
            short vehicleType = short.Parse(Console.ReadLine());
            Console.WriteLine("");

            if (vehicleType < k_MinOptionInVehicleTypeMenu || vehicleType > k_MaxOptionInVehicleTypeMenu)
            {
                throw new ValueOutOfRangeException(k_MinOptionInVehicleTypeMenu, k_MaxOptionInVehicleTypeMenu, vehicleType.ToString());
            }

            return vehicleType;
        }

        private void insertVehicleToTheGarage()
        {
            string licenseNumber = getLicenseNumberFromUser();
            bool isLicenseExist = checkIfLicenseIsExistInClientList(licenseNumber);

            if (isLicenseExist == true)
            {
                OurGarage.ChangeVehicleStatus(licenseNumber, Garage.eVehicleStatus.InRepair);
                Console.WriteLine("Vehicle number {0} is in the garage and is in repair{1}", licenseNumber, Environment.NewLine);
            }
            else
            {
                getClientInfoFromUser(out string clientName, out string clientPhoneNumber);
                short vehicleType = getVehicleTypeFromUser();
                Vehicle newVehicle = VehicleFactory.CreateVehicle(licenseNumber, (VehicleFactory.eVehicleType)vehicleType);
                List<VehicleInfoQuestions> vehicleQuestionsForUser = newVehicle.GetQuestionsList();
                List<string> vehicleAnswersFromUser = addAnswersFromUserToList(vehicleQuestionsForUser);
                newVehicle.InitVehicleInfo(vehicleAnswersFromUser);
                OurGarage.InsertNewVehicleToGarage(licenseNumber, newVehicle, clientName, clientPhoneNumber);
                Console.WriteLine("Vehicle added successfully{0}", Environment.NewLine);
            }
        }

        private void showVehicleTypesMenu()
        {
            StringBuilder vehicleMenuTypesMsg = new StringBuilder();

            for (short i = 1; i <= Enum.GetNames(typeof(VehicleFactory.eVehicleType)).Length; i++)
            {
                vehicleMenuTypesMsg.Append(i.ToString());
                vehicleMenuTypesMsg.Append(" - ");
                string enumName = Enum.GetName(typeof(VehicleFactory.eVehicleType), i);
                vehicleMenuTypesMsg.Append(splitByUpperCase(enumName));
                vehicleMenuTypesMsg.Append(Environment.NewLine);
            }

            Console.WriteLine(vehicleMenuTypesMsg);
        }

        public void Run()
        {
            short userChoice = 0;
            OurGarage = new Garage();

            string welcomeMsg = string.Format(
                @"
welcome to our garage!
                -----------------------------");
            while (userChoice != (short)eMenuOptions.Exit)
            {
                showMenu();
                try
                {
                    userChoice = getUserChoice();
                    applyChoice((eMenuOptions)userChoice);
                }
                catch (ValueOutOfRangeException voore)
                {
                    Console.WriteLine(voore.Message);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
