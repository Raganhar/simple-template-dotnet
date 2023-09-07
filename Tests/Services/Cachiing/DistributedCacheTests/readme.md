# Scope
Testing each method in caching service, mocking expected responses.
- Verifying mapping of responses to internal models

# Testing

- Unit testing of mapping logic and exception handling
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
    - 504/408 (timeout)
    
- Preferably Integration testing of happy path flow
  - Can we call the external provider ?
  - Should not be executed in the normal test running process, we dont want external dependency being down to break our entire test run
  

The less tests the better ! only write tests that bring value