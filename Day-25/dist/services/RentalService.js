"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.RentalService = void 0;
class RentalService {
    constructor() {
        this.vehicles = [];
        this.customers = [];
        this.rentals = [];
        this.rentalCounter = 1;
    }
    addVehicle(vehicle) {
        this.vehicles.push(vehicle);
    }
    addCustomer(customer) {
        this.customers.push(customer);
    }
    rentVehicle(vehicleId, customerId, days) {
        const vehicle = this.vehicles.find(v => v.id === vehicleId);
        if (!vehicle)
            return "Vehicle not found";
        if (!vehicle.isAvailable)
            return "Vehicle not available";
        const customer = this.customers.find(c => c.id === customerId);
        if (!customer)
            return "Customer not found";
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
    returnVehicle(vehicleId) {
        const vehicle = this.vehicles.find(v => v.id === vehicleId);
        if (!vehicle)
            return "Vehicle not found";
        vehicle.isAvailable = true;
        return `${vehicle.brand} returned successfully`;
    }
    listAvailableVehicles() {
        return this.vehicles.filter(v => v.isAvailable);
    }
    listActiveRentals() {
        return this.rentals;
    }
}
exports.RentalService = RentalService;
