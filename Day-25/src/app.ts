import { VehicleType } from "./models/Vehicle";
import { RentalService } from "./services/RentalService";

const service = new RentalService();

service.addVehicle({ id: 1, brand: "Toyota", type: VehicleType.Car, rentPerDay: 2000, isAvailable: true });
service.addVehicle({ id: 2, brand: "Yamaha", type: VehicleType.Bike, rentPerDay: 800, isAvailable: true });

service.addCustomer({ id: 1, name: "Dheeraj", licenseNumber: "DL12345" });
service.addCustomer({ id: 2, name: "Rahul", licenseNumber: "DL67890" });

console.log(service.rentVehicle(1, 1, 3));
console.log("Available Vehicles:", service.listAvailableVehicles());
console.log("Active Rentals:", service.listActiveRentals());
console.log(service.returnVehicle(1));

/*
PROJECT SETUP STEPS (TERMINAL COMMANDS)

1. Created a new project folder
   mkdir ts-vehicle-rental-system
   cd ts-vehicle-rental-system

2. Initialized Node project
   npm init -y

3. Installed TypeScript locally
   npm install typescript --save-dev

4. Created TypeScript configuration file
   npx tsc --init

5. Edited tsconfig.json to:
   - Set rootDir as ./src
   - Set outDir as ./dist
   - Use commonjs module
   - Enable strict mode

6. Created project folders
   mkdir src
   mkdir src/models
   mkdir src/services

7. Compiled TypeScript to JavaScript
   npx tsc

8. Ran the compiled project using Node
   node dist/app.js
*/


/*
PROJECT IMPLEMENTATION STEPS

1. Created models (interfaces and enum)
   - Vehicle.ts → Defines vehicle details and VehicleType enum
   - Customer.ts → Defines customer information
   - Rental.ts → Defines rental transaction details

2. Created RentalService class
   - Stores vehicles, customers, and rentals in arrays
   - addVehicle() → Adds new vehicles to system
   - addCustomer() → Registers customers
   - rentVehicle() → Assigns vehicle to a customer and calculates total cost
   - returnVehicle() → Marks vehicle as available again
   - listAvailableVehicles() → Shows vehicles ready for rent
   - listActiveRentals() → Displays current rental records

3. Business Logic Used
   - Vehicle availability tracking using boolean flag
   - Rental cost calculation (rentPerDay × number of days)
   - Relationship mapping between Vehicle, Customer, and Rental

4. Main File (app.ts)
   - Created RentalService object
   - Added sample vehicles and customers
   - Performed rental and return operations
   - Printed available vehicles and rental details

5. TypeScript Advantages Used
   - Strong typing with interfaces
   - Enums for fixed vehicle types
   - Compile-time error checking
   - Modular code structure
*/
