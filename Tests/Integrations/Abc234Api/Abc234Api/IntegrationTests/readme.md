# Scope
Testing each method in the integration service, actually calling external endpoints.
- usual used as part of integration development

# Testing
Expected test level: <b>Unit tests</b>
    
- Preferably Integration testing of happy path flow
  - Can we call the external provider ?
  - Should not be executed in the normal test running process, we dont want external dependency being down to break our entire test run

The less tests the better ! only write tests that bring value