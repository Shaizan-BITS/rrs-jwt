# Railway Reservation System - API Project to generate and autenticate tokens

To generate the a token for an admin:
curl --location 'https://localhost:7128/rrs/jwt/api/login' \
--header 'Content-Type: application/json' \
--data '{
    "username": "admin",
    "password": "admin"
}'

Response: JWT Token

To generate the a token for an end user:
curl --location 'https://localhost:7128/rrs/jwt/api/login' \
--header 'Content-Type: application/json' \
--data '{
    "username": "user",
    "password": "user"
}'
Response: JWT Token

To authenticate the token:

Only ADMIN can access the following endpoint, replace the header with one generated in login endpoint

curl --location 'https://localhost:7128/rrs/jwt/api/user/auth/admin' \
--header 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6InVzZXIiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJFbmRVc2VyIiwiZXhwIjoxNjk3OTc5OTA4LCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo3MTI4IiwiYXVkIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzEyOCJ9.HTxmW1B22eu2lROBjA3x96OhtNs2UnsLTvnQW7_yzUc'

Both ADMIN and EndUser can access the following endpoint:

curl --location 'https://localhost:7128/rrs/jwt/api/user/auth' \
--header 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6InVzZXIiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJFbmRVc2VyIiwiZXhwIjoxNjk3OTc5OTA4LCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo3MTI4IiwiYXVkIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzEyOCJ9.HTxmW1B22eu2lROBjA3x96OhtNs2UnsLTvnQW7_yzUc'

