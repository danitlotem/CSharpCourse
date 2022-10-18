using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public static class VehicleFactory
    {
        public static Vehicle CreateVehicle(string i_LicenseNumber, eVehicleType i_VehicleType)
        {
            Vehicle vehicleToCreate;

            switch (i_VehicleType)
            {
                case eVehicleType.RegularMotorcycle:
                    {
                        vehicleToCreate = CreateRegularMotorcycle(i_LicenseNumber);
                        break;
                    }

                case eVehicleType.ElectricMotorcycle:
                    {
                        vehicleToCreate = CreateElectricMotorcycle(i_LicenseNumber);
                        break;
                    }

                case eVehicleType.RegularCar:
                    {
                        vehicleToCreate = CreateRegularCar(i_LicenseNumber);
                        break;
                    }

                case eVehicleType.ElectricCar:
                    {
                        vehicleToCreate = CreateElectricCar(i_LicenseNumber);
                        break;
                    }

                case eVehicleType.Truck:
                    {
                        vehicleToCreate = CreateTruck(i_LicenseNumber);
                        break;
                    }

                default:
                    {
                        throw new ArgumentException();
                    }
            }

            return vehicleToCreate;
        }

        public static Motorcycle CreateRegularMotorcycle(string i_LicenseNumber)
        {
            return new Motorcycle(i_LicenseNumber, new FuelEngine(FuelEngine.eFuelType.Octan98, 6));
        }

        public static Motorcycle CreateElectricMotorcycle(string i_LicenseNumber)
        {
            return new Motorcycle(i_LicenseNumber, new ElectricEngine(1.8f));
        }

        public static Car CreateRegularCar(string i_LicenseNumber)
        {
            return new Car(i_LicenseNumber, new FuelEngine(FuelEngine.eFuelType.Octan95, 45));
        }

        public static Car CreateElectricCar(string i_LicenseNumber)
        {
            return new Car(i_LicenseNumber, new ElectricEngine(3.2f));
        }

        public static Truck CreateTruck(string i_LicenseNumber)
        {
            return new Truck(i_LicenseNumber, new FuelEngine(FuelEngine.eFuelType.Soler, 120));
        }

        public enum eVehicleType
        {
            RegularMotorcycle = 1,
            ElectricMotorcycle,
            RegularCar,
            ElectricCar,
            Truck
        }
    }
}