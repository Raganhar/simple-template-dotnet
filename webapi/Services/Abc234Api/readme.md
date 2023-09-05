# Scope
Public class that exposes an API to be used for interacting with external domain/service

# Testing

- Unit testing of validation logic
  - Focus on Control flow logic
  - Make sure to mock failure cases HTTP:
    - 200
    - 202
    - 400
    - 401
    - 403
    - 404
    - 422
    - 429
    - 500    
    
- Preferably Integration testing of happy path flow
  - Can we call the external provider ?
  - Should not be executed in the normal test running process, we dont want external dependency being down to break our entire test run
  

The less tests the better ! only write tests that bring value