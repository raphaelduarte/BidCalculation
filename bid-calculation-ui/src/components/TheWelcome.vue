<template>
  <div class="bid-calculator">
    <h1>Bid Calculator</h1>

    <!-- Selector para tipo de veículo -->
    <div class="form-group">
      <label class="label-vt" for="vehicleType">Vehicle Type:</label>
      <select v-model="vehicleType" class="input">
        <option :value="0">Common</option>
        <option :value="1">Luxury</option>
      </select>
    </div>

    <!-- Campo de input para basePrice -->
    <div class="form-group">
      <label class="label-vt" for="basePrice">Price:</label>
      <input
        type="number"
        v-model="basePrice"
        class="input"
        placeholder="Enter base price"
      />
    </div>

    <!-- Exibir a mensagem de erro se o valor for inválido -->
    <ErrorToggle :showError="isError" message="Invalid price!" />

    <!-- Renderizando a tabela com os dados da resposta -->
    <div v-if="calculation" class="result-table">
      <table>
        <thead>
          <tr>
            <th>Fee Type</th>
            <th>Amount</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="fee in calculation.fees" :key="fee.feeType">
            <td v-if="fee.feeType == 0" class="td-basic">Basic</td>
            <td v-else-if="fee.feeType == 1" class="td-special">Special</td>
            <td v-else-if="fee.feeType == 2" class="td-association">
              Association
            </td>
            <td v-else-if="fee.feeType == 3" class="td-storage">Storage</td>
            <td>{{ formatCurrency(fee.amount) }}</td>
          </tr>
        </tbody>
      </table>

      <!-- TotalCost exibido aqui -->
      <div class="total-cost">
        <p>
          <strong>Total:</strong> {{ formatCurrency(calculation.totalCost) }}
        </p>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { ref, watch, computed } from "vue";
import { BidCalculationService } from "../services/BidCalculationService";
import type { Calculation } from "../models/Calculation";
import { VehicleType } from "../models/VehicleType";
import ErrorToggle from "./ErrorToggle.vue";

export default {
  name: "BidCalculationComponent",
  components: {
    ErrorToggle,
  },
  setup() {
    const vehicleType = ref<VehicleType>(VehicleType.Car);
    const basePrice = ref<number | null>(null); // Pode ser null inicialmente
    const calculation = ref<Calculation | null>(null);
    const bidCalculationService = new BidCalculationService();

    const fetchCalculation = async () => {
      if (basePrice.value !== null && basePrice.value > 0) {
        try {
          const result = await bidCalculationService.getCalculation(
            vehicleType.value,
            basePrice.value
          );
          calculation.value = result;
          console.log("Result:", result);
        } catch (error) {
          console.error("Error:", error);
        }
      } else {
        calculation.value = null; // Resetar o cálculo quando basePrice for null ou vazio
      }
    };

    const formatCurrency = (value: number) => {
      return new Intl.NumberFormat("en-US", {
        style: "currency",
        currency: "USD",
      }).format(value);
    };

    // Watch para detectar mudanças no vehicleType ou basePrice e chamar o serviço
    watch([vehicleType, basePrice], () => {
      fetchCalculation();
    });

    // Computed property to check if there's an error (totalCost is zero)
    const isError = computed(() => {
      return !!(
        (calculation.value && calculation.value.totalCost === 0) ||
        (basePrice.value !== null && basePrice.value < 0)
      );
    });

    return {
      vehicleType,
      basePrice,
      calculation,
      formatCurrency,
      isError, // Computed property to toggle error
    };
  },
};
</script>

<style scoped>
/* Estilos refinados para o layout da calculadora */
.bid-calculator {
  max-width: 600px;
  margin: 0 auto;
  padding: 30px;
  background-color: #f4f7fa; /* Fundo suave */
  border-radius: 12px;
  box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1); /* Sombra suave */
  font-family: "Segoe UI", Tahoma, Geneva, Verdana, sans-serif;
}

/* Títulos */
h1 {
  text-align: center;
  font-size: 2.5rem;
  margin-bottom: 25px;
  color: #2c3e50; /* Azul escuro elegante */
  font-weight: 600;
}

/* Formulário */
.form-group {
  margin-bottom: 20px;
}

.label-vt {
  font-size: 1.2rem;
  color: #34495e;
  margin-bottom: 10px;
  display: block;
}

.input {
  width: 100%;
  padding: 12px;
  font-size: 1.1rem;
  border: 2px solid #dfe6e9;
  border-radius: 6px;
  background-color: #ffffff;
  color: #34495e;
  box-sizing: border-box;
  outline: none;
  transition: border-color 0.2s ease-in-out;
}

.input:focus {
  border-color: #4a90e2; /* Azul suave ao focar */
}

/* Tabela de Resultados */
.result-table {
  margin-top: 30px;
}

table {
  width: 100%;
  border-collapse: collapse;
  margin-top: 20px;
  background-color: #ffffff;
  border-radius: 8px;
  box-shadow: 0 3px 10px rgba(0, 0, 0, 0.05);
}

th,
td {
  padding: 15px;
  text-align: left;
  border-bottom: 1px solid #ecf0f1;
}

th {
  background-color: #2980b9; /* Cabeçalho azul escuro */
  color: white; /* Texto branco */
  font-weight: 600;
}

td {
  color: #34495e;
  text-align: left;
}

td:last-child {
  text-align: right;
}

/* Seção do Total */
.total-cost {
  margin-top: 20px;
  padding: 20px;
  background-color: #2980b9; /* Fundo azul escuro */
  color: white;
  font-size: 1.5rem;
  text-align: center;
  border-radius: 8px;
  font-weight: bold;
}

/* Cores diferentes para os tipos de taxas */
.td-basic {
  background-color: #ecf9ff;
  color: #2c3e50;
}

.td-special {
  background-color: #dfe6e9;
  color: #2c3e50;
}

.td-association {
  background-color: #ffeaa7;
  color: #2c3e50;
}

.td-storage {
  background-color: #fab1a0;
  color: #2c3e50;
}

/* Melhorias visuais em dispositivos móveis */
@media (max-width: 600px) {
  .bid-calculator {
    padding: 15px;
  }

  h1 {
    font-size: 2rem;
  }

  th,
  td {
    padding: 10px;
  }
}
</style>
