# School Api Documentation

This is the documentation for SchoolApi and SchoolApp WebAPI designed to manage students and professor data. Below you will find the endpoints, request parameters, and response information for each API operation, as well a web app portal to manage data.

## Project Objective

The project was developed to perform registrations of students and professors for study purposes.

## Miro: [Miro](https://miro.com/welcomeonboard/NmpNM1gyc1RoUGQyQmZnUEJDN2J0S3Y1TXZyeVgweWtmOGdweWVqNU5YNjVFU1RNZERnTEx3dlJmajE0ZnJHM3wzNDU4NzY0NTU5OTkwMTgzMzA1fDI=?share_link_id=970097797124)

## Concepts Covered:
**The REST WebApi was developed using:**
  - Object-Oriented Programming,
  - Ef Core,
  - Swagger.

**For the Frontend, an Angular App was developed to consume the API using:**
  - JSON,
  - Bootstrap.
    
## API Information

- **Title:** SmartSchool Project
- **Description:** Web Api for data management with sqlite
- **Version:** 1.0
- **Contact:** junioradevaldo@gmail.com
- **GitHub:** [juniortristao](https://github.com/juniortristao)

## APP Information

- **Title:** SmartSchool Project
- **Description:** A web app for data management using rest apis
- **Version:** 1.0
- **Contact:** junioradevaldo@gmail.com
- **GitHub:** [juniortristao](https://github.com/juniortristao)

## Startup

It is essential that the 'Visual Studio Code' program is properly installed on the machine where the application will be executed.

**Step-by-step initialization process:**

  - 1- Install SQLite, Visual Studio Code, .NET 6 SDK, and Angular 16.
  - 2- Drag the 'database.db' DLL to the SQLite database.
  - 3- Start the API (dotnet watch run) and the App (ng serve).

## Languages

C#, TypeScript, HTML, CSS.

## Base URL

The base URL for all API endpoints is `http://localhost:5128/api/`.
The swagger url is `http://localhost:5128/index.html`
The App Url is `http://localhost:4200/`

## Endpoints

### Aluno

#### Get All Students

- **Method:** GET
- **Endpoint:** `/api/v1/Aluno`
- **Description:** Retrieve a list of all students.
- **Parameters:**
  - `PageNumber` (integer, optional) - The page number for pagination.
  - `PageSize` (integer, optional) - The number of items per page for pagination.
  - `Matricula` (integer, optional) - Filter students by matricula number.
  - `Nome` (string, optional) - Filter students by name.
  - `Ativo` (integer, optional) - Filter students by active status (1 for active, 0 for inactive).
- **Response:**
  - Status Code: 200
  - Description: Success

#### Add New Student

- **Method:** POST
- **Endpoint:** `/api/v1/Aluno`
- **Description:** Add a new student to the system.
- **Request Body:**
  - Content-Type: application/json
  - Schema: AlunoRegistrarDto
- **Response:**
  - Status Code: 200
  - Description: Success

#### Get Student by ID

- **Method:** GET
- **Endpoint:** `/api/v1/Aluno/{id}`
- **Description:** Retrieve student information by ID.
- **Parameters:**
  - `id` (integer, path, required) - The ID of the student.
- **Response:**
  - Status Code: 200
  - Description: Success

#### Update Student by ID

- **Method:** PUT
- **Endpoint:** `/api/v1/Aluno/{id}`
- **Description:** Update student information by ID.
- **Parameters:**
  - `id` (integer, path, required) - The ID of the student.
- **Request Body:**
  - Content-Type: application/json
  - Schema: AlunoRegistrarDto
- **Response:**
  - Status Code: 200
  - Description: Success

#### Partially Update Student by ID

- **Method:** PATCH
- **Endpoint:** `/api/v1/Aluno/{id}`
- **Description:** Partially update student information by ID.
- **Parameters:**
  - `id` (integer, path, required) - The ID of the student.
- **Request Body:**
  - Content-Type: application/json
  - Schema: AlunoPatchDto
- **Response:**
  - Status Code: 200
  - Description: Success

#### Delete Student by ID

- **Method:** DELETE
- **Endpoint:** `/api/v1/Aluno/{id}`
- **Description:** Delete a student by ID.
- **Parameters:**
  - `id` (integer, path, required) - The ID of the student.
- **Response:**
  - Status Code: 200
  - Description: Success

#### Get Students by Disciplina

- **Method:** GET
- **Endpoint:** `/api/v1/Aluno/ByDisciplina/{id}`
- **Description:** Retrieve students by Disciplina ID.
- **Parameters:**
  - `id` (integer, path, required) - The ID of the Disciplina.
- **Response:**
  - Status Code: 200
  - Description: Success

#### Change Student State

- **Method:** PATCH
- **Endpoint:** `/api/v1/Aluno/{id}/trocarEstado`
- **Description:** Change the state of a student by ID.
- **Parameters:**
  - `id` (integer, path, required) - The ID of the student.
- **Request Body:**
  - Content-Type: application/json
  - Schema: TrocaEstadoDto
- **Response:**
  - Status Code: 200
  - Description: Success

#### Get Student Register

- **Method:** GET
- **Endpoint:** `/api/v1/Aluno/getRegister`
- **Description:** Retrieve student registration information.
- **Response:**
  - Status Code: 200
  - Description: Success

### Professor

#### Get All Professors

- **Method:** GET
- **Endpoint:** `/api/v1/Professor`
- **Description:** Retrieve a list of all professors.
- **Response:**
  - Status Code: 200
  - Description: Success

#### Add New Professor

- **Method:** POST
- **Endpoint:** `/api/v1/Professor`
- **Description:** Add a new professor to the system.
- **Request Body:**
  - Content-Type: application/json
  - Schema: ProfessorRegistrarDto
- **Response:**
  - Status Code: 200
  - Description: Success

#### Get Professor by ID

- **Method:** GET
- **Endpoint:** `/api/v1/Professor/{id}`
- **Description:** Retrieve professor information by ID.
- **Parameters:**
  - `id` (integer, path, required) - The ID of the professor.
- **Response:**
  - Status Code: 200
  - Description: Success

#### Update Professor by ID

- **Method:** PUT
- **Endpoint:** `/api/v1/Professor/{id}`
- **Description:** Update professor information by ID.
- **Parameters:**
  - `id` (integer, path, required) - The ID of the professor.
- **Request Body:**
  - Content-Type: application/json
  - Schema: ProfessorRegistrarDto
- **Response:**
  - Status Code: 200
  - Description: Success

#### Partially Update Professor by ID

- **Method:** PATCH
- **Endpoint:** `/api/v1/Professor/{id}`
- **Description:** Partially update professor information by ID.
- **Parameters:**
  - `id` (integer, path, required) - The ID of the professor.
- **Request Body:**
  - Content-Type: application/json
  - Schema: ProfessorRegistrarDto
- **Response:**
  - Status Code: 200
  - Description: Success

#### Delete Professor by ID

- **Method:** DELETE
- **Endpoint:** `/api/v1/Professor/{id}`
- **Description:** Delete a professor by ID.
- **Parameters:**
  - `id` (integer, path, required) - The ID of the professor.
- **Response:**
  - Status Code: 200
  - Description: Success

#### Get Professor Register

- **Method:** GET
- **Endpoint:** `/api/v1/Professor/getRegister`
- **Description:** Retrieve professor registration information.
- **Response:**
  - Status Code: 200
  - Description: Success

## Data Models

### AlunoRegistrarDto

```json
{
  "id": "integer",
  "matricula": "integer",
  "nome": "string",
  "sobrenome": "string",
  "telefone": "string",
  "dataNasc": "string (date-time)",
  "dataIni": "string (date-time)",
  "dataFim": "string (date-time, nullable)",
  "ativo": "boolean"
}
```

### AlunoPatchDto

```json
{
  "id": "integer (nullable)",
  "nome": "string (nullable)",
  "sobrenome": "string (nullable)",
  "telefone": "string (nullable)",
  "ativo": "boolean"
}
```

### ProfessorRegistrarDto

```json
{
  "id": "integer",
  "registro": "integer",
  "nome": "string (nullable)",
  "sobrenome": "string (nullable)",
  "telefone": "string (nullable)",
  "dataIni": "string (date-time)",
  "dataFim": "string (date-time, nullable)",
  "ativo": "boolean"
}
```

### TrocaEstadoDto

```json
{
  "estado": "boolean"
}
```
