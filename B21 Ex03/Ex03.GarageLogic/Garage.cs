using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        ////Data members
        private Dictionary<string, Client> m_GarageClients;

        ////C'tor
        public Garage()
        {
            Clients = new Dictionary<string, Client>();
        }

        ////Properties
        public Dictionary<string, Client> Clients
        {
            get
            {
                return m_GarageClients;
            }

            set
            {
                m_GarageClients = value;
            }
        }

        ////Methods
        public List<string> GetAllVehicles()
        {
            List<string> licenseList = new List<string>();

            foreach (var client in Clients)
            {
                licenseList.Add(client.Key);
            }

            return licenseList;
        }

        public List<string> GetVehiclesByStatus(eVehicleStatus i_VehicleStatus)
        {
            List<string> licenseList = new List<string>();

            foreach (var client in Clients)
            {
                if(client.Value.ClientVehicleStatus == i_VehicleStatus)
                {
                    licenseList.Add(client.Key);
                }
            }

            return licenseList; 
        }

        public void ChangeVehicleStatus(string i_LicenseNumber, eVehicleStatus i_VehicleStatus)
        {
            Clients[i_LicenseNumber].ClientVehicleStatus = i_VehicleStatus; 
        }

        public void FillVehiclesWheelsToMaxAirPressure(string i_LicenseNumber)
        {
            Clients[i_LicenseNumber].ClientVehicle.InflateAirOnWheels();
        }

        public void FuelRegularVehicle(string i_LicenseNumber, FuelEngine.eFuelType i_FuelType, int i_FuelAmount)
        {
            FuelEngine engineToFuel = Clients[i_LicenseNumber].ClientVehicle.VehicleEngine as FuelEngine;
            if(engineToFuel == null)
            {
                throw new Exception("this vehicle has electric engine"); 
            }
            else
            {
                if(((FuelEngine.eFuelType)i_FuelType != engineToFuel.FuelType)
                   || (engineToFuel.CurrentEnergyStatus + i_FuelAmount > engineToFuel.MaxEnergy))
                {
                    throw new Exception("Vehicle refueling failed");
                }
                else
                {
                    Clients[i_LicenseNumber].ClientVehicle.UpdateEnergyLevel(i_FuelAmount);
                }
            }
        }

        public void ChargeElectricVehicle(string i_LicenseNumber, float i_MinutesToCharge)
        {
            ElectricEngine engineToCharge = Clients[i_LicenseNumber].ClientVehicle.VehicleEngine as ElectricEngine;
            if (engineToCharge == null)
            {
                throw new Exception("This vehicle has fuel engine");
            }
            else
            {
                if(engineToCharge.CurrentEnergyStatus + i_MinutesToCharge > engineToCharge.MaxEnergy)
                {
                    throw new Exception("Vehicle charging failed");
                }
                else
                {
                    Clients[i_LicenseNumber].ClientVehicle.UpdateEnergyLevel(i_MinutesToCharge);
                }
            }
        }

        public string GetVehiclesFullDetails(string i_LicenseNumber)
        {
            return Clients[i_LicenseNumber].ToString();
        }

        public void InsertNewVehicleToGarage(
            string i_LicenseNumber,
            Vehicle i_NewVehicle,
            string i_ClientName,
            string i_ClientPhoneNumber)
        {
            Client newClient = new Client(i_ClientName, i_ClientPhoneNumber, i_NewVehicle);
            Clients.Add(i_LicenseNumber, newClient);
        }

        public bool CheckIfLicenseIsExistInClientList(string i_LicenseNumber)
        {
            return Clients.ContainsKey(i_LicenseNumber);
        }

        ////Enums
        public enum eVehicleStatus
        {
            InRepair = 2,
            Fixed,
            Paid
        }

        ////Nested class
        public class Client
        {
            ////Data members
            private string m_ClientName;
            private string m_ClientPhoneNumber;
            private eVehicleStatus m_ClientVehicleStatus;
            private Vehicle m_ClientVehicle;

            ////C'tor
            public Client(string i_ClientName, string i_ClientPhoneNumber, Vehicle i_ClientVehicle)
            {
                ClientName = i_ClientName;
                ClientPhoneNumber = i_ClientPhoneNumber;
                ClientVehicle = i_ClientVehicle;
                ClientVehicleStatus = eVehicleStatus.InRepair;
            }

            ////Properties
            public eVehicleStatus ClientVehicleStatus
            {
                get
                {
                    return m_ClientVehicleStatus;
                }

                set
                {
                    m_ClientVehicleStatus = value;
                }
            }

            public Vehicle ClientVehicle
            {
                get
                {
                    return m_ClientVehicle;
                }

                set
                {
                    m_ClientVehicle = value;
                }
            }

            public string ClientName
            {
                get
                {
                    return m_ClientName;
                }

                set
                {
                    m_ClientName = value;
                }
            }

            public string ClientPhoneNumber
            {
                get
                {
                    return m_ClientPhoneNumber;
                }

                set
                {
                    m_ClientPhoneNumber = value;
                }
            }

            ////Methods
            public override string ToString()
            {
                return string.Format(
                    @"

Client details:
Name: {0},  Phone number: {1}
Vehicle status: {2}
Vehicle details:
{3}",
                    ClientName,
                    ClientPhoneNumber,
                    ClientVehicleStatus.ToString(),
                    ClientVehicle.ToString());
            }
        }
    }
}