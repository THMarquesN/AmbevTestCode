# 🧾 Sale API

A RESTful API developed in .NET 8 for managing sales, supporting multiple items per sale, quantity-based discounts, business rule validation, and architecture based on DDD and CQRS.

---

## Project Setup

1. **Clone the repository:**

```bash
git clone https://github.com/THMarquesN/AmbevTestCode.git
cd sale-api
```

2. **Configure your database in **``**:**

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=SalesDb;Username=postgres;Password=yourpassword"
  }
}
```
---

## Running the Application

```bash
dotnet restore
dotnet build
dotnet ef database update
dotnet run
```

API available at:

```
https://localhost:5001
http://localhost:5000
```

---

## Main Endpoints

| Method   | Route                            | Description                |
| -------- | -------------------------------- | -------------------------- |
| `POST`   | `/api/sales`                     | Create a new sale          |
| `GET`    | `/api/sales`                     | List all sales             |
| `GET`    | `/api/sales/{id}`                | Get sale by ID             |
| `GET`    | `/api/sales/customer/{customer}` | Get sales by customer name |
| `DELETE` | `/api/sales/{id}`                | Delete a sale by ID        |

---

## Testing

### Run all tests:

```bash
dotnet test
```

Tests are located in:

```
/tests/Ambev.DeveloperEvaluation.Unit
```

- Validation: `CreateSaleRequestValidatorTests.cs`
- Handler: `CreateSaleHandlerTests.cs`

---

## Business Rules

- Sales with:
  - 4 to 9 units: **10% discount**
  - 10 to 20 units: **20% discount**
- Selling more than **20 units** is not allowed
- Sales with fewer than 4 units: **no discount**

---

## Payload Example

```json
{
  "saleNumber": "123",
  "saleDate": "2025-06-28T00:00:00Z",
  "customer": "customer",
  "branch": "branch",
  "items": [
    {
      "productId": "c1f8facc-ccf9-4f02-91b9-d2f23543510a",
      "productDescription": "Product",
      "quantity": 5,
      "unitPrice": 100.0
    }
  ]
}
```
---
