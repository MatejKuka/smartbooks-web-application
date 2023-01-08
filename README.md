# smartbooks-web-application

## Backend architecture: 
  - Onion architecture

## Technologies used:

### Frontend:
  Application: React.js, TypeScript
  - Component library: Material UI
    - HTTP client: Axios
    - Routing: react-router-dom
    - CSS framework: Tailwind
    
### Backend:
  API: .NET 6
    - Validation: FluentValidation
    - Mapping: AutoMapper
    - Database: Sqlite
    ...
    
---

#### Things that could be better implemented:
- api endpoints may be little bit confusing
- validation of existing courses is missing + some of the validations are insufficient
- In the frontend layer, there are a lot of errors because of bad TypeScript configuration
- Routing is poorly implemented in order to reflect the current states of the app
