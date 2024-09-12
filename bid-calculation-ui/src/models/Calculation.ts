import type { Fee } from "./Fee";

export interface Calculation {
    totalCost: number;
    fees: Fee[] | null;
}