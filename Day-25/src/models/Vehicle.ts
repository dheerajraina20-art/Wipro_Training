export enum VehicleType {
  Car = "Car",
  Bike = "Bike",
  Truck = "Truck"
}

export interface Vehicle {
  id: number;
  brand: string;
  type: VehicleType;
  rentPerDay: number;
  isAvailable: boolean;
}
