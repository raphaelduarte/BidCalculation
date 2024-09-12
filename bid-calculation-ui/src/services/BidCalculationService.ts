
// services/BidCalculationService.ts
import type { Calculation } from '../models/Calculation';
import { VehicleType } from '../models/VehicleType';

export class BidCalculationService {
    private apiUrl: string;

    constructor() {
        this.apiUrl = import.meta.env.VITE_API_URL as string;
    }

    async getCalculation(vehicleType: VehicleType, basePrice: number): Promise<Calculation> {
        const queryParams = new URLSearchParams({
            vehicleType: vehicleType.toString(),
            basePrice: basePrice.toString()
        });

        try {
            const response = await fetch(`${this.apiUrl}/api/BindCalculation?${queryParams}`);

            if (!response.ok) {
                throw new Error(`Error: ${response.status} - ${response.statusText}`);
            }

            const data: Calculation = await response.json();
            return data;

        } catch (error) {
            console.error('Error fetching calculation:', error);
            throw error;
        }
    }
}
