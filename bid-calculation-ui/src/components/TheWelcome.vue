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
      <input type="number" v-model="basePrice" class="input" />
    </div>

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
            <td v-else-if="fee.feeType == 2" class="td-association">Association</td>
            <td v-else-if="fee.feeType == 3" class="td-storage">Storage</td>
            <td>{{ fee.amount }}</td>
          </tr>
        </tbody>
      </table>

      <!-- TotalCost exibido aqui -->
      <div class="total-cost">
        <p><strong>Total:</strong> {{ calculation.totalCost.toFixed(2) }}</p>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { ref, watch } from 'vue';
import { BidCalculationService } from '../services/BidCalculationService';
import type { Calculation } from '../models/Calculation';
import { VehicleType } from '../models/VehicleType';

export default {
  name: 'BidCalculationComponent',
  setup() {
    const vehicleType = ref<VehicleType>(VehicleType.Car);
    const basePrice = ref<number>(0);
    const calculation = ref<Calculation | null>(null);
    const bidCalculationService = new BidCalculationService();

    const fetchCalculation = async () => {
      if (basePrice.value > 0) {
        try {
          const result = await bidCalculationService.getCalculation(vehicleType.value, basePrice.value);
          calculation.value = result;
          console.log('Resultado:', result);
        } catch (error) {
          console.error('Erro ao calcular:', error);
        }
      }
    };

    // Watch para detectar mudanças no vehicleType ou basePrice e chamar o serviço
    watch([vehicleType, basePrice], () => {
      fetchCalculation();
    });

    return {
      vehicleType,
      basePrice,
      calculation,
    };
  },
};
</script>

<style scoped>
/* Estilos para o layout da calculadora */
.bid-calculator {
  max-width: 600px;
  margin: 0 auto;
  padding: 20px;
  background-color: #ffffff; /* Fundo branco para alta legibilidade */
  border-radius: 8px;
  box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
}

/* Títulos */
h1 {
  text-align: center;
  font-size: 2rem;
  margin-bottom: 20px;
  color: #333; /* Texto mais escuro para contraste */
}

/* Formulário */
.form-group {
  margin-bottom: 20px;
  display: flex;
  align-items: center;
}

.label-vt {
  margin-right: 10px;
  font-size: 1.1rem;
  color: #333;
}

.input {
  flex: 1;
  padding: 10px;
  font-size: 1rem;
  border: 1px solid #ccc;
  border-radius: 4px;
  background-color: #f9f9f9; /* Fundo claro */
  color: #333;
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
  box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1);
}

th, td {
  padding: 15px;
  text-align: left;
  border-bottom: 1px solid #ddd;
}

th {
  background-color: #4a90e2; /* Azul mais escuro para cabeçalho */
  color: white; /* Texto branco para contraste */
  font-weight: bold;
}

td {
  color: #333; /* Texto mais escuro para melhor legibilidade */
  text-align: left;
}

td:last-child {
  text-align: right;
}

/* Seção do Total */
.total-cost {
  margin-top: 20px;
  padding: 15px;
  background-color: #4a90e2; /* Fundo azul para destaque */
  color: white; /* Texto branco para contraste */
  font-size: 1.5rem;
  text-align: center;
  border-radius: 8px;
  font-weight: bold;
}

/* Cores diferentes para os tipos de taxas */
.td-basic {
  background-color: #f0f8ff; /* Fundo claro com texto escuro */
  color: #333;
}

.td-special {
  background-color: #e6f7ff;
  color: #333;
}

.td-association {
  background-color: #fff8dc;
  color: #333;
}

.td-storage {
  background-color: #faebd7;
  color: #333;
}

/* Melhorias visuais em dispositivos móveis */
@media (max-width: 600px) {
  .bid-calculator {
    padding: 10px;
  }

  h1 {
    font-size: 1.5rem;
  }

  th, td {
    padding: 10px;
  }
}
</style>
