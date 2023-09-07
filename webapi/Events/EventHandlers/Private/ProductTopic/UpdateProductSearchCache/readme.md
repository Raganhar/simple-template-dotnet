# Scope
Use case Handler

# Testing

- Unit testing of validation logic
  - Focus on Control flow logic
- Integration testing of happy path flow
  - Preferablly only mock external dependencies.
    - Mock: 
      - HTTP calls to other services
      - Sending events
    - Dont mock:
      - Services
      - DB
      - Redis

# What not to test
- Do not spend time on trying to test the event setup, just expect the eventhandler to be invoked with the message payload


The less tests the better ! only write tests that bring value