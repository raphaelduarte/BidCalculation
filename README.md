# BidCalculation

## Project Overview

The **BidCalculation** project is designed to calculate the total price for a vehicle at an auction, including various dynamic fees based on the vehicle type (Common or Luxury). This project follows a **Domain-Driven Design (DDD)** approach, utilizing the **.NET 8.0** framework for backend services and **Vue.js 3 with TypeScript** for frontend development.

The system is divided into 3 main layers:
- **Domain**: Contains core business logic, entities, value objects, and services.
- **API**: Exposes REST APIs for external clients, like the frontend.
- **Tests**: Contains unit and integration tests to ensure code quality

## Getting Started



### Prerequisites

- **.NET 8.0 SDK**: Ensure that .NET 8.0 is installed on your machine.
- **Node.js**: For the Vue.js frontend development.

### Running the Application

1. **Clone the repository**:
   ```bash
	git clone https://github.com/raphaelduarte/BidCalculation.git
2. **Navigate to the API project**:
	``` bash
	cd BidCalculation.API
3.	**Build and run the API**: 
	```bash
	dotnet build
	dotnet run
4.	The API should now be running on https://localhost:7209
5.	**Navigate to the frontend**:
   	```bash
    	cd bid-calculation-ui
6.	**Install dependencies**:
   	```bash
    	npm install
7.	**Run the frontend application**:
   	```bash
    	npm run dev
	
	
### Key Sections Explained

1. **Project Overview**: Provides a brief explanation of the project's purpose and high-level architecture.
2. **Technologies**: Lists the key technologies used in the project.
3. **Folder Structure**: Displays the directory layout for the main layers of the project.
4. **Getting Started**: Describes how to clone, build, and run the project, both backend and frontend.
5. **Key Design Principles**: Emphasizes the focus on **Clean Code** and **DDD**.
6. **Contribution Guidelines**: Simple steps for contributing to the project.
7. **License**: States that the project is licensed under the MIT License (adjust this if your project uses a different license).

This `README.md` provides a good foundation for the initial commit and explains the overall structure and guidelines for the project. You can update it later as the project evolves.


## Technologies

- **Backend**: .NET 8.0 (C#)
- **Frontend**: Vue.js 3, TypeScript
- 
## Contribution Guidelines

1. Fork the repository.
2. Create a new branch for your feature:
3. Run the tests:
4. Commit your changes with a clear message:
1. Push to the branch:
5. Open a Pull Request.
