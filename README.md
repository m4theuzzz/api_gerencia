# api_gerencia

## Execute

run: `docker compose up`

Your API will be available on: `0.0.0.0:8000`

Suported Routes:

- GET 0.0.0.0:8000/api/v1/pacientes [busca todos os pacientes]
- GET 0.0.0.0:8000/api/v1/pacientes/{id} [busca um paciente]
- POST 0.0.0.0:8000/api/v1/pacientes [adiciona um paciente]
- PUT 0.0.0.0:8000/api/v1/pacientes/{id} [edita um paciente]
- DELETE 0.0.0.0:8000/api/v1/pacientes/{id} [remove um paciente]
