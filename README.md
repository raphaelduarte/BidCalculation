# BidCalculation

## Project Overview

The **BidCalculation** project is designed to calculate the total price for a vehicle at an auction, including various dynamic fees based on the vehicle type (Common or Luxury). This project follows a **Domain-Driven Design (DDD)** approach, utilizing the **.NET 8.0** framework for backend services and **Vue.js 3 with TypeScript** for frontend development.

The system is divided into four main layers:
- **Domain**: Contains core business logic, entities, value objects, and services.
- **Application**: Responsible for orchestrating use cases and interacting with the Domain layer.
- **Infrastructure**: Provides implementations for repositories and handles database interaction.
- **API**: Exposes REST APIs for external clients, like the frontend.

## Technologies

- **Backend**: .NET 8.0 (C#)
- **Frontend**: Vue.js 3, TypeScript, Pinia for state management
- **Database**: SQLite
- **Design Pattern**: Strategy pattern applied for fee calculation
- **Architecture**: Domain-Driven Design (DDD)

## Folder Structure

/BidCalculation.sln ├── /BidCalculation.Domain # Core business logic and domain entities ├── /BidCalculation.Application # Application use cases and services ├── /BidCalculation.Infrastructure # Database and repository implementations ├── /BidCalculation.API # REST API project ├── .gitignore # Git ignore rules └── README.md # Project documentation

## Getting Started

### Prerequisites

- **.NET 8.0 SDK**: Ensure that .NET 8.0 is installed on your machine.
- **Node.js**: For the Vue.js frontend development.
- **SQLite**: No setup required, as the project will create the SQLite database file during runtime.

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
4.	The API should now be running on http://localhost:5000
	
	
### Key Sections Explained

1. **Project Overview**: Provides a brief explanation of the project's purpose and high-level architecture.
2. **Technologies**: Lists the key technologies used in the project.
3. **Folder Structure**: Displays the directory layout for the main layers of the project.
4. **Getting Started**: Describes how to clone, build, and run the project, both backend and frontend.
5. **Key Design Principles**: Emphasizes the focus on **Clean Code** and **DDD**.
6. **Contribution Guidelines**: Simple steps for contributing to the project.
7. **License**: States that the project is licensed under the MIT License (adjust this if your project uses a different license).

This `README.md` provides a good foundation for the initial commit and explains the overall structure and guidelines for the project. You can update it later as the project evolves.

### Key Design Principles

This project follows Clean Code principles and Domain-Driven Design (DDD). Key considerations include:
- Separation of Concerns: Each layer (Domain, Application, Infrastructure, API) has a clear and isolated responsibility.
- Modularity: Each service, entity, and repository is designed to be independent and reusable.
- SOLID Principles: The code follows object-oriented design principles to ensure maintainability and scalability.
- Strategy Pattern: Used to handle the calculation of fees dynamically based on vehicle type.


## Project Overview

The **BidCalculation** project is designed to calculate the total price for a vehicle at an auction, including various dynamic fees based on the vehicle type (Common or Luxury). This project follows a **Domain-Driven Design (DDD)** approach, utilizing the **.NET 8.0** framework for backend services and **Vue.js 3 with TypeScript** for frontend development.

## Technologies

- **Backend**: .NET 8.0 (C#)
- **Frontend**: Vue.js 3, TypeScript, Pinia for state management
- **Database**: SQLite
- **Design Pattern**: Strategy pattern applied for fee calculation
- **Architecture**: Domain-Driven Design (DDD)

## Contribution Guidelines

1. Fork the repository.
2. Create a new branch for your feature:
3. Run the tests:
4. Commit your changes with a clear message:
1. Push to the branch:
5. Open a Pull Request.