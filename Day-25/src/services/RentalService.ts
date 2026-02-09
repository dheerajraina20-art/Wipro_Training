import { Customer } from "../models/Customer";
import { Rental } from "../models/Rental";
import { Vehicle } from "../models/Vehicle";

export class RentalService {
  private vehicles: Vehicle[] = [];
  private customers: Customer[] = [];
  private rentals: Rental[] = [];
  private rentalCounter: number = 1;

  addVehicle(vehicle: Vehicle): void {
    this.vehicles.push(vehicle);
  }

  addCustomer(customer: Customer): void {
    this.customers.push(customer);
  }

  rentVehicle(vehicleId: number, customerId: number, days: number): string {
    const vehicle = this.vehicles.find(v => v.id === vehicleId);
    if (!vehicle) return "Vehicle not found";
    if (!vehicle.isAvailable) return "Vehicle not available";

    const customer = this.customers.find(c => c.id === customerId);
    if (!customer) return "Customer not found";

    vehicle.isAvailable = false;

    const totalCost = vehicle.rentPerDay * days;

    this.rentals.push({
      rentalId: this.rentalCounter++,
      vehicleId,
      customerId,
      days,
      totalCost
    });

    return `Vehicle rented to ${customer.name}. Total cost: ₹${totalCost}`;
  }

  returnVehicle(vehicleId: number): string {
    const vehicle = this.vehicles.find(v => v.id === vehicleId);
    if (!vehicle) return "Vehicle not found";

    vehicle.isAvailable = true;
    return `${vehicle.brand} returned successfully`;
  }

  listAvailableVehicles(): Vehicle[] {
    return this.vehicles.filter(v => v.isAvailable);
  }

  listActiveRentals(): Rental[] {
    return this.rentals;
  }
}
