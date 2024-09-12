import type { FeeType } from "./FeeType";

export interface Fee {
    feeType: FeeType;
    amount: number;
}